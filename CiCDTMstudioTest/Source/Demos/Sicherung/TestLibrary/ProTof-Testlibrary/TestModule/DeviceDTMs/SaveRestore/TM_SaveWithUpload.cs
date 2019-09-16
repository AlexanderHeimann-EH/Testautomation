/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 8:14 
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
    /// Description of TM_SaveWithUpload.
    /// </summary>
    [TestModule("217FAAE3-A92F-47F2-B948-2C0BB4969EDF", ModuleType.UserCode, 1)]
    public class TM_SaveWithUpload : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_SaveWithUpload()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        string _fileNameSave = "";
        [TestVariable("726497EE-1E53-4D84-98AA-39B2568E8677")]
        public string fileNameSave
        {
        	get { return _fileNameSave; }
        	set { _fileNameSave = value; }
        }
        
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
        	Testlibrary.TestModules.DeviceDTM.SaveRestore.TM_SaveWithUpload.Run(fileNameSave);
        }
    }
}
