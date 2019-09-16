// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckThatParameterCannotBeSetToAnInvalidValue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The check that parameter cannot be set invalid or out of range.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Flows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    /// The check that parameter cannot be set invalid or out of range.
    /// </summary>
    public class CheckThatParameterCannotBeSetToAnInvalidValue : ICheckThatParameterCannotBeSetToAnInvalidValue
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks that a parameter cannot be set to an invalid or out of range value.
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to the parameter. Use this form: Micropilot 5x//Setup//Full calibration (4):
        /// </param>
        /// <param name="invalidValue">
        /// An invalid value for this parameter. This could be an out of range value or invalid characters.
        /// </param>
        /// <returns>
        /// True, if the parameter refused the invalid value and was set back to the original value. False, otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(string pathToParameter, string invalidValue)
        {
            Navigation navigationArea = new Navigation();
            navigationArea.SearchAndSelectParameter(pathToParameter);
            Application applicationArea = new Application();
            Unknown element = applicationArea.SearchAndSelectParameter(pathToParameter);

            string controlName = element.Element.GetAttributeValue("ControlType").ToString();
            if (controlName.Equals("CodeWrights.Frameworks.GenericUI.Presentation.DxControls.EddComboBox"))
            {
                Log.Info(string.Format("Parameter: {0} is an Combobox. Invalid value: {1} cannot be set", pathToParameter, invalidValue));
                return true;
            }

            string valueBefore = applicationArea.GetParameterValue(element);
            bool result = applicationArea.SetParameterValue(element, invalidValue, true);
            navigationArea.SearchAndSelectParameter(pathToParameter);
            element = applicationArea.SearchAndSelectParameter(pathToParameter);
            string valueAfter = applicationArea.GetParameterValue(element);
            
            if (result)
            {
                if (valueBefore.Equals(valueAfter))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + pathToParameter + "'did not accept an invalid value('" + invalidValue + "'). Parameter was not changed.");
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + pathToParameter + "' accepted an invalid value('" + invalidValue + "').");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occured.");
            return false;
        }

        #endregion
    }
}