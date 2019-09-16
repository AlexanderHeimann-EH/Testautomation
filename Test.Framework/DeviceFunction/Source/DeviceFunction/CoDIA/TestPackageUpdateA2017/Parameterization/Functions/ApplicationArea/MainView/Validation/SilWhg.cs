// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SilWhg.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class SilWhg.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class SILWHG.
    /// </summary>
    public class SilWhg : ISilWhg
    {
        #region Public Methods and Operators

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
        /// Determines whether the reset SIL sequence start page is shown.
        /// </summary>
        /// <returns><c>true</c> if  reset SIL sequence start page is shown; otherwise, <c>false</c>.</returns>
        public bool IsResetSilSequenceStartPageShown()
        {
            bool result = true;
            Element logo = new WizardNavigationElements().ResetSilSequencePageLogo;
            if (logo == null)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Determines whether the SIL sequence start page is shown.
        /// </summary>
        /// <returns><c>true</c> if SIL sequence start page is shown; otherwise, <c>false</c>.</returns>
        public bool IsSilSequenceStartPageShown()
        {
            bool result = true;
            Element logo = new WizardNavigationElements().SilSequencePageLogo;
            if (logo == null)
            {
                result = false;
            }

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
        /// Waits the until SIL WHG sequence start page is disappeared.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if the page disappears in time, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilResetSilSequenceStartPageIsDisappeared(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsResetSilSequenceStartPageShown())
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SIL WHG sequence start page is still shown after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SIL WHG sequence start page disappeared within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits the until  reset SIL WHG sequence start page is shown.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if the page is shown in time, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilResetSilSequenceStartPageIsShown(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsResetSilSequenceStartPageShown() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SIL WHG sequence start page is still not shown after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SIL WHG sequence start page was shown within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits the until SIL WHG sequence start page is disappeared.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if the page disappears in time, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilSilSequenceStartPageIsDisappeared(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsSilSequenceStartPageShown())
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SIL WHG sequence start page is still shown after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SIL WHG sequence start page disappeared within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        /// <summary>
        /// Waits the until SIL WHG sequence start page is shown.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if the page is shown in time, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilSilSequenceStartPageIsShown(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();

            watch.Start();

            while (this.IsSilSequenceStartPageShown() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SIL WHG sequence start page is still not shown after " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SIL WHG sequence start page was shown within " + timeoutInMilliseconds + " milliseconds.");
            return result;
        }

        #endregion
    }
}