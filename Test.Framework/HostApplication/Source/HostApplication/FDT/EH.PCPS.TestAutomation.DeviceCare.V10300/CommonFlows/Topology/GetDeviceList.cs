﻿/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Collections.Generic;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    /// <summary>
    /// Description of GetDeviceList.
    /// </summary>
    public class GetDeviceList : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IGetDeviceList
    {
        /// <summary>
        /// 
        /// </summary>
		public GetDeviceList()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        public List<string> Run()
		{
			/*
			 * Function not supported by DC
			 * Method reports warning message and returns with false
			 */
			
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare)");

			return null;
		}
	}
}
