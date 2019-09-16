//------------------------------------------------------------------------------
// <copyright file="GetParameter.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 16.03.2012
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
    public class GetParameter : MarshalByRefObject, IGetParameter
    {
        /// <summary>
        ///     Get a specified parameter with default tree tracing
        /// </summary>
        /// <param name="pathToParameter">Path to parameter</param>
        /// <returns>
        ///     <br>Parameter: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public Parameter Run(string pathToParameter)
        {
            return this.Run(pathToParameter, true);
        }

        /// <summary>
        ///     Get a specified parameter
        /// </summary>
        /// <param name="pathToParameter">Path to parameter including parameter name</param>
        /// <param name="withTreeTracing">Enables / disables tree tracing</param>
        /// <returns>
        ///     <br>Parameter: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public Parameter Run(string pathToParameter, bool withTreeTracing)
        {
            try
            {
                string[] seperator = { "//" };
                string[] pathParts = pathToParameter.Split(seperator, StringSplitOptions.None);
                string parameterName = pathParts[pathParts.Length - 1];
                new Parameter(parameterName);

                if (withTreeTracing)
                {
                    if ((new Navigation()).SearchAndSelectParameter(pathToParameter))
                    {
                        return this.GetAParameter(parameterName);
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter [" + parameterName + "] not found");
                    return null;
                }

                return this.GetAParameter(parameterName);
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        ///     Gets a parameter
        /// </summary>
        /// <param name="parameterName">Name of parameter</param>
        /// <returns>
        ///     <br>Parameter: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        private Parameter GetAParameter(string parameterName)
        {
            return (new Application()).GetParameter(parameterName);
        }
    }
}