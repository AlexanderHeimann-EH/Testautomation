﻿/*
 * Created by Ranorex
 * User: testadmin
 * Date: 19.11.2012
 * Time: 6:31 
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Parameterisation
{
    /// <summary>
    /// Description of TM_CloseParameterizationOnline.
    /// </summary>
    public class TM_CloseParameterizationOnline 
    {
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        public static bool Run()
        {
            return (new Modules.Parameterization.Flows.CloseModuleOnline()).Run();
        }
    }
}