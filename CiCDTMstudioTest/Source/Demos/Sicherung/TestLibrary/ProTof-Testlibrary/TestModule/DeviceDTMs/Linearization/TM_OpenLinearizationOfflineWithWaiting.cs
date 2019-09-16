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
//    /// Description of TM_OpenLinearizationOfflineWithWaiting.
//    /// </summary>
//    [TestModule("9D64ADFD-4D2A-4699-B764-56CE66198A7B", ModuleType.UserCode, 1)]
//    public class TM_OpenLinearizationOfflineWithWaiting : ITestModule
//    {
//        /// <summary>
//        /// Constructs a new instance.
//        /// </summary>
//        public TM_OpenLinearizationOfflineWithWaiting()
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
//            (new Modules.Linearization.Flows.OpenModuleOffline()).Run();
//        }
//    }
//}
