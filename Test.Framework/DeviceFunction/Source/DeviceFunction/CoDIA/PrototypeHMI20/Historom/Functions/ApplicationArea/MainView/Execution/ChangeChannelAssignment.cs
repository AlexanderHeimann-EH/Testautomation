//------------------------------------------------------------------------------
// <copyright file="ChangeChannelAssignment.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Historom.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    ///     Provides function to change the channel assignment within module HISTOROM
    /// </summary>
    public class ChangeChannelAssignment : IChangeChannelAssignment
    {
        /// <summary>
        ///     Changes the channel assignment for a selected channel
        /// </summary>
        /// <param name="channelNumber">Channel for which channel assignment should be changed</param>
        /// <param name="inputValue">New channel assignment</param>
        /// <returns>true, if call worked; false if an error occurred</returns>
        public bool Run(int channelNumber, string inputValue)
        {
            Element comboBox;
            Element statusIcon;

            switch (channelNumber)
            {
                case 1:
                    comboBox = new SettingsElements().ComboBoxAssignmentChannel1;
                    statusIcon = new SettingsElements().StatusIconChannel1;
                    if (new Settings().SetComboBoxValue(comboBox, inputValue, statusIcon))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), inputValue + " assigned to Channel 1");
                        return true;
                    }

                    return false;
                case 2:
                    comboBox = new SettingsElements().ComboBoxAssignmentChannel2;
                    statusIcon = new SettingsElements().StatusIconChannel2;
                    if (new Settings().SetComboBoxValue(comboBox, inputValue, statusIcon))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), inputValue + " assigned to Channel 2");
                        return true;
                    }

                    return false;
                case 3:
                    comboBox = new SettingsElements().ComboBoxAssignmentChannel3;
                    statusIcon = new SettingsElements().StatusIconChannel3;
                    if (new Settings().SetComboBoxValue(comboBox, inputValue, statusIcon))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), inputValue + " assigned to Channel 3");
                        return true;
                    }

                    return false;
                case 4:
                    comboBox = new SettingsElements().ComboBoxAssignmentChannel4;
                    statusIcon = new SettingsElements().StatusIconChannel4;
                    if (new Settings().SetComboBoxValue(comboBox, inputValue, statusIcon))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), inputValue + " assigned to Channel 4");
                        return true;
                    }

                    return false;
                default:
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Wrong channel number");
                    return false;
            }
        }
    }
}