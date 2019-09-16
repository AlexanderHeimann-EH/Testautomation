/*
 * Created by Ranorex
 * User: testadmin
 * Date: 2/5/2014
 * Time: 9:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_DeviceScreen.Execution
{
    /// <summary>
    /// Description of OpenDTMfunctions_DiagnosisCM.
    /// </summary>
    [TestModule("FF5B624E-76FE-4720-8462-376E4C39ACD8", ModuleType.UserCode, 1)]
    public class OpenDTMfunctions_Diagnosis : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenDTMfunctions_Diagnosis()
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
            
            var repo = GUI.HARTCommDTM.Instance;
            
            try 
            {
               	repo.DeviceCare.SimulationHART.btn_DTMfunctions.Click();
               	repo.DeviceCare.SimulationHART.btn_Diagnosis.Click();
            } 
            catch (ElementNotFoundException e) 
            {
               Report.Warn("Schaut hier mal nach: ", e.Message);
               repo.DeviceCare.SimulationHART.btn_DTMfunctions.Click();
               repo.DeviceCare.SimulationHART.btn_Diagnosis.Click();
            }
            
				
            

               
            
        }
    }
}
