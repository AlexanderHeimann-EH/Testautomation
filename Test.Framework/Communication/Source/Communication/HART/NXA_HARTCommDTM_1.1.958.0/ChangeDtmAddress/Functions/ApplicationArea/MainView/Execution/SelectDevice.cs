//------------------------------------------------------------------------------
// <copyright file="SelectDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDtmAddress.Functions.ApplicationArea.MainView.Execution
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Provides methods for selecting a device 
    /// </summary>
    public class SelectDevice : ISelectDevice
    {
        /// <summary>
        /// Selects a device from the list according to its tag
        /// </summary>
        /// <param name="deviceTag">
        /// Tag of the device which will be selected
        /// </param>
        /// <returns>
        /// True: if the device is found and selected
        /// False: if an error occurred or the device is not found
        /// </returns>
        public bool Run(string deviceTag)
        {
            bool found = false;
            IList<TreeItem> deviceList =
                (new GUI.ApplicationArea.MainView.ChangeDTMAddressMainViewElements()).DeviceList();
            foreach (var treeItem in deviceList)
            {
                if (found)
                {
                    break;
                }

                IList<Cell> cells = treeItem.FindDescendants<Cell>();
                foreach (var cell in cells)
                {
                    Element element = cell;
                    string cellName = element.GetAttributeValueText("accessiblename");
                    if (cellName.Contains("Device Tag"))
                    {
                        if (cell.Text == deviceTag)
                        {
                            Mouse.Click(element);
                            found = true;
                            break;
                        }
                    }
                }
            }

            if (found)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device found and selected");
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No device with tag " + deviceTag + "found");
            return false;
        }
    }
}
