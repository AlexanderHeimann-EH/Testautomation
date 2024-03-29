﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsModuleReady.cs" company="Process Solutions AG">
//  Endress + Hauser Process Solutions AG 
// </copyright>
// <summary>
//   Provides Validation methods which Validation whether the module is ready or not
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides Validation methods which Validation whether the module is ready or not
    /// </summary>
    public class IsModuleReady : IIsModuleReady
    {
        /// <summary>
        ///     Checks if module (online) is ready
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Button button)
        {
            return button != null && button.Enabled;
        }

        /// <summary>
        ///     Checks if module (offline) is ready
        /// </summary>
        /// <param name="button">Button to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOfflineReady(Button button)
        {
            return button != null && button.Visible;
        }

        /// <summary>
        ///     Checks if module (online) is ready
        /// </summary>
        /// <param name="element">Element to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Element element)
        {
            // EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Entered");
            return element != null && element.Enabled;
        }

        // 2013-06-28 EC - Added in addition to function above

        /// <summary>
        ///     Checks if module (online) is ready
        /// </summary>
        /// <param name="adapter">Element to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Adapter adapter)
        {
            // EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Entered");
            return adapter != null && adapter.Enabled;
        }

        /// <summary>
        ///     Checks if module (offline) is ready
        /// </summary>
        /// <param name="element">Element to check</param>
        /// <returns>
        ///     <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOfflineReady(Element element)
        {
            return element != null && element.Visible;
        }
    }
}