//------------------------------------------------------------------------------
// <copyright file="TC_CustomInstallation.cs" company="Endress+Hauser Process Solutions AG">
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

// Summary: 		Custom installation of specified Device DTMs contained in Setup

// Precondition: 	- Setup is available
// 				 	- Frame is closed

// Postcondition:	- N.A.
//					- N.A.

// Description:		- Start [Setup].exe
//					- Accept Licence Agreement
//					- Choose Custom Installation
//					- Select Devices to install
//					- Finish Installation

using System.Collections.Generic;
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
    ///     Description of TC_CustomInstallation.
    /// </summary>
    public class TC_CustomInstallation
    {
        /// <summary>
        ///     Start testcase
        /// </summary>
        /// <param name="pathToDTMSetup">Path where DTM Setup lies on hard disk</param>
        /// <param name="applicationName">Exact name of DTM Setup under test</param>
        /// <param name="devicesToInstall">Path to file of DeviceDTMs to install</param>
        /// <returns>
        ///     <br>DTM List: If call worked fine</br>
        ///     <br>Null: If an error occured</br>
        /// </returns>
        public static List<string> Run(string pathToDTMSetup, string applicationName, List<string> devicesToInstall)
        {
            bool isPassed = true;

            isPassed &= StartDTMSetup.Run(pathToDTMSetup);
            isPassed &= WizzardNavigation.Next();
            isPassed &= WizzardSelection.LicenceAccept();
            isPassed &= WizzardNavigation.Next();
            isPassed &= WizzardNavigation.Next();
            isPassed &= WizzardSelection.CustomInstallation();
            isPassed &= WizzardSelection.SelectDevices(devicesToInstall);
            isPassed &= WizzardNavigation.Next();
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
                return devicesToInstall;
            }
            Report.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Testcase failed.");
            return null;
        }
    }
}