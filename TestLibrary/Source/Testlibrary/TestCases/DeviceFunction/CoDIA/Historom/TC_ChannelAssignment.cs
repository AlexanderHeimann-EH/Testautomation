// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ChannelAssignment.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of TC_ChannelAssignment.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Historom
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Description of TC_ChannelAssignment.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_ChannelAssignment
// ReSharper restore InconsistentNaming
    {
        #region Public Methods and Operators

        /// <summary>
        /// Start execution
        /// </summary>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        public static bool Run()
        {
            bool isPassed = true;
            isPassed &= Flows.OpenModuleOnline.Run();

            // path to channel assignment parameter
            string path = "Expert//Diagnostics//Data logging//";

            // list with assignments available for the channels
            string[] comboboxList = Execution.GetComboBoxList.Run(path + "Assign channel 1 (41):");

            // in case path is not correct
            if (comboboxList == null)
            {
                isPassed = false;
            }
            else
            {
                // channels which will be checked
                int[] channels = { 1, 2, 3, 4 };

                // assignments which will be checked
                // set channels and store assignments in array
                var assignments = new[] { comboboxList[comboboxList.Length / 2], comboboxList[comboboxList.Length - 1], comboboxList[0], comboboxList[(comboboxList.Length / 2) + 1] };

                isPassed &= Execution.SetParameter.Run(path + "Assign channel 1 (41):", comboboxList[comboboxList.Length / 2]);
                isPassed &= Execution.SetParameter.Run(path + "Assign channel 2 (42):", comboboxList[comboboxList.Length - 1]);
                isPassed &= Execution.SetParameter.Run(path + "Assign channel 3 (43):", comboboxList[0]);
                isPassed &= Execution.SetParameter.Run(path + "Assign channel 4 (44):", comboboxList[(comboboxList.Length / 2) + 1]);
                isPassed &= DeviceFunctionLoader.CoDIA.Historom.Flows.OpenModuleOnline.Run();
                isPassed &= DeviceFunctionLoader.CoDIA.Historom.Flows.ReadWithWaiting.RunViaIcon();
                isPassed &= DeviceFunctionLoader.CoDIA.Historom.Flows.CheckChannelAssignment.Run(channels, assignments);
                isPassed &= DeviceFunctionLoader.CoDIA.Historom.Flows.CloseModule.Run();
                isPassed &= HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.CloseAdditionalModule.ViaWindow("Online Parameterize");
            }

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case failed.");
                Log.Screenshot();
            }

            return isPassed;
        }

        #endregion
    }
}