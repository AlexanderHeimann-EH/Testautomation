﻿/*
 * Created by Ranorex
 * User: testadmin
 * Date: 19.11.2012
 * Time: 6:41 
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

namespace ProTof_Testlibrary.TestModule.DeviceFunction.Compare
{
    /// <summary>
    /// Description of TM_OpenCompareViaMenu.
    /// </summary>
    [TestModule("4EF22D94-9EA9-49F1-8BAC-F57581326293", ModuleType.UserCode, 1)]
    public class TM_OpenCompareViaMenu : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TM_OpenCompareViaMenu()
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
            (new Modules.Compare.Flows.OpenModuleOnline()).Run();
        }
    }
}