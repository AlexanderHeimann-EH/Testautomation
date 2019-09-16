/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 13:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of OpenHostApplication.
    /// </summary>
    public class OpenHostApplication : CommonHostApplicationLayerInterfaces.CommonFlows.IOpenHostApplication
    {
        /// <summary>
        /// 
        /// </summary>
        public OpenHostApplication()
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            var module = new Functions.Helpers.DeviceCareProcessFunctions();
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Open HostApplication (DeviceCare)");
            
            return module.Run();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Run(string path)
        {
            var module = new Functions.Helpers.DeviceCareProcessFunctions();
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Open HostApplication (DeviceCare)");
            
            int processID = module.Run(path);

            return module.IsHostApplicationRunning(processID);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="timeOutInMilliseconds"></param>
        /// <returns></returns>
        public bool Run(string path, int timeOutInMilliseconds)
        {
            var module = new Functions.Helpers.DeviceCareProcessFunctions();
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Open HostApplication (DeviceCare)");
            
            int processID = module.Run(path,timeOutInMilliseconds);
            
            return module.IsHostApplicationRunning(processID);
        }
        
    }
}
