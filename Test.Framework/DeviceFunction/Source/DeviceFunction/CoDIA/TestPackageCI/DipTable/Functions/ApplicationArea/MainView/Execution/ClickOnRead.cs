// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickOnRead.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The click on read.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.DipTable.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.DipTable.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// The click on read.
    /// </summary>
    public class ClickOnRead : IClickOnRead
    {
        #region Public Methods and Operators

        /// <summary>
        /// Mouse click on the button Read
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            bool result = true;

            Button button = new MainViewElements().ReadButton;
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is not accessible");
                result = false;
            }
            else
            {
                if (button.Enabled == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is not enabled, please check the preconditions");
                    result = false;
                }
                else
                {
                    Mouse.MoveTo(button, 500);
                    button.Click(DefaultValues.locDefaultLocation);
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button found and clicked");
                }
            }

            return result;
        }

        #endregion
    }
}