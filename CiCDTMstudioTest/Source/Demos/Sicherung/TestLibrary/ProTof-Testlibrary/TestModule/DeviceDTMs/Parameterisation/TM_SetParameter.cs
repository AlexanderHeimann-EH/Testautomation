/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 6:48 
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
    /// Description of SetParameter.
    /// </summary>
    [TestModule("EE7E24BF-0C30-4ADA-B8B7-BA64EF817727", ModuleType.UserCode, 1)]
    public class TM_SetParameter : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_SetParameter()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _setParameter = "";
        [TestVariable("2716F1FE-0D9C-4B00-83B4-6983A8C7A5B8")]
        public string setParameter
        {
        	get { return _setParameter; }
        	set { _setParameter = value; }
        }
        
        string _setValue = "";
        [TestVariable("DC105DC0-E1B3-451D-8752-E65DB11A391A")]
        public string setValue
        {
        	get { return _setValue; }
        	set { _setValue = value; }
        }
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
        	Testlibrary.TestModules.DeviceDTM.Parameterization.TM_SetParameter.Run(setParameter, setValue);
        }
    }
}
