/*
 * Created by Ranorex
 * User: Tina Bertos
 * Date: 11/09/2015
 * Time: 16:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.StatusArea.Statusbar.Validation
{
    /// <summary>
    /// Description of CheckCommUnitConnected.
    /// </summary>
    [TestModule("800D2A10-0053-4A36-B53A-C0176C1331D4", ModuleType.UserCode, 1)]
    public class CheckCommUnitConnected : ITestModule
    {
       string _var_CommUnitName = "";

        /// <summary>
        /// 
        /// </summary>
       [TestVariable("78D8FF04-B5B7-45F5-A974-303A6F50C27D")]
       public string var_CommUnitName
       {
       	get { return _var_CommUnitName; }
       	set { _var_CommUnitName = value; }
       }
       
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckCommUnitConnected()
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
            
            //TODO: Databinding iteration(CDI || HART) -> protocol
            var repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;
            
            //Ask Anja how this DB will be handled when the automation Rack is ready
            
            //Initialize the Statusbar_Functions class
            Statusbar_Functions getCommunicationUnit = new Statusbar_Functions();
            
            //Set its parameter 'CommunicationUnit' -> will be passed into the IsUSBCommunicationUnitRecognized() method by its constructor
            //Passing any parameters into the method itself is not required therefore
            getCommunicationUnit.CommunicationUnit = var_CommUnitName;
            
            //Checks if HART FXA195 is connected
            if(!getCommunicationUnit.IsCommunicationUnitRecognized())
            {
               Report.Failure("No suitable communication unit has been found.");
            }
            else
            {
               Report.Success("Device is connected.");
            }
            repo.StatusArea.UsbCommunicationUnitList.Click();
        }
    }
}
