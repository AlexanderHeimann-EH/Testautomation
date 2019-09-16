// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstStrings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The Project Constant Strings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Tools 
{
    /// <summary>
    /// The Project Constant Strings.
    /// </summary>
    public static class ConstStrings  
    {
        /// <summary>
        /// The build define constants property.
        /// </summary>
        public const string BuildDefineConstantsProperty = "BuildDefineConstants";

        /// <summary>
        /// The device type project extension.
        /// </summary>
        public const string DeviceTypeProjectExtension = ".dtproj";

        /// <summary>
        /// The device type test project extension.
        /// </summary>
        public const string DeviceTypeTestProjectExtension = ".testproj";

        /// <summary>
        /// The test framework install path.
        /// </summary>
        public const string TestFrameworkRegistryPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Endress+Hauser\CiCDTMstudioTest\EH.TestPackage";

        /// <summary>
        /// The test framework registry key.
        /// </summary>
        public const string TestFrameworkRegistryKey = "InstallationPath";

        /// <summary>
        /// The test framework config file.
        /// </summary>
        public const string TestFrameworkConfigFile = "Configuration.xml";

        /// <summary>
        /// The template version.
        /// </summary>
        public const string TemplateVersion = "TemplateVersion";

        /// <summary>
        /// The output path.
        /// </summary>
        public const string ExportPath = "Export";

        /// <summary>
        /// The no device type project available.
        /// </summary>
        public const string NoDeviceTypeProjectAvailable = "Not Available";
    }
}
