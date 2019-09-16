/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 6:52 
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

namespace ProTof_Testlibrary.TestModule
{
    /// <summary>
    /// Description of TM_CheckParameterForValue.
    /// </summary>
    [TestModule("52DD8BB6-547C-456D-8B8B-1F72FCDA8A7F", ModuleType.UserCode, 1)]
    public class TM_CheckParameterForValue : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_CheckParameterForValue()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _checkParameter = "";
        [TestVariable("8A9FA9D1-8110-4DBB-A05F-4726B36CCED4")]
        public string checkParameter
        {
        	get { return _checkParameter; }
        	set { _checkParameter = value; }
        }
        
        
        string _checkValue = "";
        [TestVariable("CE45EAA8-8A12-4C6F-82AA-2C6F1CF1B62A")]
        public string checkValue
        {
        	get { return _checkValue; }
        	set { _checkValue = value; }
        }
        
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
        	Testlibrary.TestModules.DeviceDTM.Parameterization.TM_CheckParameterForValue.Run(checkParameter, checkValue);
        }
    }
}
