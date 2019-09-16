///*
// * Created by Ranorex
// * User: Testadmin
// * Date: 19.11.2012
// * Time: 09:19
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
//namespace ProTof_Testlibrary.TestModule.DeviceFunction
//{
//    /// <summary>
//    /// Description of TM_RandomOpenCloseSimple.
//    /// </summary>
//    [TestModule("B418EBBE-C06D-467C-8F4B-02A06BB1BB9C", ModuleType.UserCode, 1)]
//    public class TM_RandomOpenCloseSimple : ITestModule
//    {
//        /// <summary>
//        /// Constructs a new instance.
//        /// </summary>
//        public TM_RandomOpenCloseSimple()
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
//        	for(int counter = 1; counter <= 100; counter++)
//        	{
//        		Random randomizer = new Random();
//        		int number = randomizer.Next(1, 8);
//        		bool result = true;
//        		
//        		Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Loop " + counter.ToString());
//        		switch (number)
//        		{
//        			case 1:
//        			{
//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Compare");
//        				result = result && (new Modules.Compare.Flows.OpenModuleOnline()).Run(10000);
//        				result = result && (new Modules.Compare.Flows.CloseModule()).Run(10000);
//        				break;
//    				}
//    				case 2:
//       				{
//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Concentration");
//    					result = result && (new Modules.Concentration.Flows.OpenModuleOnline()).Run(10000);
//        				result = result && (new Modules.Concentration.Flows.CloseModule()).Run(10000);
//        				break;
//    				}
//        			case 3:
//        			{
//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Create Documentation");
//    					result = result && (new Modules.CreateDocumentation.Flows.OpenModuleOnline()).Run(10000);
//        				result = result && (new Modules.CreateDocumentation.Flows.CloseModule()).Run(10000);
//        				break;
//    				}
//        			case 4:
//        			{
//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Envelope Curve");
//    					result = result && (new Modules.EnvelopeCurve.Flows.OpenModuleOnline()).Run(10000);
//        				result = result && (new Modules.EnvelopeCurve.Flows.CloseModule()).Run(10000);
//        				break;
//    				}
//        			case 5:
//        			{
//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Event List");
//    					result = result && (new Modules.EventList.Flows.OpenModuleOnline()).Run(10000);
//        				result = result && (new Modules.EventList.Flows.CloseModule()).Run(10000);
//        				break;
//    				}
//        			case 6:
//        			{
//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Linearization");
//    					result = result && (new Modules.Linearization.Flows.OpenModuleOnline()).Run(10000);
//        				result = result && (new Modules.Linearization.Flows.CloseModuleOnline()).Run(10000);
//        				break;
//    				}
//        			case 7:
//        			{
//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Parameterization");
//    					result = result && (new Modules.Parameterization.Flows.OpenModuleOnline()).Run(10000);
//        				result = result && (new Modules.Parameterization.Flows.CloseModuleOnline()).Run(10000);
//        				break;
//    				}
//        			case 8:
//        			{
//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Save Restore");
//    					result = result && (new Modules.SaveRestore.Flows.OpenModuleOnline()).Run(10000);
//        				result = result && (new Modules.SaveRestore.Flows.CloseModule()).Run(10000);
//        				break;
//    				}
//        		}
//    				
//				if(result)
//				{
//					Report.Success("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "Module successfully opened and closed.");
//				}
//				else
//				{
//					Report.Failure("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseSimple", "An error occured while open / close module.");
//				}
//        	}
//        }
//    }
//}
