/*
 * Created by Ranorex
 * User: testadmin
 * Date: 30/04/2014
 * Time: 14:27
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

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.ApplicationArea.Page_DeviceScreen.Validation
{
    /// <summary>
    /// Description of UserCodeModule2.
    /// </summary>
    [TestModule("16D42EE6-36F3-4591-AA20-A93F8F1594DE", ModuleType.UserCode, 1)]
    public class CheckOnlineFunctionOpen : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckOnlineFunctionOpen()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        string _OpenTab = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("939F5CE8-F927-4E22-BFA1-94B7D17DB91E")]
        public string OpenTab
        {
           get { return _OpenTab; }
           set { _OpenTab = value; }
        }
        
        string _ID_FunctionTab = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("ADEE7407-3267-411A-93AB-1B04922B9F76")]
        public string ID_FunctionTab
        {
           get { return _ID_FunctionTab; }
           set { _ID_FunctionTab = value; }
        }
        
        string _Function = "";

        /// <summary>
        /// 
        /// </summary>
        [TestVariable("DF2B886A-BC94-4F5A-9BCE-567CEAEB9D43")]
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
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
           
            string IDTabFunction="";
            
            
            IDTabFunction= "TabItem_"+ ID_FunctionTab;
		
			
			
				
				

               if (OpenTab =="Y") 
               
            {
            
				var repo = GUI.DeviceCareApplication.Instance;
				repo.TabFunction = IDTabFunction ;
					
				  
				Report.Log(ReportLevel.Info, Function ,  " Validate " + Function , new RecordItemIndex(7));
				var tabItem_Variable = repo.DeviceCare.MenuArea.Menu_DeviceScreen.DTMFunctionMenutop.acess.FunctionWindow.Tab.TabItem_Variable;
				Validate.Attribute(tabItem_Variable, "Visible", "True");
				 
            
            }
            else 
            {
				Report.Log(ReportLevel.Info, Function ,  " Open "+ Function + "with no changes" , new RecordItemIndex(7));
				
            
            
        }
    }
}
}