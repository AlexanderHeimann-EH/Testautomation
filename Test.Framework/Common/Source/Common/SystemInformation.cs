//------------------------------------------------------------------------------
// <copyright file="SystemInformation.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 27.04.2011
 * Time: 6:30 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using Microsoft.VisualBasic.Devices;

    /// <summary>
    ///     Description of SystemInformation.
    /// </summary>
    public static class SystemInformation
    {
        /// <summary>
        ///     Gets path of environment variable ALLUSERSPROFILE
        /// </summary>
        /// <returns>
        ///     <br>Path: if call worked fine</br>
        ///     <br>Empty String: if an error occurred</br>
        /// </returns>
        public static string GetApplicationDataPath
        {
            get
            {
                const string EnvironmentVariable = "ALLUSERSPROFILE";
                string path = Environment.GetEnvironmentVariable(EnvironmentVariable);
                if (!string.IsNullOrEmpty(path))
                {
                    return path;
                }

                Debug.Print("Could not get path to environment variable: " + EnvironmentVariable);
                return string.Empty;
            }
        }

        #region Guido Simons Ergänzungen

        /// <summary>
        /// Gets the current System Language in short Format like DE-de or EN-us...
        /// </summary>
        public static string SystemLanguage
        {
            get { return CultureInfo.CurrentCulture.Name; }
        }

        /// <summary>
        /// Gets the whole windows version string and Name, Version, Build and Service Packs
        /// </summary>
        public static string WindowsVersion
        {
            get
            {
                // OperatingSystem osInfo = System.Environment.OSVersion;
                string strVers = string.Empty;

                if (Environment.OSVersion.Platform == PlatformID.Win32Windows)
                {
                    // Windows 98 / 98SE oder Windows Me. Windows 95 unterstützt .NET nicht 
                    if (Environment.OSVersion.Version.Minor == 10)
                    {
                        strVers = "Windows 98";
                    }

                    if (Environment.OSVersion.Version.Minor == 90)
                    {
                        strVers = "Windows Me";
                    }
                }

                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                {
                    // Windows NT 4.0, 2000, XP oder Server 2003. Windows NT 3.51 unterstützt .NET nicht 
                    if (Environment.OSVersion.Version.Major == 4)
                    {
                        strVers = "Windows NT 4.0";
                    }

                    if (Environment.OSVersion.Version.Major == 5)
                    {
                        switch (Environment.OSVersion.Version.Minor)
                        {
                            case 0:
                                strVers = "Windows 2000";
                                break;
                            case 1:
                                strVers = "Windows XP";
                                break;
                            case 2:
                                strVers = "Windows Server 2003";
                                break;
                        }
                    }

                    if (Environment.OSVersion.Version.Major == 6)
                    {
                        if (Environment.OSVersion.Version.Minor == 0)
                        {
                            strVers = "Vista/Win2008";
                        }

                        if (Environment.OSVersion.Version.Minor == 1)
                        {
                            strVers = "Win7";
                        }

                        if (Environment.OSVersion.Version.Minor == 2)
                        {
                            strVers = "Win8";
                        }
                    }
                }

                strVers += " " + Environment.OSVersion.ServicePack + ", Revision " +
                           Environment.OSVersion.Version.Revision.ToString(CultureInfo.InvariantCulture) + ", " +
                           Environment.OSVersion.VersionString;

                if (strVers == string.Empty)
                {
                    strVers = "Unbekannte Windows-Version";
                }

                return strVers;
            }
        }

        /// <summary>
        /// Gets a value indicating whether is win 7.
        /// </summary>
        public static bool IsWin7
        {
            get { return WindowsVersion.StartsWith("Win7 "); }
        }

        /// <summary>
        /// Gets a value indicating whether is win 8.
        /// </summary>
        public static bool IsWin8
        {
            get { return WindowsVersion.StartsWith("Win8 "); }
        }

        /// <summary>
        /// Gets a value indicating whether is win xp.
        /// </summary>
    
        public static bool IsWinXp
        {
            get { return WindowsVersion.StartsWith("Windows XP "); }
        }

        /// <summary>
        /// Gets a value indicating whether is 64 bit.
        /// </summary>
        public static bool Is64Bit
        {
            get
            {
                if (IntPtr.Size == 8)
                {
                    // 64 bit machine 
                    return true;
                }

                if (IntPtr.Size == 4)
                {
                    // 32 bit machine 
                    return false;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets Display Color Depth, in Bits per Pixel, should always be 32.
        /// </summary>
        public static int DisplayColor
        {
            get { return Screen.PrimaryScreen.BitsPerPixel; }
        }

        /// <summary>
        ///     Gets the current Display resolution as a Rectangle Object
        /// </summary>
        public static Rectangle ScreenResolution
        {
            get { return Screen.PrimaryScreen.Bounds; }
        }

        #endregion

        /// <summary>
        ///     Provide system information
        /// </summary>
        public static void GetInformation()
        {
            var information = new ComputerInfo();
            ulong availableRamInByte = information.AvailablePhysicalMemory;
            ulong availableRamInMByte = availableRamInByte / (1024 * 1024);
            ulong totalRamInByte = information.TotalPhysicalMemory;
            ulong totalRamInMByte = totalRamInByte / (1024 * 1024);

            int counter;
            int count = 0;
            IList<Process> processes = Process.GetProcesses();

            for (counter = 0; counter < processes.Count; counter++)
            {
                int buffer = processes[counter].HandleCount;

                switch (processes[counter].ProcessName)
                {
                    case "FMPFrame":
                        Tools.Log.Info(processes[counter].ProcessName + "-Handles: ", buffer.ToString(CultureInfo.InvariantCulture));
                        if (buffer > 0)
                        {
                            Tools.Log.Info(processes[counter].ProcessName + "-GDI-Handles: ", GetGuiResourcesGdiCount(processes[counter]).ToString(CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            Tools.Log.Info(processes[counter].ProcessName + "-GDI-Handles: ", "0");
                        }

                        break;

                    case "RanorexStudio":
                        Tools.Log.Info(processes[counter].ProcessName + "-Handles: ", buffer.ToString(CultureInfo.InvariantCulture));
                        if (buffer > 0)
                        {
                            Tools.Log.Info(processes[counter].ProcessName + "-GDI-Handles: ", GetGuiResourcesGdiCount(processes[counter]).ToString(CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            Tools.Log.Info(processes[counter].ProcessName + "-GDI-Handles: ", "0");
                        }

                        break;
                }

                count = count + processes[counter].HandleCount;
            }

            for (counter = 0; counter < processes.Count; counter++)
            {
                processes[counter].Dispose();
            }

            Tools.Log.Info("Used handles:", count.ToString(CultureInfo.InvariantCulture));
            Tools.Log.Info("RAM available in MByte:", availableRamInMByte.ToString(CultureInfo.InvariantCulture));
            Tools.Log.Info("RAM total in MByte:", totalRamInMByte.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     Get GUI resources
        /// </summary>
        /// <param name="processHandle">Process handle</param>
        /// <param name="flags">Flags in unsigned integer</param>
         /// <returns>integer value</returns>
        [DllImport("User32.dll")]
        public static extern int GetGuiResources(IntPtr processHandle, int flags);

        /// <summary>
        /// Provide GUI resource information about GDI count
        /// </summary>
        /// <param name="process">a process</param>
        /// <returns>Graphical User Interface  Resource GDI Count</returns>
        public static int GetGuiResourcesGdiCount(Process process)
        {
            return GetGuiResources(process.Handle, 0);
        }

        /// <summary>
        /// Provide GUI resource information about user
        /// </summary>
        /// <param name="process">a process</param>
        /// <returns>Graphical User Interface Resource User</returns>
        public static int GetGuiResourcesUser(Process process)
        {
            return GetGuiResources(process.Handle, 1);
        }
    }
}