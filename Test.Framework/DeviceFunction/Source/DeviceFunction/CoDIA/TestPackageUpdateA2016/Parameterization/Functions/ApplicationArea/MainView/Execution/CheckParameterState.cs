//------------------------------------------------------------------------------
// <copyright file="CheckParameterState.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 21.03.2012
 * Time: 1:28 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Provides functions for application area within module Parameterization
    /// </summary>
    public class CheckParameterState : MarshalByRefObject, ICheckParameterState
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
                return (new Application()).CheckForParameterState(parameterName, parameterState);
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}