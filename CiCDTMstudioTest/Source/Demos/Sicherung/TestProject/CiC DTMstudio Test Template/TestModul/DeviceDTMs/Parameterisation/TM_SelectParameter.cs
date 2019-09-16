/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 6:46 
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
    /// Description of TM_SelectParameter.
    /// </summary>
    [TestModule("001E09BA-7695-4F66-893F-E82DFD15D84E", ModuleType.UserCode, 1)]
    public class TM_SelectParameter : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_SelectParameter()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _path = "";
        [TestVariable("D05FAD68-89B3-4B2C-B1E5-3A3BB9AF75A9")]
        public string path
        {
        	get { return _path; }
        	set { _path = value; }
        }
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
        	Testlibrary.TestModules.DeviceDTM.Parameterization.TM_SelectParameter.Run(path);
        }
    }
}
