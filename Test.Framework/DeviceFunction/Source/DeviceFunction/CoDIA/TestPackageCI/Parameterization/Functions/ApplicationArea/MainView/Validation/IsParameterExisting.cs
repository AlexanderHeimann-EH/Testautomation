// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsParameterExisting.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class IsParameterExisting.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution;

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
            Parameter parameter = new GetParameter().Run(pathToParameter);
            if (parameter != null)
            {
                result = true;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + pathToParameter + " exists.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + pathToParameter + " does not exist.");
            }

            return result;
        }

        #endregion
    }
}