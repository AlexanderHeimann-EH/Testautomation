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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.MenuArea.Menu_PAM.Execution
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The OpenFieldXpert recording.
    /// </summary>
    [TestModule("659a48e5-fe92-419a-ac55-4e3619b5ce15", ModuleType.Recording, 1)]
    public partial class OpenFieldXpert : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;

        static OpenFieldXpert instance = new OpenFieldXpert();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenFieldXpert()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static OpenFieldXpert Instance
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

            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'MenuArea.MainMenu.PAMMenuItems.ButtonFieldXpert' at Center.", repo.MenuArea.MainMenu.PAMMenuItems.ButtonFieldXpertInfo, new RecordItemIndex(0));
            repo.MenuArea.MainMenu.PAMMenuItems.ButtonFieldXpert.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='true') on item 'DeviceCare.ApplicationArea.Page_PAM.FieldXpert'.", repo.DeviceCare.ApplicationArea.Page_PAM.FieldXpert.SelfInfo, new RecordItemIndex(1));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_PAM.FieldXpert.SelfInfo, "Visible", "true");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
