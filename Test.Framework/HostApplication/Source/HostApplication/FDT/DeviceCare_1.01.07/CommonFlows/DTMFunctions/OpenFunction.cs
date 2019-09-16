/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of OpenFunction.
    /// </summary>
    public class OpenFunction : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IOpenFunction
    {
        /// <summary>
        /// 
        /// </summary>
        public OpenFunction()
        {
        }
        
        /// <summary>
        /// Opens any DTM function by its name and validates if the action was successful 
        /// </summary>
        /// <param name="functionName">The name of the DTM function</param>
        /// <returns>True if the action was successful</returns>
        public bool Run(string functionName)
        {
            //instanciate all necessary modules
            var selectDeviceFunction = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers.InterfaceHelpers.DTMFunctions();
            var devScreen = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
            //set module variable
            devScreen.DeviceFunctionName = functionName;
        
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Open "+functionName+" function tab");
            
            //execution: select button DTM functions
            devScreen.ClickFunctionMenu();
            
            //validate if function is already opened
            //if function is already open -> skip execution
            if (devScreen.IsFunctionEnabled())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The function \""+functionName+"\"is already opened");
                return true;
            }
            
            //validate -> next step
            if (devScreen.IsDTMFunctionMenuShown())
            {
                //select functionName
                if (devScreen.ClickDeviceFunction())
                {
                    //validate -> next step
                    if (devScreen.IsTabOpen())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
