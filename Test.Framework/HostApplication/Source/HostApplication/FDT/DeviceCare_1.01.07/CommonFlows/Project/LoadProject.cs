/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 14:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;


namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of LoadProject.
    /// </summary>
    public class LoadProject : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.ILoadProject
    {
        /// <summary>
        /// 
        /// </summary>
        public LoadProject()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Run(string projectName)
        {
            /*
             * Function not supported by DC
             * Method reports warning message and returns with false
             */
            
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare");
            
            return false;
        }
    }
}
