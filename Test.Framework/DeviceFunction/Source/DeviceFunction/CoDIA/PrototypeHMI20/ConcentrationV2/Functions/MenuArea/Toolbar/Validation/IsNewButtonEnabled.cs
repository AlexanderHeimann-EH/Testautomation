// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsNewButtonEnabled.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of  IsCalculationButtonEnabled.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.MenuArea.Toolbar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Description of  IsNewButtonEnabled.
    /// </summary>
    public class IsNewButtonEnabled : IIsNewButtonEnabled
    {
        #region Public Methods and Operators

        /// <summary>
        /// Returns whether the new button is enabled
        /// </summary>
        /// <returns><c>true</c> if enabled, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            Button newButton = new ToolbarElements().ButtonNew;

            if (newButton == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation button is null.");
                return false;
            }
            else
            {
                return newButton.Enabled;
            }
        }

        #endregion
    }
}