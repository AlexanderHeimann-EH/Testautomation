// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsParameterReadOnly.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class IsParameterReadOnly.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

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
            bool result = false;
            Navigation navigationArea = new Navigation();
            result = navigationArea.SearchAndSelectParameter(pathToParameter);
            Application applicationArea = new Application();
            Unknown element = applicationArea.SearchAndSelectParameter(pathToParameter);
            result &= applicationArea.IsParameterReadOnly(element);

            if (element != null)
            {
                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + " '" + pathToParameter + "' is read only.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + " '" + pathToParameter + "' is not read only.");
                }    
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + " '" + pathToParameter + "' could not be found.");
            }
            
            return result;
        }

        #endregion
    }
}