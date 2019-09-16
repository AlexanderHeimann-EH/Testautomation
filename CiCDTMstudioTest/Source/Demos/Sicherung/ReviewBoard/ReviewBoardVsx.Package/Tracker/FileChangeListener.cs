using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using ShellConstants = Microsoft.VisualStudio.Shell.Interop.Constants;

namespace ReviewBoardVsx.Package.Tracker
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/microsoft.visualstudio.shell.interop.ivsfilechangeevents(v=VS.90).aspx
    /// http://nativeclient-sdk.googlecode.com/svn-history/r502/trunk/src/third_party/Microsoft.VisualStudio.Project/FileChangeManager.cs
    /// http://www.koders.com/csharp/fid127BC2AFCC2D56826135983EBCA899BD8E2601AA.aspx
    /// </summary>
    public class FileChangeListener : IVsFileChangeEvents, IDisposable
    {
        public delegate void FilesChangedHandler(uint cChanges, string[] rgpszFile, uint[] rggrfChange);
        public event FilesChangedHandler OnFilesChanged;

        private IVsFileChangeEx fileChangeEx;
        private Dictionary<string, uint> eventCookies = new Dictionary<string, uint>();

        private bool isDisposed;
        private static volatile object Mutex = new object();

        public FileChangeListener(IServiceProvider serviceProvider)
        {
            fileChangeEx = serviceProvider.GetService(typeof(SVsFileChangeEx)) as IVsFileChangeEx;
            Debug.Assert(fileChangeEx != null, "Could not get the IVsFileChangeEx object from the services exposed by this project");
            if (fileChangeEx == null)
            {
                throw new InvalidOperationException();
            }
        }

        #region IVsFileChangeEvents Members

        public int FilesChanged(uint cChanges, string[] rgpszFile, uint[] rggrfChange)
        {
            if (OnFilesChanged != null)
            {
                OnFilesChanged(cChanges, rgpszFile, rggrfChange);
            }
            return VSConstants.S_OK;
        }

        /// <summary>
        /// Does nothing; This *File*ChangeListener class is not interested in *Directory* changes.
        /// </summary>
        /// <param name="pszDirectory"></param>
        /// <returns></returns>
        public int DirectoryChanged(string pszDirectory)
        {
            return VSConstants.S_OK;
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                lock (Mutex)
                {
                    if (disposing)
                    {
                        Clear();
                    }
                    isDisposed = true;
                }
            }
        }

        public void Subscribe(string filepath, bool prelowered)
        {
            if (fileChangeEx != null && !String.IsNullOrEmpty(filepath))
            {
                if (!prelowered)
                {
                    filepath = filepath.ToLower();
                }

                lock (eventCookies)
                {
                    if (!eventCookies.ContainsKey(filepath))
                    {
                        uint cookie;
                        ErrorHandler.ThrowOnFailure(fileChangeEx.AdviseFileChange(filepath, (uint)(_VSFILECHANGEFLAGS.VSFILECHG_Size | _VSFILECHANGEFLAGS.VSFILECHG_Time), this, out cookie));
                        MyPackage.OutputGeneral("Tracking \"" + filepath + "\"");
                        eventCookies.Add(filepath, cookie);
                    }
                }
            }
        }

        public void Ignore(string filepath, bool ignore, bool prelowered)
        {
            if (fileChangeEx != null && !String.IsNullOrEmpty(filepath))
            {
                if (!prelowered)
                {
                    filepath = filepath.ToLower();
                }

                uint cookie;
                lock (eventCookies)
                {
                    if (eventCookies.TryGetValue(filepath, out cookie))
                    {
                        ErrorHandler.ThrowOnFailure(fileChangeEx.IgnoreFile(cookie, filepath, (ignore) ? 0 : 1));
                        MyPackage.OutputGeneral("Ignoring \"" + filepath + "\"");
                    }
                }
            }
        }

        public void Unsubscribe(string filepath, bool prelowered)
        {
            if (fileChangeEx != null && !String.IsNullOrEmpty(filepath))
            {
                if (!prelowered)
                {
                    filepath = filepath.ToLower();
                }

                uint cookie;
                lock (eventCookies)
                {
                    if (eventCookies.TryGetValue(filepath, out cookie))
                    {
                        ErrorHandler.ThrowOnFailure(fileChangeEx.UnadviseFileChange(cookie));
                        MyPackage.OutputGeneral("Not Tracking \"" + filepath + "\"");
                    }
                }
            }
        }

        public void Clear()
        {
            lock (eventCookies)
            {
                foreach (string filepath in eventCookies.Keys)
                {
                    Unsubscribe(filepath, true);
                }
                eventCookies.Clear();
            }
        }
    }
}
