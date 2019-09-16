// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadingAndWriting.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Validation methods for read and write operations
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.DipTable.Functions.StatusArea.Statusbar.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.DipTable.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.DipTable.GUI.StatusArea.Statusbar;

    using Ranorex;

    /// <summary>
    /// Validation methods for read and write operations
    /// </summary>
    public class ReadingAndWriting : IReadingAndWriting
    {
        #region Public Methods and Operators

        /// <summary>
        /// Validates whether reading from device started
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// True: if progress bar(buttonOperationInProgress) is != null
        /// </returns>
        public bool HasReadingStarted(int timeoutInMilliseconds)
        {
            bool result = false;
            var stopwatch = new Stopwatch();
            Button button = new StatusbarElements().OperationInProgress;
            stopwatch.Start();
            while (button == null && stopwatch.ElapsedMilliseconds < timeoutInMilliseconds)
            {
                button = new StatusbarElements().OperationInProgress;
            }

            stopwatch.Stop();

            // Progress bar did not appear -> timeout
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading did not start within " + timeoutInMilliseconds + " milliseconds.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading started after " + stopwatch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeoutInMilliseconds + " milliseconds).");
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Validates whether writing from device started
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// True: if progress bar(buttonOperationInProgress) is != null
        /// </returns>
        public bool HasWritingStarted(int timeoutInMilliseconds)
        {
            bool result = false;
            var stopwatch = new Stopwatch();
            Button button = new StatusbarElements().OperationInProgress;
            stopwatch.Start();
            while (button == null && stopwatch.ElapsedMilliseconds < timeoutInMilliseconds)
            {
                button = new StatusbarElements().OperationInProgress;
            }

            stopwatch.Stop();

            // Progress bar did not appear -> timeout
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing did not start within " + timeoutInMilliseconds + " milliseconds.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing started after " + stopwatch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeoutInMilliseconds + " milliseconds).");
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Determines whether [read button is active].
        /// </summary>
        /// <returns><c>true</c> if [read button is active]; otherwise, <c>false</c>.</returns>
        public bool IsReadButtonActive()
        {
            bool result = false;

            Button read = new MainViewElements().ReadButton;

            if (read == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is null");
            }
            else
            {
                if (read.Enabled)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is active");
                    result = true;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is not active");
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether reading is active
        /// </summary>
        /// <returns>
        /// True: if reading is active. False: otherwise
        /// </returns>
        public bool IsReading()
        {
            bool result = false;
            Button button = new StatusbarElements().OperationInProgress;
            if (button == null)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Progress bar not visible. Reading is not active.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading is active.");
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Determines whether [write button is active].
        /// </summary>
        /// <returns><c>true</c> if [write button is active]; otherwise, <c>false</c>.</returns>
        public bool IsWriteButtonActive()
        {
            bool result = false;

            Button write = new MainViewElements().WriteButton;

            if (write == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is null");
            }
            else
            {
                if (write.Enabled)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is active");
                    result = true;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is not active");
                }
            }

            return result;
        }

        /// <summary>
        /// Determines whether reading or writing is active
        /// </summary>
        /// <returns>
        /// True: if reading is active. False: otherwise
        /// </returns>
        public bool IsWriting()
        {
            bool result = false;
            Button button = new StatusbarElements().OperationInProgress;
            if (button == null)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Progress bar not visible. Writing is not active.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing is active.");
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Waits the until read button and write button are active.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if read button and write button are active, <c>false</c> otherwise.
        /// </returns>
        public bool WaitUntilReadButtonAndWriteButtonAreActive(int timeoutInMilliseconds)
        {
            bool result = true;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (this.IsReadButtonActive() == false || this.IsWriteButtonActive() == false)
            {
                if (stopwatch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read and write button did not become active within " + timeoutInMilliseconds + " milliseconds");
                    result = false;
                    break;
                }
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read and write button became active after " + stopwatch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeoutInMilliseconds + " milliseconds).");
            }

            return result;
        }

        /// <summary>
        /// Waits until reading finished
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// True: if reading is finished; False: otherwise
        /// </returns>
        public bool WaitUntilReadingIsFinished(int timeoutInMilliseconds)
        {
            bool result = true;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (this.IsReading())
            {
                if (stopwatch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading did not finish within " + timeoutInMilliseconds + " milliseconds");
                    result = false;
                    break;
                }
            }

            stopwatch.Stop();
            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading finished after " + stopwatch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeoutInMilliseconds + " milliseconds).");
            }

            return result;
        }

        /// <summary>
        /// Waits until writing is finished
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// True: if reading or writing is finished; False: otherwise
        /// </returns>
        public bool WaitUntilWritingIsFinished(int timeoutInMilliseconds)
        {
            bool result = true;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (this.IsWriting())
            {
                if (stopwatch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing did not finish within " + timeoutInMilliseconds + " milliseconds");
                }
            }

            stopwatch.Stop();
            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing finished after " + stopwatch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeoutInMilliseconds + " milliseconds).");
            }

            return result;
        }

        #endregion
    }
}