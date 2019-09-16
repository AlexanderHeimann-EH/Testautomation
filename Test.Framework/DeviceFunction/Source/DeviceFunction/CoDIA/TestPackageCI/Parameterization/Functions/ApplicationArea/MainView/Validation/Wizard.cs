// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wizard.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class Wizard.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class Wizard.
    /// </summary>
    public class Wizard : IWizard
    {
        #region Public Methods and Operators

        /// <summary>
        /// The is parameter existing.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsParameterExisting(string parameterName)
        {
            bool result = false;
            Application applicationArea = new Application();
            Unknown parameterControl = applicationArea.SearchAndSelectParameter(parameterName);
            
            if (parameterControl != null)
            {
                if (parameterControl.Visible)
                {
                    result = true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("The parameter: {0} exist.", parameterName));
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("The parameter: {0} exist but is not visible.", parameterName));
                }
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("The parameter: {0} does not exist.", parameterName));
            }

            return result;
        }

        /// <summary>
        /// The is image existing.
        /// </summary>
        /// <param name="imageName">
        /// The image name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsImageExisting(string imageName)
        {
            bool result = false;
            Application applicationArea = new Application();
            Unknown parameterControl = applicationArea.SearchAndSelectImage(imageName);
            
            if (parameterControl != null)
            {
                result = true;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("The image: {0} exist.", imageName));
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("The image: {0} does not exist.", imageName));
            }

            return result;
        }

        /// <summary>
        /// The is parameter read only.
        /// </summary>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsParameterReadOnly(string parameterName)
        {
            bool result = false;
            Application applicationArea = new Application();
            Unknown element = applicationArea.SearchAndSelectParameter(parameterName);
            
            if (element != null)
            {
                result = applicationArea.IsParameterReadOnly(element);

                if (result)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("The parameter: {0} is read only.", parameterName));
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("The parameter: {0} is not read only.", parameterName));
                }
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("The parameter: {0} does not exist.", parameterName));
            }

            return result;
        }

        /// <summary>
        /// The is envelope curve button enabled.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsEnvelopeCurveButtonEnabled()
        {
            Button openEnvelopeCurve = new WizardNavigationElements().OpenCreateDocumentation;
            return this.IsButtonEnabled(openEnvelopeCurve);
        }

        /// <summary>
        /// The is create documentation button enabled.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsCreateDocumentationButtonEnabled()
        {
            Button openCreateDocumentation = new WizardNavigationElements().OpenCreateDocumentation;
            return this.IsButtonEnabled(openCreateDocumentation);
        }

        /// <summary>
        /// The is save restrore button enabled.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsSaveRestroreButtonEnabled()
        {
            Button openSaveRestore = new WizardNavigationElements().OpenCreateDocumentation;
            return this.IsButtonEnabled(openSaveRestore);
        }

        /// <summary>
        /// Determines whether the additional settings button is active.
        /// </summary>
        /// <returns><c>true</c> if cancel button is active; otherwise, <c>false</c>.</returns>
        public bool IsAdditionalSettingsButtonActive()
        {
            try
            {
                bool result;
                Button button = new WizardNavigationElements().AdditionalSettings;
                if (button == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Additional settings button is not accessible");
                    result = false;
                }
                else
                {
                    result = button.Enabled;
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Determines whether the cancel button is active.
        /// </summary>
        /// <returns><c>true</c> if cancel button is active; otherwise, <c>false</c>.</returns>
        public bool IsCancelButtonActive()
        {
            try
            {
                bool result;
                Button button = new WizardNavigationElements().Cancel;
                if (button == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cancel button is not accessible");
                    result = false;
                }
                else
                {
                    result = button.Enabled;
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Determines whether the confirm button is active.
        /// </summary>
        /// <returns><c>true</c> if confirm button is active; otherwise, <c>false</c>.</returns>
        public bool IsConfirmButtonActive()
        {
            try
            {
                bool result;
                Button button = new WizardNavigationElements().Confirm;
                if (button == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirm button is not accessible");
                    result = false;
                }
                else
                {
                    result = button.Enabled;
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Determines whether the end of sequence button is active.
        /// </summary>
        /// <returns><c>true</c> if cancel button is active; otherwise, <c>false</c>.</returns>
        public bool IsEndOfSequenceButtonActive()
        {
            try
            {
                bool result;
                Button button = new WizardNavigationElements().EndOfSequence;
                if (button == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End of sequence button is not accessible");
                    result = false;
                }
                else
                {
                    result = button.Enabled;
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Determines whether the Navigation parameter tree is shown.
        /// </summary>
        /// <returns><c>true</c> if Navigation parameter tree is shown; otherwise, <c>false</c>.</returns>
        public bool IsNavigationTreeShown()
        {
            bool result = true;
            Element tree = NavigationElements.NavigationTree;
            if (tree == null)
            {
                result = false;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Navigation tree is not visible.");
            }
            else if (tree.Visible == false)
            {
                result = false;
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Navigation tree is not visible.");
            }

            return result;
        }

        /// <summary>
        /// Determines whether the next button is active.
        /// </summary>
        /// <returns><c>true</c> if Next button is active; otherwise, <c>false</c>.</returns>
        public bool IsNextButtonActive()
        {
            try
            {
                bool result;
                Button button = new WizardNavigationElements().Next;
                if (button == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Next button is not accessible");
                    result = false;
                }
                else
                {
                    result = button.Enabled;
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Determines whether the previous button is active.
        /// </summary>
        /// <returns><c>true</c> if previous button is active; otherwise, <c>false</c>.</returns>
        public bool IsPreviousButtonActive()
        {
            try
            {
                bool result;
                Button button = new WizardNavigationElements().Previous;
                if (button == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Previous button is not accessible");
                    result = false;
                }
                else
                {
                    result = button.Enabled;
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Waits until additional settings button is active.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if additional settings button is active, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilAdditionalSettingsButtonIsActive(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsAdditionalSettingsButtonActive() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Additional settings button still inactive after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Additional settings button became active within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits until cancel button is active.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if cancel button is active, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilCancelButtonIsActive(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsCancelButtonActive() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cancel button still inactive after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cancel button became active within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits until the canceling progress is finished.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> If canceling is finished and the parameter tree is visible again, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilCancelingIsFinished(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            Button previous = new WizardNavigationElements().Previous;
            if (previous == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Previous button is null.");
            }
            else
            {
                watch.Start();

                while (previous.Visible)
                {
                    if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                    {
                        result = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Canceling did not finish within " + timeoutInMilliseconds + " milliseconds.");
                        break;
                    }
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Canceling finished within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits until confirm button is active.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if confirm button is active, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilConfirmButtonIsActive(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsConfirmButtonActive() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirm button still inactive after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Confirm button became active within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits until end of sequence button is active.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if end of sequence button is active, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilEndOfSequenceButtonIsActive(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsEndOfSequenceButtonActive() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End of sequence button still inactive after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End of sequence button became active within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits until next button is active.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if next button is active, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilNextButtonIsActive(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsNextButtonActive() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Next button still inactive after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Next button became active within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits until previous button is active.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if previous button is active, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilPreviousButtonIsActive(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsPreviousButtonActive() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Previous button still inactive after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Previous button became active within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// The is button active.
        /// </summary>
        /// <param name="moduleButtonInWizard">
        /// The module button in wizard.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsButtonEnabled(Button moduleButtonInWizard)
        {
            if (moduleButtonInWizard != null)
            {
                if (moduleButtonInWizard.Enabled)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        #endregion
    }
}