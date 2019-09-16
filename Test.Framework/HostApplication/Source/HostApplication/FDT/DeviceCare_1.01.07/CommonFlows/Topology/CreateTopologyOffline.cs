/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 15:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Collections.Generic;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of CreateTopologyOffline.
    /// </summary>
    public class CreateTopologyOffline //: CommonFlow.ICreateTopologyOffline
    {
        /// <summary>
        /// 
        /// </summary>
		public CreateTopologyOffline()
		{
		}

        /*TODO: Decision needed
		 * Shall we implement this interface?
		 * Since PCP is the only protocol which supports offline functionality in DeviceCare
		 * we could easily connect the normal way and call the 'offline' function afterwards
		 */

        /// <summary>
        /// 
        /// </summary>
        public bool Run()
		{
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare)");
			return false;
		}
        
        /// <summary>
        /// 
        /// </summary>
        public bool Run(List<string> communications, List<string> devices)
		{
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare)");
			return false;
		}


        /// <summary>
        /// 
        /// </summary>
        public bool Run(List<string> communications, List<string> devices, string projectName)
		{
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare)");
			return false;
		}
		
	}
}
