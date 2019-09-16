// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationFileSupport.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Security.AccessControl;
    using System.Security.Principal;

    /// <summary>
    /// Contains helper methods for evaluating the paths, for configuration files.
    /// </summary>
    public static class ConfigurationFileSupport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the file stream of a specific configuration file.
        /// </summary>
        /// <param name="manufacturer">Name of the manufacturer, which is hosting the ImsOpcBridge.</param>
        /// <param name="applicationName">Name of the application, which is hosting the ImsOpcBridge.</param>
        /// <param name="componentName">Name of the component. Usually "ImsOpcBridge". Can also be null or string.Empty.</param>
        /// <param name="commonConfiguration">If set to <c>true</c> the configuration is shared between different users on the same computer.</param>
        /// <param name="versionDependent">If set to <c>true</c> the configuration is dependent on the assembly version of EH.ImsOpcBridge.Base.</param>
        /// <param name="relativePathItems">The path items, relative to the base configuration path ...Application Data\Endress+Hauser\ImsOpcBridge\[Shared|(version)].</param>
        /// <param name="fileName">The name of the configuration file located at the specified path.</param>
        /// <param name="createIfMissing">If set to <c>true</c>, the file should be created when missing.</param>
        /// <returns>The configuration file info.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK.")]
        public static FileInfo GetConfigurationFileInfo(string manufacturer, string applicationName, string componentName, bool commonConfiguration, bool versionDependent, string[] relativePathItems, string fileName, bool createIfMissing)
        {
            var fileInfo = GetConfigurationFileInfo(manufacturer, applicationName, componentName, commonConfiguration, versionDependent, relativePathItems, fileName);

            if (!fileInfo.Exists && createIfMissing)
            {
                if ((fileInfo.Directory != null) && !fileInfo.Directory.Exists)
                {
                    fileInfo.Directory.Create();
                    fileInfo.Directory.Refresh();
                }

                using (fileInfo.Create())
                {
                }

                fileInfo.Refresh();
            }

            if (fileInfo.Exists)
            {
                try
                {
                    // This gets the "Authenticated Users" group, no matter what it's called
                    var sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);

                    // Create the rules
                    var fullControlRights = new FileSystemAccessRule(sid, FileSystemRights.FullControl, AccessControlType.Allow);

                    // Get your file's ACL
                    var fsecurity = File.GetAccessControl(fileInfo.FullName);

                    // Add the new rule to the ACL
                    fsecurity.AddAccessRule(fullControlRights);

                    // Set the ACL back to the file
                    File.SetAccessControl(fileInfo.FullName, fsecurity);
                }
                catch (Exception)
                {
                }
            }

            return fileInfo;
        }

        /// <summary>
        /// Gets the file stream of a specific configuration file.
        /// </summary>
        /// <param name="manufacturer">Name of the manufacturer, which is hosting the ImsOpcBridge.</param>
        /// <param name="applicationName">Name of the application, which is hosting the ImsOpcBridge.</param>
        /// <param name="componentName">Name of the component. Usually "ImsOpcBridge". Can also be null or string.Empty.</param>
        /// <param name="relativePathItems">The path items, relative to the base configuration path ...Application Data\Endress+Hauser\ImsOpcBridge\[Shared|(version)].</param>
        /// <param name="fileName">The name of the configuration file located at the specified path.</param>
        /// <param name="createIfMissing">If set to<c>true</c>, the file should be created when missing.</param>
        /// <returns>The configuration file info.</returns>
        /// <remarks>This method is looking for configuration files in the following order:
        /// (1) In the Application Data folder of the current user at ...Application Data\Endress+Hauser\ImsOpcBridge\(version of the EH.ImsOpcBridge.Base assembly)...
        /// (2) In the Application Data folder of the current user at ...Application Data\Endress+Hauser\ImsOpcBridge\Shared...
        /// (3) In the Application Data folder of all users at ...Application Data\Endress+Hauser\ImsOpcBridge\(version of the EH.ImsOpcBridge.Base assembly)...
        /// (4) In the Application Data folder of all users at ...Application Data\Endress+Hauser\ImsOpcBridge\Shared...
        /// If createIfMissing is set to<c>true</c>and there is no configuration file found. The method creates a configuration file at ...Application Data\Endress+Hauser\ImsOpcBridge\Shared...</remarks>
        public static FileInfo GetConfigurationFileInfo(string manufacturer, string applicationName, string componentName, string[] relativePathItems, string fileName, bool createIfMissing)
        {
            // start checking for most specific configuration: local, version dependent
            var configurationFileInfo = GetConfigurationFileInfo(manufacturer, applicationName, componentName, false, true, relativePathItems, fileName, false);
            if (configurationFileInfo.Exists)
            {
                return configurationFileInfo;
            }

            // continue with next configuration: local, non version dependent
            configurationFileInfo = GetConfigurationFileInfo(manufacturer, applicationName, componentName, false, false, relativePathItems, fileName, false);
            if (configurationFileInfo.Exists)
            {
                return configurationFileInfo;
            }

            // continue with next configuration: common, version dependent
            configurationFileInfo = GetConfigurationFileInfo(manufacturer, applicationName, componentName, true, true, relativePathItems, fileName, false);
            if (configurationFileInfo.Exists)
            {
                return configurationFileInfo;
            }

            // continue with next configuration: common, non version dependent
            configurationFileInfo = GetConfigurationFileInfo(manufacturer, applicationName, componentName, true, false, relativePathItems, fileName, createIfMissing);
            return configurationFileInfo;
        }

        /// <summary>
        /// Sets the full access rights automatic common configuration for authenticated users.
        /// </summary>
        /// <param name="directoryInfo">The directory.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK.")]
        public static void SetFullAccessRightsToCommonConfigurationForAuthenticatedUsers(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                throw new ArgumentNullException(@"directoryInfo");
            }
            
            if (directoryInfo.Exists)
            {
                try
                {
                    // This gets the "Authenticated Users" group, no matter what it's called
                    var sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);

                    // Create the rules
                    var fullControlRights = new FileSystemAccessRule(sid, FileSystemRights.FullControl, AccessControlType.Allow);

                    // Get your file's ACL
                    var fsecurity = Directory.GetAccessControl(directoryInfo.FullName);

                    // Add the new rule to the ACL
                    fsecurity.AddAccessRule(fullControlRights);

                    // Set the ACL back to the file
                    Directory.SetAccessControl(directoryInfo.FullName, fsecurity);

                    foreach (FileInfo fi in directoryInfo.GetFiles())
                    {
                        // Get the file's FileSecurity
                        var ac = fi.GetAccessControl();

                        // inherit from the directory
                        ac.AddAccessRule(fullControlRights);

                        // apply change
                        fi.SetAccessControl(ac);
                    }

                    // Recurse into Directories
                    directoryInfo.GetDirectories().ToList().ForEach(subDirectoryInfo => SetFullAccessRightsToCommonConfigurationForAuthenticatedUsers(subDirectoryInfo));
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Sets the full access rights automatic common configuration for authenticated users.
        /// </summary>
        /// <param name="manufacturer">The manufacturer.</param>
        /// <param name="applicationName">Name of the application.</param>
        public static void SetFullAccessRightsToCommonConfigurationForAuthenticatedUsers(string manufacturer, string applicationName)
        {
            const Environment.SpecialFolder SpecialFolder = Environment.SpecialFolder.CommonApplicationData;
            var applicationDataPath = Environment.GetFolderPath(SpecialFolder);

            var filePathItem = new List<string> { applicationDataPath, manufacturer, applicationName };
            var path = Path.Combine(filePathItem.ToArray());
            var directoryInfo = new DirectoryInfo(path);
            SetFullAccessRightsToCommonConfigurationForAuthenticatedUsers(directoryInfo);
        }

        /// <summary>
        /// Returns the directory info of a configuration path.
        /// </summary>
        /// <param name="manufacturer">Name of the manufacturer, which is hosting the ImsOpcBridge.</param>
        /// <param name="applicationName">Name of the application, which is hosting the ImsOpcBridge.</param>
        /// <param name="componentName">Name of the component. Usually "ImsOpcBridge". Can also be null or string.Empty.</param>
        /// <param name="commonConfiguration">If set to <c>true</c> the configuration is shared between different users on the same computer.</param>
        /// <param name="versionDependent">If set to <c>true</c> the configuration is dependent on the assembly version of EH.ImsOpcBridge.Base.</param>
        /// <param name="relativePathItems">The path items, relative to the base configuration path ...Application Data\Endress+Hauser\ImsOpcBridge\[Shared|(version)].</param>
        /// <param name="createIfMissing">If set to <c>true</c>, the file should be created when missing.</param>
        /// <returns>The directory info.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = @"OK.")]
        public static DirectoryInfo GetConfigurationPath(string manufacturer, string applicationName, string componentName, bool commonConfiguration, bool versionDependent, IEnumerable<string> relativePathItems, bool createIfMissing)
        {
            var path = BuildPath(manufacturer, applicationName, componentName, commonConfiguration, versionDependent, relativePathItems);
            var directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists && createIfMissing)
            {
                directoryInfo.Create();
                directoryInfo.Refresh();
            }

            return directoryInfo;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Builds the file path.
        /// </summary>
        /// <param name="manufacturer">Name of the manufacturer, which is hosting the ImsOpcBridge.</param>
        /// <param name="applicationName">Name of the application, which is hosting the ImsOpcBridge.</param>
        /// <param name="componentName">Name of the component. Usually "ImsOpcBridge". Can also be null or string.Empty.</param>
        /// <param name="commonConfiguration">If set to <c>true</c> the configuration is shared between different users on the same computer.</param>
        /// <param name="versionDependent">If set to <c>true</c> the configuration is dependent on the assembly version of EH.ImsOpcBridge.Base.</param>
        /// <param name="relativePathItems">The path items, relative to the base configuration path ...Application Data\Endress+Hauser\ImsOpcBridge\[Shared|(version)].</param>
        /// <param name="fileName">The name of the configuration file located at the specified path.</param>
        /// <returns>The path of the configuration file.</returns>
        private static string BuildFilePath(string manufacturer, string applicationName, string componentName, bool commonConfiguration, bool versionDependent, IEnumerable<string> relativePathItems, string fileName)
        {
            var path = BuildPath(manufacturer, applicationName, componentName, commonConfiguration, versionDependent, relativePathItems);
            return Path.Combine(path, fileName);
        }

        /// <summary>
        /// Builds a specific path in the configuration.
        /// </summary>
        /// <param name="manufacturer">Name of the manufacturer, which is hosting the ImsOpcBridge.</param>
        /// <param name="applicationName">Name of the application, which is hosting the ImsOpcBridge.</param>
        /// <param name="componentName">Name of the component. Usually "ImsOpcBridge". Can also be null or string.Empty.</param>
        /// <param name="commonConfiguration">If set to <c>true</c> the configuration is shared between different users on the same computer.</param>
        /// <param name="versionDependent">If set to <c>true</c> the configuration is dependent on the assembly version of EH.ImsOpcBridge.Base.</param>
        /// <param name="relativePathItems">The path items, relative to the base configuration path ...Application Data\Endress+Hauser\ImsOpcBridge\[Shared|(version)].</param>
        /// <returns>The path of the configuration file.</returns>
        private static string BuildPath(string manufacturer, string applicationName, string componentName, bool commonConfiguration, bool versionDependent, IEnumerable<string> relativePathItems)
        {
            Environment.SpecialFolder specialFolder;

            if (commonConfiguration)
            {
                specialFolder = Environment.SpecialFolder.CommonApplicationData;
            }
            else
            {
                specialFolder = Environment.SpecialFolder.LocalApplicationData;
            }

            var applicationDataPath = Environment.GetFolderPath(specialFolder);

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionString;

            if (versionDependent)
            {
                // ReSharper disable LocalizableElement
                versionString = string.Format(CultureInfo.InvariantCulture, @"{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
                // ReSharper restore LocalizableElement
            }
            else
            {
                // ReSharper disable LocalizableElement
                versionString = @"Shared";
                // ReSharper restore LocalizableElement
            }

            List<string> filePathItem;

            if (string.IsNullOrEmpty(componentName))
            {
                filePathItem = new List<string> { applicationDataPath, manufacturer, applicationName, versionString };
            }
            else
            {
                filePathItem = new List<string> { applicationDataPath, manufacturer, applicationName, componentName, versionString };
            }

            filePathItem.AddRange(relativePathItems);

            return Path.Combine(filePathItem.ToArray());
        }

        /// <summary>
        /// Returns information about a configuration file.
        /// </summary>
        /// <param name="manufacturer">Name of the manufacturer, which is hosting the ImsOpcBridge.</param>
        /// <param name="applicationName">Name of the application, which is hosting the ImsOpcBridge.</param>
        /// <param name="componentName">Name of the component. Usually "ImsOpcBridge". Can also be null or string.Empty.</param>
        /// <param name="commonConfiguration">If set to <c>true</c> the configuration is shared between different users on the same computer.</param>
        /// <param name="versionDependent">If set to <c>true</c> the configuration is dependent on the assembly version of EH.ImsOpcBridge.Base.</param>
        /// <param name="relativePathItems">The path items, relative to the base configuration path ...Application Data\Endress+Hauser\ImsOpcBridge\[Shared|(version)].</param>
        /// <param name="fileName">The name of the configuration file located at the specified path.</param>
        /// <returns>The configuration file info.</returns>
        private static FileInfo GetConfigurationFileInfo(string manufacturer, string applicationName, string componentName, bool commonConfiguration, bool versionDependent, IEnumerable<string> relativePathItems, string fileName)
        {
            var filePath = BuildFilePath(manufacturer, applicationName, componentName, commonConfiguration, versionDependent, relativePathItems, fileName);
            return new FileInfo(filePath);
        }

        #endregion
    }
}
