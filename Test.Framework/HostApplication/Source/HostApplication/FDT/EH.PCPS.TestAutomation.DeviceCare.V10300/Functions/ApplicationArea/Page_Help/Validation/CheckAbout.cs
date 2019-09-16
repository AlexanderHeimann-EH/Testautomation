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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Help.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckAbout recording.
    /// </summary>
    [TestModule("48b1a535-5535-455a-ab1e-7c6082d101e9", ModuleType.Recording, 1)]
    public partial class CheckAbout : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;

        static CheckAbout instance = new CheckAbout();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckAbout()
        {
            VersionUnderTest = "yourValue";
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckAbout Instance
        {
            get { return instance; }
        }

#region Variables

        string _VersionUnderTest;

        /// <summary>
        /// Gets or sets the value of variable VersionUnderTest.
        /// </summary>
        [TestVariable("f3873395-76fa-4555-8aa2-b2644210ec32")]
        public string VersionUnderTest
        {
            get { return _VersionUnderTest; }
            set { _VersionUnderTest = value; }
        }

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
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About'.", repo.DeviceCare.ApplicationArea.Page_Help.About.SelfInfo, new RecordItemIndex(0));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.SelfInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(0)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Button_Imprint'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Button_ImprintInfo, new RecordItemIndex(1));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Button_ImprintInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(1)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Enabled='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Button_Imprint'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Button_ImprintInfo, new RecordItemIndex(2));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Button_ImprintInfo, "Enabled", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(2)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Text_Title_Imprint'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Text_Title_ImprintInfo, new RecordItemIndex(3));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Text_Title_ImprintInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(3)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_Imprint'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_ImprintInfo, new RecordItemIndex(4));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_ImprintInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(4)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Button_OpenSource'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Button_OpenSourceInfo, new RecordItemIndex(5));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Button_OpenSourceInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(5)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Enabled='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Button_OpenSource'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Button_OpenSourceInfo, new RecordItemIndex(6));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Button_OpenSourceInfo, "Enabled", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(6)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Text_Title_OpenSource'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Text_Title_OpenSourceInfo, new RecordItemIndex(7));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Text_Title_OpenSourceInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(7)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_OpenSource'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_OpenSourceInfo, new RecordItemIndex(8));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_OpenSourceInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(8)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Button_Version'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Button_VersionInfo, new RecordItemIndex(9));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Button_VersionInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(9)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Enabled='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Button_Version'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Button_VersionInfo, new RecordItemIndex(10));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Button_VersionInfo, "Enabled", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(10)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Text_Title_Version'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Text_Title_VersionInfo, new RecordItemIndex(11));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Text_Title_VersionInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(11)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_Version'.", repo.DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_VersionInfo, new RecordItemIndex(12));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Help.About.Text_SubTitle_VersionInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(12)); }
            
            // Checks the version number if it is correct!
            try {
                //Validate_Text_SubTitle_Version();
                //Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(13)); }
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}