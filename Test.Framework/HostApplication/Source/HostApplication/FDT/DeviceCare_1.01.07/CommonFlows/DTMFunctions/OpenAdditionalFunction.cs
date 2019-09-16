/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of OpenAdditionalFunction.
    /// </summary>
    public class OpenAdditionalFunction: EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IOpenAdditionalFunction
    {
        /// <summary>
        /// 
        /// </summary>
        public OpenAdditionalFunction()
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public bool Run(string functionName)
        {
            //instanciate all necessary modules
            var selectDeviceFunction = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers.InterfaceHelpers.DTMFunctions();
            var devScreen = new EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
            //set module variables
            devScreen.DeviceFunctionName = functionName;
            devScreen.IsAdditionalFunction = true;
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Open "+functionName+" function tab");
            
            //execution: select button Additional functions
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
