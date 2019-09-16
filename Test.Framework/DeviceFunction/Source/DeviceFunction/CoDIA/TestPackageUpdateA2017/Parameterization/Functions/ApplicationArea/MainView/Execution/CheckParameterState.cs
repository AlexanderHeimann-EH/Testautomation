// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckParameterState.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 21.03.2012
 * Time: 1:28 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides functions for application area within module Parameterization
    /// </summary>
    public class CheckParameterState : ICheckParameterState
    {
        /// <summary>
        ///     Function check parameter state
        /// </summary>
        /// <param name="parameterName">Parameter to check</param>
        /// <param name="parameterState">Expected state</param>
        /// <returns>
        ///     <br>True: if call worded fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(string parameterName, string parameterState)
        {
            try
            {
                Navigation navigationArea = new Navigation();
                navigationArea.SearchAndSelectParameter(parameterName);
                Application applicationArea = new Application();
                return applicationArea.CheckForParameterState(parameterName, parameterState);
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}