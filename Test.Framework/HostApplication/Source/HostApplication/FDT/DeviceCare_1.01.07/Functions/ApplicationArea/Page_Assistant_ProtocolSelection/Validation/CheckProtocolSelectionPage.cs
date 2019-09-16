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

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Assistant_ProtocolSelection.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckProtocolSelectionPage recording.
    /// </summary>
    [TestModule("4d66b09b-bf44-4c2c-a503-1b6aefb1d8be", ModuleType.Recording, 1)]
    public partial class CheckProtocolSelectionPage : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication.Instance;

        static CheckProtocolSelectionPage instance = new CheckProtocolSelectionPage();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckProtocolSelectionPage()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckProtocolSelectionPage Instance
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

            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.Text_Title_Protocol'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.Text_Title_ProtocolInfo, new RecordItemIndex(0));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.Text_Title_ProtocolInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(0)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonHART'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonHARTInfo, new RecordItemIndex(1));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonHARTInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(3000);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(1)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonHART'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonHARTInfo, new RecordItemIndex(2));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonHARTInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(2)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonPROFIBUS'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonPROFIBUSInfo, new RecordItemIndex(3));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonPROFIBUSInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(3)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonPROFIBUS'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonPROFIBUSInfo, new RecordItemIndex(4));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonPROFIBUSInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(4)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonFOUNDATIONFieldbus'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonFOUNDATIONFieldbusInfo, new RecordItemIndex(5));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonFOUNDATIONFieldbusInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(5)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonFOUNDATIONFieldbus'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonFOUNDATIONFieldbusInfo, new RecordItemIndex(6));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonFOUNDATIONFieldbusInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(6)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonServiceInterface'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonServiceInterfaceInfo, new RecordItemIndex(7));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.ButtonServiceInterfaceInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(7)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonServiceInterface'.", repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonServiceInterfaceInfo, new RecordItemIndex(8));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.ProtocolSelectionPage.ProtocolSelectionList.Text_ButtonServiceInterfaceInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(8)); }
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
