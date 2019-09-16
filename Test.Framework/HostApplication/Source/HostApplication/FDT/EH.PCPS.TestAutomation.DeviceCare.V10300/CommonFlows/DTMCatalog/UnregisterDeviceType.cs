/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    /// <summary>
    /// Description of UnregisterDeviceType.
    /// </summary>
    public class UnregisterDeviceType : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IUnregisterDeviceType
    {
        /// <summary>
        /// 
        /// </summary>
        public UnregisterDeviceType()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                     "Host Application: DeviceCare does not implicitly support registering a device type \r\nA DTM catalog update will be triggered");
            //open settings menu
            var openSettings = new Functions.MenuArea.Menu_Home.Execution.OpenSettings();
            TestModuleRunner.Run(openSettings);
            
            //open dtm catalog page
            var openDTMCatalog = new Functions.MenuArea.Menu_Settings.Execution.OpenDTMCatalog();
            TestModuleRunner.Run(openDTMCatalog);
            //press f5 for catalog update
            var triggerUpdate = new Functions.ApplicationArea.Page_Settings.Execution.TriggerManualCatalogUpdate();
            TestModuleRunner.Run(triggerUpdate);
            //report info that dtm catalog update was triggered
            
            if (triggerUpdate.WasSuccessful)
            {
                return true;
            }
            else
            {
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
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                     "Function is not supported by Host Application: DeviceCare)");
            
            return false;
        }
    }
}
