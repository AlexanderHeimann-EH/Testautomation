// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="DisconnectDevice.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of DisconnectDevice.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
	/// Description of DisconnectDevice.
	/// </summary>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here.")]
    public class DisconnectDevice : CommonHostApplicationLayerInterfaces.CommonFlows.IDisconnectDevice
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
			
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Disconnect device (toggle offline)");

            // check if device is connected and store value
			bool isConnected = connectionStatus.IsDeviceConnected();
			if (isConnected)
			{
				Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is in online state. Checking if device supports offline functionality...");
				
				// check if device supports offline functionality
				// else return false and user warning
				devScreen.OpenDtmFunctions();
				
				if (devScreen.IsDTMFunctionMenuShown())
				{
					if (devScreen.IsOfflineSupported())
					{
						// device supports offline functionality
						Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device supports offline functionality. Toggling offline...");
						
						// toggle online
						devScreen.ToggleOnline();
						Delay.Milliseconds(2500);
						
						if (connectionStatus.IsDeviceDisconnected())
						{
							Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Successfully disconnected the device");
							return true;
						}
					    
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not disconnect the device");
					    return false;
					}
				    
                    // device does not support offline
				    // report a warning and return false
				    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device does not support offline functionality. Cancel disconnecting the device...");
				    return false;
				}
			}
			else
			{
				// device is already connected -> do nothing and return
				Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device is already in offline state");
				return true;
			}

			return false;
		}
	}
}
