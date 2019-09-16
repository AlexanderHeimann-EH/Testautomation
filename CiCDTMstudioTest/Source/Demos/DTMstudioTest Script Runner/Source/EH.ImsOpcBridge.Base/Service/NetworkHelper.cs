// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NetworkHelper.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;

    using EH.ImsOpcBridge.Configuration;
    using EH.ImsOpcBridge.FileHandling;

    /// <summary>
    /// The network helper.
    /// </summary>
    public static class NetworkHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the free TCP port.
        /// </summary>
        /// <returns>The free port number.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = @"OK.")]
        public static int GetFreeTcpPort()
        {
            var l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            var port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }

        /// <summary>
        /// Writes the base address automatic configuration file.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="isService">if set to <c>true</c> the application is a service.</param>
        /// <param name="baseAddress">The base address.</param>
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "OK.")]
        public static void WriteBaseAddressToConfigFile(string manufacturer, string applicationName, bool isService, string baseAddress)
        {
            CleanupBaseAddressConfigFiles(manufacturer, applicationName);

            string[] relativePathItems;
            
            if (isService)
            {
                relativePathItems = new string[] { };
            }
            else
            {
                relativePathItems = new string[] { Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture) };
            }
            
            // ReSharper disable LocalizableElement
            var configurationFile = ConfigurationFileSupport.GetConfigurationFileInfo(manufacturer, applicationName, @"WCF", true, false, relativePathItems, @"WcfBaseAddress.config", true);
            using (var fileStream = FileHandler.OpenFile(configurationFile.FullName, FileMode.Create, FileAccess.ReadWrite))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(baseAddress);
                }
            }

            // ReSharper restore LocalizableElement
        }

        /// <summary>
        /// Reads the base address from configuration file.
        /// </summary>
        /// <returns>The base address.</returns>
        [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "OK.")]
        public static string ReadServiceBaseAddressFromConfigFile()
        {
            string[] relativePathItems = new string[] { };

            // ReSharper disable LocalizableElement
            var configurationFile = ConfigurationFileSupport.GetConfigurationFileInfo(@"Endress+Hauser", @"EH.ImsOpcBridge.Service", @"WCF", true, false, relativePathItems, @"WcfBaseAddress.config", false);
            configurationFile.Refresh();
            if (!configurationFile.Exists)
            {
                return string.Empty;
            }

            using (var fileStream = FileHandler.OpenFile(configurationFile.FullName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(fileStream))
                {
                    return reader.ReadToEnd();
                }
            }

            // ReSharper restore LocalizableElement
        }

        /// <summary>
        /// Cleanups the base address configuration files.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="applicationName">Name of the application.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK.")]
        public static void CleanupBaseAddressConfigFiles(string manufacturer, string applicationName)
        {
            var myOtherProcesses = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            var baseRelativePathItems = new string[] { };
            var basePath = ConfigurationFileSupport.GetConfigurationPath(manufacturer, applicationName, @"WCF", true, false, baseRelativePathItems, true);

            try
            {
                foreach (var subDirectory in basePath.EnumerateDirectories())
                {
                    int subDirectoryNameAsInt;

                    if (int.TryParse(subDirectory.Name, NumberStyles.Integer, CultureInfo.InvariantCulture, out subDirectoryNameAsInt))
                    {
                        if (myOtherProcesses.All(p => p.Id != subDirectoryNameAsInt))
                        {
                            try
                            {
                                subDirectory.Delete(true);
                            }
                            catch (System.Exception)
                            {
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
            }
        }

        /// <summary>
        /// Cleanups the base address configuration file.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="isService">if set to <c>true</c> [is service].</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK.")]
        public static void CleanupBaseAddressConfigFile(string manufacturer, string applicationName, bool isService)
        {
            // ReSharper disable LocalizableElement
            string[] relativePathItems;

            if (isService)
            {
                relativePathItems = new string[] { };

                var configurationFile = ConfigurationFileSupport.GetConfigurationFileInfo(manufacturer, applicationName, @"WCF", true, false, relativePathItems, @"WcfBaseAddress.config", true);
                configurationFile.Delete();
            }
            else
            {
                relativePathItems = new string[] { Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture) };

                var configurationPath = ConfigurationFileSupport.GetConfigurationPath(manufacturer, applicationName, @"WCF", true, false, relativePathItems, true);
                try
                {
                    configurationPath.Delete(true);
                }
                catch (Exception)
                {
                }
            }

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
