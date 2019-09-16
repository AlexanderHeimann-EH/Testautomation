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

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Assistant_ConfigureCommDTM.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The HART_CheckSimulationDTM recording.
    /// </summary>
    [TestModule("4d808069-ba10-486b-9683-87074bdb31d9", ModuleType.Recording, 1)]
    public partial class HART_CheckSimulationDTM : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10107.GUI.DeviceCareApplication.Instance;

        static HART_CheckSimulationDTM instance = new HART_CheckSimulationDTM();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public HART_CheckSimulationDTM()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static HART_CheckSimulationDTM Instance
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

            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.Button_Scan'.", repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.Button_ScanInfo, new RecordItemIndex(0));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.Button_ScanInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.MenuArea_CommDTM.ButtonConfiguration'.", repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.MenuArea_CommDTM.ButtonConfigurationInfo, new RecordItemIndex(1));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.MenuArea_CommDTM.ButtonConfigurationInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.MenuArea_CommDTM.ButtonAdvanced'.", repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.MenuArea_CommDTM.ButtonAdvancedInfo, new RecordItemIndex(2));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.MenuArea_CommDTM.ButtonAdvancedInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}
