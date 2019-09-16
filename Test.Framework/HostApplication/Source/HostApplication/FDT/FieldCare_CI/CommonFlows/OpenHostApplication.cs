//------------------------------------------------------------------------------
// <copyright file="OpenHostApplication.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 25.02.2014
 * Time: 14:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;

    /// <summary>
    ///     Opens HostApplication
    /// </summary>
    /// <returns>true: if application is opened; false: if an error occurred</returns>
    public class OpenHostApplication : IOpenHostApplication
    {
        /// <summary>
        /// Opens FieldCare
        /// </summary>
        /// <returns>true: if fc is opened; false: if an error occurred</returns>
        public bool Run()
        {
            if (Execution.StartFrame.FieldCare())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame is started successfully");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame is not started successfully");
            return false;
        }

        /// <summary>
        /// Opens HostApplication
        /// </summary>
        /// <param name="path">installation path of the HostApplication</param>
        /// <returns>true in case of success;false in case of an error</returns>
        public bool Run(string path)
        {
            if (Execution.StartFrame.FieldCare(path))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame is started successfully");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Frame is not started successfully");
            return false;
        }

        /// <summary>
        /// Opens HostApplication
        /// </summary>
        /// <param name="path">installation path of the HostApplication</param>
        /// <param name="timeOutInMilliseconds">Time for action to finish true in case of success;false in case of an error</param>
        /// <returns>true in case of success;false in case of an error</returns>
        public bool Run(string path, int timeOutInMilliseconds)
        {
            throw new NotImplementedException();
        }
    }
}