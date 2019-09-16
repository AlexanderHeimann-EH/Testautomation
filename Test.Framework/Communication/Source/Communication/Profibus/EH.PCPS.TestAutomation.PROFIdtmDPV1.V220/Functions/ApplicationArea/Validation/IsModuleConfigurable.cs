// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsModuleConfigurable.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Checks if the module is offline
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V220.Functions.ApplicationArea.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    /// Checks if the module is offline
    /// </summary>
    public class IsModuleConfigurable
    {
        /// <summary>
        /// Checks if the module configurable (offline)
        /// by determining if the Baud Rate combo box is enabled
        /// </summary>
        /// <param name="suppressLogging">
        /// The suppress Logging.
        /// </param>
        /// <returns>
        /// <br>True: if module is configurable (offline)</br>
        ///     <br>False: if module is not configurable (online) or an error occurred</br>
        /// </returns>
        public bool Run(bool suppressLogging)
        {
            ComboBox cb = new GUI.ProfIdtmDpv1RepoElements().BaudRateComboBox;

            if (!cb.Enabled)
            {
                return false;
            }

            if (!suppressLogging)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is configurable");
            }

            return true;
        }
    }
}
