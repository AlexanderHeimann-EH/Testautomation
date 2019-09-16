﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Ranorex.Core.Repository;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Assistant_ModemSelection.Execution
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SelectHARTModem_Simulation recording.
    /// </summary>
    [TestModule("756d732c-7d82-4ed9-8d76-b85eb89cdbe4", ModuleType.Recording, 1)]
    public partial class SelectHARTModem_Simulation : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;

        static SelectHARTModem_Simulation instance = new SelectHARTModem_Simulation();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectHARTModem_Simulation()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SelectHARTModem_Simulation Instance
        {
            get { return instance; }
        }

#region Variables

#endregion

        /// <summary>
        /// Starts the replay of the static recording <see cref="Instance"/>.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
        public static void Start()
        {
            TestModuleRunner.Run(Instance);
        }

        /// <summary>
        /// Performs the playback of actions in this recording.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.00;

            Init();

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.HART.ButtonSimulationDTM' at Center.", repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.HART.ButtonSimulationDTMInfo, new RecordItemIndex(0));
            repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.HART.ButtonSimulationDTM.Click();
            Delay.Milliseconds(200);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}