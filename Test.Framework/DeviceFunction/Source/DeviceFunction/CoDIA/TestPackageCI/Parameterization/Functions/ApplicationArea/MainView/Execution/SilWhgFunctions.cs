// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SilWhgFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Go online with focused device
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView;

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
                Button button = new WizardNavigationElements().Cancel;
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
            Application applicationArea = new Application();
            Unknown element = applicationArea.SearchAndSelectParameter(parameterName);
            return applicationArea.SetParameterValue(element, parameterValue, true);
        }

        /// <summary>
        /// Gets a SIL WHG parameter from the SIL WHG wizard.
        /// </summary>
        /// <param name="parameterName">Name of the parameter. E.g. Commissioning: , Set write protection: , Value of simulated distance: etc....</param>
        /// <returns>The value of the parameter.</returns>
        public string GetSilWhgParameter(string parameterName)
        {            
            try
            {
                Application applicationArea = new Application();
                Unknown element = applicationArea.SearchAndSelectParameter(parameterName);
                string result = applicationArea.GetParameterValue(element);
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
                Button button = new WizardNavigationElements().Confirm;
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
                Button button = new WizardNavigationElements().Next;
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
                Button button = new WizardNavigationElements().Previous;
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