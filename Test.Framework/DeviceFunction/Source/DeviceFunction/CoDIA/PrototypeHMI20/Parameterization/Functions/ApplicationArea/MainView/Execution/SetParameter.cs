// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of SetParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

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
            bool result = false;
            string[] separator = { "//" };
            string[] pathParts = pathToParameter.Split(separator, StringSplitOptions.None);

            if (AppComController.Controller != null)
            {
                if (new SelectParameterAbsolute().Run(pathToParameter))
                {
                    AppComController.Controller.SetStringValue(pathParts[pathParts.Length - 1], inputValue);

                    //Hier sicherstellen, dass die obige Aktion abgeschlossen
                    var watch = new Stopwatch();
                    watch.Start();
                    while (watch.ElapsedMilliseconds < 3000)
                    {
                        //wait
                    }

                    watch.Stop();

                    if (DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation.WaitForDisplayContentChangedAfterSet.Run(15000, pathParts[pathParts.Length - 1], inputValue))
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Recognized display content update. Parameter '{0}' set to '{1}'.", pathToParameter, inputValue));
                        result = true;
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("No display content update. Parameter '{0}' not set to '{1}'.", pathToParameter, inputValue));
                    }
                }

            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Remote host not connected! Please establish a connection first.");
            }

            return result;
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
            return this.Run(pathToParameter, inputValue);
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
                return this.Run(pathToParameter, inputValue);
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