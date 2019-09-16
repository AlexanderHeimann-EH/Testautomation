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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_DeviceScreen.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckDTMfunctions_Diagnosis recording.
    /// </summary>
    [TestModule("5d466dd6-7ea7-4d8f-8343-7d025e3a0aa8", ModuleType.Recording, 1)]
    public partial class CheckDTMfunctions_Diagnosis : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.HARTCommDTM repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.HARTCommDTM repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.HARTCommDTM.Instance;

        static CheckDTMfunctions_Diagnosis instance = new CheckDTMfunctions_Diagnosis();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckDTMfunctions_Diagnosis()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckDTMfunctions_Diagnosis Instance
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

            Report.Log(ReportLevel.Info, "Delay", "Waiting for 10s.", new RecordItemIndex(0));
            Delay.Duration(10000, false);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.CommDTM.TabItem_Diagnosis'.", repo.DeviceCare.CommDTM.TabItem_DiagnosisInfo, new RecordItemIndex(1));
            Validate.Attribute(repo.DeviceCare.CommDTM.TabItem_DiagnosisInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.CommDTM.Container_HARTCommDTM'.", repo.DeviceCare.CommDTM.Container_HARTCommDTMInfo, new RecordItemIndex(2));
            Validate.Attribute(repo.DeviceCare.CommDTM.Container_HARTCommDTMInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Screenshot(ReportLevel.Info, "User", "", repo.DeviceCare.Self, false, new RecordItemIndex(3));
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
