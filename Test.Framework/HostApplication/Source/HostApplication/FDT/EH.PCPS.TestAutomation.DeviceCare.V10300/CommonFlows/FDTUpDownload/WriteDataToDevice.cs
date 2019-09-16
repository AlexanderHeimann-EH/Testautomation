// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="WriteDataToDevice.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of WriteDataToDevice.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Description of WriteDataToDevice.
    /// </summary>
    public class WriteDataToDevice : CommonHostApplicationLayerInterfaces.CommonFlows.IWriteDataToDevice
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            // instantiate all modules
            var connectionStatus = new Functions.StatusArea.Statusbar.Statusbar_Functions();
            var devScreen = new Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
            
            devScreen.IsAdditionalFunction = false;
            devScreen.DeviceFunctionName = "OfflineParameterization";
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Write data to device");
            
            // check if device is connected
            if (connectionStatus.IsDeviceConnected())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is connected. Checking if device supports offline functionality...");
                
                // check if device supports offline functionality
                // else return false and user warning
                devScreen.OpenDtmFunctions();
                
                if (devScreen.IsDTMFunctionMenuShown())
                {
                    if (devScreen.IsOfflineSupported())
                    {
                        // device supports offline functionality
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device supports offline functionality. Writing device data...");
                        
                        if (devScreen.WriteToDevice())
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing of the device data was successful");
                        }
                    }
                    else
                    {
                        // device does not support offline
                        // report a warning and return false
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device does not support offline functionality. Cancelling the write request.");
                        return false;
                    }
                }
            }

            return false;
        }
    }
}
