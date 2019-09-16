/*
 * Created by Ranorex
 * User: i02401156
 * Date: 16.01.2015
 * Time: 14:44
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

namespace ksydjfklsadlfoe
{
    /// <summary>
    /// Description of UserCodeModule1.
    /// </summary>
    [TestModule("CD4D5232-F518-4A30-B756-4EA3FE7C1395", ModuleType.UserCode, 1)]
    public class UserCodeModule1 : ITestModule
    {
    	string _NewVariable1 = "";
    	[TestVariable("B7CFEB15-47AC-4BCE-B3EC-1991B2952D70")]
    	public string NewVariable1
    	{
    		get { return _NewVariable1; }
    		set { _NewVariable1 = value; }
    	}
    	
    	public string test { get; set;}
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public UserCodeModule1()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _NewVariable = "";
        [TestVariable("A6D475E7-D2DA-4181-8BBC-B3D000333319")]
        public string NewVariable
        {
        	get { return _NewVariable; }
        	set { _NewVariable = value; }
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
        }
    }
}
