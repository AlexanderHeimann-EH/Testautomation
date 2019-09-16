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

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Assistant_ModemSelection.Execution
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SelectCDIModem_TCPIP recording.
    /// </summary>
    [TestModule("a6ed3f56-7489-45f2-a9a8-9ee902bd4a33", ModuleType.Recording, 1)]
    public partial class SelectCDIModem_TCPIP : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication.Instance;

        static SelectCDIModem_TCPIP instance = new SelectCDIModem_TCPIP();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SelectCDIModem_TCPIP()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SelectCDIModem_TCPIP Instance
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

            Report.Log(ReportLevel.Info, "Invoke Action", "Invoking Focus() on item 'DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIEthernet'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIEthernetInfo, new RecordItemIndex(0));
            repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIEthernet.Focus();
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIEthernet' at Center.", repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIEthernetInfo, new RecordItemIndex(1));
            repo.DeviceCare.ApplicationArea.Page_Assistant.ModemSelectionPages.ModemSelectionList.EHInterface.CDI.ButtonCDIEthernet.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='true') on item 'DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls'.", repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.SelfInfo, new RecordItemIndex(2));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.SelfInfo, "Visible", "true");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
