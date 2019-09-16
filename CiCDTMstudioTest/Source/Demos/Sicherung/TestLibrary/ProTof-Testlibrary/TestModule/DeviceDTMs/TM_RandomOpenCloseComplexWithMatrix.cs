///*
// * Created by Ranorex
// * User: testadmin
// * Date: 22.11.2012
// * Time: 7:52 
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
//    /// Description of TM_RandomOpenCloseComplexWithMatrix.
//    /// </summary>
//    [TestModule("9B390465-FA7F-4688-AF9F-0888E216A2B0", ModuleType.UserCode, 1)]
//    public class TM_RandomOpenCloseComplexWithMatrix : ITestModule
//    {
//    	string _numberOfLoops = "50";
//    	[TestVariable("A4BB649B-D6C2-4815-AD6F-76E03EF3571D")]
//    	public string numberOfLoops
//    	{
//    		get { return _numberOfLoops; }
//    		set { _numberOfLoops = value; }
//    	}
//    	
//    	string _timeOutInMiliseconds = "20000";
//    	[TestVariable("0AB64AD7-DEE6-43C9-A473-3C3878B1ECF6")]
//    	public string timeOutInMiliseconds
//    	{
//    		get { return _timeOutInMiliseconds; }
//    		set { _timeOutInMiliseconds = value; }
//    	}
//    	
//        /// <summary>
//        /// Constructs a new instance.
//        /// </summary>
//        public TM_RandomOpenCloseComplexWithMatrix()
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
//        	#region member initialization
//        	
//        	bool resultOpen 		= true;
//        	bool resultClose		= true;
//        	int maxNumberOfLoops 	= Convert.ToInt32(numberOfLoops);
//        	int maxModules			= 9;
//        	int randomLowBorder 	= 1;			 
//    		int randomHighBorder	= maxModules;	// max number of modules
//    		int randomNumber 		= 0;	
//    		Random randomizer 		= new Random();
//        	List<int> listOfOpenModules 	= new List<int>();
//        	List<int> listOfDeniedModules 	= new List<int>();
//        	bool[,]lockingMatrix 	= new bool[maxModules,maxModules];
//        	
//        	#endregion
//        	
//        	#region matrix initialization
//        	
//        	// debugausgabe
//        	Report.Info("Fülle Matrix", "");
//        	
//        	// Matrix mit Daten füllen
//        	for(int row = 0; row < maxModules; row++)
//        	{
//        		for(int column = 0; column< maxModules; column++)
//        		{
//        			if(column == row)
//        			{
//        				lockingMatrix[row,column] = false;	
//        			}
//        			else
//        			{
//        				lockingMatrix[row,column] = true;
//        			}
//        		}
//        	}
//        	
////        	// Debugausgabe
////        	string rowWise = "";
////        	for(int row = 0; row < maxModules; row++)
////        	{
////        		for(int column = 0; column < maxModules; column++)
////        		{
////        			rowWise = rowWise + lockingMatrix[row,column].ToString() + "\t";
////        		}
////        		System.Diagnostics.Debug.Print(rowWise);
////        		rowWise = "";
////        	}
////        	System.Diagnostics.Debug.Print("");
////        	System.Diagnostics.Debug.Print("");
//        	
//        	SpecificInitialization(lockingMatrix);
//        	
//        	// debugausgabe
//        	Report.Info("Matrix gefüllt", "");
//        	
////        	// Debugausgabe
////        	rowWise = "";
////        	for(int row = 0; row < maxModules; row++)
////        	{
////        		for(int column = 0; column < maxModules; column++)
////        		{
////        			rowWise = rowWise + lockingMatrix[row,column].ToString() + "\t";
////        		}
////        		System.Diagnostics.Debug.Print(rowWise);
////        		rowWise = "";
////        	}
//
//        	#endregion
//       	
//        	for(int counter = 1; counter <= maxNumberOfLoops; counter++)
//        	{
//        		Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix"
//        		            , "Loop " + counter.ToString() + " of " + maxNumberOfLoops);
//        		listOfDeniedModules.Clear();
//        		
//        		        		
//	        	#region get allowed modules
//	        	
//	        	// item und reihe des modules sind gleichgestzt
//	        	foreach(int item in listOfOpenModules)
//	        	{
//	        		// fuer jede modul das geöffnet werden soll (spalte)
//	        		for(int column = 0; column < maxModules; column++)
//	        		{
//	        			// wenn zu oeffnendes modul NICHT erlaubt ist
//	        			if(lockingMatrix[item, column] == false)
//	        			{
//	        				// wenn es noch keinen entsprechenden Eintrag gibt
//	        				if(listOfDeniedModules.Contains(column) == false)
//	        				{
//	        					// liste der verbotenen module erweitern
//	        					listOfDeniedModules.Add(column);	
//	        				}
//	        			}
//	        		}
//	        	}
//	        	
//	        	// Debugausgabe
//	        	string deniedModules = "";
//	        	foreach(int item in listOfDeniedModules)
//	        	{
//	        		deniedModules = deniedModules + item.ToString() + ", ";
//	        	}
//	        	Report.Info("Denied modules are: " + deniedModules, "");
//	        	
//	        	#endregion
//        		
//        		// wenn nicht alle module gesperrt sind
//	        	if(listOfDeniedModules.Count < maxModules)
//	        	{
//	        		
//	        		#region get random module
//	        		
//	        		// Get random number for module to open
//	        		randomNumber = randomizer.Next(randomLowBorder, randomHighBorder);
//		    		while(listOfDeniedModules.Contains(randomNumber) == true)
//		    		{
//		    			// Debugausgabe
//		    			Report.Info("Module [" + randomNumber.ToString() + " is not allowed... selecting another...");
//		    			randomNumber = randomizer.Next(randomLowBorder, randomHighBorder);
//		    		}
//		    		// Debugausgabe
//		    		Report.Info("Module to open is [" + randomNumber.ToString());
//		    		
//		    		#endregion
//		    		
//		    		#region open
//	    		
//		    		if(!listOfOpenModules.Contains(randomNumber))
//		        	{
//			    		#region switch case of module to open
//			    		switch (randomNumber)
//			    		{
//			    			case (int)enumModules.Compare:
//			    			{
//			    				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix", "Open Compare");
//			    				resultOpen = resultOpen && (new Modules.Compare.Flows.OpenModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//			    				break;
//							}
////			    			case (int)enumModules.Concentration:
////			   				{
////			    				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.RandomOpenCloseComplex", "Open Concentration");
////								resultOpen = resultOpen && (new Modules.Concentration.Flows.OpenModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
////			    				break;
////							}
//			    			case (int)enumModules.CreateDocumentation:
//			    			{
//			    				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix", "Open Create Documentation");
//								resultOpen = resultOpen && (new Modules.CreateDocumentation.Flows.OpenModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//			    				break;
//							}
//			    			case (int)enumModules.EnvelopeCurve:
//			    			{
//			    				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix", "Open Envelope Curve");
//								resultOpen = resultOpen && (new Modules.EnvelopeCurve.Flows.OpenModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//			    				break;
//							}
//			    			case (int)enumModules.EventList:
//			    			{
//			    				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix", "Open Event List");
//								resultOpen = resultOpen && (new Modules.EventList.Flows.OpenModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//			    				break;
//							}
//			    			case (int)enumModules.Linearization:
//			    			{
//			    				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix", "Open Linearization");
//								resultOpen = resultOpen && (new Modules.Linearization.Flows.OpenModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//			    				break;
//							}
//			    			case (int)enumModules.Parameterization:
//			    			{
//			    				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix", "Open Parameterization");
//								resultOpen = resultOpen && (new Modules.Parameterization.Flows.OpenModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//			    				break;
//							}
//			    			case (int)enumModules.SaveRestore:
//			    			{
//			    				Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix", "Open Save Restore");
//								resultOpen = resultOpen && (new Modules.SaveRestore.Flows.OpenModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//			    				break;
//							}
//			    			default:
//			    				break;
//			    		}
//				        		
//				        #endregion
//		    		
//				        #region check result
//				        
//			    		if(resultOpen)
//			    		{
//			    			// add module to list of opened modules
//			    			listOfOpenModules.Add(randomNumber);
//			    			Report.Success("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix"
//			    			               , "Module opened successfully.");
//			    		}
//			    		else
//			    		{
//			    			Report.Failure("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix"
//			    			               , "Module is not opened.");
//			    		}
//			    		
//			    		#endregion
//		    		}
//	    		
//	    			#endregion
//	    			
//	        	}
//	    			    		
//	    		// re-initialize random-number, there is a chance ca 50% that a module is closed
//	    		if(listOfDeniedModules.Count < maxModules)
//	        	{
//	    			randomNumber	= randomizer.Next(randomLowBorder, (randomHighBorder*2));
//	    		}
//	    		else
//	    		{
//	    			randomNumber = randomizer.Next(randomLowBorder, randomHighBorder);
//	    			while(listOfOpenModules.Contains(randomNumber) == false)
//		    		{
//		    			// Debugausgabe
//		    			Report.Info("Module [" + randomNumber.ToString() + " is not opened... selecting another...");
//		    			randomNumber = randomizer.Next(randomLowBorder, randomHighBorder);
//		    		}
//	    		}
//	    		
//	    		#region close
//	    		
//	    		if(listOfOpenModules.Contains(randomNumber))
//	    		{
//	    			#region switch case of module to close
//	    			
//	    			resultClose = CloseModule(randomNumber);
//	    			
//	    			#endregion
//	    			
//	    			#region check result
//	    			
//	    			if(resultClose)
//	        		{
//	        			// remove module from list of opened modules
//	        			if(listOfOpenModules.Remove(randomNumber))
//	        			{
//	        				Report.Success("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix"
//	        				               , "Module closed successfully.");
//	        			}
//	        			else
//	        			{
//	        				Report.Warn("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix"
//	        				            , "An error occured while removing module from list of opened modules");
//	        			}
//	        			
//	        		}
//	    			else
//	        		{
//	        			Report.Failure("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix"
//	    				               , "Module is not closed.");
//	        		}
//	    			
//	    			#endregion
//	    			
//	    		}
//	    		
//	    		#endregion
//	    		
//	    		#region check loop result
//	    		
//	    		if((resultOpen && resultClose))
//				{
//					Report.Success("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix"
//	    			               , "Loop worked fine");
//				}
//				else
//				{
//					Report.Failure("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplexWithMatrix"
//					               , "An error occured while open / close module.");
//				}
//				
//				#endregion
//			
//        	}
//        	
//        	#region cleanup of remaining list items
//
//        	// debugausgabe
//        	Report.Info("Cleaning up remaining modules");
//        	foreach(int module in listOfOpenModules)
//        	{
//        		// debugausgabe
//        		Report.Info("Closing " + module.ToString());
//        		bool cleanUpResult = true;
//        		cleanUpResult = CloseModule(module);
//        	}
//        	
//        	#endregion
//
//        }
//        
//	    /// <summary>
//		/// Close a random module
//		/// </summary>
//		/// <param name="number">module id to close</param>
//		/// <returns>
//		/// <br>True: if call worked fine</br>
//		/// <br>False: if an error occured</br>
//		/// </returns>
//	    private bool CloseModule(int number)
//	    {
//	    	bool resultClose = true; 
//	    	switch (number)
//			{
//	    		case (int)enumModules.Compare:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Compare");
//					resultClose = resultClose && (new Modules.Compare.Flows.CloseModule()).Run(Convert.ToInt32(timeOutInMiliseconds));
//					break;
//				}
////	    		case (int)enumModules.Concentration:
////	       		{
////	        		Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Concentration");
////	        		resultClose = resultClose && (new Modules.Concentration.Flows.CloseModule()).Run(Convert.ToInt32(timeOutInMiliseconds));
////	        		break;
////	    		}
//				case (int)enumModules.CreateDocumentation:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Create Documentation");
//					resultClose = resultClose && (new Modules.CreateDocumentation.Flows.CloseModule()).Run(Convert.ToInt32(timeOutInMiliseconds));
//					break;
//				}
//				case (int)enumModules.EnvelopeCurve:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Envelope Curve");
//					resultClose = resultClose && (new Modules.EnvelopeCurve.Flows.CloseModule()).Run(Convert.ToInt32(timeOutInMiliseconds));
//					break;
//				}
//				case (int)enumModules.EventList:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Event List");
//					resultClose = resultClose && (new Modules.EventList.Flows.CloseModule()).Run(Convert.ToInt32(timeOutInMiliseconds));
//					break;
//				}
//				case (int)enumModules.Linearization:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Linearization");
//					resultClose = resultClose && (new Modules.Linearization.Flows.CloseModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//					break;
//				}
//				case (int)enumModules.Parameterization:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Parameterization");
//					resultClose = resultClose && (new Modules.Parameterization.Flows.CloseModuleOnline()).Run(Convert.ToInt32(timeOutInMiliseconds));
//					break;
//				}
//				case (int)enumModules.SaveRestore:
//				{
//					Report.Info("ProTof_Testlibrary.TestModule.DeviceFunction.TM_RandomOpenCloseComplex", "Close Save Restore");
//					resultClose = resultClose && (new Modules.SaveRestore.Flows.CloseModule()).Run(Convert.ToInt32(timeOutInMiliseconds));
//					break;
//				}
//				default:
//				{
//					break;
//				}
//			}
//	    	
//	    	return resultClose;
//	    }
//	
//	    /// <summary>
//	    /// Initializes look matrix
//	    /// </summary>
//	    /// <param name="lockingMatrix"></param>
//	    private void SpecificInitialization(bool[,] lockingMatrix)
//	    {
//	    	lockingMatrix[0,1] = false;	// save/retore with compare
//	    	lockingMatrix[0,2] = false;	// save/retore with create documentation
//	    	lockingMatrix[0,3] = false;	// save/retore with event list
//	    	lockingMatrix[0,4] = false;	// save/retore with historom
//	    	lockingMatrix[0,5] = false;	// save/retore with envelope curve
//	    	lockingMatrix[0,6] = false;	// save/retore with linearisation
//	    	lockingMatrix[0,7] = false;	// save/retore with parameterisation
//	    	lockingMatrix[0,8] = false;	// save/retore with concentration
//	    	
//	    	lockingMatrix[1,0] = true; // compare with save/restore 
//	    	lockingMatrix[1,2] = true; // compare with create documentation
//	    	lockingMatrix[1,3] = true; // compare with event list
//	    	lockingMatrix[1,4] = true; // compare with historom
//	    	lockingMatrix[1,5] = true; // compare with envelope curve
//	    	lockingMatrix[1,6] = true; // compare with linearisation
//	    	lockingMatrix[1,7] = true; // compare with parameterisation
//	    	lockingMatrix[1,8] = true; // compare with concentration
//	    	
//	    	lockingMatrix[2,0] = false; // create documentation with save/restore
//	    	lockingMatrix[2,1] = false; // create documentation with compare
//	    	lockingMatrix[2,3] = false; // create documentation with event list
//	    	lockingMatrix[2,4] = false; // create documentation with historom
//	    	lockingMatrix[2,5] = false; // create documentation with envelope curve
//	    	lockingMatrix[2,6] = false; // create documentation with linearisation
//	    	lockingMatrix[2,7] = false; // create documentation with parameterisation
//	    	lockingMatrix[2,8] = false; // create documentation with concentration
//	    	
//	    	lockingMatrix[3,0] = true; // event list with save/restore
//	    	lockingMatrix[3,1] = true; // event list with compare
//	    	lockingMatrix[3,2] = true; // event list with create documentation
//	    	lockingMatrix[3,4] = true; // event list with historom
//	    	lockingMatrix[3,5] = true; // event list with envelope curve
//	    	lockingMatrix[3,6] = true; // event list with linearisation
//	    	lockingMatrix[3,7] = true; // event list with parameterisation
//	    	lockingMatrix[3,8] = true; // event list with concentration
//	    	
//	    	lockingMatrix[4,0] = true; // historom with save/restore
//	    	lockingMatrix[4,1] = true; // historom with compare
//	    	lockingMatrix[4,2] = true; // historom with create documentation
//	    	lockingMatrix[4,3] = true; // historom with event list
//	    	lockingMatrix[4,5] = true; // historom with envelope curve
//	    	lockingMatrix[4,6] = true; // historom with linearisation
//	    	lockingMatrix[4,7] = true; // historom with parameterisation
//	    	lockingMatrix[4,8] = true; // historom with concentration
//	    	
//	    	lockingMatrix[5,0] = true; // envelope curve with save/restore
//	    	lockingMatrix[5,1] = true; // envelope curve with compare
//	    	lockingMatrix[5,2] = true; // envelope curve with create documentation
//	    	lockingMatrix[5,3] = true; // envelope curve with event list
//	    	lockingMatrix[5,4] = true; // envelope curve with historom
//	    	lockingMatrix[5,6] = true; // envelope curve with linearisation
//	    	lockingMatrix[5,7] = true; // envelope curve with parameterisation
//	    	lockingMatrix[5,8] = true; // envelope curve with concentration
//	    	
//	    	lockingMatrix[6,0] = true; // linearization with save/restore
//	    	lockingMatrix[6,1] = true; // linearization with compare
//	    	lockingMatrix[6,2] = true; // linearization with create documentation
//	    	lockingMatrix[6,3] = true; // linearization with event list
//	    	lockingMatrix[6,4] = true; // linearization with historom
//	    	lockingMatrix[6,5] = true; // linearization with envelope curve
//	    	lockingMatrix[6,7] = true; // linearization with parameterisation
//	    	lockingMatrix[6,8] = true; // linearization with concentration
//	    	
//	    	lockingMatrix[7,0] = true; // parameterization with save/restore
//	    	lockingMatrix[7,1] = true; // parameterization with compare
//	    	lockingMatrix[7,2] = true; // parameterization with create documentation
//	    	lockingMatrix[7,3] = true; // parameterization with event list
//	    	lockingMatrix[7,4] = true; // parameterization with historom
//	    	lockingMatrix[7,5] = true; // parameterization with envelope curve
//	    	lockingMatrix[7,6] = true; // parameterization with linearisation
//	    	lockingMatrix[7,8] = true; // parameterization with concentration
//	    	
//	    	lockingMatrix[8,0] = true; // concentration with save/restore
//	    	lockingMatrix[8,1] = true; // concentration with compare
//	    	lockingMatrix[8,2] = true; // concentration with create documentation
//	    	lockingMatrix[8,3] = true; // concentration with event list
//	    	lockingMatrix[8,4] = true; // concentration with historom
//	    	lockingMatrix[8,5] = true; // concentration with envelope curve
//	    	lockingMatrix[8,6] = true; // concentration with linearisation
//	    	lockingMatrix[8,7] = true; // concentration with parameterisation
//	    	
//	    }
//    
//        /// <summary>
//        /// Enum of modules
//        /// </summary>
//		private enum enumModules{ 
//        	SaveRestore=0, 
//        	Compare, 
//        	CreateDocumentation,
//            EventList, 
//            HistoROM, 
//            EnvelopeCurve, 
//            Linearization, 
//            Parameterization, 
//            Concentration
//        }
//    }
//}
//
