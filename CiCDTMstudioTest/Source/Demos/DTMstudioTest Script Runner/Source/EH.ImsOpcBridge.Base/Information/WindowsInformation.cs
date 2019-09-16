// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowsInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Information
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.ImsOpcBridge.Properties;

    using log4net;

    using Microsoft.Win32;

    /// <summary>
    /// The windows information.
    /// </summary>
    public static class WindowsInformation
    {
        #region Static Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the installer is running.
        /// </summary>
        /// <value><c>true</c> if this instance is installer running; otherwise, <c>false</c> .</value>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK here.")]
        public static bool IsInstallerRunning
        {
            get
            {
                try
                {
                    const string KeyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\InProgress";

                    using (var localMachineKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                    {
                        using (var key = localMachineKey.OpenSubKey(KeyName, false))
                        {
                            if (key != null)
                            {
                                return true;
                            }
                        }
                    }

                    using (var localMachineKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                    {
                        using (var key = localMachineKey.OpenSubKey(KeyName, false))
                        {
                            if (key != null)
                            {
                                return true;
                            }
                        }
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Logger.Error(Resources.CantReadWindowsRegistry, ex);
                    return false;
                }
            }
        }

        #endregion
    }
}
