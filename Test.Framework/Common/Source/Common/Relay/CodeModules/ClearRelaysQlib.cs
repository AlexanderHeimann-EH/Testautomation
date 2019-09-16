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
  /// Description of relaysClear.
  /// </summary>
  [TestModule("83EE5FA4-5E28-44D8-94C3-2422498ED902", ModuleType.UserCode, 1)]
  public class ClearRelaysQlib : ITestModule
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ClearRelaysQlib"/> class. 
    /// Constructs a new instance.
    /// </summary>
    public ClearRelaysQlib()
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
    
    // If unsetBit is 99 all relays will be unset.
    uint unsetBit = 99;

        /// <summary>
        /// 
        /// </summary>
    [TestVariable("AB8FC2BB-51F7-4CDA-9D30-B04E81869D80")]
    public uint UnsetBit
    {
      get { return this.unsetBit; }
      set { this.unsetBit = value; }
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
      
      if (this.UnsetBit == 99)
      {
        RelaysAccessMethodsQlib.ClearAll(this.CardAddress);
        System.Threading.Thread.Sleep(15000);
      }
      else
      {
        RelaysAccessMethodsQlib.ClearChannel(this.CardAddress, this.UnsetBit);
        System.Threading.Thread.Sleep(15000);
      }
    }
  }
}
