// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsParameterExisting.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class IsParameterExisting.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class IsParameterExisting.
    /// </summary>
    public class IsParameterExisting : IIsParameterExisting
    {
        #region Public Methods and Operators

        /// <summary>
        /// Searches for the specified parameter reports whether it is existing
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to the parameter
        /// </param>
        /// <returns>
        /// True if the parameter exists, false otherwise.
        /// </returns>
        public bool Run(string pathToParameter)
        {
            bool result = false;

            if ((new Navigation()).SearchAndSelectParameter(pathToParameter) == false)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + pathToParameter + " does not exist.");
            }
            else
            {
                string[] separator = { "//" };
                string[] pathParts = pathToParameter.Split(separator, StringSplitOptions.None);
                string parameterName = pathParts[pathParts.Length - 1];

                Parameter parameter = new Application().GetParameter(parameterName);
                if (parameter.ParameterState == ParameterState.NotRecognized)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + pathToParameter + " does not exist.");
                }
                else
                {
                    result = true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + pathToParameter + " exists.");
                }
            }

            return result;
        }

        #endregion
    }
}