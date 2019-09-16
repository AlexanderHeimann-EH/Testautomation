/*
 * Created by Ranorex
 * User: testadmin
 * Date: 18/06/2014
 * Time: 15:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Relay.CodeModules
{
    using System;

    using EH.PCPS.TestAutomation.Common.Relay;

    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of Deditec_Set_relays.
    /// </summary>
    
    [TestModule("F85724DF-DF05-4E69-B115-5F7596840503", ModuleType.UserCode, 1)]
    public class SetRelaysDeditec : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SetRelaysDeditec()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _relaysID = "99";
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("36DAD7BC-8702-4489-8DC0-61B81A87C46D")]
        public string relaysID
        {
            get { return this._relaysID; }
            set { this._relaysID = value; }
        }
        
        string _CardAddress = "0";
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("429839C5-9A1E-4692-BDC9-394B9759B444")]
        public string CardAddress
        {
            get { return this._CardAddress; }
            set { this._CardAddress = value; }
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

            bool result = false;
            
            uint relaysIDN = Convert.ToUInt32(this.relaysID);
            uint cardAddressN = Convert.ToUInt32(this.CardAddress);
            
            if (relaysIDN == 99)
            {
                
                RelayAccessMethodsDeditec.SetAll(cardAddressN,1, out result);
            }
            else
            {
                
                RelayAccessMethodsDeditec.SetSingle(cardAddressN, relaysIDN,1, out result);
            }            
        }
    }
}