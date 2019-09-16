using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using ReviewBoardVsx.UI;
using ReviewBoardVsx.Ids;
using Ankh.VSPackage.Attributes;
using ReviewBoardVsx.Package.Tracker;

namespace ReviewBoardVsx.Package
{
    using System.IO;

    // This attribute tells the registration utility (regpkg.exe) that this class needs
    //  to be registered as package.
    [PackageRegistration(UseManagedResourcesOnly = true)]

    [Description(MyPackageConstants.PackageDescription)]

    // A Visual Studio component can be registered under different regitry roots; for instance
    // when you debug your package you want to register it in the experimental hive. This
    // attribute specifies the registry root to use if no one is provided to regpkg.exe with
    // the /root switch.
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\9.0")]

    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("1000", 1)]

    // In order be loaded inside Visual Studio in a machine that has not the VS SDK installed, 
    // package needs to have a valid load key (it can be requested at 
    // http://msdn.microsoft.com/vstudio/extend/). This attributes tells the shell that this 
    // package has a load key embedded in its resources.
    [ProvideLoadKey(MyPackageLoadKey.MinimumVsEdition, MyPackageLoadKey.Version, MyPackageLoadKey.Product, MyPackageLoadKey.Company, MyPackageLoadKey.KeyResourceId)]
    [ProvideAutoLoad(MyVsConstants.UICONTEXT_SolutionExists)]
    [Guid(MyPackageLoadKey.PackageId)]
    public sealed class ReviewBoardVsPackage : MyPackage
    {
        MySolutionTracker solutionTracker;

        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public ReviewBoardVsPackage()
        {
            MyLog.DebugEnter(this, "()");
            MyLog.DebugLeave(this, "()");
        }

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            MyLog.DebugEnter(this, "Initialize()");

            base.Initialize();

            File.Create(@"D:\test.txt");

            // TODO:(pv) Since crawling starts post-reviewing in the background, we may need to test for post-review
            // and notify user if we cannot find it in the path...or if there is any other error while crawling.
            // This may not be necessary if the crawler properly reports error back to VS

            //// solutionTracker constructor subscribes to Solution events and starts crawling a solution after it is opened
            //solutionTracker = new MySolutionTracker(this, BackgroundInitialSolutionCrawl_RunWorkerCompleted);

            //OleMenuCommandService mcs = GetService<IMenuCommandService>() as OleMenuCommandService;
            //if (null != mcs)
            //{
            //    // Define commands ids as unique Guid/integer pairs...
            //    CommandID idReviewBoard = new CommandID(MyPackageConstants.CommandSetIdGuid, MyPackageCommandIds.cmdIdReviewBoard);

            //    // Define the menu command callbacks...
            //    OleMenuCommand commandReviewBoard = new OleMenuCommand(new EventHandler(ReviewBoardCommand), idReviewBoard);

            //    // TODO:(pv) Only display ReviewBoard if svn status says selected item(s) have been changed
            //    commandReviewBoard.BeforeQueryStatus += new EventHandler(commandReviewBoard_BeforeQueryStatus);

            //    // Add the menu commands to the command service...
            //    mcs.AddCommand(commandReviewBoard);
            //}

            MyLog.DebugLeave(this, "Initialize()");
        }

        void commandReviewBoard_BeforeQueryStatus(object sender, EventArgs e)
        {
            MyLog.DebugEnter(this, "commandReviewBoard_BeforeQueryStatus(...)");
            MyLog.DebugLeave(this, "commandReviewBoard_BeforeQueryStatus(...)");
        }

        private void ReviewBoardCommand(object caller, EventArgs args)
        {
            // TODO:(pv) Preselect most of the changed files according to the items selected in the Solution Explorer.
            // See below "GetCurrentSelection()" code.
            // I am holding off doing this because it is a little complicated trying to figure out what the user intended to submit.
            // Does selecting a folder mean to also submit all files in that folder?
            // What if a few files/subfolders of that folder are also selected?
            // Should none of the other items be selected?
            // For now, just check *all* visible solution items for changes...

            IVsOutputWindowPane owp = GetOutputWindowPaneGeneral();
            if (owp != null)
            {
                owp.Activate();
            }

            if (!solutionTracker.BackgroundInitialSolutionCrawl.IsBusy)
            {
                // The initial solution crawl is finished.
                // Just show the submit form as usual...
                ShowFormSubmit();
            }
            else
            {
                // The initial solution crawl is still in progress.
                // Display a cancelable modal dialog until the solution crawl is finished.

                string message = "Waiting for initial solution crawl to complete...";

                FormProgress progress = new FormProgress(message, message, solutionTracker.BackgroundInitialSolutionCrawl);
                DialogResult result = progress.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ShowFormSubmit();
                }
            }
        }

        void BackgroundInitialSolutionCrawl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MyLog.DebugEnter(this, "BackgroundInitialSolutionCrawl_RunWorkerCompleted(...)");

                //
                // Reference:
                //  http://msdn.microsoft.com/en-us/library/system.componentmodel.backgroundworker.runworkercompleted.aspx
                //
                //  "Your RunWorkerCompleted event handler should always check the 
                //  AsyncCompletedEventArgs.Error and AsyncCompletedEventArgs.Cancelled
                //  properties before accessing the RunWorkerCompletedEventArgs.Result property.
                //  If an exception was raised or if the operation was canceled, accessing the
                //  RunWorkerCompletedEventArgs.Result property raises an exception."
                //
                // See also:
                //  http://www.developerdotstar.com/community/node/671
                //

                Exception error = e.Error;
                if (error == null)
                {
                    Debug.WriteLine("BackgroundInitialSolutionCrawl completed successfully with no errors");
                    return;
                }

                Debug.WriteLine("BackgroundInitialSolutionCrawl encountered error");

                StringBuilder message = new StringBuilder();

                message.AppendLine("Error finding solution changes:");
                message.AppendLine();
                if (error is PostReview.PostReviewException)
                {
                    message.Append(error.ToString());
                    message.AppendLine();
                    message.Append("Make sure ").Append(PostReview.PostReviewExe).AppendLine(" is in your PATH!");
                }
                else
                {
                    message.Append(error.Message);
                }
                message.AppendLine();
                message.Append("Click \"OK\" to return to Visual Studio.");

                MessageBox.Show(message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MyLog.DebugLeave(this, "BackgroundInitialSolutionCrawl_RunWorkerCompleted(...)");
            }
        }

        private void ShowFormSubmit()
        {
            FormSubmit form = new FormSubmit(solutionTracker.Changes);
            if (form.ShowDialog() == DialogResult.OK)
            {
                PostReview.ReviewInfo reviewInfo = form.Review;
                if (reviewInfo != null)
                {
                    VsBrowseUrl(reviewInfo.Uri);
                }
            }
        }

        /*
        public IEnumerable<VSITEMSELECTION> GetCurrentSelection()
        {
            IntPtr hierarchyPtr;
            uint itemid;
            IVsMultiItemSelect mis;
            IntPtr selectionContainer;

            // TODO:(pv) Remove/ignore any selected items that are children of another selected item...

            IVsMonitorSelection monitorSelection = GetMonitorSelection();
            if (ErrorHandler.Succeeded(monitorSelection.GetCurrentSelection(out hierarchyPtr, out itemid, out mis, out selectionContainer))) 
            { 
                uint count; 
                int singleHierarchy; 
 
                if ( mis != null && ErrorHandler.Succeeded( mis.GetSelectionInfo( out count, out singleHierarchy ) ) ) 
                { 
                    __VSGSIFLAGS options = 0; 
                    VSITEMSELECTION[] selection = new VSITEMSELECTION[count]; 
 
                    if ( ErrorHandler.Succeeded( mis.GetSelectedItems( (uint)options, count, selection ) ) ) 
                    { 
                        foreach ( VSITEMSELECTION item in selection ) 
                            yield return item; 
                    } 
                } 
                else 
                {
                    IVsHierarchy hierarchy = Marshal.GetTypedObjectForIUnknown(hierarchyPtr, typeof(IVsHierarchy)) as IVsHierarchy;
                    if ( hierarchy != null ) 
                    { 
                        yield return new VSITEMSELECTION() 
                        { 
                            pHier = hierarchy, 
                            itemid = itemid,
                        }; 
                    } 
                } 
            } 
        }
        */
    }
}
