// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignChannelsRandomly.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class AssignChannelsRandomly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Flows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    /// Class AssignChannelsRandomly.
    /// </summary>
    public class AssignChannelsRandomly : IAssignChannelsRandomly
    {
        #region Public Methods and Operators

        /// <summary>
        /// Sets all channels to a more or less random value
        /// </summary>
        /// <returns><c>true</c> if channels set, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            bool result;
            IList<ListItem> channelAssignments;
            if (new RunSelectTab().Run(3) == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to select Settings tab.");
            }
            else
            {
                channelAssignments = new Settings().GetComboBoxValues();
                if (channelAssignments == null || channelAssignments.Count == 0)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get the channel assignment entries from channel 1 combo box.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Setting channels to random values.");
                    result = new ConfigureSettingsTab().Run(channelAssignments[1].Text, channelAssignments[channelAssignments.Count / 2].Text, channelAssignments[channelAssignments.Count - 1].Text, channelAssignments[1].Text, string.Empty, string.Empty);
                }
            }

            return result;
        }

        #endregion
    }
}