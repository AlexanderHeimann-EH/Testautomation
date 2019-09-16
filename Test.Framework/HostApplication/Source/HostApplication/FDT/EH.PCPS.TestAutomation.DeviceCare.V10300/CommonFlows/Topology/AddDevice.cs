/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 15:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

using Ranorex;
using Ranorex.Core;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
	/// <summary>
	/// Description of AddDevice.
	/// </summary>
	public class AddDevice //: CommonFlow.IAddDevice
	{
        /// <summary>
        /// The add device
        /// </summary>
        public AddDevice()
		{
		}
		
        /// <summary>
        /// The rund
        /// </summary>
        /// <param name="communication">string</param>
        /// <param name="_communication">string</param>
        /// <returns>bool</returns>
		public bool Run(string communication, string _communication)
		{
			/*
			 * Function not supported by DC
			 * Method reports warning message and returns with false
			 */
			
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare)");
			
			return false;
		}
		
        /// <summary>
        /// The run
        /// </summary>
        /// <param name="communication">string</param>
        /// <returns>Bool</returns>
		public bool Run(string communication/*, string device*/)
		{
			/*
			 * Function not supported by DC
			 * Method reports warning message and returns with false
			 */
			
			Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not supported by Host Application: DeviceCare)");
			
			return false;
		}
	}
}
