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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_PAM.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckPAM_PAMSuite recording.
    /// </summary>
    [TestModule("c2697e95-83e1-401f-8a49-703d14cca564", ModuleType.Recording, 1)]
    public partial class CheckPAM_PAMSuite : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;

        static CheckPAM_PAMSuite instance = new CheckPAM_PAMSuite();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckPAM_PAMSuite()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckPAM_PAMSuite Instance
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
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_PAM.PAMSuite'.", repo.DeviceCare.ApplicationArea.Page_PAM.PAMSuite.SelfInfo, new RecordItemIndex(0));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_PAM.PAMSuite.SelfInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(0)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_PAM.PAMSuite.Text_Titel_PAMSuite'.", repo.DeviceCare.ApplicationArea.Page_PAM.PAMSuite.Text_Titel_PAMSuiteInfo, new RecordItemIndex(1));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_PAM.PAMSuite.Text_Titel_PAMSuiteInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(1)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_PAM.PAMSuite.Text_SubTitle_PAMSuite'.", repo.DeviceCare.ApplicationArea.Page_PAM.PAMSuite.Text_SubTitle_PAMSuiteInfo, new RecordItemIndex(2));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_PAM.PAMSuite.Text_SubTitle_PAMSuiteInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(2)); }
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
