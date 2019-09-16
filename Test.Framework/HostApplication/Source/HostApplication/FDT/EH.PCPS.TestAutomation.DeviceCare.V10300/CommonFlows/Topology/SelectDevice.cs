/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
	/// <summary>
	/// Description of SelectDevice.
	/// </summary>
	public class SelectDevice //: EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.ISelectDevice
	{
		/// <summary>
		/// 
		/// </summary>
		public SelectDevice()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="communication"></param>
		/// <returns></returns>
		public bool Run(string communication)
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
