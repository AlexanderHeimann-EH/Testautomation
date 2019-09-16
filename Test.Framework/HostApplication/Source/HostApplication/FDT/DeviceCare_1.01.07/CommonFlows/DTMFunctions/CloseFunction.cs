// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseFunction.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CloseFunction.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Description of CloseFunction.
    /// </summary>
    public class CloseFunction : ICloseFunction
    {
        /// <summary>
        /// Closes any DTM function by its name and validates if the action was successful
        /// </summary>
        /// <param name="functionName">The name of the DTM function</param>
        /// <returns>True if the action was successful</returns>
        public bool Run(string functionName)
        {
            // instanciate all necessary modules
            var selectDeviceFunction = new Functions.Helpers.InterfaceHelpers.DTMFunctions();
            var devScreen = new Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
            
            // set module variables
            devScreen.DeviceFunctionName = functionName;

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Close " + functionName + " function tab");

            // check if tab exists
            if (devScreen.IsTabOpen())
            {
                // close desired function tab
                devScreen.CloseFunctionTab();
                
                // check if tab is really closed
                if (devScreen.IsTabClosed())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
