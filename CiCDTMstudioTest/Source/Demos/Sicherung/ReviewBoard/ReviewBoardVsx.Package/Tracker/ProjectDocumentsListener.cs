using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using ShellConstants = Microsoft.VisualStudio.Shell.Interop.Constants;

namespace ReviewBoardVsx.Package.Tracker
{
    /// <summary>
    /// This class keeps track of files and directories being added, renamed [moved?], or removed from a Project.
    /// 
    /// Ideas came from Ankh ProjectTracker and:
    /// http://www.java2s.com/Open-Source/CSharp/Development/StyleCop/Microsoft/VisualStudio/Package/ProjectDocumentsListener.cs.htm
    /// http://www.java2s.com/Open-Source/CSharp/Development/StyleCop/Microsoft/VisualStudio/Shell/Flavor/Project.cs.htm
    /// http://www.java2s.com/Open-Source/CSharp/Development/StyleCop/Microsoft/VisualStudio/Shell/Flavor/ProjectDocumentsChangeEventsArgs.cs.htm
    /// </summary>
    [CLSCompliant(false)]
    public class ProjectDocumentsListener : IVsTrackProjectDocumentsEvents2, IDisposable
    {
        public class ProjectItemsAddRemoveEventArgs : EventArgs
        {
            public IVsProject Project { get; private set; }
            public ReadOnlyCollection<string> Items { get; private set; }

            public ProjectItemsAddRemoveEventArgs(IVsProject project, IList<string> items)
            {
                Project = project;
                Items = new ReadOnlyCollection<string>(items);
            }
        }

        public class ProjectItemsRenameEventArgs : EventArgs
        {
            public class RenamedItem
            {
                public string PathOld { get; private set; }
                public string PathNew { get; private set; }

                public RenamedItem(string pathOld, string pathNew)
                {
                    PathOld = pathOld;
                    PathNew = pathNew;
                }
            }

            public IVsProject Project { get; private set; }
            public ReadOnlyCollection<RenamedItem> Items { get; private set; }

            public ProjectItemsRenameEventArgs(IVsProject project, IList<RenamedItem> items)
            {
                Project = project;
                Items = new ReadOnlyCollection<RenamedItem>(items);
            }
        }

        public event EventHandler<ProjectItemsAddRemoveEventArgs> FileAdded;
        public event EventHandler<ProjectItemsRenameEventArgs> FileRenamed;
        public event EventHandler<ProjectItemsAddRemoveEventArgs> FileRemoved;
        public event EventHandler<ProjectItemsAddRemoveEventArgs> DirectoryAdded;
        public event EventHandler<ProjectItemsRenameEventArgs> DirectoryRenamed;
        public event EventHandler<ProjectItemsAddRemoveEventArgs> DirectoryRemoved;

        public IServiceProvider ServiceProvider { get; private set; }

        private IVsTrackProjectDocuments2 projectDocumentTracker2;

        private uint eventsCookie = (uint)ShellConstants.VSCOOKIE_NIL;
        private bool isDisposed;
        private static volatile object Mutex = new object();

        public ProjectDocumentsListener(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            projectDocumentTracker2 = serviceProvider.GetService(typeof(SVsTrackProjectDocuments)) as IVsTrackProjectDocuments2;
            Debug.Assert(projectDocumentTracker2 != null, "Could not get the IVsTrackProjectDocuments2 object from the services exposed by this project");
            if (projectDocumentTracker2 == null)
            {
                throw new InvalidOperationException();
            }
        }

        public void Initialize()
        {
            if (projectDocumentTracker2 != null && eventsCookie == (uint)ShellConstants.VSCOOKIE_NIL)
            {
                ErrorHandler.ThrowOnFailure(projectDocumentTracker2.AdviseTrackProjectDocumentsEvents(this, out eventsCookie));
            }
        }

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
                    if (disposing && projectDocumentTracker2 != null && eventsCookie != (uint)ShellConstants.VSCOOKIE_NIL)
                    {
                        ErrorHandler.ThrowOnFailure(projectDocumentTracker2.UnadviseTrackProjectDocumentsEvents((uint)eventsCookie));
                        eventsCookie = (uint)ShellConstants.VSCOOKIE_NIL;
                    }
                    isDisposed = true;
                }
            }
        }

        #region IVsTrackProjectDocumentsEvents2 methods

        public int OnQueryAddFiles(IVsProject pProject, int cFiles, string[] rgpszMkDocuments, VSQUERYADDFILEFLAGS[] rgFlags, VSQUERYADDFILERESULTS[] pSummaryResult, VSQUERYADDFILERESULTS[] rgResults)
        {
            try
            {
                MyLog.DebugEnter(this, "OnQueryAddFiles");
                return VSConstants.S_OK; // ignore
            }
            finally
            {
                MyLog.DebugLeave(this, "OnQueryAddFiles");
            }
        }

        public int OnAfterAddFilesEx(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSADDFILEFLAGS[] rgFlags)
        {
            try
            {
                MyLog.DebugEnter(this, "OnAfterAddFilesEx");
                GenerateAddRemoveEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, FileAdded);
                return VSConstants.S_OK;
            }
            finally
            {
                MyLog.DebugLeave(this, "OnAfterAddFilesEx");
            }
        }

        public int OnQueryRenameFiles(IVsProject pProject, int cFiles, string[] rgszMkOldNames, string[] rgszMkNewNames, VSQUERYRENAMEFILEFLAGS[] rgFlags, VSQUERYRENAMEFILERESULTS[] pSummaryResult, VSQUERYRENAMEFILERESULTS[] rgResults)
        {
            try
            {
                MyLog.DebugEnter(this, "OnQueryRenameFiles");
                return VSConstants.S_OK; // ignore
            }
            finally
            {
                MyLog.DebugLeave(this, "OnQueryRenameFiles");
            }
        }

        public int OnAfterRenameFiles(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgszMkOldNames, string[] rgszMkNewNames, VSRENAMEFILEFLAGS[] rgFlags)
        {
            try
            {
                MyLog.DebugEnter(this, "OnAfterRenameFiles");
                // TODO:(pv) This may not handle solution/project file renames very well...
                GenerateRenameEvents(rgpProjects, rgFirstIndices, rgszMkOldNames, rgszMkNewNames, FileRenamed);
                return VSConstants.S_OK;
            }
            finally
            {
                MyLog.DebugLeave(this, "OnAfterRenameFiles");
            }
        }

        public int OnQueryRemoveFiles(IVsProject pProject, int cFiles, string[] rgpszMkDocuments, VSQUERYREMOVEFILEFLAGS[] rgFlags, VSQUERYREMOVEFILERESULTS[] pSummaryResult, VSQUERYREMOVEFILERESULTS[] rgResults)
        {
            try
            {
                MyLog.DebugEnter(this, "OnQueryRemoveFiles");
                return VSConstants.S_OK; // ignore
            }
            finally
            {
                MyLog.DebugLeave(this, "OnQueryRemoveFiles");
            }
        }

        public int OnAfterRemoveFiles(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSREMOVEFILEFLAGS[] rgFlags)
        {
            try
            {
                MyLog.DebugEnter(this, "OnAfterRemoveFiles");
                GenerateAddRemoveEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, FileRemoved);
                return VSConstants.S_OK;
            }
            finally
            {
                MyLog.DebugLeave(this, "OnAfterRemoveFiles");
            }
        }

        public int OnQueryAddDirectories(IVsProject pProject, int cDirectories, string[] rgpszMkDocuments, VSQUERYADDDIRECTORYFLAGS[] rgFlags, VSQUERYADDDIRECTORYRESULTS[] pSummaryResult, VSQUERYADDDIRECTORYRESULTS[] rgResults)
        {
            try
            {
                MyLog.DebugEnter(this, "OnQueryAddDirectories");
                return VSConstants.S_OK; // ignore
            }
            finally
            {
                MyLog.DebugLeave(this, "OnQueryAddDirectories");
            }
        }

        public int OnAfterAddDirectoriesEx(int cProjects, int cDirectories, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSADDDIRECTORYFLAGS[] rgFlags)
        {
            try
            {
                MyLog.DebugEnter(this, "OnAfterAddDirectoriesEx");
                GenerateAddRemoveEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, DirectoryAdded);
                return VSConstants.S_OK;
            }
            finally
            {
                MyLog.DebugLeave(this, "OnAfterAddDirectoriesEx");
            }
        }

        public int OnQueryRenameDirectories(IVsProject pProject, int cDirs, string[] rgszMkOldNames, string[] rgszMkNewNames, VSQUERYRENAMEDIRECTORYFLAGS[] rgFlags, VSQUERYRENAMEDIRECTORYRESULTS[] pSummaryResult, VSQUERYRENAMEDIRECTORYRESULTS[] rgResults)
        {
            try
            {
                MyLog.DebugEnter(this, "OnQueryRenameDirectories");
                return VSConstants.S_OK; // ignore
            }
            finally
            {
                MyLog.DebugLeave(this, "OnQueryRenameDirectories");
            }
        }

        public int OnAfterRenameDirectories(int cProjects, int cDirs, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgszMkOldNames, string[] rgszMkNewNames, VSRENAMEDIRECTORYFLAGS[] rgFlags)
        {
            try
            {
                MyLog.DebugEnter(this, "OnAfterRenameDirectories");
                GenerateRenameEvents(rgpProjects, rgFirstIndices, rgszMkOldNames, rgszMkNewNames, DirectoryRenamed);
                return VSConstants.S_OK;
            }
            finally
            {
                MyLog.DebugLeave(this, "OnAfterRenameDirectories");
            }
        }

        public int OnQueryRemoveDirectories(IVsProject pProject, int cDirectories, string[] rgpszMkDocuments, VSQUERYREMOVEDIRECTORYFLAGS[] rgFlags, VSQUERYREMOVEDIRECTORYRESULTS[] pSummaryResult, VSQUERYREMOVEDIRECTORYRESULTS[] rgResults)
        {
            try
            {
                MyLog.DebugEnter(this, "OnQueryRemoveDirectories");
                return VSConstants.S_OK; // ignore
            }
            finally
            {
                MyLog.DebugLeave(this, "OnQueryRemoveDirectories");
            }
        }

        public int OnAfterRemoveDirectories(int cProjects, int cDirectories, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, VSREMOVEDIRECTORYFLAGS[] rgFlags)
        {
            try
            {
                MyLog.DebugEnter(this, "OnAfterRemoveDirectories");
                GenerateAddRemoveEvents(rgpProjects, rgFirstIndices, rgpszMkDocuments, DirectoryRemoved);
                return VSConstants.S_OK;
            }
            finally
            {
                MyLog.DebugLeave(this, "OnAfterRemoveDirectories");
            }
        }

        public int OnAfterSccStatusChanged(int cProjects, int cFiles, IVsProject[] rgpProjects, int[] rgFirstIndices, string[] rgpszMkDocuments, uint[] rgdwSccStatus)
        {
            try
            {
                MyLog.DebugEnter(this, "OnAfterSccStatusChanged");
                return VSConstants.S_OK; // ignore
            }
            finally
            {
                MyLog.DebugLeave(this, "OnAfterSccStatusChanged");
            }
        }

        #endregion IVsTrackProjectDocumentsEvents2 methods

        private void GenerateAddRemoveEvents(
            IVsProject[] projects,
            int[] firstPaths,
            string[] itemPaths,
            EventHandler<ProjectItemsAddRemoveEventArgs> eventToGenerate)
        {
            if (eventToGenerate == null)
                return; // no event = nothing to do

            if (projects == null || firstPaths == null || itemPaths == null)
            {
                throw new ArgumentNullException();
            }

            if (projects.Length != firstPaths.Length)
            {
                throw new ArgumentException();
            }

            int cProjects = projects.Length;
            int cPaths = itemPaths.Length;

            IVsProject project;
            List<string> items = new List<string>();
            string itemPath;

            int iPath = 0;
            for (int iProject = 0; (iProject < cProjects) && (iPath < cPaths); iProject++)
            {
                int iLastPathThisProject = (iProject < cProjects - 1) ? firstPaths[iProject + 1] : cPaths;

                items.Clear();

                for (; iPath < iLastPathThisProject; iPath++)
                {
                    itemPath = itemPaths[iPath];
                    items.Add(itemPath);
                }

                if (items.Count > 0)
                {
                    // if project == null then Solution, else Project
                    project = projects[iProject];

                    try
                    {
                        eventToGenerate(this, new ProjectItemsAddRemoveEventArgs(project, items));
                    }
                    catch (Exception error)
                    {
                        Debug.Fail(error.Message);
                    }
                }
            }
        }

        private void GenerateRenameEvents(
            IVsProject[] projects,
            int[] firstPaths,
            string[] itemPathsOld,
            string[] itemPathsNew,
            EventHandler<ProjectItemsRenameEventArgs> eventToGenerate)
        {
            if (eventToGenerate == null)
                return; // no event = nothing to do

            if (projects == null || firstPaths == null || itemPathsOld == null || itemPathsNew == null)
            {
                throw new ArgumentNullException();
            }

            if (projects.Length != firstPaths.Length)
            {
                throw new ArgumentException();
            }

            if (itemPathsOld.Length != itemPathsNew.Length)
            {
                throw new ArgumentException();
            }

            int cProjects = projects.Length;
            int cPaths = itemPathsOld.Length;

            // TODO: C++ projects do not send directory renames; but do send OnAfterRenameFile() events
            //       for all files (one at a time). We should detect that case here and fix up this dirt!

            IVsProject project;
            List<ProjectItemsRenameEventArgs.RenamedItem> items = new List<ProjectItemsRenameEventArgs.RenamedItem>();
            string itemPathOld;
            string itemPathNew;
            ProjectItemsRenameEventArgs.RenamedItem item;

            int iPath = 0;
            for (int iProject = 0; (iProject < cProjects) && (iPath < cPaths); iProject++)
            {
                int iLastPathThisProject = (iProject < cProjects - 1) ? firstPaths[iProject + 1] : cPaths;

                items.Clear();

                for (; iPath < iLastPathThisProject; iPath++)
                {
                    itemPathOld = itemPathsOld[iPath];
                    itemPathNew = itemPathsNew[iPath];

                    // TODO:(pv) Can we ignore if the path was renamed to just a different case?
                    if (itemPathOld == itemPathNew)
                        continue;

                    item = new ProjectItemsRenameEventArgs.RenamedItem(itemPathOld, itemPathNew);
                    items.Add(item);
                }

                if (items.Count > 0)
                {
                    // if project == null then Solution, else Project
                    project = projects[iProject];

                    try
                    {
                        eventToGenerate(this, new ProjectItemsRenameEventArgs(project, items));
                    }
                    catch (Exception error)
                    {
                        Debug.Fail(error.Message);
                    }
                }
            }
        }
    }
}