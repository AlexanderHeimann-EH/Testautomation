/*
 * Created by Ranorex
 * User: Tina Bertos
 * Date: 07/10/2015
 * Time: 16:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers.Generics
{
    /// <summary>
    /// Description of ExecuteAssistantConnect.
    /// </summary>
    [TestModule("95101EEE-3E1F-4D7D-8D6A-63AC9E491A4C", ModuleType.UserCode, 1)]
    public class ExecuteAssistantConnect : ITestModule
    {
       string _var_CommUnitName = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("4ADC5887-2FF3-4093-A3C8-099AC837EB5B")]
       public string var_CommUnitName
       {
       	get { return _var_CommUnitName; }
       	set { _var_CommUnitName = value; }
       }
       
       string _var_ProtocolName = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("0566A91C-88C9-4D99-93D1-551623BC8F41")]
       public string var_ProtocolName
       {
       	get { return _var_ProtocolName; }
       	set { _var_ProtocolName = value; }
       }
       
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ExecuteAssistantConnect()
        {
            // Do not delete - a parameterless constructor is required!
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
            
            AssistantConnect goOnline = new AssistantConnect();
            goOnline.ProtocolName = var_ProtocolName;
            goOnline.CommUnit = var_CommUnitName;
            
            goOnline.GoOnline();
        }
    }
}
