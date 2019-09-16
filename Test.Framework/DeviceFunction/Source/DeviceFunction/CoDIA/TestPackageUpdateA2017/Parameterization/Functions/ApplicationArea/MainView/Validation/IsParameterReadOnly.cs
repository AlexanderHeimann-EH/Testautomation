// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsParameterReadOnly.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class IsParameterReadOnly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class IsParameterReadOnly.
    /// </summary>
    public class IsParameterReadOnly : IIsParameterReadOnly
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether a specified parameter is read only.
        /// </summary>
        /// <param name="pathToParameter">
        /// The parameter name and path. E.g. 'Micropilot 5x//Setup//Full calibration (4):'.
        /// </param>
        /// <returns>
        /// <c>true</c> if the parameter is read only, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(string pathToParameter)
        {
            bool result;
            string[] separator = { "//" };
            string[] pathParts = pathToParameter.Split(separator, StringSplitOptions.None);
            string parameterName = pathParts[pathParts.Length - 1];

            if (Execution.Navigation.SearchAndSelectParameter(pathToParameter) == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to find and select the parameter: " + " '" + pathToParameter + "'.");
            }
            else if (Execution.Application.IsParameterReadOnly(parameterName) == false)
            {
                result = false;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + " '" + pathToParameter + "' is not read only.");
            }
            else
            {
                result = true;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + " '" + pathToParameter + "' is read only.");
            }

            return result;
        }

        #endregion
    }
}