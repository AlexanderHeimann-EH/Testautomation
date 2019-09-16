// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsModuleConfigurable.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Checks if the module is offline
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.Functions.ApplicationArea.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20501.GUI;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    /// Checks if the module is offline
    /// </summary>
    public class IsModuleConfigurable
    {
        /// <summary>
        /// Checks if the module configurable (offline)
        /// by determining if the communication Unit combo box is enabled
        /// </summary>
        /// <returns>
        ///     <br>True: if module is configurable (offline)</br>
        ///     <br>False: if module is not configurable (online) or an error occurred</br>
        /// </returns>
        public static bool Run()
        {
            ComboBox cb = new CDICommDTMRepoElements().ComboboxFoundDevices;

            if (cb != null && cb.Enabled)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is configurable");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Modul is not configurable. Combobox [Selected COM port] is not available or not enabled");
            return false;
        }
    }
}
