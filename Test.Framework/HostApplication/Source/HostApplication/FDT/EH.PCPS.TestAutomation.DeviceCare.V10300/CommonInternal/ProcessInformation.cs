/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 17.09.2015
 * Time: 15:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;
using System.Diagnostics;

using Ranorex;

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonInternal
{
	/// <summary>
	/// Description of ProcessInfo.
	/// </summary>
	public class ProcessInformation
	{
		/// <summary>
		/// 
		/// </summary>
		public ProcessInformation()
		{
		}

        /// <summary>
        /// Creates a process summary and returns log messages as a list
        /// </summary>
        /// <param name="processToMonitor">The process to create a summary from</param>
        /// <returns>A list containing formatted strings which can be published with a short foreach loop</returns>
        private static List<string> GetProcessSummary(Process processToMonitor)
		{
			List<string> logList = new List<string>();
			
			if (!processToMonitor.HasExited)
			{
				string pWorkingSet = EH.PCPS.TestAutomation.Common.Tools.ProcessMemoryInfo.PrintMemoryInfo(processToMonitor);
				
				logList.Add("Window Title: "+processToMonitor.MainWindowTitle);
				logList.Add("Physical memory usage: "+pWorkingSet);
				logList.Add("Total processor time: "+processToMonitor.TotalProcessorTime.ToString());
				logList.Add("Base Priority: "+processToMonitor.BasePriority.ToString());
				logList.Add("Priority class: "+processToMonitor.PriorityClass.ToString());
				
				return logList;
			}
			else
			{
				logList.Add("The process has already exited. Getting the exit code...");
				logList.Add("Exit code is: "+processToMonitor.ExitCode);
				return logList;
			}
			
			
		}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="process"></param>
		public static void PublishProcessSummary(Process process)
		{
			foreach(string logEntry in GetProcessSummary(process))
			{
				Report.Info(logEntry);
			}
		}
	}
}
