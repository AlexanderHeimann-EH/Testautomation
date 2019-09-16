/*
 * Created by Ranorex
 * User: testadmin
 * Date: 19.11.2012
 * Time: 7:04 
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

using Modules = DeviceFunction.CoDIA.Modules;

namespace ProTof_Testlibrary.TestModule.DeviceFunction.CreateDocumentation
{
    /// <summary>
    /// Description of TM_CloseCreateDocumentationViaWindow.
    /// </summary>
    [TestModule("1C3FB761-3D71-42AF-991E-AD57095C6087", ModuleType.UserCode, 1)]
    public class TM_CloseCreateDocumentationViaWindow : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_CloseCreateDocumentationViaWindow()
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
//            (new Modules.CreateDocumentation.Flows.CloseModule()).Run();
			DeviceFunctionLoader.CoDIA.CreateDocumentation.Flows.CloseModule.Run();
        }
    }
}
