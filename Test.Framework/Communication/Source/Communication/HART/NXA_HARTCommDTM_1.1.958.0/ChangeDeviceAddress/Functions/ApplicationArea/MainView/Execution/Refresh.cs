//------------------------------------------------------------------------------
// <copyright file="Refresh.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDeviceAddress.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDeviceAddress.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// The refresh.
    /// </summary>
    public class Refresh : IRefresh
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
            Element refreshButton = new GUI.ApplicationArea.MainView.ChangeDeviceAddressMainViewElements().RefreshButton;
            if (refreshButton == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Change button is null, check the Ranorex path in the repository");
                result = false;
            }
            else
            {
                if (refreshButton.Enabled == false)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Change button is not enabled");
                    result = false;
                }
                else
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button found and enabled, clicking...");
                    Mouse.Click(refreshButton);
                }
            }

            return result;
        }
    }
}
