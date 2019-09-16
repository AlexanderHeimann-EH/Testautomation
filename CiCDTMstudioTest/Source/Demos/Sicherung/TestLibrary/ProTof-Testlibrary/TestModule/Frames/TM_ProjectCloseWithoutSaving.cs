/*
 * Created by Ranorex
 * User: testadmin
 * Date: 26.03.2012
 * Time: 8:26 
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
    /// Description of TM_ProjectClose.
    /// </summary>
    [TestModule("DBE0D17C-12C1-40FF-B50A-CCD99C5189CF", ModuleType.UserCode, 1)]
    public class TM_ProjectCloseWithoutSaving : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_ProjectCloseWithoutSaving()
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
        	Testlibrary.TestModules.Frame.TM_ProjectClose.Run("", false);
        }
    }
}
