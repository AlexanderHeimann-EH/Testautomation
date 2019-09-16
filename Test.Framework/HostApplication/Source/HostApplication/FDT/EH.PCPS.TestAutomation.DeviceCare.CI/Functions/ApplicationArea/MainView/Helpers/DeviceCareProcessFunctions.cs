// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceCareProcessFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of DeviceCareProcessFunctions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 17.08.2015
 * Time: 14:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Helpers
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools.Logging;

    using Ranorex;

    /// <summary>
    /// Description of DeviceCareProcessFunctions.
    /// </summary>
    public class DeviceCareProcessFunctions
    {
        #region fields

        /// <summary>
        /// The drives.
        /// </summary>
        private DriveInfo[] drives;

        /// <summary>
        /// The drive list.
        /// </summary>
        private List<string> driveList;

        /// <summary>
        /// The path fragments.
        /// </summary>
        private List<string> pathFragments;

        /// <summary>
        /// The installation path.
        /// </summary>
        private string installationPath;
        
        #endregion

        #region Konstruktor

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCareProcessFunctions"/> class.
        /// </summary>
        public DeviceCareProcessFunctions()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            this.drives = null;
            this.driveList = new List<string>();
            this.pathFragments = new List<string>();
        }

        #endregion

        #region Fields and Properties

        /// <summary>
        /// Gets or sets the installation path.
        /// </summary>
        public string InstallationPath
        {
            get { return this.installationPath; }
            set { this.installationPath = value; }
        }
        #endregion
        
        #region Methods

        #region Public

        /// <summary>
        /// Tries to find the DeviceCare directory on the local host
        /// and starts the application if a directory was found
        /// </summary>
        /// <returns>True if the process was found and could be started</returns>
        public bool Run()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            this.InstallationPath = null;

            if (Validation.HostApplication.IsHostApplicationOpen() == false)
            {
                this.PopulatePathFragments();
                this.GetDriveVolumeLabel();

                Report.Debug("Looking for the installation directory.");
                Report.Debug("Hard drives found: " + this.driveList.Count.ToString(CultureInfo.InvariantCulture));

                foreach (string t in this.driveList)
                {
                    if (this.InstallationPath == null)
                    {
                        for (int j = 0; j <= 2; j++)
                        {
                            try
                            {
                                string root = t + this.pathFragments[j];
                                this.GetSubDirectories(root);
                            }
                            catch (IOException)
                            {
                                Report.Debug("HostApplication directory: " + this.InstallationPath);
                            }
                        }
                    }
                }

                this.InstallationPath = this.InstallationPath + @"\DeviceCare\DeviceCare.exe";
                Report.Debug("HostApplication directory: " + this.InstallationPath);
                int processId = Execution.HostApplication.StartHostApplication(this.InstallationPath);

                Report.Info("Waiting for DeviceCare to load.");
                
                if (!Validation.HostApplication.WaitUntilHostApplicationOpened())
                {
                    Report.Error("DeviceCare is not started in time: " + Common.DefaultValues.GeneralTimeout.ToString(CultureInfo.InvariantCulture));
                    return false;
                }

                return Validation.HostApplication.IsHostApplicationOpen(processId);
            }
            
            Report.Debug("DeviceCare was already running.");
            return false;
        }

        /// <summary>
        /// Tries to start DeviceCare under a provided path
        /// </summary>
        /// <param name="path">The complete path to the application including the application name</param>
        /// <returns>Returns the process ID of the running process</returns>
        public int Run(string path)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            int processId = 0;
            if (Validation.HostApplication.IsHostApplicationOpen() == false)
            {
                Report.Debug("Running DeviceCare under: " + path);
                processId = Execution.HostApplication.StartHostApplication(path);
                Report.Debug("Waiting for the application to load.");
                if (!Validation.HostApplication.WaitUntilHostApplicationOpened())
                {
                    Report.Error("DeviceCare is not started in time: " + Common.DefaultValues.GeneralTimeout.ToString(CultureInfo.InvariantCulture));
                    return -1;
                }
            }
            else
            {
                Report.Debug("DeviceCare was already running.");
            }

            return processId;
        }

        /// <summary>
        /// Tries to start DeviceCare under a provided path
        /// Waits for the frame for a specific amount of time provided in
        /// 'timeOutInMilliseconds'
        /// </summary>
        /// <param name="path">The complete path to the application including the application name</param>
        /// <param name="timeOutInMilliseconds">The time in milliseconds to wait for the frame to exist</param>
        /// <returns>The process ID of the running process</returns>
        public int Run(string path, int timeOutInMilliseconds)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            int processId = 0;

            if (Validation.HostApplication.IsHostApplicationOpen() == false)
            {
                Report.Debug("Running DeviceCare under: " + path);
                processId = Execution.HostApplication.StartHostApplication(path);
                Report.Debug("Waiting for DeviceCare to load (timing out after " + timeOutInMilliseconds.ToString(CultureInfo.InvariantCulture) + "ms).");
                if (!Validation.HostApplication.WaitUntilHostApplicationOpened())
                {
                    Report.Error("DeviceCare is not started in time: " + Common.DefaultValues.GeneralTimeout.ToString(CultureInfo.InvariantCulture));
                    return -1;
                }
            }
            else
            {
                Report.Debug("DeviceCare was already running.");
            }

            return processId;
        }

        #endregion

        #region Private

        /// <summary>
        /// Searches all subdirectories in a directory which matches the search pattern "En*"
        /// This is used for top hierarchy search (searching for "Endress+Hauser" folders)
        /// </summary>
        /// <param name="root">The directory to get subdirectories from</param>
        private void GetSubDirectories(string root)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            string[] subdirectoryEntries = Directory.GetDirectories(root, "En*");

            foreach (string subdirectory in subdirectoryEntries)
            {
                this.LoadSubDirs(subdirectory);
            }
        }

        /// <summary>
        /// Gets all subdirectories of a directory which match the search pattern "DeviceCare"
        /// If directory is found, the installation path is set
        /// </summary>
        /// <param name="dir">The directory to search in</param>
        private void LoadSubDirs(string dir)
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            Report.Debug("Subdir: " + dir);
            string[] subdirectoryEntries = Directory.GetDirectories(dir, "DeviceCare");
            foreach (string subdirectory in subdirectoryEntries)
            {
                Report.Debug("Directory found in: " + subdirectory);
                this.InstallationPath = subdirectory;
            }
        }

        /// <summary>
        /// Adds all volume labels of all hard drives of the host to a list
        /// </summary>
        private void GetDriveVolumeLabel()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            this.drives = DriveInfo.GetDrives();
            Report.Debug("Detected Drives: ");
            foreach (var drive in this.drives)
            {
                Report.Debug("Drive:" + drive.Name);
                Report.Debug("Drive type:" + drive.DriveType);
                if (drive.IsReady)
                {
                    Report.Debug("Drive: " + drive.VolumeLabel);

                    if (drive.DriveType.ToString() == "Fixed")
                    {
                        this.driveList.Add(drive.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Here you can specify all the directories where the application should be searched subsequently
        /// </summary>
        private void PopulatePathFragments()
        {
            Log.Enter(this, MethodBase.GetCurrentMethod().Name);
            this.pathFragments.Add(@"\Program Files");
            this.pathFragments.Add(@"\Program Files (x86)");
            this.pathFragments.Add(string.Empty);
        }

        #endregion
        
        #endregion
    }
}
