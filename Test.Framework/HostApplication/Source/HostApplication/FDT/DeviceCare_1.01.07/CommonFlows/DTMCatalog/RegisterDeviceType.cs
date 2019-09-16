/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

using Ranorex;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of RegisterDeviceType.
    /// </summary>
    public class RegisterDeviceType : CommonHostApplicationLayerInterfaces.CommonFlows.IRegisterDeviceType
    {
        /// <summary>
        /// 
        /// </summary>
        public RegisterDeviceType()
        {
        }    
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Register Device Type");
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Host Application: DeviceCare does not implicitly support registering a device type \r\nA DTM catalog update will be triggered");
            
            var functions_pageSettings = new Functions.ApplicationArea.Page_Settings.Page_Settings_Functions();
            var functions_pageHome = new Functions.ApplicationArea.Page_Home.Page_Home_Functions();

            //precondition: home screen is shown
            if (!functions_pageHome.IsHomePageShown())
            {
                
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),"Home screen is not shown. Cannot start execution of the task");
                return false;
            }
            
            //open settings menu
            functions_pageSettings.OpenSettingsPage();
            
            if (functions_pageSettings.IsSettingsPageShown())
            {
                //open dtm catalog page
                functions_pageSettings.OpenDTMCatalog();
                
                if (functions_pageSettings.IsDTMCatalogShown())
                {
                    //press f5 for catalog update
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM catalog update will be triggered...");
                    return functions_pageSettings.TriggerUpdate();
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM catalog is not shown. Terminating execution");
                    return false;
                }
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Settings page is not shown. Terminating execution");
                return false;
            }

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="devices"></param>
        /// <returns></returns>
        public bool Run(List<string> devices)
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */
            
            //Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare");
            Report.Warn("Function is not supported by Host Application: DeviceCare");
            
            return false;
        }
    }
}
