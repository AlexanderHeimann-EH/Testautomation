//------------------------------------------------------------------------------
// <copyright file="FileWatcher.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Security.Permissions;

    /// <summary>
    /// The file watcher allows the user to monitor file operations for files with a specified file extension in a specified folder
    /// </summary>
    public class FileWatcher
    {
        /// <summary>
        /// The watcher.
        /// </summary>
        private readonly FileSystemWatcher watcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWatcher"/> class. 
        /// Generates a File System Watcher, sets path, event handler and filter
        /// </summary>
        /// <param name="path">
        /// Path of the directory to watch, most likely @"C:\"
        /// </param>
        /// <param name="filter">
        /// file extension to watch
        /// </param>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public FileWatcher(string path, string filter)
        {
            this.watcher = new FileSystemWatcher();
            this.watcher.Path = path;
            this.watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName |
                                   NotifyFilters.DirectoryName;
            this.watcher.Filter = filter;
            this.watcher.IncludeSubdirectories = true;
            this.watcher.Changed += this.OnChanged;
            this.watcher.Created += this.OnCreated;
        }

        /// <summary>
        /// Gets or sets a value indicating whether event fired.
        /// </summary>
        public bool EventFired { get; set; }

        /// <summary>
        /// Enables Event raising
        /// </summary>
        public void StartFileWatcher()
        {
            this.watcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Disables Event raising
        /// </summary>
        public void StopFileWatcher()
        {
            this.watcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// Wait until file is modified
        /// </summary>
        /// <param name="timeOutInMilliseconds">time until action must be done</param>
        /// <returns>
        ///     <br>True: if file is modified or created</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool WaitUntilEventFired(int timeOutInMilliseconds)
        {
            bool result = true;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (this.EventFired == false)
            {
                if (stopwatch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No file has been modified after >" + timeOutInMilliseconds + "Milliseconds @ " + this.watcher.Path + ".");
                result = false;
                break;
            }

            stopwatch.Stop();

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File was modified");
            }

            return result;
        }

        /// <summary>
        /// Event handler for "changed" events
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File: " + e.FullPath + " " + e.ChangeType);
            this.EventFired = true;
        }

        /// <summary>
        /// Event handler for "created" events
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnCreated(object source, FileSystemEventArgs e)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File: " + e.FullPath + " " + e.ChangeType);
            this.EventFired = true;
        }
    }
}