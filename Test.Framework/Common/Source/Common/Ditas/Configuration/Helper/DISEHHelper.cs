// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DISEHHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 15/04/2014
 * Time: 15:00
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

    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment;

    using Ranorex;

    /// <summary>
    /// Description of DISEHHelper.
    /// </summary>
    public class DISEHHelper
    {
        #region Constants

        /// <summary>
        /// The connect_ cm d_ savecred.
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
        /// The diseh meas tech mapping.
        /// </summary>
        private Dictionary<string, string> disehMeasTechMapping = null;

        /// <summary>
        /// The diseh protocol mapping.
        /// </summary>
        private Dictionary<string, string> disehProtocolMapping = null;

        /// <summary>
        /// The diseh pwd.
        /// </summary>
        private string disehPwd = string.Empty;

        /// <summary>
        /// The diseh server name.
        /// </summary>
        private string disehServerName = string.Empty;

        /// <summary>
        /// The diseh user.
        /// </summary>
        private string disehUser = string.Empty;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DISEHHelper"/> class.
        /// </summary>
        /// <param name="disehServerName">
        /// The diseh server name.
        /// </param>
        /// <param name="disehUser">
        /// The diseh user.
        /// </param>
        /// <param name="disehPwd">
        /// The diseh pwd.
        /// </param>
        public DISEHHelper(string disehServerName, string disehUser, string disehPwd)
        {
            this.disehServerName = disehServerName;
            this.disehUser = disehUser;
            this.disehPwd = disehPwd;

            if (this.disehProtocolMapping == null || this.disehMeasTechMapping == null)
            {
                this.disehProtocolMapping = new Dictionary<string, string>();
                this.disehProtocolMapping.Add("profibus dp", "DP");
                this.disehProtocolMapping.Add("profibus pa", "PA");
                this.disehProtocolMapping.Add("ethernet ip", "ETH");
                this.disehProtocolMapping.Add("foundation fieldbus h1", "FF");
                this.disehProtocolMapping.Add("hart", "HART");
                this.disehProtocolMapping.Add("modbus ethernet", "MBE");
                this.disehProtocolMapping.Add("modbus rs485", "MR4");

                this.disehMeasTechMapping = new Dictionary<string, string>();
                this.disehMeasTechMapping.Add("analysis", "AN");
                this.disehMeasTechMapping.Add("components", "CO");
                this.disehMeasTechMapping.Add("flow", "FL");
                this.disehMeasTechMapping.Add("level", "LE");
                this.disehMeasTechMapping.Add("pressure", "PR");
                this.disehMeasTechMapping.Add("temperature", "TE");
            }

            this.MapDISEH();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DISEHHelper"/> class.
        /// </summary>
        public DISEHHelper()
        {
            if (this.disehProtocolMapping == null || this.disehMeasTechMapping == null)
            {
                this.disehProtocolMapping = new Dictionary<string, string>();
                this.disehProtocolMapping.Add("profibus dp", "DP");
                this.disehProtocolMapping.Add("profibus pa", "PA");
                this.disehProtocolMapping.Add("ethernet ip", "ETH");
                this.disehProtocolMapping.Add("foundation fieldbus h1", "FF");
                this.disehProtocolMapping.Add("hart", "HART");
                this.disehProtocolMapping.Add("modbus ethernet", "MBE");
                this.disehProtocolMapping.Add("modbus rs485", "MR4");

                this.disehMeasTechMapping = new Dictionary<string, string>();
                this.disehMeasTechMapping.Add("analysis", "AN");
                this.disehMeasTechMapping.Add("components", "CO");
                this.disehMeasTechMapping.Add("flow", "FL");
                this.disehMeasTechMapping.Add("level", "LE");
                this.disehMeasTechMapping.Add("pressure", "PR");
                this.disehMeasTechMapping.Add("temperature", "TE");
            }

            this.MapDISEH();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the meas tech mapping.
        /// </summary>
        public Dictionary<string, string> MeasTechMapping
        {
            get
            {
                return this.disehMeasTechMapping;
            }
        }

        /// <summary>
        /// Gets the protocol mapping.
        /// </summary>
        public Dictionary<string, string> ProtocolMapping
        {
            get
            {
                return this.disehProtocolMapping;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get drive letter.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDriveLetter()
        {
            // Find the drive letter
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_MappedLogicalDisk");

            foreach (var o in searcher.Get())
            {
                var drive = (ManagementObject)o;
                string driveName = Convert.ToString(drive["ProviderName"]);

                if (driveName.Contains(this.disehServerName))
                {
                    return Convert.ToString(drive["Name"]);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// The get driver path for device.
        /// </summary>
        /// <param name="device">
        /// The device.
        /// </param>
        /// <param name="pamToolName">
        /// The pam tool name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDriverPathForDevice(Device device, string pamToolName)
        {
            string driveLetter = this.GetDriveLetter();

            string deviceIID = Convert.ToString(device.IID);
            string deviceType = device.Type;
            string deviceProtocol = device.Communication;
            string deviceFirmware = device.Firmware;
            string deviceMeasTech = device.MeasTech;
            string deviceFamily = device.Family.Replace(" ", "_");

            string pathProtocol = this.ProtocolMapping[deviceProtocol.ToLower()];
            string pathMeasTech = this.MeasTechMapping[deviceMeasTech.ToLower()];

            pamToolName = pamToolName.ToLower();

            if (pamToolName.Equals("ams"))
            {
                pamToolName = "3_AMS";
            }
            else if (pamToolName.Equals("pdm"))
            {
                pamToolName = "6_PDM";
            }

            // Y:\HART\FL\0x005A_Prosonic_Flow_B_200\1.00.00_1166\Supporting_Material\6_PDM

            // string path = driveLetter + "\\" + pathProtocol + "\\" + pathMeasTech + "\\" + deviceType + "_" + deviceFamily + "\\" + deviceFirmware + "_" + deviceIID + "\\Supporting_Material\\" + pamToolName;
            string path = driveLetter + "\\" + pathProtocol + "\\" + pathMeasTech + "\\" + deviceType + "_" + deviceFamily + "\\" + deviceFirmware + "_" + deviceIID + "\\Supporting_Material\\" + pamToolName;
            Report.Info("DISEH PATH " + path);
            string[] driverDir = Directory.GetDirectories(path, "*_R");

            string driverPath = string.Empty;
            if (driverDir.Length > 0)
            {
                driverPath = driverDir[0];
            }
            else
            {
                string[] zip = Directory.GetFiles(path, "*_R.zip");
                if (zip.Length > 0)
                {
                    driverPath = zip[0];
                }
            }

            return driverPath;
        }

        /// <summary>
        /// The map diseh.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MapDISEH()
        {
            NETRESOURCE nr = new NETRESOURCE();

            nr.dwType = RESOURCETYPE_DISK;
            nr.lpRemoteName = this.disehServerName;
            bool connected = false;

            if (!this.IsDISEHMapped())
            {
                string driveLetter = this.GetNextDriveLetter();

                if (driveLetter != null)
                {
                    nr.lpLocalName = driveLetter + ":";
                }

                if (WNetAddConnection2(ref nr, this.disehPwd, this.disehUser, CONNECT_CMD_SAVECRED) == 0)
                {
                    connected = true;
                }
            }

            return connected;
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
        /// The is diseh mapped.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsDISEHMapped()
        {
            bool isMapped = false;

            // Find the drive letter
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_MappedLogicalDisk");

            foreach (var o in searcher.Get())
            {
                var drive = (ManagementObject)o;
                string driveName = Convert.ToString(drive["ProviderName"]);

                if (driveName.ToLower().Contains(this.disehServerName.ToLower()))
                {
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