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

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_PAM.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The CheckPAM_FieldXpert recording.
    /// </summary>
    [TestModule("673e9b04-d886-4c08-9542-ea430ea03a58", ModuleType.Recording, 1)]
    public partial class CheckPAM_FieldXpert : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication.Instance;

        static CheckPAM_FieldXpert instance = new CheckPAM_FieldXpert();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckPAM_FieldXpert()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CheckPAM_FieldXpert Instance
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
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_PAM.FieldXpert'.", repo.DeviceCare.ApplicationArea.Page_PAM.FieldXpert.SelfInfo, new RecordItemIndex(0));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_PAM.FieldXpert.SelfInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(0)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_PAM.FieldXpert.Text_Title_FieldXpert'.", repo.DeviceCare.ApplicationArea.Page_PAM.FieldXpert.Text_Title_FieldXpertInfo, new RecordItemIndex(1));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_PAM.FieldXpert.Text_Title_FieldXpertInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(1)); }
            
            try {
                Report.Log(ReportLevel.Info, "Validation", "(Optional Action)\r\nValidating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_PAM.FieldXpert.Text_SubTitle_FieldXpert'.", repo.DeviceCare.ApplicationArea.Page_PAM.FieldXpert.Text_SubTitle_FieldXpertInfo, new RecordItemIndex(2));
                Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_PAM.FieldXpert.Text_SubTitle_FieldXpertInfo, "Visible", "True", Validate.DefaultMessage, false);
                Delay.Milliseconds(0);
            } catch(Exception ex) { Report.Log(ReportLevel.Warn, "Module", "(Optional Action) " + ex.Message, new RecordItemIndex(2)); }
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}