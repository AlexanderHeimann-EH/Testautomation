// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportDirectory.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 02/04/2014
 * Time: 09:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.Helper
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;

    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment;

    using Ranorex;

    using DateTime = System.DateTime;

    /// <summary>
    /// Description of ReportDirectory.
    /// </summary>
    public class ReportDirectory
    {
        #region Static Fields

        /// <summary>
        /// The device family.
        /// </summary>
        private static readonly string DeviceFamily;

        /// <summary>
        /// The device firmware.
        /// </summary>
        private static readonly string DeviceFirmware;

        /// <summary>
        /// The device iid.
        /// </summary>
        private static readonly string DeviceIid;

        /// <summary>
        /// The device type.
        /// </summary>
        private static readonly string DeviceType;

        /// <summary>
        /// The path meas tech.
        /// </summary>
        private static readonly string PathMeasTech;

        /// <summary>
        /// The path protocol.
        /// </summary>
        private static readonly string PathProtocol;

        /// <summary>
        /// The destination directory.
        /// </summary>
        private static string destinationDirectory = string.Empty;

        /// <summary>
        /// The device meas tech.
        /// </summary>
        private static string deviceMeasTech;

        /// <summary>
        /// The device protocol.
        /// </summary>
        private static string deviceProtocol;

        /// <summary>
        /// The source dir.
        /// </summary>
        private static string sourceDirectory = Directory.GetCurrentDirectory();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="ReportDirectory"/> class.
        /// </summary>
        static ReportDirectory()
        {
            Device device = TestRunFacade.GetDevice();
            if (device != null)
            {
                DeviceIid = Convert.ToString(device.IID);
                DeviceType = device.Type;
                deviceProtocol = device.Communication;
                DeviceFirmware = device.Firmware;
                deviceMeasTech = device.MeasTech;
                DeviceFamily = device.Family.Replace(" ", "_");

                PathProtocol = new DISEHHelper().ProtocolMapping[deviceProtocol.ToLower()];
                PathMeasTech = new DISEHHelper().MeasTechMapping[device.MeasTech.ToLower()];
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The move reports to directory.
        /// </summary>
        /// <param name="testRunID">
        /// The test run id.
        /// </param>
        /// <param name="deviceIID">
        /// The device iid.
        /// </param>
        public static void MoveReportsToDirectory(int testRunID, int deviceIID)
        {
            Report.End();
            Thread.Sleep(10000);
            string driveLetter = new DISEHHelper().GetDriveLetter();
            if (driveLetter != string.Empty && testRunID != 0)
            {
                destinationDirectory = driveLetter + "\\" + PathProtocol + "\\" + PathMeasTech + "\\" + DeviceType + "_" + DeviceFamily + "\\" + DeviceFirmware + "_" + Convert.ToString(deviceIID) + "\\Testreports\\TA_Reports\\" + Convert.ToString(testRunID);
            }

            CreateDirectoryAndMoveAll();
        }

        /// <summary>
        /// Moves the reports to fail directory.
        /// </summary>
        public static void MoveReportsToFailDirectory()
        {
            Report.End();
            Thread.Sleep(10000);
            DateTime now = DateTime.Now;

            string driveLetter = new DISEHHelper().GetDriveLetter();
            string timeStamp = now.ToString("yyyMMdd") + "_" + now.ToString("HHmm");

            if (driveLetter != string.Empty)
            {
                destinationDirectory = driveLetter + "\\" + PathProtocol + "\\" + PathMeasTech + "\\" + DeviceType + "_" + DeviceFamily + "\\" + DeviceFirmware + "_" + Convert.ToString(DeviceIid) + "\\Testreports\\TA_Reports\\Fail\\Unknown\\" + timeStamp;
            }

            CreateDirectoryAndMoveAll();
        }

        /// <summary>
        /// The move reports to fail directory.
        /// </summary>
        /// <param name="deviceIID">
        /// The device iid.
        /// </param>
        public static void MoveReportsToFailDirectory(int deviceIID)
        {
            Report.End();
            Thread.Sleep(10000);
            DateTime now = DateTime.Now;

            string driveLetter = new DISEHHelper().GetDriveLetter();
            string timeStamp = now.ToString("yyyMMdd") + "_" + now.ToString("HHmm");

            if (driveLetter != string.Empty)
            {
                // destinationDir = driveLetter + "\\team-id\\ID\\07_TA\\Reports\\" + Convert.ToString(deviceIID) + "\\Fail\\" + timestamp;                
                destinationDirectory = driveLetter + "\\" + PathProtocol + "\\" + PathMeasTech + "\\" + DeviceType + "_" + DeviceFamily + "\\" + DeviceFirmware + "_" + Convert.ToString(deviceIID) + "\\Testreports\\TA_Reports\\Fail\\" + timeStamp;
            }

            CreateDirectoryAndMoveAll();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The do copy folder.
        /// </summary>
        private static void DoCopyFolder()
        {
            string[] theDirectories = Directory.GetDirectories(sourceDirectory, "*images*");
            foreach (string curDir in theDirectories)
            {
                destinationDirectory = destinationDirectory + curDir.Substring(curDir.LastIndexOf("\\", System.StringComparison.Ordinal));
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                string[] theFilesInCurrentDir = Directory.GetFiles(curDir, "*_trace.jpg*");
                if (theFilesInCurrentDir.Length > 0)
                {
                    foreach (string currentFile in theFilesInCurrentDir)
                    {
                        string destFile = destinationDirectory + "\\" + currentFile.Substring(currentFile.LastIndexOf("\\", System.StringComparison.Ordinal) + 1);
                        File.Copy(ToShortPathName(currentFile), destFile);
                    }
                }

                // Directory.Delete(curDir);
            }
        }

        /// <summary>
        /// The get short path name.
        /// </summary>
        /// <param name="lpszLongPath">
        /// The lpsz long path.
        /// </param>
        /// <param name="lpszShortPath">
        /// The lpsz short path.
        /// </param>
        /// <param name="cchBUffer">
        /// The cch b uffer.
        /// </param>
        /// <returns>
        /// The <see cref="uint"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetShortPathName([MarshalAs(UnmanagedType.LPTStr)] string lpszLongPath, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszShortPath, uint cchBUffer);

        /// <summary>
        /// The to short path name.
        /// </summary>
        /// <param name="sLongFileName">
        /// The s long file name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string ToShortPathName(string sLongFileName)
        {
            uint bufferSize = 256;
            StringBuilder shortNameBuffer = new StringBuilder((int)bufferSize);

            uint result = GetShortPathName(sLongFileName, shortNameBuffer, bufferSize);

            return shortNameBuffer.ToString();
        }

        /// <summary>
        /// The create directory and move all.
        /// </summary>
        private static void CreateDirectoryAndMoveAll()
        {
            sourceDirectory = ToShortPathName(sourceDirectory);

            // destinationDir = ToShortPathName(destinationDir);
            Directory.CreateDirectory(destinationDirectory);

            Report.Info("Moving Ranorex Reports from " + sourceDirectory + " to " + destinationDirectory);

            string[] filePaths = Directory.GetFiles(sourceDirectory, "*rxlog*");
            MoveFiles(filePaths);

            filePaths = Directory.GetFiles(sourceDirectory, "*RanorexReport*.*");
            MoveFiles(filePaths);

            DoCopyFolder();
        }

        /// <summary>
        /// The move files.
        /// </summary>
        /// <param name="filePaths">
        /// The file paths.
        /// </param>
        private static void MoveFiles(string[] filePaths)
        {
            if (destinationDirectory != string.Empty)
            {
                for (int i = 0; i < filePaths.Length; i++)
                {
                    string fileName = filePaths[i].Substring(filePaths[i].LastIndexOf("\\", StringComparison.Ordinal) + 1);
                    string sourceFile = sourceDirectory + "\\" + fileName;
                    string destinationFile = destinationDirectory + "\\" + fileName;

                    File.Move(sourceFile, destinationFile);
                    File.Delete(sourceFile);
                }
            }
        }

        #endregion
    }
}