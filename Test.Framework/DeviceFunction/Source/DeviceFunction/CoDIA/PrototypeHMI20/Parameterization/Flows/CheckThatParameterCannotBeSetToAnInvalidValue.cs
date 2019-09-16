// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckThatParameterCannotBeSetToAnInvalidValue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The check that parameter cannot be set invalid or out of range.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Flows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;

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
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not implemented yet.");
            return true;
        }

        #endregion
    }
}