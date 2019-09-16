/*
 * Created by Ranorex
 * User: testadmin
 * Date: 22/05/2014
 * Time: 11:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_Assistant_ConfigureCommDTM.Execution
{
    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of ConfigureSearch.
    /// </summary>
    [TestModule("A1C68DB3-B4E8-463E-81DC-1AFD091BA455", ModuleType.UserCode, 1)]
    public class ConfigureCommDTM_OLD : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConfigureCommDTM_OLD()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _MaxVal = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("9310BB3C-E662-423F-AAEC-E1D70D8B31DF")]
        public string MaxVal
        {
            get { return _MaxVal; }
            set { _MaxVal = value; }
        }
        
        string _MinVal = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("1644AE06-89BA-4477-A8A7-EFF02451746B")]
        public string MinVal
        {
            get { return _MinVal; }
            set { _MinVal = value; }
        }
        
        string _Modem = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("86B9114D-34C0-414B-8F69-7E9C51E8DE9C")]
        public string Modem
        {
            get { return _Modem; }
            set { _Modem = value; }
        }
        
        string _Protocol = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("D3FF87D0-2903-42BC-9EE4-BCFF7F4060D3")]
        public string Protocol
        {
            get { return _Protocol; }
            set { _Protocol = value; }
        }
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            if (Protocol == "FF")
            {
                ConfigureFoundationDTM.Start();
            }
            if (Protocol == "Hart" )
            {
                ConfigureHart.Start(MaxVal,MinVal);
            }
            if (Protocol == "CDI" & Modem == "CDIUSB" )
            {
                ConfigureCDI_USB.Start();
            }
            if (this.Protocol == "Profibus" )
            {
                ConfigureProfibus.Instance.MinVal = this.MinVal;
                ConfigureProfibus.Instance.MaxVal = this.MaxVal;
                ConfigureProfibus.Start();
            }
            
            PressScanButton.Start();
        }
    }
}

