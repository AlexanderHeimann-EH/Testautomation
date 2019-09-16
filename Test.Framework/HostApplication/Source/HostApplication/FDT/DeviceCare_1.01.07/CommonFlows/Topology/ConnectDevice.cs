/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 15:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

using Ranorex;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of ConnectDevice.
    /// </summary>
    public class ConnectDevice : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IConnectDevice
	{

        /// <summary>
        /// 
        /// </summary>
        public ConnectDevice()
		{
		}
        
        /// <summary>
        /// 
        /// </summary>
        public bool Run()
		{
			//instantiate all modules
			var connectionStatus = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.StatusArea.Statusbar.Statusbar_Functions();
			var execFunction = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers.InterfaceHelpers.DTMFunctions();
			var devScreen = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
			
			devScreen.IsAdditionalFunction = false;
			devScreen.DeviceFunctionName = "OfflineParameterization";
			
			
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Connect device (toggle online)");
			//check if device is connected and store value
			bool isConnected = connectionStatus.IsDeviceConnected();
			if (isConnected == false)
			{
				Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is in offline state. Checking if device supports offline functionality...");
				
				//check if device supports offline functionality
				//else return false and user warning
				devScreen.ClickFunctionMenu();
				
				if (devScreen.IsDTMFunctionMenuShown())
				{
					if (devScreen.IsOfflineSupported())
					{
						//device supports offline functionality
						Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device supports offline functionality. Toggling online...");
						         
						//toggle online
						devScreen.ToggleOnline();
						Delay.Milliseconds(2500);
						
						if (connectionStatus.IsDeviceConnected())
						{
							Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Successfully connected the device");
							return true;
						}
						else
						{
							Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not connect to the device");
							return false;
						}
					}
					else
					{
						//device does not support offline
						//report a warning and return false
						Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device does not support offline functionality. Cancel connecting the device...");
						return false;
					}
				}
			}
			else
			{
				//device is already connected -> do nothing and return
				Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device is already in online state");
				return true;
					
			}
			return false;
		}
	}
}
