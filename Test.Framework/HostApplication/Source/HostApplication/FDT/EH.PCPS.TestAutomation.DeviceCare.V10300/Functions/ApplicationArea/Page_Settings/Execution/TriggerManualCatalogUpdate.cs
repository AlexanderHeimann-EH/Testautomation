/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 05.05.2015
 * Time: 14:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_Settings.Execution
{
    using System.Diagnostics;

    /// <summary>
    /// Description of TriggerManualCatalogUpdate.
    /// </summary>
    [TestModule("A66B4A2C-7B7C-4379-ABA1-B1DCEF9B4332", ModuleType.UserCode, 1)]
    public class TriggerManualCatalogUpdate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TriggerManualCatalogUpdate()
        {
            // Do not delete - a parameterless constructor is required!
        }

        GUI.DeviceCareApplication repo = GUI.DeviceCareApplication.Instance;
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        //TODO: Refactor the method. Add a timer to Observeprogressbar(PBar bar) to catch failures when bar gets stuck
        //TODO: Export to dedicated class -> class is Page_Settings_Functions
        void ITestModule.Run()
        {
           Mouse.DefaultMoveTime = 300;
           Keyboard.DefaultKeyPressTime = 100;
           Delay.SpeedFactor = 1.0;
           
           //precondition: dtm catalog page is shown
           if (pageExists())
           {
           	//press f5
           	Keyboard.Press(System.Windows.Forms.Keys.F5);
           	//wait 0,5 seconds and check if progressbar is visible
           	Thread.Sleep(500);
           	
           	try
           	{
                Stopwatch watch = new Stopwatch();
                watch.Start();
                while (watch.ElapsedMilliseconds < 10000)
                {
                    if (watch.ElapsedMilliseconds >= 10000)
                    {
                        // return false;
                    }

                    if (repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbarInfo.Exists())
                    {
                        watch.Stop();
                        // return true;
                    }
                }
           		//repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbarInfo.WaitForExists(10000);
           		
           		//get progressbar value
           		
           		ObserveProgressbar(repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbar);
           		
           		if (repo.DeviceCare.ApplicationArea.Page_Settings.DTMCatalogUpdateProgressbar.Element.Visible == false)
           		{
           			_WasSuccessful = true;
           		}
           	}
           	catch (Exception)
           	{
           		_WasSuccessful = false;
           	}

           }
           else
           {
           	//this is only reached if the preceding TC has failed too
           	// in that case an exception will be thrown here
           	
           	throw new RanorexException("DTM catalog page was not shown after second validation");
           }
        }
        
        private bool _WasSuccessful;
        /// <summary>
        /// 
        /// </summary>
        public bool WasSuccessful
        {
           get { return _WasSuccessful;}
        }
        
        bool pageExists()
        {
           return repo.DeviceCare.ApplicationArea.Page_Settings.Table_DTMCatalog.SelfInfo.Exists();
        }
        
        private void ObserveProgressbar(ProgressBar bar)
        {
           double prevValue = 0;
           while(bar.Element.Visible)
           {
           	if (prevValue != bar.Value)
           	{
           		Report.Log(ReportLevel.Info,string.Format("DTM catalog update progress: {0}",bar.Value));
           	}
           	if (bar.Value >= 95)
           	{
           		break;
           	}
           	Delay.Milliseconds(250);
           }
        }
    }
}
