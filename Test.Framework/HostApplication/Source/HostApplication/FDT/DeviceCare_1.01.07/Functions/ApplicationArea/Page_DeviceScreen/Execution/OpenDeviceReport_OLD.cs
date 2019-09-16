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

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_DeviceScreen.Execution
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The OpenDeviceReport_OLD recording.
    /// </summary>
    [TestModule("33f77926-60b9-4acb-843f-dc52fbf279b4", ModuleType.Recording, 1)]
    public partial class OpenDeviceReport_OLD : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.HARTCommDTM repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.HARTCommDTM repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.HARTCommDTM.Instance;

        static OpenDeviceReport_OLD instance = new OpenDeviceReport_OLD();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenDeviceReport_OLD()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenDeviceReport_OLD Instance
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left DoubleClick item 'DeviceCare.SimulationHART.btn_DeviceReport' at Center.", repo.DeviceCare.SimulationHART.btn_DeviceReportInfo, new RecordItemIndex(0));
            repo.DeviceCare.SimulationHART.btn_DeviceReport.DoubleClick();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating NotExists on item 'DeviceCare.SimulationHART.Text_EventLog'.", repo.DeviceCare.SimulationHART.Text_EventLogInfo, new RecordItemIndex(1));
            Validate.NotExists(repo.DeviceCare.SimulationHART.Text_EventLogInfo);
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
