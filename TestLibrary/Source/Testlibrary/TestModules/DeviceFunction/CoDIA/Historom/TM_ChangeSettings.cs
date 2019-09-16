// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TM_ChangeSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 6/5/2013
 * Time: 10:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Testlibrary.TestModules.DeviceFunction.CoDIA.Historom
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Historom;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Historom.Functions.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// Description of TM_ChangeSettings.
    /// </summary>
    public class TM_ChangeSettings
    {
        /// <summary>
        /// Opens Historom module and changes the channel assignments in tab settings, will check if assignment is correct after performing a read and opening tab statistic results
        /// </summary>
        /// <returns>true for success</returns>
        public static bool Run()
        {
            bool isPassed = true;

            isPassed &= Flows.OpenModuleOnline.Run();
            isPassed &= Execution.RunSelectTab.Run(3);

            IList<ListItem> comboboxList = Execution.Settings.GetComboBoxValues();

            // in case path is not correct
            if (comboboxList == null)
            {
                isPassed = false;
            }
            else
            {
                // channels and assignments which will be checked
                int[] channels = { 1, 2, 3, 4 };
                string[] assignments = { comboboxList[comboboxList.Count / 2].Text, comboboxList[comboboxList.Count - 1].Text, comboboxList[0].Text, comboboxList[(comboboxList.Count / 2) + 1].Text };

                isPassed &= Execution.ChangeChannelAssignment.Run(channels[0], assignments[0]);
                isPassed &= Execution.ChangeChannelAssignment.Run(channels[1], assignments[1]);
                isPassed &= Execution.ChangeChannelAssignment.Run(channels[2], assignments[2]);
                isPassed &= Execution.ChangeChannelAssignment.Run(channels[3], assignments[3]);
                isPassed &= Flows.CheckStatusInfo.Run();
                isPassed &= Flows.ReadWithWaiting.RunViaIcon();
                isPassed &= Flows.CheckStatusInfo.Run();
                isPassed &= Flows.CheckChannelAssignment.Run(channels, assignments);
                isPassed &= Flows.CloseModule.Run();
            }

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case failed.");
            }

            return isPassed;
        }
    }
}