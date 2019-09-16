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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Assistant_EH_ProtocolSelection.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckEHInterfaceSelectionPage recording.
    /// </summary>
    [TestModule("bc30b567-4fe6-44a3-afa3-6cf667b2a147", ModuleType.Recording, 1)]
    public partial class CheckEHInterfaceSelectionPage : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;

        static CheckEHInterfaceSelectionPage instance = new CheckEHInterfaceSelectionPage();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckEHInterfaceSelectionPage()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckEHInterfaceSelectionPage Instance
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

            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonIPC'.", repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonIPCInfo, new RecordItemIndex(0));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonIPCInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonIPC'.", repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonIPCInfo, new RecordItemIndex(1));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonIPCInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonPCP'.", repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonPCPInfo, new RecordItemIndex(2));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonPCPInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonPCP'.", repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonPCPInfo, new RecordItemIndex(3));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonPCPInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonISS'.", repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonISSInfo, new RecordItemIndex(4));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonISSInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonISS'.", repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonISSInfo, new RecordItemIndex(5));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonISSInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonCDI'.", repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonCDIInfo, new RecordItemIndex(6));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.ButtonCDIInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonCDI'.", repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonCDIInfo, new RecordItemIndex(7));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.EHInterfaceSelectionPage.EHInterfaceSelectionList.Text_ButtonCDIInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}