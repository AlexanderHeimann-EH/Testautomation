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

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Help.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckDTM recording.
    /// </summary>
    [TestModule("9d8d2ca2-8ccb-43d5-bbbc-7a44d614afae", ModuleType.Recording, 1)]
    public partial class CheckDTM : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication.Instance;

        static CheckDTM instance = new CheckDTM();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckDTM()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckDTM Instance
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
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.SelfInfo, new RecordItemIndex(0));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.SelfInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(0)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMStandard'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMStandardInfo, new RecordItemIndex(1));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMStandardInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(1)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Enabled='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMStandard'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMStandardInfo, new RecordItemIndex(2));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMStandardInfo, "Enabled", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(2)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_DTMStandard'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_DTMStandardInfo, new RecordItemIndex(3));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_DTMStandardInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(3)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_DTMStandard'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_DTMStandardInfo, new RecordItemIndex(4));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_DTMStandardInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(4)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMAdditional'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMAdditionalInfo, new RecordItemIndex(5));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMAdditionalInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(5)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Enabled='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMAdditional'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMAdditionalInfo, new RecordItemIndex(6));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_DTMAdditionalInfo, "Enabled", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(6)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_DTMAdditional'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_DTMAdditionalInfo, new RecordItemIndex(7));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_DTMAdditionalInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(7)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_DTMAdditional'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_DTMAdditionalInfo, new RecordItemIndex(8));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_DTMAdditionalInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(8)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Button_CommDTM'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_CommDTMInfo, new RecordItemIndex(9));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_CommDTMInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(9)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Enabled='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Button_CommDTM'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_CommDTMInfo, new RecordItemIndex(10));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Button_CommDTMInfo, "Enabled", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(10)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_CommDTM'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_CommDTMInfo, new RecordItemIndex(11));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_Title_CommDTMInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(11)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_CommDTM'.", repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_CommDTMInfo, new RecordItemIndex(12));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.DTM.Text_SubTitle_CommDTMInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(12)); }
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
