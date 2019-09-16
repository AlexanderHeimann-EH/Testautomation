﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsModuleReady.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Checks if a module is ready
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMFXA291.V20700.Functions.ApplicationArea.Validation
{
    using EH.PCPS.TestAutomation.CDICommDTMFXA291.V20700.GUI;

    using Ranorex;

    /// <summary>
    /// Checks if a module is ready
    /// </summary>
    public class IsModuleReady
    {
        /// <summary>
        /// Checks if button [Refresh] is available
        /// </summary>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public static bool Run()
        {
            Button button = new CDICommDTMRepoElements().ButtonRefresh;

            if (button == null)
            {
                return false;
            }

            return true;
        }
    }
}
