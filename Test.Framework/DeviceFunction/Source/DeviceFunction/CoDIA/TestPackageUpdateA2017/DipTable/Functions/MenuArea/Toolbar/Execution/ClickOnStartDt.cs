// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickOnStartDt.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The click on StartDT.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.DipTable.Functions.MenuArea.Toolbar.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.DipTable.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    /// The click on StartDT.
    /// </summary>
    public class ClickOnStartDt : IClickOnStartDt
    {
        #region Public Methods and Operators

        /// <summary>
        /// Mouse click on the button StartDT.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            bool result = true;

            Button button = (new ToolbarElements()).StartDtButton;
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start dt button is not accessible, please check the Ranorex path in the repository");
                result = false;
            }
            else
            {
                if (button.Enabled == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start dt button is not enabled, please check the preconditions");
                    result = false;
                }
                else
                {
                    button.Focus();
                    Mouse.MoveTo(button, 500);
                    button.Click(DefaultValues.locDefaultLocation);
                }
            }

            return result;
        }

        #endregion
    }
}