//------------------------------------------------------------------------------
// <copyright file="GetHeaderParameter.cs" company="Endress+Hauser Process Solutions AG">
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

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Description of GetParameter.
    /// </summary>
    public class GetHeaderParameter : MarshalByRefObject, IGetHeaderParameter
    {
        /// <summary>
        ///     Function: Get a specific parameter
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <returns>
        ///     <br>Parameter: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public Parameter Run(string parameterName)
        {
            try
            {
                Parameter parameter = (new Identification()).GetHeaderParameter(parameterName);
                return parameter;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}