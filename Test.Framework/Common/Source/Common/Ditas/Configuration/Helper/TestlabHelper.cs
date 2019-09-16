// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestlabHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 08/09/2014
 * Time: 10:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.Helper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management;
    using System.Runtime.InteropServices;

    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.Common;

    using Ranorex;

    /// <summary>
    /// Description of TestlabHelper.
    /// </summary>
    public class TestlabHelper
    {
        #region Constants

        /// <summary>
        /// The connect_cmd_savecred.
        /// </summary>
        private const uint CONNECT_CMD_SAVECRED = 4096;

        /// <summary>
        /// The n o_ error.
        /// </summary>
        private const uint NO_ERROR = 0;

        /// <summary>
        /// The resourcetyp e_ disk.
        /// </summary>
        private const uint RESOURCETYPE_DISK = 1;

        #endregion

        #region Fields

        /// <summary>
        /// The path to exe.
        /// </summary>
        private string pathToExe = string.Empty;

        /// <summary>
        /// The testlab job location.
        /// </summary>
        private string testlabJobLocation = string.Empty;

        /// <summary>
        /// The testlab pwd.
        /// </summary>
        private string testlabPwd = string.Empty;

        /// <summary>
        /// The testlab share.
        /// </summary>
        private string testlabShare = string.Empty;

        /// <summary>
        /// The testlab user.
        /// </summary>
        private string testlabUser = string.Empty;

        /// <summary>
        /// The vm name.
        /// </summary>
        private string vmName = string.Empty;

        /// <summary>
        /// The testlab drive letter.
        /// </summary>
        private string testlabDriveLetter = string.Empty;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestlabHelper"/> class.
        /// </summary>
        public TestlabHelper()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestlabHelper"/> class.
        /// </summary>
        /// <param name="testlabShare">
        /// The testlab share.
        /// </param>
        /// <param name="testlabUser">
        /// The testlab user.
        /// </param>
        /// <param name="testlabPwd">
        /// The testlab pwd.
        /// </param>
        /// <param name="testlabJobLocation">
        /// The testlab job location.
        /// </param>
        /// <param name="vmName">
        /// The vm name.
        /// </param>
        /// <param name="pathToExe">
        /// The path to exe.
        /// </param>
        public TestlabHelper(string testlabShare, string testlabUser, string testlabPwd, string testlabJobLocation, string vmName, string pathToExe)
        {
            this.testlabShare = testlabShare;
            this.testlabUser = testlabUser;
            this.testlabPwd = testlabPwd;
            this.testlabJobLocation = testlabJobLocation;
            this.vmName = vmName;
            this.pathToExe = pathToExe;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The map testlab.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MapTestlab()
        {
            if (!this.IsTestlabMapped())
            {
                bool connected = false;
                NETRESOURCE nr = new NETRESOURCE();

                this.testlabDriveLetter = this.GetNextDriveLetter();

                if (this.testlabDriveLetter != string.Empty)
                {
                    nr.lpLocalName = this.testlabDriveLetter + ":";
                }

                nr.dwType = RESOURCETYPE_DISK;

                nr.lpRemoteName = this.testlabShare;

                if (WNetAddConnection2(ref nr, this.testlabPwd, this.testlabUser, CONNECT_CMD_SAVECRED) == 0)
                {
                    connected = true;
                }

                return connected;
            }

            return true;
        }

        /// <summary>
        /// The move job xml to exe dir.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MoveJobXMLToExeDir()
        {
            bool success = false;
            try
            {
                string jobFileLocation = this.testlabShare + this.testlabJobLocation + "\\" + this.vmName;
                string[] files = Directory.GetFiles(jobFileLocation, "*.xml");

                string filePathTo = this.pathToExe + "\\testConfig.xml";

                Report.Info("JOB LOC " + jobFileLocation);
                Report.Info("SAVE TO " + filePathTo);
                if (files.Length > 0)
                {
                    if (File.Exists(filePathTo))
                    {
                        File.Delete(filePathTo);
                    }

                    Report.Info("FILE " + files[0]);
                    File.Move(files[0], filePathTo);
                    success = true;
                }
                else
                {
                    Report.Info("Config xml not found in " + jobFileLocation);
                }
            }
            catch (IOException exception)
            {
                Report.Error("Exception:", exception.ToString());
                return false;
            }

            return success;
        }

        /// <summary>
        /// The write status file to testlab.
        /// </summary>
        /// <param name="status">
        /// The status.
        /// </param>
        public void WriteStatusFileToTestlab(TestStatus.Status status)
        {
            string jobFileLocation = this.testlabShare + this.testlabJobLocation + "\\" + this.vmName;
            string[] files = Directory.GetFiles(jobFileLocation, "*.txt");

            string statusString = string.Empty;
            if (status == TestStatus.Status.Running)
            {
                statusString = "test_running";
            }
            else if (status == TestStatus.Status.ConfigNotCopied)
            {
                statusString = "test_config_not_copied";
            }
            else if (status == TestStatus.Status.Finished)
            {
                statusString = "testfinished_VM";
            }
            else if (status == TestStatus.Status.Timeout)
            {
                statusString = "timeout";
            }

            if (files.Length > 0)
            {
                if (File.Exists(files[0]))
                {
                    File.Delete(files[0]);
                }
            }

            string pathAndStatus = jobFileLocation + "\\" + statusString + ".txt";

            Report.Info("PATH AND STATUS " + pathAndStatus);
            File.Create(pathAndStatus);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The w net add connection 2.
        /// </summary>
        /// <param name="lpNetResource">
        /// The lp net resource.
        /// </param>
        /// <param name="lpPassword">
        /// The lp password.
        /// </param>
        /// <param name="lpUserName">
        /// The lp user name.
        /// </param>
        /// <param name="dwFlags">
        /// The dw flags.
        /// </param>
        /// <returns>
        /// The <see cref="uint"/>.
        /// </returns>
        [DllImport("mpr.dll", CharSet = CharSet.Auto)]
        private static extern uint WNetAddConnection2(ref NETRESOURCE lpNetResource, [In] [MarshalAs(UnmanagedType.LPTStr)] string lpPassword, [In] [MarshalAs(UnmanagedType.LPTStr)] string lpUserName, uint dwFlags);

        /// <summary>
        /// The get next drive letter.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetNextDriveLetter()
        {
            List<string> inUse = new List<string>();

            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                inUse.Add(drive.Name.Substring(0, 1).ToUpper());
            }

            char[] alphas = "EFGHIJKLMNOPQRSTUVWXY".ToCharArray();

            foreach (char alpha in alphas)
            {
                if (!inUse.Contains(alpha.ToString()))
                {
                    return alpha.ToString();
                }
            }

            return null;
        }

        /// <summary>
        /// The is testlab mapped.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsTestlabMapped()
        {
            bool isMapped = false;

            // Find the drive letter
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_MappedLogicalDisk");

            foreach (ManagementObject drive in searcher.Get())
            {
                string driveName = Convert.ToString(drive["ProviderName"]);

                if (driveName.Contains(this.testlabShare) && driveName.Contains("testlab"))
                {
                    this.testlabDriveLetter = Convert.ToString(drive["Name"]);
                    isMapped = true;
                    break;
                }
            }

            return isMapped;
        }

        #endregion

        /// <summary>
        /// The netresource.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct NETRESOURCE
        {
            /// <summary>
            /// The dw scope.
            /// </summary>
            public readonly uint dwScope;

            /// <summary>
            /// The dw type.
            /// </summary>
            public uint dwType;

            /// <summary>
            /// The dw display type.
            /// </summary>
            public readonly uint dwDisplayType;

            /// <summary>
            /// The dw usage.
            /// </summary>
            public readonly uint dwUsage;

            /// <summary>
            /// The lp local name.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpLocalName;

            /// <summary>
            /// The lp remote name.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpRemoteName;

            /// <summary>
            /// The lp comment.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)]
            public readonly string lpComment;

            /// <summary>
            /// The lp provider.
            /// </summary>
            [MarshalAs(UnmanagedType.LPTStr)]
            public readonly string lpProvider;
        }
    }
}