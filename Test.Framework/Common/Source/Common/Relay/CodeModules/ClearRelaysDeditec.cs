/*
 * Created by Ranorex
 * User: testadmin
 * Date: 18/06/2014
 * Time: 15:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Relay.CodeModules
{
    using System;

    using Relay;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of Deditec_Get_relays.
    /// </summary>
    /// 
    [TestModule("05DDCD6D-A048-46B0-9F9A-A2785E41B663", ModuleType.UserCode, 1)]
    public class ClearRelaysDeditec : ITestModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClearRelaysDeditec"/> class. 
        /// Constructs a new instance.
        /// </summary>
        public ClearRelaysDeditec()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _relaysID = "99";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("268E2F12-ACBF-408C-88E4-28139AB30E50")]
        public string relaysID
        {
            get { return this._relaysID; }
            set { this._relaysID = value; }
        }
        
        string _CardAddresse = "0";
        
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("D8B56D4A-14BB-4CF9-94FA-DCC2A009DF2A")]
        public string CardAddresse
        {
            get { return this._CardAddresse; }
            set { this._CardAddresse = value; }
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
            
            uint CardAddressN, relaysIDN;
            bool result = false;
            
            CardAddressN= Convert.ToUInt32( this.CardAddresse);
            relaysIDN= Convert.ToUInt32( this.relaysID);

            if (relaysIDN == 99)
            {
                RelayAccessMethodsDeditec.SetAll(CardAddressN, 0, out result);
            }
            else
            {
                RelayAccessMethodsDeditec.SetSingle(CardAddressN, relaysIDN, 0, out result);
            }
        }
    }
}
