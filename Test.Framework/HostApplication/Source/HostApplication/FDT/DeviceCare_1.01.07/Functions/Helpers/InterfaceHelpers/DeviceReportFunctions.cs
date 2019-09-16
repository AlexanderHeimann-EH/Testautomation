/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 17.08.2015
 * Time: 12:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

/*
 * TODO: All methods in here refer to dialogs or pop ups.
 * We should think of a good class name or make some new classes to divide pop ups/dialogs
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.Functions.Helpers.InterfaceHelpers
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
