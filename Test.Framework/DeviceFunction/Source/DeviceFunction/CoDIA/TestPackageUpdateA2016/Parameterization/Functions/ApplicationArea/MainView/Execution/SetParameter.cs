// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

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
        /// <param name="pathToParameter">Path to parameter including parameter name</param>
        /// <param name="inputValue">New value</param>
        /// <param name="confirmChange">Determines whether to confirm the changed value</param>
        /// <returns><br>Parameter: if call worked fine</br>
        /// <br>Null: if an error occurred</br></returns>
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
        /// <param name="confirmChange">Determines whether to confirm the changed value</param>
        /// <returns>
        /// <br>Parameter: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public bool Run(string pathToParameter, string inputValue, bool withTreeTracing, bool confirmChange)
        {
            try
            {
                string[] separator = { "//" };
                string[] pathParts = pathToParameter.Split(separator, StringSplitOptions.None);
                string parameterName = pathParts[pathParts.Length - 1];
                parameterName = parameterName.Replace("\\", string.Empty); // added seg

                if (withTreeTracing)
                {
                    if ((new Navigation()).SearchAndSelectParameter(pathToParameter))
                    {
                        return this.SetParameterToValue(parameterName, inputValue, confirmChange);
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter [" + parameterName + "] not found");
                    return false;
                }

                return this.SetParameterToValue(parameterName, inputValue, confirmChange);
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets a parameter
        /// </summary>
        /// <param name="parameterName">
        /// Part of path to parameter
        /// </param>
        /// <param name="inputValue">
        /// new value
        /// </param>
        /// <param name="confirm">Determines whether to confirm the changed value</param>
        /// <returns>
        /// <br>String: if call worked fine</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        private bool SetParameterToValue(string parameterName, string inputValue, bool confirm)
        {
            if ((new Application()).SetParameterValue(parameterName, inputValue, confirm))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter [" + parameterName + "] set to [" + inputValue + "].");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter [" + parameterName + "] not set to [" + inputValue + "].");
            return false;
        }

        #endregion
    }
}