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

using Modules = DeviceFunction.CoDIA.Modules;

namespace ProTof_Testlibrary.TestModule.DeviceFunction.CreateDocumentation
{
    /// <summary>
    /// Description of TM_CloseCreateDocumentationViaWindow.
    /// </summary>
    public class TM_CloseCreateDocumentationViaWindow 
    {
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public static bool Run()
        {
//            (new Modules.CreateDocumentation.Flows.CloseModule()).Run();
			return DeviceFunctionLoader.CoDIA.CreateDocumentation.Flows.CloseModule.Run();
        }
    }
}
