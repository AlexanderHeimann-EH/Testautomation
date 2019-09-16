// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsCalculateButtonInactive.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class IsCalculateButtonInactive.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.MenuArea.Toolbar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.MenuArea.Toolbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    /// Class IsCalculateButtonInactive.
    /// </summary>
    public class IsCalculateButtonInactive : IIsCalculateButtonInactive
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether button 'Calculate' is inactive or not
        /// </summary>
        /// <returns><c>true</c> if inactive, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            bool result = true;

            Button calculate = new ToolbarElements().CalculateButton;

            if (calculate == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button 'Calculate' is null.");
            }
            else
            {
                if (calculate.Enabled)
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button 'Calculate' is active.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button 'Calculate' is inactive.");
                }
            }

            return result;
        }

        #endregion
    }
}