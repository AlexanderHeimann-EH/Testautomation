// -----------------------------------------------------------------------
// <copyright file="ClickOnShowTable.cs" company="Endress+Hauser Process Solutions AG">
//  Endress + Hauser
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Functions.MenuArea.Toolbar.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    /// The click on show table.
    /// </summary>
    public class ClickOnShowTable : IClickOnShowTable
    {
        /// <summary>
        /// Mouse click on the button show table
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            bool result = true;

            Button button = (new ToolbarElements()).ShowTable;
            if (button == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Show table button is not accessible, please check the Ranorex path in the repository");
                result = false;
            }
            else
            {
                if (button.Enabled == false)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Show table button is not enabled, please check the preconditions");
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
    }
}
