/*
 * Created by Ranorex
 * User: Janosch Spillmann
 * Date: 18/01/2012
 * Version: 1.0
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Relay.CodeModules
{
    using Ranorex;
    using Ranorex.Core.Testing;

    /// <summary>
    /// Description of relaysSet.
    /// </summary>
    [TestModule("9F58158A-5699-48DD-8D07-3B65FC0D5E34", ModuleType.UserCode, 1)]
    public class SetRelaysQlib : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SetRelaysQlib()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        uint cardAddress = 99;
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("8792518F-E3C7-4254-83C7-6A82084E0BFD")]
        public uint CardAddress
        {
            get { return this.cardAddress; }
            set { this.cardAddress = value; }
        }
        
        // If setBit is 99 all relays will be set.
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("AB8FC2BB-51F7-4CDA-9D30-B04E81869D80")]
        public uint SetBit { get; set; } = 99;

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
            
            if (this.SetBit == 99)
            {
                RelaysAccessMethodsQlib.SetAll(this.CardAddress);
            }
            else
            {
                RelaysAccessMethodsQlib.SetChannel(this.CardAddress, this.SetBit);
            }
        }
    }
}
