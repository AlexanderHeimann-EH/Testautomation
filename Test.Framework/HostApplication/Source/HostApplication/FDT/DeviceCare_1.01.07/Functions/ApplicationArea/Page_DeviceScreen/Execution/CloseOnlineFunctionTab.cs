/*
 * Created by Ranorex
 * User: testadmin
 * Date: 30/04/2014
 * Time: 15:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using Ranorex;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_DeviceScreen.Execution
{
    /// <summary>
    /// Description of UserCodeModule2.
    /// </summary>
    [TestModule("48BE49C3-85B8-4C85-826A-884F8EEC6378", ModuleType.UserCode, 1)]
    public class CloseOnlineFunctionTab : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CloseOnlineFunctionTab()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string _OpenTab = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("4F6F2398-AF7D-4C40-BB14-CB7223F6F6DB")]
        public string OpenTab
        {
           get { return _OpenTab; }
           set { _OpenTab = value; }
        }
        
        string _ID_Function = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("AD3AE15B-12BF-4AEE-8033-88A9CC1A1014")]
        public string ID_Function
        {
           get { return _ID_Function; }
           set { _ID_Function = value; }
        }
        
        string _Function = "";
        
        /// <summary>
        /// 
        /// </summary>
        [TestVariable("5E2F7787-EA7F-4C02-B7B8-1A2B60EB2CE1")]
        public string Function
        {
           get { return _Function; }
           set { _Function = value; }
        }
        
     
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
           
            string IDTabFunction="TabItem_" + ID_Function; 
            
            if (OpenTab== "Y" )
            {
				var repo = GUI.DeviceCareApplication.Instance;
				repo.TabFunction = IDTabFunction ;
				Report.Log(ReportLevel.Info, Function ,  " Close " + Function , new RecordItemIndex(7));
				  try {	
				 repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.acess.FunctionWindow.Tab.TabButton_To_Close.Click();
				 } catch(Exception ex) { Report.Warn("(Optional Action) " + ex.Message); }
				
            }
        }
    }
}

