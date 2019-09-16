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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_DeviceScreen.Execution
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The SaveDataDTM recording.
    /// </summary>
    [TestModule("32376b8c-58a3-4cb8-bb9d-7822e5e45c7f", ModuleType.Recording, 1)]
    public partial class SaveDataDTM : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;

        static SaveDataDTM instance = new SaveDataDTM();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SaveDataDTM()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static SaveDataDTM Instance
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

            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdFunctionsSeparator'.", repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdFunctionsSeparatorInfo, new RecordItemIndex(0));
            Validate.Attribute(repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdFunctionsSeparatorInfo, "Visible", "True");
            Delay.Milliseconds(100);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ProgramFunctionBTN' at 104;26.", repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ProgramFunctionBTNInfo, new RecordItemIndex(1));
            repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ProgramFunctionBTN.Click("104;26");
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Down item 'DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ItemText1' at 75;12.", repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ItemText1Info, new RecordItemIndex(2));
            repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ItemText1.MoveTo("75;12");
            Mouse.ButtonDown(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Up item 'DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ItemText1' at 75;12.", repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ItemText1Info, new RecordItemIndex(3));
            repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.ItemText1.MoveTo("75;12");
            Mouse.ButtonUp(System.Windows.Forms.MouseButtons.Left);
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 500ms.", new RecordItemIndex(4));
            Delay.Duration(500, false);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
