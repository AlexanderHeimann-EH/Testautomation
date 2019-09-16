// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstallationCheck.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2013
// </copyright>
// <summary>
//   The enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 03.12.2013
 * Time: 08:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System;

    using Microsoft.Win32;

    using Ranorex;

    /// <summary>
    /// Description of IsProgramInstalled.
    /// </summary>
    public class InstallationCheck
    {
        /// <summary>
        /// Checks for a specific program if it is installed on that system by checking the
        /// registry-key values under SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall
        /// </summary>
        /// <param name="programDisplayName">The name of the program to check for</param>
        /// <param name="exceptionOnFail">Specifies if method should throw an exception on failure</param>
        /// <returns>Returns true if the program is installed, false if it is not
        /// ElementNotFoundException: if exceptionOnFail is true and program is not installed</returns>
        public static bool IsProgramInstalled(string programDisplayName, bool exceptionOnFail)
        {
            string displayName = null;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");

            Report.Info(string.Format("Checking install status of: {0}", programDisplayName));
            if (key != null)
            {
                foreach (string keyName in key.GetSubKeyNames())
                {
                    RegistryKey subkey = key.OpenSubKey(keyName);
                    if (subkey != null)
                    {
                        displayName = subkey.GetValue("DisplayName") as string;
                    }

                    if (programDisplayName.Equals(displayName, StringComparison.OrdinalIgnoreCase))
                    {
                        Report.Info(displayName);
                        Report.Success("Program is installed");
                        return true;
                    }
                }
            }

            Report.Failure("{0} is not installed", programDisplayName);
            if (exceptionOnFail)
            {
                throw new ElementNotFoundException(programDisplayName + " is not installed on that system");
            }

            return false; 
        }
    }
}
