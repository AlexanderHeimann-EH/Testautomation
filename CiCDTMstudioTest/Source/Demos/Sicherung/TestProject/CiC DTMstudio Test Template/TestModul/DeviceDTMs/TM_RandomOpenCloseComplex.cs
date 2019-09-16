///*
// * Created by Ranorex
// * User: Testadmin
// * Date: 19.11.2012
// * Time: 13:33
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
//    /// Description of TM_RandomOpenCloseComplex.
//    /// </summary>
//    [TestModule("021FE9E9-E411-436B-BC49-A1DC3B823416", ModuleType.UserCode, 1)]
//    public class TM_RandomOpenCloseComplex : ITestModule
//    {
//    	string _numberOfLoops = "500";
//    	[TestVariable("C248411A-EA04-4CDF-A0F5-A3CC1320BC89")]
//    	public string numberOfLoops
//    	{
//    		get { return _numberOfLoops; }
//    		set { _numberOfLoops = value; }
//    	}
//    	
//        /// <summary>
//        /// Constructs a new instance.
//        /// </summary>
//        public TM_RandomOpenCloseComplex()
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
//        	List<int> listOfOpenModules = new List<int>();
//        	
//        	int maxNumberOfLoops = Convert.ToInt32(numberOfLoops);
//        	
//        	for(int counter = 1; counter <= maxNumberOfLoops; counter++)
//        	{
//        		Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex"
//        		            , "Loop " + counter.ToString());
//        		
//        		// initialize variables
//        		Random randomizer = new Random();
//        		int randomLow 		= 1;	// 
//        		int randomHigh 		= 7;	// max number of modules
//        		int number 			= randomizer.Next(randomLow, randomHigh);
//        		bool resultOpen 	= true;
//        		bool resultClose	= true;
//        		
//        		#region open block
//        		
//        		if(!listOfOpenModules.Contains(number))
//        		{
//	        		#region switch case of module to open
//	        		
//	        		switch (number)
//	        		{
//	        			case 1:
//	        			{
//	        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Open Compare");
//	        				resultOpen = resultOpen && (new Modules.Compare.Flows.OpenModuleOnline()).Run(10000);
//	        				break;
//	    				}
//	//    				case 2:
//	//       				{
//	//        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.RandomOpenCloseComplex", "Open Concentration");
//	//    					result = result && (new Modules.Concentration.Flows.OpenModuleOnline()).Run(10000);
//	//        				break;
//	//    				}
//	        			case 3:
//	        			{
//	        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.RandomOpenCloseComplex", "Open Create Documentation");
//	    					resultOpen = resultOpen && (new Modules.CreateDocumentation.Flows.OpenModuleOnline()).Run(10000);
//	        				break;
//	    				}
//	        			case 4:
//	        			{
//	        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.RandomOpenCloseComplex", "Open Envelope Curve");
//	    					resultOpen = resultOpen && (new Modules.EnvelopeCurve.Flows.OpenModuleOnline()).Run(10000);
//	        				break;
//	    				}
//	        			case 5:
//	        			{
//	        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.RandomOpenCloseComplex", "Open Event List");
//	    					resultOpen = resultOpen && (new Modules.EventList.Flows.OpenModuleOnline()).Run(10000);
//	        				break;
//	    				}
//	        			case 6:
//	        			{
//	        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.RandomOpenCloseComplex", "Open Linearization");
//	    					resultOpen = resultOpen && (new Modules.Linearization.Flows.OpenModuleOnline()).Run(10000);
//	        				break;
//	    				}
//	        			case 7:
//	        			{
//	        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.RandomOpenCloseComplex", "Open Parameterization");
//	    					resultOpen = resultOpen && (new Modules.Parameterization.Flows.OpenModuleOnline()).Run(10000);
//	        				break;
//	    				}
//	        			case 8:
//	        			{
//	        				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.RandomOpenCloseComplex", "Open Save Restore");
//	    					resultOpen = resultOpen && (new Modules.SaveRestore.Flows.OpenModuleOnline()).Run(10000);
//	        				break;
//	    				}
//	        			default:
//	        				break;
//	        		}
//	        		
//	        		#endregion
//	        		
//	        		if(resultOpen)
//	        		{
//	        			// add module to list of opened modules
//	        			listOfOpenModules.Add(number);
//	        			Report.Success("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex"
//	        			               , "Module opened successfully.");
//	        		}
//	        		else
//	        		{
//	        			Report.Failure("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex"
//	        			               , "Module is not opened.");
//	        		}
//        		}
//        		
//        		#endregion
//        		
//				// re-initialize random-number, with 50%   				
//        		number 				= randomizer.Next(randomLow, (randomHigh*2));
//        		
//        		#region close block
//        		
//        		if(listOfOpenModules.Contains(number))
//        		{
//        			#region switch case of module to close
//        			
//        			resultClose = CloseModule(number);
//        			
//        			#endregion
//        			
//        			if(resultClose)
//	        		{
//	        			// remove module from list of opened modules
//	        			if(listOfOpenModules.Remove(number))
//	        			{
//	        				Report.Success("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex"
//	        				               , "Module closed successfully.");
//	        			}
//	        			else
//	        			{
//	        				Report.Warn("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex"
//	        				            , "An error occured while removing module from list of opened modules");
//	        			}
//	        			
//	        		}
//        			else
//	        		{
//	        			Report.Failure("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex"
//        				               , "Module is not closed.");
//	        		}
//        		}
//        		
//        		#endregion
//        		
//        		#region loop result
//        		
//        		if((resultOpen && resultClose))
//				{
//					Report.Success("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex"
//        			               , "Loop worked fine");
//				}
//				else
//				{
//					Report.Failure("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex"
//					               , "An error occured while open / close module.");
//				}
//				
//				#endregion
//        	}
//        	
//        	#region cleanup of remaining list items
//
//        	foreach(int module in listOfOpenModules)
//        	{
//        		bool cleanUpResult = true;
//        		cleanUpResult = CloseModule(module);
//        	}
//        	
//        	#endregion
//        	
//        }
//
//    	/// <summary>
//    	/// Close a random module
//    	/// </summary>
//    	/// <param name="number">module id to close</param>
//    	/// <returns>
//    	/// <br>True: if call worked fine</br>
//    	/// <br>False: if an error occured</br>
//    	/// </returns>
//	    private bool CloseModule(int number)
//	    {
//	    	bool resultClose = true; 
//	    	
//	    	switch (number)
//			{
//				case 1:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Compare");
//					resultClose = resultClose && (new Modules.Compare.Flows.CloseModule()).Run(10000);
//					break;
//				}
////	    		case 2:
////	       		{
////	        		Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Concentration");
////	        		resultClose = resultClose && (new Modules.Concentration.Flows.CloseModule()).Run(10000);
////	        		break;
////	    		}
//				case 3:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Create Documentation");
//					resultClose = resultClose && (new Modules.CreateDocumentation.Flows.CloseModule()).Run(10000);
//					break;
//				}
//				case 4:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Envelope Curve");
//					resultClose = resultClose && (new Modules.EnvelopeCurve.Flows.CloseModule()).Run(10000);
//					break;
//				}
//				case 5:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Event List");
//					resultClose = resultClose && (new Modules.EventList.Flows.CloseModule()).Run(10000);
//					break;
//				}
//				case 6:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Linearization");
//					resultClose = resultClose && (new Modules.Linearization.Flows.CloseModuleOnline()).Run(10000);
//					break;
//				}
//				case 7:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Parameterization");
//					resultClose = resultClose && (new Modules.Parameterization.Flows.CloseModuleOnline()).Run(10000);
//					break;
//				}
//				case 8:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Save Restore");
//					resultClose = resultClose && (new Modules.SaveRestore.Flows.CloseModule()).Run(10000);
//					break;
//				}
//				default:
//				{
//					break;
//				}
//			}
//	    	
//	    	return resultClose;
//		}
//    }
//}
