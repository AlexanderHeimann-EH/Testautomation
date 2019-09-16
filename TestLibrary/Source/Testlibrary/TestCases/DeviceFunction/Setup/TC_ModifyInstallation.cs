//------------------------------------------------------------------------------
// <copyright file="TC_ModifyInstallation.cs" company="Endress+Hauser Process Solutions AG">
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

// Summary: 		Modify installation by select and deselct 
//					Device DTMs to install or remove.

// Precondition: 	- Setup is available
//					- Setup is installed
// 				 	- Frame is closed

// Postcondition:	- Installation is modified
//					- N.A.

// Description:		- Start [Setup].exe
//					- Select / deselect DeviceDTMs
//					- Execute installation
//					- Finish Installation

using System.Collections.Generic;
using System.Reflection;
using Common.Tools;
using SetupWizzardCoDIADTMs.Dialogs;
using SetupWizzardCoDIADTMs.Functions;
using SetupWizzardCoDIADTMs.Messages;
using Ranorex;

namespace Testlibrary.TestCases.DeviceFunction.Setup
{
    /// <summary>
    ///     Description of TC_ModifyInstallation.
    /// </summary>
    public class TC_ModifyInstallation
    {
        /// <summary>
        ///     Start execution
        /// </summary>
        public static List<string> Run(string pathToDTMSetup, List<string> devicesToInstall)
        {
            bool isPassed = true;

            isPassed &= StartDTMSetup.Run(pathToDTMSetup);
            isPassed &= WizzardNavigation.Next();
            isPassed &= WizzardSelection.ModifyInstallation();
            isPassed &= WizzardSelection.SelectDevices(devicesToInstall);
            isPassed &= WizzardNavigation.Next();
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
                return devicesToInstall;
            }
            Report.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Testcase failed.");
            return null;
        }
    }
}