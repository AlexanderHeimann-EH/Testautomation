//------------------------------------------------------------------------------
// <copyright file="TM_GetProgramData.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 31.01.2012
 * Time: 11:22 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


using System.Reflection;
using Common.OSSpecific;
using Common.Tools;
using Ranorex;

namespace Testlibrary.TestModules.DeviceFunction.Setup
{
    /// <summary>
    ///     Description of TM_GetProgramData.
    /// </summary>
    public class TM_GetProgramData
    {
        /// <summary>
        ///     Start execution
        /// </summary>
        public static bool Run(string applicationName)
        {
            bool isPassed = true;
            int processId = AddRemovePrograms.Open();
            if (processId > -1)
            {
                isPassed &= AddRemovePrograms.ShowSupportInformation(applicationName);
                isPassed &= AddRemovePrograms.PrintSupportInformation();
                isPassed &= AddRemovePrograms.Close(processId);
            }
            else
            {
                isPassed = false;
            }

            if (isPassed)
            {
                Report.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Testmodule passed.");
            }
            else
            {
                Report.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Testmodule failed.");
            }

            return isPassed;
        }
    }
}