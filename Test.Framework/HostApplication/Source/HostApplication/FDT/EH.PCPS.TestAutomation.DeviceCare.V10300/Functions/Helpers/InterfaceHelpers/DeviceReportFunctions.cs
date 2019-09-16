/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 17.08.2015
 * Time: 12:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.IO;

/*
 * TODO: All methods in here refer to dialogs or pop ups.
 * We should think of a good class name or make some new classes to divide pop ups/dialogs
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers.InterfaceHelpers
{
    /// <summary>
    /// Description of DeviceReportFunctions.
    /// </summary>
    public class DeviceReportFunctions
	{

        /// <summary>
        /// 
        /// </summary>
        public DeviceReportFunctions()
		{
		}
		//TODO: Geht ins common projekt -> tools
		/// <summary>
		/// Checks if a specific file exists
		/// </summary>
		/// <param name="name">The name (including location) of the file</param>
		/// <returns>True if the file exists</returns>
		public bool IsFileCreated(string name)
		{
			if (File.Exists(name))
			{
				return true;
			}
			return false;
		}
	}
}
