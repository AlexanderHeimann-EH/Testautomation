//------------------------------------------------------------------------------
// <copyright file="TC_RepairInstallation.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 03.02.2012
 * Time: 11:22 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

// Summary: 		Repair available installation 

// Precondition: 	- Setup is available
//					- Setup is already installed
// 				 	- Frame is closed

// Postcondition:	- DTM is re-installed
//					- N.A.

// Description:		- Start [Setup].exe
//					- Repair Installation
//					- Finish Installation

using System.Reflection;
using Common.Tools;
using SetupWizzardCoDIADTMs.Dialogs;
using SetupWizzardCoDIADTMs.Functions;
using SetupWizzardCoDIADTMs.Messages;
using Ranorex;

namespace Testlibrary.TestCases.DeviceFunction.Setup
{
    /// <summary>
    ///     Description of TC_RepairInstallation.
    /// </summary>
    public class TC_RepairInstallation
    {
        /// <summary>
        ///     Start execution
        /// </summary>
        public static void Run(string pathToDTMSetup)
        {
            bool isPassed = true;

            isPassed &= StartDTMSetup.Run(pathToDTMSetup);
            isPassed &= WizzardNavigation.Next();
            isPassed &= WizzardSelection.RepairInstallation();
            isPassed &= WizzardNavigation.Install();
            isPassed &= WizzardNavigation.Finish();

            if (!isPassed)
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