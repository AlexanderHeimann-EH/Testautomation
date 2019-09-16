// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventlistOperations.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.GUI.MenuArea.Toolbar;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.GUI.StatusArea.Statusbar;

    using Ranorex;

    /// <summary>
    ///     Description of event list operations.
    /// </summary>
    public class EventlistOperations : IEventlistOperations
    {
        /// <summary>
        ///     Searches for button "Operation in Progress" in the lower status bar of the module(found while reading)
        /// </summary>
        /// <returns>
        ///     true: if button is found
        ///     false: if button is not found
        /// </returns>
        public bool IsOperationInProgress()
        {
            Button operationInProgress = new StatusBarElements().ButtonOperationInProgress;
            return operationInProgress != null;
        }

        /// <summary>
        ///     Waits until HISTOROM event list reading is finished
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time within module should be ready</param>
        /// <returns>
        ///     <br>True: if reading is finished in time</br>
        ///     <br>False: if reading is not finished in time</br>
        /// </returns>
        public bool WaitUntilReadFinished(int timeOutInMilliseconds)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (this.IsReading() && this.IsReadFinished() == false)
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Eventlist reading did not finish within " + timeOutInMilliseconds + " milliseconds");
                watch.Stop();
                return false;
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Eventlist reading finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            return true;
        }

        /// <summary>
        ///     Checks if Reading is started, progress bar must be visible one time, cancel button active, read inactive
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time within reading should have started</param>
        /// <returns>
        ///     <br>True: if reading has started (progress bar is visible,cancel active, read inactive)</br>
        ///     <br>False: if reading has not started in time</br>
        /// </returns>
        public bool IsReadStarted(int timeOutInMilliseconds)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
            {
                // if(IsProgressbarVisible() && IsCancelButtonActive() && IsReadButtonActive() == false)
                if (this.IsReadButtonActive() == false && this.IsCancelButtonActive() && this.IsOperationInProgress())
                {
                    return true;
                }
            }

            watch.Stop();
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading not started!Check button read/cancel and the progressbar");
            return false;
        }

        /// <summary>
        ///     Checks if Reading is finished on the basis of read and cancel buttons and the progress bar
        /// </summary>
        /// <returns>
        ///     true: when button read is active, cancel inactive and progress bar is not visible
        ///     false: when state is not as mentioned above
        /// </returns>
        public bool IsReadFinished()
        {
            // if(IsCancelButtonActive() == false && IsProgressbarVisible() == false && IsReadButtonActive())
            return this.IsCancelButtonActive() == false && this.IsOperationInProgress() == false && this.IsReadButtonActive();
        }

        /// <summary>
        ///     Checks if HISTOROM is in reading mode: progress bar must be visible, cancel button active and read button inactive
        /// </summary>
        /// <returns>
        ///     <br>True: if module is reading curves</br>
        ///     <br>False: if module is not reading curves</br>
        /// </returns>
        public bool IsReading()
        {
            if (this.IsCancelButtonActive() == false)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading may be finished, button Cancel is inactive");
                return false;
            }

            if (this.IsReadButtonActive())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading may be finished, button Read is active");
                return false;
            }

            if (this.IsOperationInProgress() == false)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading may be finished, Progressbar is not visible");
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Checks whether event list is empty or not
        /// </summary>
        /// <returns>
        ///     true if list is empty
        ///     false if list is not empty
        /// </returns>
        public bool IsEventlistEmpty()
        {
            return (new TableElements()).FindFirstEvent() == false;
        }

        /// <summary>
        ///     Determines whether the read button in toolbar is active/inactive
        /// </summary>
        /// <returns>
        ///     true: if button is enabled
        ///     false: if button is not enabled
        /// </returns>
        public bool IsReadButtonActive()
        {
            Button button = new ToolbarElements().ButtonRead;
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button == null!");
                return false;
            }

            return button.Enabled;
        }

        /// <summary>
        ///     Determines whether the cancel button in toolbar is active/inactive
        /// </summary>
        /// <returns>
        ///     true: if button is enabled
        ///     false: if button is not enabled
        /// </returns>
        public bool IsCancelButtonActive()
        {
            Button button = new ToolbarElements().ButtonCancel;
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cancel button == null!");
                return false;
            }

            return button.Enabled;
        }
    }
}