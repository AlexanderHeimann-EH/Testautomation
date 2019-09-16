// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckParameterLockingState.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CheckParameterLockingState.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Flows
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class CheckParameterLockingState.
    /// </summary>
    public class CheckParameterLockingState : ICheckParameterLockingState
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks the locking state of a list of parameter. They can either be read only or writable.
        /// </summary>
        /// <param name="pathToParameter">
        /// A list with paths to parameter. A path looks like this: Micropilot 5x//Setup//Full calibration (4).
        /// </param>
        /// <param name="shouldBeReadOnly">
        /// The expected locking state of the parameter. True = read only; False = write able.
        /// </param>
        /// <returns>
        /// <c>true</c> if all parameter have the expected locking state, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(List<string> pathToParameter, bool shouldBeReadOnly)
        {
            bool result = true;

            foreach (var path in pathToParameter)
            {
                if (Validation.IsParameterReadOnly.Run(path) != shouldBeReadOnly)
                {
                    result = false;
                    if (shouldBeReadOnly)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter '" + path + "' is not read only.");
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter '" + path + "' is not write able.");
                    }
                }
            }

            return result;
        }

        #endregion
    }
}