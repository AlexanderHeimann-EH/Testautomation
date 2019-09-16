/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26/05/2014
 * Time: 12:42
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers
{
    /// <summary>
    /// Description of DefineTestCase.
    /// </summary>
    [TestModule("3B656C85-3434-4861-AE23-98CFF8307B12", ModuleType.UserCode, 1)]
    public class ConfigureTestDTMs : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ConfigureTestDTMs()
        {
            // Do not delete - a parameterless constructor is required!
        }

        int _MaxVal = 0;

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("EF2D45FA-5401-4C42-9C41-C2D21EC2DD84")]
        public int MaxVal
        {
           get { return _MaxVal; }
           set { _MaxVal = value; }
        }
        
        int _MinVal = 0;

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("D2BA3A93-67A5-4650-B83F-B700845B749C")]
        public int MinVal
        {
           get { return _MinVal; }
           set { _MinVal = value; }
        }
        
        string _Protocol_Connection = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("85C2D081-304F-4FE3-914F-1A8526D52081")]
        public string Protocol_Connection
        {
           get { return _Protocol_Connection; }
           set { _Protocol_Connection = value; }
        }
        
        string _DeviceName = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("EA3CBE78-9AE3-4163-9A09-3FC6A0C0C422")]
        public string DeviceName
        {
           get { return _DeviceName; }
           set { _DeviceName = value; }
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
            
            
              var DeviceTestCase = TestSuite.Current.GetTestCase ( "CheckDeviceDTM");
            
         
               DeviceTestCase.DataRange.MinRange = MinVal;
               DeviceTestCase.DataRange.MaxRange = MaxVal ;

				DeviceTestCase.DataContext.SetRange( DeviceTestCase.DataRange.MinRange, DeviceTestCase.DataRange.MaxRange);
				
			
        }
    }
}