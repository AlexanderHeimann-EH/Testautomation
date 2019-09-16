// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetParameterStatus.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class GetParameterStatus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Flows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class GetParameterStatus.
    /// </summary>
    public class GetParameterStatus : IGetParameterStatus
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the current status of a specified parameter from the dtm identification area (header).
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name. E.g. "Device tag:".
        /// </param>
        /// <returns>
        /// The current status of the parameter.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string FromHeaderParameter(string parameterName)
        {
            string result;
            var headerParameter = new GetHeaderParameter().Run(parameterName);
            if (headerParameter == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterName + " ' is null. Status cannot be determined.");
                result = "Unknown.";
            }
            else
            {
                result = headerParameter.ParameterState.ToString();
            }

            return result;
        }

        /// <summary>
        /// Gets the current status of a specified parameter from the dtm.
        /// </summary>
        /// <param name="pathToParameter">
        /// The parameter name and path. E.g. 'Micropilot 5x//Setup//Full calibration (4):'.
        /// </param>
        /// <returns>
        /// The current status of the parameter.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string FromParameter(string pathToParameter)
        {
            string result;
            var parameter = new GetParameter().Run(pathToParameter);
            if (parameter == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + pathToParameter + " ' is null. Status cannot be determined.");
                result = "Unknown.";
            }
            else
            {
                result = parameter.ParameterState.ToString();
            }

            return result;
        }

        #endregion
    }
}