// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickOnWrite.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The click on write.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// The click on write.
    /// </summary>
    public class ClickOnWrite : IClickOnWrite
    {
        #region Public Methods and Operators

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

        #endregion
    }
}