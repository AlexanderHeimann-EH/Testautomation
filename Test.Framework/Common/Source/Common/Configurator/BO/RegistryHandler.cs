// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistryHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Contains methods to get values from OS registry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Configurator.BO
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Microsoft.Win32;

    /// <summary>
    /// Contains methods to get values from OS registry.
    /// </summary>
    public static class RegistryHandler
    {
        /// <summary>
        /// Get installation path of TestPackage from registry
        /// </summary>
        /// <returns>
        /// path as string
        /// </returns>
        public static string GetPathFromRegistry()
        {
            const string KeyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Endress+Hauser\CiCDTMstudioTest\EH.TestPackage";
            const string ValueName = "InstallationPath";

            var registryObject = Registry.GetValue(KeyName, ValueName, null);

            if (registryObject == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "There is no TestPackage installed.");
            }

            var installationPath = (string)registryObject;
            if (installationPath == null)
            {
                return string.Empty;
            }

            return installationPath;
        }
    }
}
