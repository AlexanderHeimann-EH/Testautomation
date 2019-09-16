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
    ///The CreateDTMReport recording.
    /// </summary>
    [TestModule("ce9b7e71-4d8d-4d5d-83bf-1913d60ed3ed", ModuleType.Recording, 1)]
    public partial class CreateDTMReport : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;

        static CreateDTMReport instance = new CreateDTMReport();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CreateDTMReport()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static CreateDTMReport Instance
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

            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='true') on item 'DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdPrintFSeparator'.", repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdPrintFSeparatorInfo, new RecordItemIndex(0));
            Validate.Attribute(repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdPrintFSeparatorInfo, "Visible", "true");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 100ms.", new RecordItemIndex(1));
            Delay.Duration(100, false);
            
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdPrintFSeparator' at Center.", repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdPrintFSeparatorInfo, new RecordItemIndex(2));
            repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.AutomIdPrintFSeparator.Click();
            Delay.Milliseconds(200);
            
            Report.Log(ReportLevel.Info, "Delay", "Waiting for 30s.", new RecordItemIndex(3));
            Delay.Duration(30000, false);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}