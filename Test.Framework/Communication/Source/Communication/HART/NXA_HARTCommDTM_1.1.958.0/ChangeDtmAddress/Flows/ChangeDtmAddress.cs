//------------------------------------------------------------------------------
// <copyright file="ChangeDtmAddress.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDtmAddress.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Flows;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// The change device address.
    /// </summary>
    public class ChangeDtmAddress : IChangeDtmAddress
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="deviceTag">
        /// The device tag.
        /// </param>
        /// <param name="deviceAddress">
        /// The device address.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string deviceTag, string deviceAddress)
        {
            bool result = true;

            if (
                CommunicationLoader.HART.NXA820.ChangeDtmAddress.Functions.ApplicationArea.MainView.Execution
                                   .SelectDevice.Run(deviceTag) == false)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Selecting a device via tag failed, wrong tag used?");
                result = false;
            }
            else
            {
                Element comboBox =
                    new GUI.ApplicationArea.MainView.ChangeDTMAddressMainViewElements().ChangeDeviceAddressComboBox;
                if (comboBox == null)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Change Dtm Address ComboBox is null");
                    result = false;
                }
                else
                {
                    if (
                        CommunicationLoader.HART.NXA820.ChangeDtmAddress.Functions.ApplicationArea.MainView.Execution
                                           .SetParameter.SetParameterValue(comboBox, deviceAddress) == false)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Changing dtm address to " + deviceAddress + " failed");
                        result = false;
                    }
                    else
                    {
                        if (
                            CommunicationLoader.HART.NXA820.ChangeDtmAddress.Functions.ApplicationArea.MainView
                                               .Execution.Change.Run() == false)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking the change button failed");
                            result = false;
                        }
                    }
                }
            }

            return result;
        }
    }
}
