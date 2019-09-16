// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessMemoryInfo.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2013
// </copyright>
// <summary>
//   The enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 04.12.2013
 * Time: 11:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Description of MemoryInfo.
    /// </summary>
    public class ProcessMemoryInfo
    {
        /// <summary>
        /// This method gets the private physical memory allocated for the process.
        /// This method does only work for windows systems higher than Windows XP
        /// </summary>
        /// <param name="process">The System.Process to print the memory of</param>
        /// <returns>The Private Working Set (string) memory of the specific process</returns>
        public static string PrintMemoryInfo(Process process)
        {
            process.Refresh();
            
            // long memorySize2 = (long)fmpframe.PrivateMemorySize64;
            var prfCntr = new PerformanceCounter("Process", "Working Set - Private", process.ProcessName);
            long memorySize = prfCntr.RawValue;
            
            string[] suffix = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (memorySize == 0)
            {
                return "0" + suffix[0];
            }

            long bytes = Math.Abs(memorySize);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(memorySize) * num) + suffix[place];
        }
    }
}
