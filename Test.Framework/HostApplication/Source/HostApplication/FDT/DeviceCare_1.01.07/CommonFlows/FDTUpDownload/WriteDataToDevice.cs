/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of WriteDataToDevice.
    /// </summary>
    public class WriteDataToDevice : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IWriteDataToDevice
    {
        /// <summary>
        /// 
        /// </summary>
        public WriteDataToDevice()
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            //instantiate all modules
            var connectionStatus = new Functions.StatusArea.Statusbar.Statusbar_Functions();
            var execFunction = new Functions.Helpers.InterfaceHelpers.DTMFunctions();
            var devScreen = new Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
            
            devScreen.IsAdditionalFunction = false;
            devScreen.DeviceFunctionName = "OfflineParameterization";
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Write data to device");
            //check if device is connected
            if (connectionStatus.IsDeviceConnected())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is connected. Checking if device supports offline functionality...");
                
                //check if device supports offline functionality
                //else return false and user warning
                devScreen.ClickFunctionMenu();
                
                if (devScreen.IsDTMFunctionMenuShown())
                {
                    if (devScreen.IsOfflineSupported())
                    {
                        //device supports offline functionality
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device supports offline functionality. Writing device data...");
                        
                        if (devScreen.WriteToDevice())
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing of the device data was successful");
                        }
                    }
                    else
                    {
                        //device does not support offline
                        //report a warning and return false
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device does not support offline functionality. Cancelling the write request.");
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
