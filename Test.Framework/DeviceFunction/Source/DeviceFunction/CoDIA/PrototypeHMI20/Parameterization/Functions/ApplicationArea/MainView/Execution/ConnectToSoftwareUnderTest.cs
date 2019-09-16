// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectToSoftwareUnderTest.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of ConnectToSoftwareUnderTest.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    using Microsoft.Win32;

    /// <summary>
    /// Class ConnectToSoftwareUnderTest.
    /// </summary>
    class ConnectToSoftwareUnderTest : IConnectToSoftwareUnderTest
    {
        /// <summary>
        /// Connects the testing interface
        /// </summary>
        /// <param name="remoteHost">The remote host.</param>
        /// <param name="remotePort">The remote port.</param>
        /// <param name="pushMessageServerHost">The push message server host.</param>
        /// <param name="pushMessageServerPort">The push message server port.</param>
        /// <returns><c>true</c> if connected, <c>false</c> otherwise.</returns>
        private bool Run(string remoteHost, ushort remotePort, string pushMessageServerHost, ushort pushMessageServerPort)
        {
            return AppComController.Connect(remoteHost, remotePort, pushMessageServerHost, pushMessageServerPort);
        }

        /// <summary>
        /// Connects the testing interface using the config file TestInterface.txt in temp folder. Defaults will be used if file not found
        /// </summary>
        /// <returns><c>true</c> if connected, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            try
            {
                bool result;
                string configFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                string searchForThis = Path.Combine(configFolderPath, "TestingInterface.txt");

                if (File.Exists(searchForThis))
                {
                    StreamReader file = new StreamReader(searchForThis);
                    string line = file.ReadLine();
                    string[] separator = { "," };
                    string[] configParts = line.Split(separator, StringSplitOptions.None);
                    ushort remotePortUshort = Convert.ToUInt16(configParts[1]);
                    ushort pushMessageServerPortUshort = Convert.ToUInt16(configParts[3]);
                    result = this.Run(configParts[0], remotePortUshort, configParts[2], pushMessageServerPortUshort);
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "TestingInterface.txt config file does not exist. Using defaults for connection.");
                    result = this.Run("localhost", 4876, "localhost", 8080);
                }

                return result;
            }
            catch (Exception e)
            {

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), e.Message);
                return false;
            }
        }

        /// <summary>
        /// Get installation path of TestPackage from registry
        /// </summary>
        /// <returns>
        /// path as string
        /// </returns>
        private string GetTestPackagePathFromRegistry()
        {
            string result = string.Empty;
            const string KeyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Endress+Hauser\CiCDTMstudioTest\EH.TestPackage";
            const string ValueName = "InstallationPath";

            var registryObject = Registry.GetValue(KeyName, ValueName, null);

            if (registryObject != null)
            {
                result = (string)registryObject;

            }

            return result;
        }
    }
}
