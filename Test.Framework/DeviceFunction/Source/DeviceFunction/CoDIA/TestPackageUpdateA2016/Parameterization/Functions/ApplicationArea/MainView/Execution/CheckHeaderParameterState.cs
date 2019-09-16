//------------------------------------------------------------------------------
// <copyright file="CheckHeaderParameterState.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 06.07.2012
 * Time: 1:28 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides functions for identification area within module Parameterization
    /// </summary>
    public class CheckHeaderParameterState : MarshalByRefObject, ICheckHeaderParameterState
    {
        /// <summary>
        ///     Function check header parameter state
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
                return (new Identification()).CheckParameterForState(parameterName, parameterState);
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}