// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsCalculationButtonEnabled.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of  IsCalculationButtonEnabled.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.MenuArea.Toolbar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Description of  IsCalculationButtonEnabled.
    /// </summary>
    public class IsCalculationButtonEnabled : IIsCalculationButtonEnabled
    {
        #region Public Methods and Operators

        /// <summary>
        /// Returns whether the calculate button is enabled
        /// </summary>
        /// <returns><c>true</c> if enabled, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            Button buttonCalculate = new ToolbarElements().ButtonCalculate;

            if (buttonCalculate == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation button is null.");
                return false;
            }
            else
            {
                return buttonCalculate.Enabled;
            }
        }

        #endregion
    }
}