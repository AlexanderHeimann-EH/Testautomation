// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 16.03.2012
 * Time: 1:28 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Description of GetParameter.
    /// </summary>
    public class GetParameter : IGetParameter
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to parameter.
        /// </param>
        /// <returns>
        /// The <see cref="Parameter"/>.
        /// </returns>
        public Parameter Run(string pathToParameter)
        {
            try
            {
                Parameter parameter;
                Navigation navigationArea = new Navigation();
                navigationArea.SearchAndSelectParameter(pathToParameter);
                Application applicationArea = new Application();
                parameter = applicationArea.GetParameter(pathToParameter);

                if (parameter == null)
                {
                    Log.Info("The parameter: " + pathToParameter + " does not exist.");
                }
                else
                {
                    Log.Info("The parameter: " + pathToParameter + " exists.");
                    Log.Info(string.Format("Parameter Label: {0}", parameter.ParameterName));
                    Log.Info(string.Format("Parameter Value: {0}", parameter.ParameterValue));
                    Log.Info(string.Format("Parameter State: {0}", parameter.ParameterState));
                    Log.Info(string.Format("Parameter Unit:  {0}", parameter.ParameterUnit));
                }

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