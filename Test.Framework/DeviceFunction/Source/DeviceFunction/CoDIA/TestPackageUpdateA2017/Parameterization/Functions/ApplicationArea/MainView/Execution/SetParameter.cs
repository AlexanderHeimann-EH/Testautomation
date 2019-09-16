// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of SetParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    ///     Description of SetParameter.
    /// </summary>
    public class SetParameter : ISetParameter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Set a specified parameter
        /// </summary>
        /// <param name="pathToParameter">
        /// Path to parameter including parameter name
        /// </param>
        /// <param name="inputValue">
        /// New value
        /// </param>
        /// <returns>
        /// <br>Parameter: if call worked fine</br>
        /// <br>Null: if an error occurred</br>
        /// </returns>
        public bool Run(string pathToParameter, string inputValue)
        {
            return this.Run(pathToParameter, inputValue, true, true);
        }

        /// <summary>
        /// Set a specified parameter
        /// </summary>
        /// <param name="pathToParameter">
        /// Path to parameter including parameter name
        /// </param>
        /// <param name="inputValue">
        /// New value
        /// </param>
        /// <param name="confirmChange">
        /// Determines whether to confirm the changed value
        /// </param>
        /// <returns>
        /// <br>Parameter: if call worked fine</br>
        /// <br>Null: if an error occurred</br>
        /// </returns>
        public bool Run(string pathToParameter, string inputValue, bool confirmChange)
        {
            return this.Run(pathToParameter, inputValue, true, confirmChange);
        }

        /// <summary>
        /// Set a specified parameter
        /// </summary>
        /// <param name="pathToParameter">
        /// Path to parameter including parameter name
        /// </param>
        /// <param name="inputValue">
        /// New value
        /// </param>
        /// <param name="withTreeTracing">
        /// Enables / disables tree tracing
        /// </param>
        /// <param name="confirmChange">
        /// Determines whether to confirm the changed value
        /// </param>
        /// <returns>
        /// <br>Parameter: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public bool Run(string pathToParameter, string inputValue, bool withTreeTracing, bool confirmChange)
        {
            try
            {
                bool result;
                Navigation navigationArea = new Navigation();
                result = navigationArea.SearchAndSelectParameter(pathToParameter);
                Application applicationArea = new Application();
                Unknown element = applicationArea.SearchAndSelectParameter(pathToParameter);
                result &= applicationArea.SetParameterValue(element, inputValue, confirmChange);
                
                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}