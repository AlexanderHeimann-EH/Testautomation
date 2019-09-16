/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 8:15 
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
    /// Description of TM_RestoreWithDownload.
    /// </summary>
    [TestModule("7B5A31D5-A15D-4FDC-83DA-76640AA94DB6", ModuleType.UserCode, 1)]
    public class TM_RestoreWithDownload : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_RestoreWithDownload()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        string _fileNameLoad = "";
        [TestVariable("0044F406-027C-4CC3-90FE-B54C3E74820A")]
        public string fileNameLoad
        {
        	get { return _fileNameLoad; }
        	set { _fileNameLoad = value; }
        }
        

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
        	Testlibrary.TestModules.DeviceDTM.SaveRestore.TM_RestoreWithDownload.Run(fileNameLoad);
        }
    }
}
