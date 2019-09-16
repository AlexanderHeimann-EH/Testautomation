/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.04.2012
 * Time: 2:39 
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

namespace ProTof_Testlibrary.TestModule.Frames
{
    /// <summary>
    /// Description of TM_FDTDownload.
    /// </summary>
    [TestModule("6A83AA24-4E37-4503-941C-7947E0CDE40C", ModuleType.UserCode, 1)]
    public class TM_FDTDownload : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_FDTDownload()
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
        	Testlibrary.TestModules.Frame.TM_FDTDownload.Run();
        }
    }
}
