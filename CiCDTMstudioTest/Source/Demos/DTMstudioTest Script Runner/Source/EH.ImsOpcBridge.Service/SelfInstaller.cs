// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelfInstaller.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The self installer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Service
{
    using System.Configuration.Install;
    using System.Reflection;

    /// <summary>
    /// Class SelfInstaller
    /// </summary>
    public static class SelfInstaller
    {
        #region Static Fields

        /// <summary>
        /// The _exe path
        /// </summary>
        private static readonly string ExePath = Assembly.GetExecutingAssembly().Location;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Installs me.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public static bool InstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new[] { ExePath });
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Uninstalls me.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public static bool UninstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new[] { "/u", ExePath });
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}