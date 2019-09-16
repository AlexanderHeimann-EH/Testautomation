// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WizardFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class WizardFunctions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.CreateDocumentation.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;

    using Execution = EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class WizardFunctions.
    /// </summary>
    public class WizardFunctions : IWizardFunctions
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Click Additional Settings in Navigation Menu of the wizard.
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool AdditionalSettings()
        {
            try
            {
                Button button = new WizardNavigationElements().AdditionalSettings;
                if (button != null && button.Enabled)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking additional settings button.");
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Additional settings button is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Click Cancel in Navigation Menu of the wizard.
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
        ///     Click Confirm in Navigation Menu of the wizard.
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
        ///     Click End Of Sequence in Navigation Menu of the wizard.
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool EndOfSequence()
        {
            try
            {
                Button button = new WizardNavigationElements().EndOfSequence;
                if (button != null && button.Enabled)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking End Of Sequence button.");
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End Of Sequence button is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Gets a parameter from a wizard.
        /// </summary>
        /// <param name="parameterName">
        /// Name of the parameter. E.g. Commissioning: , Set write protection: , Value of simulated distance: etc....
        /// </param>
        /// <returns>
        /// The value of the parameter.
        /// </returns>
        public string GetWizardParameterValue(string parameterName)
        {
            try
            {
                string result = string.Empty;
                Application applicationArea = new Application();
                Parameter parameter = applicationArea.GetParameter(parameterName);
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
        /// Navigates to a wizard.
        /// </summary>
        /// <param name="parameterName">
        /// Name of the wizard parameter shown in the parameter tree. For example: Micropilot 5x//Commissioning
        /// </param>
        /// <returns>
        /// <c>true</c> if wizard parameter is found and selected, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool NavigateToWizard(string parameterName)
        {
            return new Navigation().SearchAndSelectParameter(parameterName);
        }

        /// <summary>
        ///     Click Next in Navigation Menu of the wizard.
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
        /// Opens the create documentation.
        /// </summary>
        /// <returns><c>true</c> if module open and ready, <c>false</c> otherwise.</returns>
        public bool OpenCreateDocumentation()
        {
            bool result = false;
            Button openCreateDocumentation = new WizardNavigationElements().OpenCreateDocumentation;

            if (openCreateDocumentation == null || openCreateDocumentation.Enabled == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The button Open Create Documentation is null or not enabled.");
            }
            else
            {
                openCreateDocumentation.Click();

                // Is module opening in time
                if (Validation.ModuleOpeningAndClosing.WaitUntilModuleIsOpen(DefaultValues.GeneralTimeout) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not opened in time.");
                }
                else
                {
                    // Is module online in time
                    if (DeviceFunctionLoader.CoDIA.CreateDocumentation.Functions.StatusArea.Statusbar.Validation.WaitUntilDtmIsConnected.Run(DefaultValues.iTimeoutModules) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not online in time.");
                    }
                    else
                    {
                        // Is module ready in time
                        if (Validation.WaitUntilModuleOnlineIsReady.Run(DefaultValues.iTimeoutModules) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not ready in time.");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is opened and ready to use.");
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Opens the envelope curve.
        /// </summary>
        /// <returns><c>true</c> if module is open and ready, <c>false</c> otherwise.</returns>
        public bool OpenEnvelopeCurve()
        {
            bool result = false;
            Button openEnvelopeCurve = new WizardNavigationElements().OpenEnvelopeCurve;

            if (openEnvelopeCurve == null || openEnvelopeCurve.Enabled == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The button Open Envelope Curve is null or not enabled.");
            }
            else
            {
                openEnvelopeCurve.Click();

                // Is module opening in time
                if (DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation.ModuleOpeningAndClosing.WaitUntilModuleIsOpen(DefaultValues.GeneralTimeout) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not opened in time.");
                }
                else
                {
                    // Is module online in time
                    if (DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.StatusArea.Statusbar.Validation.WaitUntilDtmIsConnected.Run(DefaultValues.iTimeoutModules) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not online in time.");
                    }
                    else
                    {
                        // Is module ready in time
                        if (DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation.WaitUntilModuleOnlineIsReady.Run(DefaultValues.iTimeoutModules) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not ready in time.");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is opened and ready to use.");
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Opens the Open Save Restore.
        /// </summary>
        /// <returns><c>true</c> if module is open and ready, <c>false</c> otherwise.</returns>
        public bool OpenSaveRestore()
        {
            bool result = false;
            Button openSaveRestore = new WizardNavigationElements().OpenSaveRestore;

            if (openSaveRestore == null || openSaveRestore.Enabled == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The button Open Save Restore is null or not enabled.");
            }
            else
            {
                openSaveRestore.Click();

                // Is module opening in time
                if (DeviceFunctionLoader.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Validation.ModuleOpeningAndClosing.WaitUntilModuleIsOpen(DefaultValues.GeneralTimeout) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not opened in time.");
                }
                else
                {
                    // Is module online in time
                    if (DeviceFunctionLoader.CoDIA.SaveRestore.Functions.StatusArea.Statusbar.Validation.WaitUntilDtmIsConnected.Run(DefaultValues.iTimeoutModules) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not online in time.");
                    }
                    else
                    {
                        // Is module ready in time
                        if (DeviceFunctionLoader.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Validation.WaitUntilModuleOnlineIsReady.Run(DefaultValues.iTimeoutModules) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not ready in time.");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is opened and ready to use.");
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        ///     Click Previous in Navigation Menu of the wizard.
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

        /// <summary>
        /// Changes a parameter within a wizard. NOTE: THE PARAMETER MUST BE VISIBLE!
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
        public bool SetWizardParameterValue(string parameterName, string parameterValue)
        {
            return Execution.Application.SetParameterValue(parameterName, parameterValue, true, 0);
        }

        #endregion
    }
}