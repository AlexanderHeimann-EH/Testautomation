// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="ConnectDevice.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of ConnectDevice.
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
	/// Description of ConnectDevice.
	/// </summary>
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1027:TabsMustNotBeUsed", Justification = "Reviewed. Suppression is OK here.")]
    public class ConnectDevice : CommonHostApplicationLayerInterfaces.CommonFlows.IConnectDevice
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
			
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Connect device (toggle online)");

			// check if device is connected and store value
            bool isConnected = connectionStatus.IsDeviceConnected();
			if (isConnected == false)
			{
				Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is in offline state. Checking if device supports offline functionality...");
				
				// check if device supports offline functionality
				// else return false and user warning
				devScreen.OpenDtmFunctions();
				
				if (devScreen.IsDTMFunctionMenuShown())
				{
					if (devScreen.IsOfflineSupported())
					{
						// device supports offline functionality
						Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device supports offline functionality. Toggling online...");
						         
						// toggle online
						devScreen.ToggleOnline();
						Delay.Milliseconds(2500);
						
						if (connectionStatus.IsDeviceConnected())
						{
							Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Successfully connected the device");
							return true;
						}

					    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not connect to the device");
					    return false;
					}
				    
                    // device does not support offline
				    // report a warning and return false
				    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device does not support offline functionality. Cancel connecting the device...");
				    return false;
				}
			}
			else
			{
				// device is already connected -> do nothing and return
				Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The device is already in online state");
				return true;
			}

			return false;
		}
	}
}
