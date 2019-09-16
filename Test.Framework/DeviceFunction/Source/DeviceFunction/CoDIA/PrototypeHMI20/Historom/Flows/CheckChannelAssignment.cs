//------------------------------------------------------------------------------
// <copyright file="CheckChannelAssignment.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Historom.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Description of CheckChannelAssignment.
    /// </summary>
    public class CheckChannelAssignment : ICheckChannelAssignment
    {
        /// <summary>
        ///     Opens tab statistic and checks actual channel assignment against user specs
        /// </summary>
        /// <param name="channelNumber">Channel numbers for the channels which should be checked</param>
        /// <param name="assignment">According assignment for every channel which should be checked</param>
        /// <returns>
        ///     true: If actual channel assignments match the user given ones
        ///     false: If an error occurred
        /// </returns>
        public bool Run(int[] channelNumber, string[] assignment)
        {
            if (new RunSelectTab().Run(2) == false)
            {
                // could not open statistic tab
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Statistic results");
                return false;
            }

            // Statistic tab is open, check specified channel(s) with according assignment
            bool result = true;
            int index = 0;
            foreach (int number in channelNumber)
            {
                // catch assignment array index out of bounds
                if (assignment.Length < (index + 1))
                {
                    result = false;
                    break;
                }

                result &= new StatisticResults().IsChannelAssignmentCorrect(channelNumber[index], assignment[index]);
                index++;
            }

            if (result == false)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Channel assignments do not match");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Channel assignments match");
            return true;
        }
    }
}