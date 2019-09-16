//------------------------------------------------------------------------------
// <copyright file="SelectParameter.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.03.2012
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
    ///     Description of SelectParameter.
    /// </summary>
    public class SelectParameter : MarshalByRefObject, ISelectParameter
    {
        /// <summary>
        /// Selects specified parameter
        /// </summary>
        /// <param name="pathToParameter">Path to parameter including parameter name. Use this form: Setup//Advanced setup//Locking status:</param>
        /// <returns>
        /// true: when parameter was found and selected
        /// false: if an error occurred
        /// </returns>
        public bool Run(string pathToParameter)
        {
            try
            {
                string[] seperator = { "//" };
                string[] pathParts = pathToParameter.Split(seperator, StringSplitOptions.None);
                string parameterName = pathParts[pathParts.Length - 1];
                
                new Parameter(parameterName);
                
                if ((new Navigation()).SearchAndSelectParameter(pathToParameter))
                {
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter [" + parameterName + "] is not available");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}