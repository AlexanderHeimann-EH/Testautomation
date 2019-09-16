// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base
// Author           : I02423401
// Created          : 04-16-2013
//
// Last Modified By : I02423401
// Last Modified On : 04-16-2013
// ***********************************************************************
// <copyright file="SystemInfo.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace EH.ImsOpcBridge.Support
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Management;

    using Microsoft.Win32;

    /// <summary>
    /// the SystemInfo class gets the hardware- and software information.
    /// </summary>
    public class SystemInfo
    {
        #region Fields

        /// <summary>
        /// The hardware information list.
        /// </summary>
        private readonly List<string> hardwareInformationList = new List<string>();

        /// <summary>
        /// The software information list.
        /// </summary>
        private readonly List<string> softwareInformationList = new List<string>();

        /// <summary>
        /// Folder of the supportFiles
        /// </summary>
        private readonly DirectoryInfo supportFilesFolder;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemInfo" /> class. Prevents a default instance of the <see cref="SystemInfo" /> class from being created.
        /// </summary>
        /// <param name="supportFilesFolder">The support files folder.</param>
        public SystemInfo(DirectoryInfo supportFilesFolder)
        {
            this.supportFilesFolder = supportFilesFolder;
            this.softwareInformationList = GetSoftwareInformation();
            this.hardwareInformationList = GetHardwareInformation();

            ////this.WriteInTextFile(this.HardwareInformationList, "Hardware");
            ////this.WriteInTextFile(this.SoftwareInformationList, "Software");
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets HardwareInformationList.
        /// </summary>
        /// <value>The hardware information list.</value>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Is correct here.")]
        public List<string> HardwareInformationList
        {
            get
            {
                return this.hardwareInformationList;
            }
        }

        /// <summary> 
        /// Gets SoftwareInformationList.
        /// </summary>
        /// <value>The software information list.</value>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Is correct here.")]
        public List<string> SoftwareInformationList
        {
            get
            {
                return this.softwareInformationList;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Writes the in text file.
        /// </summary>
        /// <param name="infoList">The info list.</param>
        /// <param name="textWriter">The text writer.</param>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Must be non-static.")]
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Is correct here.")]
        public void WriteInTextFile(List<string> infoList, TextWriter textWriter)
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException(@"textWriter");
            }

            if (infoList == null)
            {
                throw new ArgumentNullException(@"infoList");
            }

            foreach (var info in infoList)
            {
                textWriter.WriteLine(info);
            }
        }

        /// <summary>
        /// The write in text file.
        /// </summary>
        /// <param name="infoList">The info list.</param>
        /// <param name="name">The name.</param>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Is correct here.")]
        public void WriteInTextFile(List<string> infoList, string name)
        {
            using (var textWriter = new StreamWriter(this.supportFilesFolder + name + ".txt"))
            {
                this.WriteInTextFile(infoList, textWriter);
            }
        }

        /// <summary>
        /// Write the Software and Hardware Infos in text files
        /// </summary>
        public void WriteInTextFiles()
        {
            //// Write Software Infos in a Textfile: Software.txt
            using (var textWriter = new StreamWriter(this.supportFilesFolder + "\\Software.txt"))
            {
                foreach (var info in this.SoftwareInformationList)
                {
                    textWriter.WriteLine(info);
                }
            }

            //// Write Hardware Infos in a Textfile: Hardware.txt
            using (var textWriter = new StreamWriter(this.supportFilesFolder + "\\Hardware.txt"))
            {
                foreach (var info in this.HardwareInformationList)
                {
                    textWriter.WriteLine(info);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get device manager.
        /// </summary>
        /// <returns>returns the device manager list.</returns>
        private static List<string> GetDeviceManager()
        {
            var deviceManager = new List<string>();

            using (var managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_PnPEntity"))
            {
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    if (managementObject["Name"] != null)
                    {
                        deviceManager.Add("Name : " + managementObject["Name"]);
                    }

                    if (managementObject["ErrorDescription"] != null)
                    {
                        deviceManager.Add("ErrorDescription : " + managementObject["ErrorDescription"]);
                    }

                    if (managementObject["Status"] != null)
                    {
                        deviceManager.Add("Status : " + managementObject["Status"]);
                    }

                    deviceManager.Add(string.Empty);
                }

                return deviceManager;
            }
        }

        /// <summary>
        /// The get hard drive.
        /// </summary>
        /// <returns>Returns Hard drive information.</returns>
        private static List<string> GetHardDrive()
        {
            var hardDrive = new List<string>();
            using (var managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia"))
            {
                foreach (ManagementObject wmiHd in managementObjectSearcher.Get())
                {
                    if (wmiHd["Tag"].ToString() == "\\\\.\\PHYSICALDRIVE0")
                    {
                        if (wmiHd["SerialNumber"] != null)
                        {
                            hardDrive.Add(@"PhysicalHardDisk ID: " + wmiHd["SerialNumber"]);
                        }
                    }
                }

                if (hardDrive.Count == 0)
                {
                    hardDrive.Add(@"PhysicalHardDisk ID: unknown");
                }

                hardDrive.Add(" ");
            }

            using (var managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_LogicalDisk"))
            {
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    if (managementObject["Name"] != null)
                    {
                        hardDrive.Add(managementObject["Name"].ToString());
                    }

                    if (managementObject["VolumeSerialNumber"] != null)
                    {
                        hardDrive.Add(@"HardDisk ID: " + managementObject["VolumeSerialNumber"]);
                    }

                    if (managementObject["Size"] != null)
                    {
                        ulong hardDriveCapacity = ulong.Parse(managementObject["Size"].ToString(), CultureInfo.InvariantCulture) / 1000000;
                        hardDrive.Add(@"Size : " + hardDriveCapacity + " MB");
                    }

                    if (managementObject["FreeSpace"] != null)
                    {
                        ulong hardDriveFreeSpace = ulong.Parse(managementObject["FreeSpace"].ToString(), CultureInfo.InvariantCulture) / 1000000;
                        hardDrive.Add(@"FreeSpace : " + hardDriveFreeSpace + " MB");
                    }

                    if (managementObject["DeviceID"] != null)
                    {
                        hardDrive.Add(@"DeviceID : " + managementObject["DeviceID"]);
                    }

                    hardDrive.Add(string.Empty);
                }
            }

            return hardDrive;
        }

        /// <summary>
        /// The get hardware information.
        /// </summary>
        /// <returns>returns the Hardware information</returns>
        private static List<string> GetHardwareInformation()
        {
            var hardwareInformation = new List<string>();
            hardwareInformation.Add("===================================================");
            hardwareInformation.Add("Hardware Informations : ");
            hardwareInformation.Add("Date : " + DateTime.Now);
            hardwareInformation.Add("===================================================");
            hardwareInformation.Add("### Operating System ###");
            hardwareInformation.Add("---------------------------------------------------");
            hardwareInformation.AddRange(GetOperatingSystem());
            hardwareInformation.Add("===================================================");
            hardwareInformation.Add("### Virtual Machine ###");
            hardwareInformation.Add("---------------------------------------------------");
            hardwareInformation.AddRange(GetVirtualMachineInfo());
            hardwareInformation.Add("===================================================");
            hardwareInformation.Add("### Processor ###");
            hardwareInformation.Add("---------------------------------------------------");
            hardwareInformation.AddRange(GetProcessor());
            hardwareInformation.Add("===================================================");
            hardwareInformation.Add("### Memory ###");
            hardwareInformation.Add("---------------------------------------------------");
            hardwareInformation.AddRange(GetMemory());
            hardwareInformation.Add("===================================================");
            hardwareInformation.Add("### Hard Drive ###");
            hardwareInformation.Add("---------------------------------------------------");
            hardwareInformation.AddRange(GetHardDrive());
            hardwareInformation.Add("===================================================");
            hardwareInformation.Add("### Device Manager ###");
            hardwareInformation.Add("---------------------------------------------------");
            hardwareInformation.AddRange(GetDeviceManager());
            hardwareInformation.Add("===================================================");

            return hardwareInformation;
        }

        /// <summary>
        /// The get processes.
        /// </summary>
        /// <returns>returns process information</returns>
        private static List<string> GetInstalledSoftware()
        {
            var installedSoftware = new List<string>();

            const string UninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(UninstallKey))
            {
                if (registryKey != null)
                {
                    foreach (string subKeyName in registryKey.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = registryKey.OpenSubKey(subKeyName))
                        {
                            if (subKey != null)
                            {
                                if (subKey.GetValue("DisplayName") != null)
                                {
                                    installedSoftware.Add(subKey.GetValue("DisplayName") + "  " + subKey.GetValue("DisplayVersion"));
                                }
                            }
                        }
                    }
                }
            }

            installedSoftware.Sort();
            return installedSoftware;
        }

        /// <summary>
        /// The get memory.
        /// </summary>
        /// <returns>Returns Memory information</returns>
        private static List<string> GetMemory()
        {
            var memory = new List<string>();

            using (var managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_PhysicalMemory "))
            {
                ulong physicalMemory = 0;
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    if (managementObject["Capacity"] != null)
                    {
                        ulong test = ulong.Parse(managementObject["Capacity"].ToString(), CultureInfo.InvariantCulture);

                        physicalMemory += test;
                    }
                }

                physicalMemory = physicalMemory / 1000000;
                memory.Add("Physical Memory : " + physicalMemory.ToString(CultureInfo.InvariantCulture) + "MB");
                return memory;
            }
        }

        /// <summary>
        /// The get operating system.
        /// </summary>
        /// <returns>returns Operating System information</returns>
        private static List<string> GetOperatingSystem()
        {
            var operatingSystem = new List<string>();

            using (var managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem"))
            {
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    if (managementObject["Caption"] != null)
                    {
                        operatingSystem.Add("Operating System Name : " + managementObject["Caption"]); // Display operating system caption
                    }

                    try
                    {
                        if (managementObject["OSArchitecture"] != null)
                        {
                            operatingSystem.Add("Operating System Architecture : " + managementObject["OSArchitecture"]); // Display operating system architecture.
                        }
                    }
                    catch (ManagementException)
                    {
                        operatingSystem.Add("Operating System Architecture : unknown");
                    }

                    if (managementObject["CSDVersion"] != null)
                    {
                        operatingSystem.Add("Operating System Service Pack  : " + managementObject["CSDVersion"]); // Display operating system version.
                    }
                }

                return operatingSystem;
            }
        }

        /// <summary>
        /// The get processes.
        /// </summary>
        /// <returns>returns process information</returns>
        private static List<string> GetProcesses()
        {
            var processes = new List<string>();

            using (var managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_Process"))
            {
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    if (managementObject["Name"] != null)
                    {
                        processes.Add((string)managementObject["Name"]);
                    }
                }

                processes.Sort();
                return processes;
            }
        }

        /// <summary>
        /// The get processor.
        /// </summary>
        /// <returns>returns processor information</returns>
        private static List<string> GetProcessor()
        {
            var processor = new List<string>();

            using (var managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_Processor"))
            {
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    if (managementObject["Name"] != null)
                    {
                        processor.Add("Processor Name : " + managementObject["Name"]);
                    }
                }

                return processor;
            }
        }

        /// <summary>
        /// Gets the software information.
        /// </summary>
        /// <returns>returns the software information</returns>
        private static List<string> GetSoftwareInformation()
        {
            var softwareInformation = new List<string>();
            softwareInformation.Add("===================================================");
            softwareInformation.Add("Software Informations : ");
            softwareInformation.Add("Date : " + DateTime.Now);
            softwareInformation.Add("===================================================");
            softwareInformation.Add("### Installed Software ###");
            softwareInformation.Add("---------------------------------------------------");
            softwareInformation.AddRange(GetInstalledSoftware());
            softwareInformation.Add("===================================================");
            softwareInformation.Add("### Processes ###");
            softwareInformation.Add("---------------------------------------------------");
            softwareInformation.AddRange(GetProcesses());
            softwareInformation.Add("===================================================");
            return softwareInformation;
        }

        /// <summary>
        /// The get virtual machine info.
        /// </summary>
        /// <returns>returns virtual machine info</returns>
        private static List<string> GetVirtualMachineInfo()
        {
            var virtualMachine = new List<string>();

            using (var managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem"))
            {
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                    if (managementObject["Manufacturer"] != null)
                    {
                        if (managementObject["Manufacturer"].ToString().ToLower(CultureInfo.CurrentCulture) == "microsoft corporation" || managementObject["Manufacturer"].ToString().ToLower(CultureInfo.CurrentCulture).Contains("vmware") || managementObject["Model"].ToString() == "VirtualBox")
                        {
                            virtualMachine.Add("This system runs in a virtual machine.");
                            virtualMachine.Add("Virtual Machine Manufacturer: " + managementObject["Manufacturer"]);
                        }
                    }
                }

                if (virtualMachine.Count == 0)
                {
                    virtualMachine.Add("This system runs on a physical machine.");
                }

                return virtualMachine;
            }
        }

        #endregion
    }
}
