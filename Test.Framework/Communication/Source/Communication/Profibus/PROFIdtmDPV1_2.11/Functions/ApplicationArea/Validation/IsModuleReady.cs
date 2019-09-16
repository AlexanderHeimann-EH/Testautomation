// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsModuleReady.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Checks if a module is ready
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.Functions.ApplicationArea.Validation
{
    using Ranorex;

    /// <summary>
    /// Checks if a module is ready
    /// </summary>
    public class IsModuleReady
    {
        /// <summary>
        /// Checks if button [OK] is available
        /// </summary>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool Run()
        {
            Button button = new GUI.ProfIdtmDpv1RepoElements().ButtonOk;

            if (button == null)
            {
                return false;
            }

            return true;
        }
    }
}
