//------------------------------------------------------------------------------
// <copyright file="Change.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDtmAddress.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// The Change.
    /// </summary>
    public class Change : IChange
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            bool result = true;
            Element changeButton = new ChangeDtmAddress.GUI.ApplicationArea.MainView.ChangeDTMAddressMainViewElements().ChangeButton;
            if (changeButton == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Change button is null, check the Ranorex path in the repository");
                result = false;
            }
            else
            {
                if (changeButton.Enabled == false)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Change button is not enabled");
                    result = false;
                }
                else
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button found and enabled, clicking...");
                    Mouse.Click(changeButton);
                }
            }

            return result;
        }
    }
}
