// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoDIADataManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The CoDIADataManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DTMstudioCoDIA.TestApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using EH.DTMstudioTest.Common.Serialization;
    using EH.DTMstudioTest.Common.TransportObjects;
    using EH.DTMstudioTest.Interface.DTMstudioCoDIA.Interfaces;

    /// <summary>
    /// The CoDIA data manager.
    /// </summary>
    public class CoDIADataManager : IDataManager
    {
        #region Fields

        /// <summary>
        /// The temp DTM studio CoDIA data path.
        /// </summary>
        private const string TempDTMstudioCoDIADataPath = @"TempCoDIADTMstudioCoDIAData.xml";

        /// <summary>
        /// The temp DTM studio test data path.
        /// </summary>
        private const string TempDTMstudioTestDataPath = @"TempCoDIADTMstudioTestData.xml";

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the DTM studio test data.
        /// </summary>
        public DTMstudioTestData DTMstudioTestData { get; set; }

        /// <summary>
        /// Gets or sets the DTM studio CoDIA data.
        /// </summary>
        public DTMstudioCoDIAData DTMstudioCoDIAData { get; set; }

        #endregion
         
        #region Public Methods

        /// <summary>
        /// The get DTM studio data.
        /// </summary>
        public void GetDTMstudioData()
        {
            this.GetDTMstudioCoDIAData();
            this.GetDTMstudioTestData();
        }

        /// <summary>
        /// The get configuration.
        /// </summary>
        public void GetDTMstudioCoDIAData()
        {
            this.DTMstudioCoDIAData = new DTMstudioCoDIAData();
            this.DTMstudioCoDIAData.GetDemoData();
        }

        /// <summary>
        /// The get DTM studio test data.
        /// </summary>
        public void GetDTMstudioTestData()
        {
            this.DTMstudioTestData = new DTMstudioTestData();
            this.DTMstudioTestData.GetDemoData();
        }

        /// <summary>
        /// The set DTM studio test data.
        /// </summary>
        /// <param name="dtmStudioTestData">
        /// The DTM studio test data.
        /// </param>
        public void SetDTMstudioTestData(DTMstudioTestData dtmStudioTestData) 
        {
            this.DTMstudioTestData = dtmStudioTestData;
        }



        /// <summary>
        /// The set DTM studio CoDIA data.
        /// </summary>
        /// <param name="dtmStudioCoDIAData">
        /// The DTM studio CoDIA data.
        /// </param> 
        public void SetDTMstudioCoDIAData(DTMstudioCoDIAData dtmStudioCoDIAData) 
        {
            this.DTMstudioCoDIAData = dtmStudioCoDIAData;
        }

        /// <summary>
        /// The save DTM studio data.
        /// </summary>
        public void SaveDTMstudioData()
        {
            this.SaveDTMstudioCoDIAData();
            this.SaveDTMstudioTestData();
        }

        /// <summary>
        /// The save DTM studio CoDIA data.
        /// </summary>
        public void SaveDTMstudioCoDIAData() 
        {
            XmlSerialization.XmlSerializeObject(TempDTMstudioCoDIADataPath, this.DTMstudioCoDIAData);
        }

        /// <summary>
        /// The save DTM studio test data.
        /// </summary>
        public void SaveDTMstudioTestData()
        {
            XmlSerialization.XmlSerializeObject(TempDTMstudioTestDataPath, this.DTMstudioTestData);
        }

        /// <summary>
        /// The load DTM studio CoDIA data.
        /// </summary>
        /// <exception cref="Exception">
        /// throw exception 
        /// </exception>
        public void LoadDTMstudioCoDIAData() 
        {
            if (File.Exists(TempDTMstudioTestDataPath))
            {
                Exception exception;
                this.DTMstudioTestData = (DTMstudioTestData)XmlSerialization.XmlDeserializeObject(TempDTMstudioTestDataPath, typeof(DTMstudioTestData), out exception, false);

                if (exception != null)
                {
                    throw exception;
                }
            }
        }

        /// <summary>
        /// The load DTM studio test data.
        /// </summary>
        /// <exception cref="Exception">
        /// throw exception
        /// </exception>
        public void LoadDTMstudioTestData() 
        {
            if (File.Exists(TempDTMstudioCoDIADataPath))
            {
                Exception exception;
                this.DTMstudioCoDIAData = (DTMstudioCoDIAData)XmlSerialization.XmlDeserializeObject(TempDTMstudioCoDIADataPath, typeof(DTMstudioCoDIAData), out exception, false);

                if (exception != null)
                {
                    throw exception;
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// The get device type project.
        /// </summary>
        /// <returns>
        /// The <see cref="DeviceTypeProject"/>.
        /// </returns>
        private DeviceTypeProject GetDemoDeviceTypeProject()
        {
            return new DeviceTypeProject
            {
                Guid = new Guid("99fffe7f-7b4f-446e-af8e-169bc18e2468"),
                DeviceFunctions = this.GetDemoDeviceFunctions(),
                DeviceTypeFramework = this.GetDemoDeviceTypeFramework(),
                FDTDeviceTypeName = "HA_11_28_0201_FMR5x"
            };
        }

        /// <summary>
        /// The get device type framework.
        /// </summary>
        /// <returns>
        /// The <see cref="DeviceTypeFramework"/>.
        /// </returns>
        private DeviceTypeFramework GetDemoDeviceTypeFramework()
        {
            return new DeviceTypeFramework
                       {
                           FrameworkComponents = this.GetDemoFrameworkComponents(),
                           Name = "I_v1.3.31.6954",
                           Version = new Version(1, 3, 31, 6954)
                       };
        }

        /// <summary>
        /// The get demo framework components.
        /// </summary>
        /// <returns>
        /// The <see cref="FrameworkComponent"/>.
        /// </returns>
        private List<FrameworkComponent> GetDemoFrameworkComponents()
        {
            return new List<FrameworkComponent>
                       {
                           new FrameworkComponent
                               {
                                   Name = "CWComponents",
                                   Version = new Version(1, 2, 50, 8980)
                               },
                           new FrameworkComponent
                               {
                                   Name = "EHComponents",
                                   Version = new Version(1, 0, 4, 1145)
                               },
                       };
        }

        /// <summary>
        /// The get demo device functions.
        /// </summary>
        /// <returns>
        /// The <see cref="DeviceFunction"/>.
        /// </returns>
        private List<DeviceFunction> GetDemoDeviceFunctions()
        {
            return new List<DeviceFunction>
                       {
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 0, 34, 1145),
                                   Name = "EH.CoDIA.HistoROM.GUI"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 0, 34, 1145),
                                   Name = "EH.CoDIA.HistoROM.BO"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 0, 34, 1145),
                                   Name = "EHCoDIAEnvelopeCurve.GUI"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 0, 34, 1145),
                                   Name = "EHCoDIAEnvelopeCurve.BO"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 0, 34, 1145),
                                   Name = "EHCoDIALinearization.GUI.Offline"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 0, 34, 1145),
                                   Name = "EHCoDIALinearization.GUI.Online"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 0, 34, 1145),
                                   Name = "EHCoDIAEventList.GUI"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 0, 34, 1145),
                                   Name = "EHCoDIAEventList.BO"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 2, 50, 8980),
                                   Name = "UploadDownloadManagerGui"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 2, 50, 8980),
                                   Name = "UploadDownloadManagerBO"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 2, 50, 8980),
                                   Name = "AboutBoxDialog"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 2, 50, 8980),
                                   Name = "DatasetComparison.GUI"
                               },
                           new DeviceFunction
                               {
                                   Active = true,
                                   Version = new Version(1, 2, 50, 8980),
                                   Name = "DatasetComparison.BO"
                               },
                       };
        }

        /// <summary>
        /// The get demo test machine specific data.
        /// </summary>
        /// <returns>
        /// The <see cref="TestEnvironment"/>.
        /// </returns>
        private TestEnvironment GetDemoTestEnvironment()
        {
            var testMachineSpecificData = new TestEnvironment
            {
                ComputerName = Environment.MachineName,
                HostApplicationType = "FDT",
                HostApplicationName = "FieldCare_2.09.01",
                OperatingSystemName = Environment.OSVersion.VersionString,
                OperatingSystemBitVersion = Environment.Is64BitOperatingSystem ? "64 Bit" : "32 Bit",
                OperatingSystemLanguage = CultureInfo.InstalledUICulture,
                OperatingSystemServicePack = Environment.OSVersion.ServicePack,
                CommunicationProtocol = "HART",
            };

            return testMachineSpecificData;
        }

        #endregion
    }
}
