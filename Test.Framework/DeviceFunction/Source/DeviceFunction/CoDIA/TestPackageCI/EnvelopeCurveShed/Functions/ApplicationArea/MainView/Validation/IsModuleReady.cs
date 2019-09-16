﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsModuleReady.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Provides Validation methods which Validation whether the module is ready or not
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides Validation methods which Validation whether the module is ready or not
    /// </summary>
    public class IsModuleReady : IIsModuleReady
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks if module (offline) is ready
        /// </summary>
        /// <param name="button">
        /// Button to check
        /// </param>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOfflineReady(Button button)
        {
            return button != null && button.Visible;
        }

        /// <summary>
        /// Checks if module (offline) is ready
        /// </summary>
        /// <param name="element">
        /// Element to check
        /// </param>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOfflineReady(Element element)
        {
            return element != null && element.Visible;
        }

        /// <summary>
        /// Checks if module (online) is ready
        /// </summary>
        /// <param name="button">
        /// Button to check
        /// </param>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Button button)
        {
            return button != null && button.Enabled;
        }

        /// <summary>
        /// Checks if module (online) is ready
        /// </summary>
        /// <param name="element">
        /// Element to check
        /// </param>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Element element)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Entered");
            return element != null && element.Enabled;
        }

        // 2013-06-28 EC - Added in addition to function above

        /// <summary>
        /// Checks if module (online) is ready
        /// </summary>
        /// <param name="adapter">
        /// Element to check
        /// </param>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool IsModuleOnlineReady(Adapter adapter)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Entered");
            return adapter != null && adapter.Enabled;
        }

        #endregion
    }
}