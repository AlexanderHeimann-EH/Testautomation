//------------------------------------------------------------------------------
// <copyright file="TC_RemoveInstallation.cs" company="Endress+Hauser Process Solutions AG">
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

// Summary: 		Complete installation of all Device DTMs contained in Setup

// Precondition: 	- Setup is available
// 				 	- Frame is closed

// Postcondition:	- DTM is installed
//					- N.A.

// Description:		- Start [Setup].exe
//					- Remove Installation
//					- Finish Installation

using System.Reflection;
using Common.Tools;
using SetupWizzardCoDIADTMs.Dialogs;
using SetupWizzardCoDIADTMs.Functions;
using Ranorex;

namespace Testlibrary.TestCases.DeviceFunction.Setup
{
    /// <summary>
    ///     Description of TC_RemoveInstallation.
    /// </summary>
    public class TC_RemoveInstallation
    {
        /// <summary>
        ///     Start execution
        /// </summary>
        public static void Run(string pathToDTMSetup)
        {
            bool isPassed = true;

            isPassed &= StartDTMSetup.Run(pathToDTMSetup);
            isPassed &= WizzardNavigation.Next();
            isPassed &= WizzardSelection.RemoveInstallation();
            isPassed &= WizzardNavigation.Remove();
            isPassed &= WizzardNavigation.Finish();

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