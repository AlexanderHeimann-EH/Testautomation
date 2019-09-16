/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
	/// <summary>
	/// Description of DisconnectDevice.
	/// </summary>
	public class DisconnectDevice : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IDisconnectDevice
	{
        /// <summary>
        /// 
        /// </summary>
        public DisconnectDevice()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        public bool Run()
		{
			//instantiate all modules
			var connectionStatus = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.StatusArea.Statusbar.Statusbar_Functions();
			var execFunction = new Functions.Helpers.InterfaceHelpers.DTMFunctions();
			var devScreen = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
			
			devScreen.IsAdditionalFunction = false;
			devScreen.DeviceFunctionName = "OfflineParameterization";
			
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Disconnect device (toggle offline)");
			//check if device is connected and store value
			bool isConnected = connectionStatus.IsDeviceConnected();
			if (isConnected)
			{
				Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is in online state. Checking if device supports offline functionality...");
				
				//check if device supports offline functionality
				//else return false and user warning
				devScreen.ClickFunctionMenu();
				
				if (devScreen.IsDTMFunctionMenuShown())
				{
					if (devScreen.IsOfflineSupported())
					{
						//device supports offline functionality
						Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device supports offline functionality. Toggling offline...");
						
						//toggle online
						devScreen.ToggleOnline();
						Delay.Milliseconds(2500);
						
						if (connectionStatus.IsDeviceDisconnected())
						{
							Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Successfully disconnected the device");
							return true;
						}
						else
						{
							Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not disconnect the device");
							return false;
						}
					}
					else
					{
						//device does not support offline
						//report a warning and return false
						Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device does not support offline functionality. Cancel disconnecting the device...");
						return false;
					}
				}
			}
			else
			{
				//device is already connected -> do nothing and return
				Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device is already in offline state");
				return true;
					
			}
			return false;
		}
	}
}
