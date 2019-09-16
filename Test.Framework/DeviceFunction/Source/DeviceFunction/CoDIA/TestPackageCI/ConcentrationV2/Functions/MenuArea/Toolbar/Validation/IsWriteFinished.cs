// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsWriteFinished.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of IsWriteFinished.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.MenuArea.Toolbar.Validation
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Description of IsWriteFinished.
    /// </summary>
    public class IsWriteFinished : IIsWriteFinished
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Checks if writing coefficients to the device is finished
        /// </summary>
        /// <returns>
        ///     true: if write button is enabled and user notification message is shown
        ///     false: if either write button is not enabled or message is not shown
        /// </returns>
        public bool Run()
        {
            Button buttonWrite = new ToolbarElements().ButtonWrite;
            if (buttonWrite.Enabled)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}