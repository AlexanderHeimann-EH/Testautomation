//------------------------------------------------------------------------------
// <copyright file="TC_CompleteUpgrade.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 30.01.2012
 * Time: 11:22 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

// Summary: 		Complete upgrade of all Device DTMs contained in Setup

// Precondition: 	- Setup is available
// 				 	- Frame is closed

// Postcondition:	- N.A.
//					- N.A.

// Description:		- Start [Setup].exe
//					- Accept Licence Agreement
//					- Choose Complete Upgrade
//					- Finish Update

using System.Reflection;
using Common.Tools;
using SetupWizzardCoDIADTMs.Dialogs;
using SetupWizzardCoDIADTMs.Functions;
using SetupWizzardCoDIADTMs.Messages;
using Ranorex;
using Testlibrary.TestModules.DeviceFunction.Setup;

namespace Testlibrary.TestCases.DeviceFunction.Setup
{
    /// <summary>
    ///     Description of TC_CompleteUpgrade.
    /// </summary>
    public class TC_CompleteUpgrade
    {
        /// <summary>
        ///     Start execution
        /// </summary>
        public static void Run(string pathToDTMSetup, string applicationName, bool ignoreWarnings)
        {
            bool isPassed = true;

            isPassed &= StartDTMSetup.Run(pathToDTMSetup);
            isPassed &= WizzardNavigation.Next(ignoreWarnings);
            isPassed &= WizzardNavigation.Next(ignoreWarnings);
            isPassed &= WizzardSelection.LicenceAccept();
            isPassed &= WizzardNavigation.Next(ignoreWarnings);
            isPassed &= WizzardNavigation.Next(ignoreWarnings);
            isPassed &= WizzardSelection.CompleteUpgrade();
            isPassed &= WizzardNavigation.Install();
            isPassed &= WizzardNavigation.Finish();

            if (isPassed)
            {
                isPassed &= TM_GetProgramData.Run(applicationName);
            }
            else
            {
                isPassed &= SetupMessages.CancelMissingFileSetup();
                isPassed &= SetupMessages.CancelFaultySetup();
                isPassed &= WizzardNavigation.Finish();
            }

            if (isPassed)
            {
                Report.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Testcase passed.");
            }
            else
            {
                Report.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Testcase failed.");
            }
        }
    }
}