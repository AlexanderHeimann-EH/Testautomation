// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadAndWrite.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurve.GUI.StatusArea.Statusbar;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Validation methods for all read and write related actions
    /// </summary>
    public class ReadAndWrite : IReadAndWrite
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether progress bar is visible or not
        /// </summary>
        /// <returns>true: if it is, false if not</returns>
        public bool IsProgressbarVisible()
        {
            Button progress = (new StatusbarElements()).OperationInProgress;
            return progress != null;
        }

        /// <summary>
        ///     Checks if envelope curve is in reading mode
        /// </summary>
        /// <returns>
        ///     <br>True: if module is reading curves</br>
        ///     <br>False: if module is not reading curves</br>
        /// </returns>
        public bool IsReading()
        {
            return this.IsProgressbarVisible() || this.IsReadyToStopReading();
        }

        /// <summary>
        ///     Checks if stop reading button is enabled and accessible
        /// </summary>
        /// <returns>
        ///     <br>True: if module is ready to stop reading</br>
        ///     <br>False: if module is not ready to stop reading</br>
        /// </returns>
        public bool IsReadyToStopReading()
        {
            Button icon = (new Elements()).BtnEndRead;
            return icon != null && icon.Enabled;
        }

        /// <summary>
        ///     Checks if envelope curve is in MAP writing mode
        /// </summary>
        /// <returns>
        ///     <br>True: if module is writing MAP</br>
        ///     <br>False: if module is not writing MAP</br>
        /// </returns>
        public bool IsWritingMAP()
        {
            return this.IsProgressbarVisible() || this.IsReadyToStopReading();
        }

        /// <summary>
        /// Waits until Read-Curve is finished
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// Time within module should be ready
        /// </param>
        /// <returns>
        /// <br>True: if reading is finished in time</br>
        ///     <br>False: if reading is not finished in time</br>
        /// </returns>
        public bool WaitUntilReadFinished(int timeOutInMilliseconds)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (this.IsReading())
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single curve reading did not finish within " + timeOutInMilliseconds + " milliseconds");
                watch.Stop();
                return false;
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Curve reading finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            return true;
        }

        #endregion
    }
}