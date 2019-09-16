// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SilWhgFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Go online with focused device
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    ///     Go online with focused device
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class SilWhgFunctions : ISilWhgFunctions
    {
        // ReSharper restore InconsistentNaming
        #region Public Methods and Operators

        /// <summary>
        ///     Click Cancel in Navigation Menu
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                Button button = new WHGSILNavigationElements().Cancel;
                if (button != null && button.Enabled)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking cancel button.");
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cancel button is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Changes a parameter within the SIL/WHG wizard.NOTE: THE PARAMETER MUST BE VISIBLE!
        /// </summary>
        /// <param name="parameterName">
        /// Name of the parameter. E.g. Commissioning: , Set write protection: , Value of simulated distance: etc...
        /// </param>
        /// <param name="parameterValue">
        /// The parameter value.E.g. Expert mode
        /// </param>
        /// <returns>
        /// <c>true</c> if parameter changed, <c>false</c> otherwise.
        /// </returns>
        public bool SetSilWhgParameter(string parameterName, string parameterValue)
        {
            return Execution.Application.SetParameterValue(parameterName, parameterValue, true, 0);
        }

        /// <summary>
        /// Gets a SIL WHG parameter from the SIL WHG wizard.
        /// </summary>
        /// <param name="parameterName">Name of the parameter. E.g. Commissioning: , Set write protection: , Value of simulated distance: etc....</param>
        /// <returns>The value of the parameter.</returns>
        public string GetSilWhgParameter(string parameterName)
        {
            //return Execution.GetParameterValue.Run(parameterName);
            try
            {
                string result = string.Empty;
                Parameter parameter = new Application().GetParameter(parameterName);
                if (parameter == null)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + parameterName + " could not be found");
                }
                else
                {
                    result = parameter.ParameterValue;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The parameter: " + parameterName + " is found");
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }

        /// <summary>
        ///     Click Confirm in Navigation Menu
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool Confirm()
        {
            try
            {
                Button button = new WHGSILNavigationElements().Confirm;
                if (button != null && button.Enabled)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking confirm button.");
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirm button is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Navigates through the parameter tree to the SIL/WHG wizard.
        /// </summary>
        /// <param name="parameterName">
        /// Name of the SIL/WHG parameter shown in the parameter tree. For example: Levelflex FMP5x//Setup//Advanced setup//SIL/WHG confirmation OR Levelflex FMP5x//Setup//Advanced setup//Deactivate SIL/WHG
        /// </param>
        /// <returns>
        /// <c>true</c> if SIL/WHG parameter is found and selected, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool NavigateToSilWhgWizard(string parameterName)
        {
            return Execution.Navigation.SearchAndSelectParameter(parameterName);
        }

        /// <summary>
        ///     Click Next in Navigation Menu
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool Next()
        {
            try
            {
                Button button = new WHGSILNavigationElements().Next;
                if (button != null && button.Enabled)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking next button.");
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Next button is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Click Previous in Navigation Menu
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool Previous()
        {
            try
            {
                Button button = new WHGSILNavigationElements().Previous;
                if (button != null && button.Enabled)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking previous button.");
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Previous button is not accessible");
                return false;
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