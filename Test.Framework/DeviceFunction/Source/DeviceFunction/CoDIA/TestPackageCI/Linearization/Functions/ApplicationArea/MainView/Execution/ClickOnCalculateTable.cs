// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickOnCalculateTable.cs" company="Endress+Hauser Process Solutions AG">
//   E+H PCPS AG
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    /// Provides functionality for clicking the calculate button in the tank tab
    /// </summary>
    public class ClickOnCalculateTable : IClickOnCalculateTable
    {
        /// <summary>
        /// Clicks the calculate button.
        /// </summary>
        /// <returns>
        /// True: if button is found and clicked; False: otherwise
        /// </returns>
        public bool Run()
        {
            bool result = true;
            Button button = new GUI.ApplicationArea.MainView.TankTabElements().CalculateTableButton;
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculate table button is not accessible");
                result = false;
            }
            else
            {
                if (button.Enabled == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculate table button is not enabled");
                    result = false;
                }
                else
                {
                    Mouse.MoveTo(button, 500);
                    button.Click(DefaultValues.locDefaultLocation);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculate table button found and clicked");
                }
            }

            return result;
        }
    }
}
