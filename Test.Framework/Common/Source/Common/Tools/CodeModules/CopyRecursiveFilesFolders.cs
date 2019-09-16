/*
 * Created by Ranorex
 */

namespace EH.PCPS.TestAutomation.Common.Tools.CodeModules
{
    using System;
    using System.IO;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// It is often required to copy a folder or files – modified by the system under test – to initialize the test data. 
    /// This code module copies a folder, including the files and subfolders which are part of it to a given location.
    /// </summary>
    [TestModule("8A40F2F4-FBDA-45DB-B31F-EDA97A90245F", ModuleType.UserCode, 1)]
    public class CopyRecursiveFilesFolders : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CopyRecursiveFilesFolders()
        {
            // Do not delete - a parameterless constructor is required!
        }
        string _FromLocation = @"C:\FromFolder";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("F2CF227A-79D4-4962-8246-974831637966")]
        public string FromLocation
        {
            get { return this._FromLocation; }
            set { this._FromLocation = value; }
        }
        
        string _ToLocation = @"C:\ToFolder";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("812682A8-2D6F-4938-BFBA-B684DE5624E4")]
        public string ToLocation
        {
            get { return this._ToLocation; }
            set { this._ToLocation = value; }
        }
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;

            if (this.CopyAll(new DirectoryInfo(this.FromLocation), new DirectoryInfo(this.ToLocation)))
            {
                Report.Success("File Copy", "Completed successfully from " + this.FromLocation + " to " + this.ToLocation);
            }
            else
            {
                Report.Failure("File Copy", "Failed to copy folder from " + this.FromLocation + " to " + this.ToLocation);
            }
        }

        private bool CopyAll(DirectoryInfo sourceDir, DirectoryInfo targetDir)
        {
            bool enableTracingScreenshots = Ranorex.Core.Reporting.TestReport.EnableTracingScreenshots;
            try
            {
                // Disable screenshots due performance.
                Ranorex.Core.Reporting.TestReport.EnableTracingScreenshots = false;

                if (Directory.Exists(targetDir.FullName) == false)
                {
                    Directory.CreateDirectory(targetDir.FullName);
                }
                
                foreach (FileInfo file in sourceDir.GetFiles())
                {
                    Report.Info("Copying " + targetDir.FullName + "\\" + file.Name);
                    file.CopyTo(Path.Combine(targetDir.ToString(), file.Name), true);
                }

                foreach (DirectoryInfo sourceSubDir in sourceDir.GetDirectories())
                {
                    DirectoryInfo targetSubDir = targetDir.CreateSubdirectory(sourceSubDir.Name);
                    this.CopyAll(sourceSubDir, targetSubDir);
                }
                return true;
            }
            catch (Exception ex)
            {
                Report.Failure("Failure", ex.ToString());
                return false;
            }       
            finally
            {
                // Enable screenshots after the action is finished.
                Ranorex.Core.Reporting.TestReport.EnableTracingScreenshots = enableTracingScreenshots;
            }
        }
    }
}

