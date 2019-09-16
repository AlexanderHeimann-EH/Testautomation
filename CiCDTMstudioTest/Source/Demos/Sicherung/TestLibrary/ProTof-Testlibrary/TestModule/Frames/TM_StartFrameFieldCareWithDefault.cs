/*
 * Created by Ranorex
 * User: testadmin
 * Date: 23.03.2012
 * Time: 2:04 
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

namespace ProTof_Testlibrary
{
    /// <summary>
    /// Description of TM_StartFrameFieldCareWithDefault.
    /// </summary>
    [TestModule("0C8EDE24-1D24-44E6-BC2D-B2CEBE0BC258", ModuleType.UserCode, 1)]
    public class TM_StartFrameFieldCareWithDefault : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_StartFrameFieldCareWithDefault()
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
        	Testlibrary.TestModules.Frame.TM_StartFrameFieldCareWithDefault.Run();
        }
    }
}
