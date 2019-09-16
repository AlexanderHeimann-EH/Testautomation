// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetProgramFilesPath.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2011
// </copyright>
// <summary>
//   The enumerations.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Anja Kellner
 * Date: 17/11/2011
 * Time: 09:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System;

    /// <summary>
    /// This class contains a method to return the ProgramFiles Path
    /// </summary>
    public static class GetProgramFilesPath
    {
        /// <summary>
        /// This method returns the ProgramFiles Path for 32 Bit applications
        /// </summary>
        /// <returns>The program files path as string</returns>
        public static string GetProgramFilesPath32Bit()
        {
            if (8 == IntPtr.Size || (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }
      
        return Environment.GetEnvironmentVariable("ProgramFiles");
        }
    }
}
