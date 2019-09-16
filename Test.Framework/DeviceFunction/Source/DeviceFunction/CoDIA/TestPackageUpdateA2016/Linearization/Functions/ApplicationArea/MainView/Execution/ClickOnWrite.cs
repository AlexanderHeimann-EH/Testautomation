// -----------------------------------------------------------------------
// <copyright file="ClickOnWrite.cs" company="Endress+Hauser Process Solutions AG">
// Endress + Hauser
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// The click on write.
    /// </summary>
    public class ClickOnWrite : IClickOnWrite
    {
        /// <summary>
        /// Mouse click on the button Write
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            bool result = true;

            Button button = new MainViewElements().WriteButton;
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is not accessible");
                result = false;
            }
            else
            {
                if (button.Enabled == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is not enabled, please check the preconditions");
                    result = false;
                }
                else
                {
                    Mouse.MoveTo(button, 500);
                    button.Click(DefaultValues.locDefaultLocation);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button found and clicked");
                }
            }

            return result;
        }
    }
}
