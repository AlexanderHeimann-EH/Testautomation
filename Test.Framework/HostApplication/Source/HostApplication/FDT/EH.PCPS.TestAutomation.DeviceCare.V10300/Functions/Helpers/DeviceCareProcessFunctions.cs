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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

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
        /// The repo.
        /// </summary>
        private GUI.DeviceCareApplication repo;

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
            this.drives = null;
            this.driveList = new List<string>();
            this.pathFragments = new List<string>();
            this.repo = GUI.DeviceCareApplication.Instance;
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
            this.InstallationPath = null;

            if (this.IsHostApplicationRunning(this.GetProcessList()) == false)
            {
                this.PopulatePathFragments();
                this.GetDriveVolumeLabel();

                Report.Info("Looking for the installation directory...");
                Report.Debug("Hard drives found: " + this.driveList.Count.ToString(CultureInfo.InvariantCulture));

                for (int i = 0; i < this.driveList.Count; i++)
                {
                    if (this.InstallationPath == null)
                    {
                        for (int j = 0; j <= 2; j++)
                        {
                            try
                            {
                                string root = this.driveList[i] + this.pathFragments[j];
                                this.GetSubDirectories(root);
                            }
                            catch (IOException)
                            {
                            }
                        }
                    }
                }

                this.InstallationPath = this.InstallationPath + @"\DeviceCare\DeviceCare.exe";
                Report.Debug("HostApplication directory: " + this.InstallationPath);
                int processId = this.StartHostApplication(this.InstallationPath);
                Report.Info("Waiting for the application to load...");
                this.WaitForFrame(20000);
                return this.IsHostApplicationRunning(processId);
            }
            else
            {
                Report.Failure("HostApplication was already running.");

                // TODO: Report running processes
            }

            return false;
        }

        /// <summary>
        /// Tries to start DeviceCare under a provided path
        /// </summary>
        /// <param name="path">The complete path to the application including the application name</param>
        /// <returns>Returns the process ID of the running process</returns>
        public int Run(string path)
        {
            int processId = 0;
            if (this.IsHostApplicationRunning(this.GetProcessList()) == false)
            {
                Report.Info("Running HostApplication: DeviceCare under: " + path);
                processId = this.StartHostApplication(path);
                Report.Info("Waiting for the application to load...");
                this.WaitForFrame();
            }
            else
            {
                Report.Failure("HostApplication was already running.");

                // TODO: Report running processes
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
            int processId = 0;

            if (this.IsHostApplicationRunning(this.GetProcessList()) == false)
            {
                Report.Info("Running HostApplication: DeviceCare under: " + path);
                processId = this.StartHostApplication(path);
                Report.Info("Waiting for the application to load (timing out after " + timeOutInMilliseconds.ToString(CultureInfo.InvariantCulture) + "ms)...");
                this.WaitForFrame(timeOutInMilliseconds);
            }
            else
            {
                Report.Failure("HostApplication was already running.");

                // TODO: Report running processes
            }

            return processId;
        }

        /// <summary>
        /// Checks if the 'DeviceCare' process is running on the local host
        /// </summary>
        /// <param name="localAll">A list of all running processes</param>
        /// <returns>True if the process is running</returns>
        public bool IsHostApplicationRunning(Process[] localAll)
        {
            bool isRunning = false;
            foreach (Process process in localAll)
            {
                if (process.ProcessName == "DeviceCare")
                {
                    isRunning = true;
                }
            }

            return isRunning;
        }

        /// <summary>
        /// Validates if a process is running by checking if a process
        /// with the given processID exists
        /// </summary>
        /// <param name="processId">The believed process ID of the process to validate</param>
        /// <returns>True if the application is running</returns>
        public bool IsHostApplicationRunning(int processId)
        {
            if (Process.GetProcessById(processId) != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the DC process instance which is running on the local host
        /// </summary>
        /// <returns>The DC process</returns>
        public Process GetDcProcess()
        {
            Process[] localAll = this.GetProcessList();

            foreach (Process p in localAll)
            {
                if (p.ProcessName == "DeviceCare")
                {
                    return p;
                }
            }

            return null;
        }

        #endregion

        #region Private

        /// <summary>
        /// Waits a specific amount of time until the frame is visible and exists
        /// </summary>
        /// <param name="timeOutInMilliseconds">The time in milliseconds to wait for the frame to exist</param>
        /// <returns>True if the application is running and visible</returns>
        private bool WaitForFrame(int timeOutInMilliseconds)
        {
            // bool exists = this.repo.DeviceCare.TitleArea.EndressHauserLogoInfo.Exists(timeOutInMilliseconds);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < 10000)
            {
                if (watch.ElapsedMilliseconds >= 10000)
                {
                    return false;
                }

                if (this.repo.Header.PictureLogoEndressHauserInfo.Exists())
                {
                    watch.Stop();
                    Report.Success("HostApplication is running and visible");
                    return true;
                }
            }

            // if (exists)
            // {
            //    Report.Success("HostApplication is running and visible");
            //    return true;
            // }
            // else
            // {
            Report.Failure("HostApplication timed out");
            return false;
            // }
        }

        /// <summary>
        /// Waits for a fixed amount of time (5 min) until
        /// the frame is running and visible
        /// </summary>
        /// <returns>True if the application is running and visible</returns>
        private bool WaitForFrame()
        {
            Stopwatch preventDeadlock = new Stopwatch();
            int timeOut = 300000; // TimeSpan.FromMinutes(5);
            preventDeadlock.Start();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < timeOut)
            {
                if (watch.ElapsedMilliseconds >= timeOut)
                {
                    Report.Failure("HostApplication was not visible after " + (timeOut / 60000) + " minutes. Action was unsuccessful");
                    return false;
                }

                if (this.repo.Header.PictureLogoEndressHauserInfo.Exists())
                {
                    watch.Stop();
                    Report.Success("HostApplication is running and visible");
                    return true;
                }
            }

            // bool exists = repo.DeviceCare.TitleArea.EndressHauserLogoInfo.Exists(1000);

            // while (exists == false)
            // {
            //    exists = repo.DeviceCare.TitleArea.EndressHauserLogoInfo.Exists(200);
            //    if (preventDeadlock.Elapsed > timeOut)
            //    {
            //        Report.Failure("HostApplication was not visible after 5 minutes. Action was unsuccessful");
            //        return false;
            //    }
            // }

            // Report.Success("HostApplication is running and visible");
            // return true;

            Report.Failure("HostApplication was not visible after " + (timeOut / 60000) + " minutes. Action was unsuccessful");
            return false;
        }

        /// <summary>
        /// Searches all subdirectories in a directory which matches the search pattern "En*"
        /// This is used for top hierarchy search (searching for "Endress+Hauser" folders)
        /// </summary>
        /// <param name="root">The directory to get subdirectories from</param>
        private void GetSubDirectories(string root)
        {
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
            Report.Debug("Subdir: " + dir);
            var source = new DirectoryInfo(dir);
            string[] subdirectoryEntries = Directory.GetDirectories(dir, "DeviceCare");
            foreach (string subdirectory in subdirectoryEntries)
            {
                Report.Success("Directory found in: " + subdirectory);
                this.InstallationPath = subdirectory;
            }
        }

        /// <summary>
        /// Runs an application with a specified path
        /// </summary>
        /// <param name="path">The path of the program to start</param>
        /// <returns>The process id of the started process</returns>
        private int StartHostApplication(string path)
        {
            if (File.Exists(path))
            {
                return Host.Local.RunApplication(path, string.Empty, string.Empty, true);    
            }

            Report.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Path to DeviceCare [" + path + "] is not valid.");
            return -1;
        }

        /// <summary>
        /// Adds all volume labels of all hard drives of the host to a list
        /// </summary>
        private void GetDriveVolumeLabel()
        {
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
            this.pathFragments.Add(@"\Program Files");
            this.pathFragments.Add(@"\Program Files (x86)");
            this.pathFragments.Add(string.Empty);
        }

        /// <summary>
        /// Gets an array of all running processes
        /// </summary>
        /// <returns>An array of all running processes</returns>
        private Process[] GetProcessList()
        {
            return Process.GetProcesses();
        }

        #endregion
        #endregion
    }
}
