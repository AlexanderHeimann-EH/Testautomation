///*
// * Created by Ranorex
// * User: testadmin
// * Date: 19.11.2012
// * Time: 6:35 
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Drawing;
//using System.Threading;
//using WinForms = System.Windows.Forms;
//
//using Ranorex;
//using Ranorex.Core;
//using Ranorex.Core.Testing;
//
//using Modules = DeviceFunction.CoDIA.Modules;
//
//namespace ProTof_Testlibrary.TestModule.DeviceFunction.Linearization
//{
//    /// <summary>
//    /// Description of TM_CloseLinearizationOffline.
//    /// </summary>
//    [TestModule("94D18E46-5FEE-444E-8E8D-6C020A7A4014", ModuleType.UserCode, 1)]
//    public class TM_CloseLinearizationOffline : ITestModule
//    {
//        /// <summary>
//        /// Constructs a new instance.
//        /// </summary>
//        public TM_CloseLinearizationOffline()
//        {
//            // Do not delete - a parameterless constructor is required!
//        }
//
//        /// <summary>
//        /// Performs the playback of actions in this module.
//        /// </summary>
//        /// <remarks>You should not call this method directly, instead pass the module
//        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
//        /// that will in turn invoke this method.</remarks>
//        void ITestModule.Run()
//        {
//            (new Modules.Linearization.Flows.CloseModuleOffline()).Run();
//        }
//    }
//}
