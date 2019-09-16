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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Assistant_ConfigureCommDTM.Validation
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    ///The EH_CheckOwnConfig_ISS_CDI_CDIUSB recording.
    /// </summary>
    [TestModule("480f030e-4138-4d76-b53c-16d89f999b84", ModuleType.Recording, 1)]
    public partial class EH_CheckOwnConfig_ISS_CDI_CDIUSB : ITestModule
    {
        /// <summary>
        /// Holds an instance of the EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repository.
        /// </summary>
        public static EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;

        static EH_CheckOwnConfig_ISS_CDI_CDIUSB instance = new EH_CheckOwnConfig_ISS_CDI_CDIUSB();

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public EH_CheckOwnConfig_ISS_CDI_CDIUSB()
        {
        }

        /// <summary>
        /// Gets a static instance of this recording.
        /// </summary>
        public static EH_CheckOwnConfig_ISS_CDI_CDIUSB Instance
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

            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls'.", repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.SelfInfo, new RecordItemIndex(0));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.SelfInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Combobox_FoundUSBDevices'.", repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Combobox_FoundUSBDevicesInfo, new RecordItemIndex(1));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Combobox_FoundUSBDevicesInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Visible='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Button_USBRefresh_CDI_ISS'.", repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Button_USBRefresh_CDI_ISSInfo, new RecordItemIndex(2));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Button_USBRefresh_CDI_ISSInfo, "Visible", "True");
            Delay.Milliseconds(0);
            
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Enabled='True') on item 'DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Button_USBRefresh_CDI_ISS'.", repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Button_USBRefresh_CDI_ISSInfo, new RecordItemIndex(3));
            Validate.Attribute(repo.DeviceCare.ApplicationArea.Page_Assistant.CommDTMConfigurationPages.OwnConfigurationControls.ISS_CDI_CDIUSB_CommDTM.Button_USBRefresh_CDI_ISSInfo, "Enabled", "True");
            Delay.Milliseconds(0);
            
        }

#region Image Feature Data
#endregion
    }
#pragma warning restore 0436
}