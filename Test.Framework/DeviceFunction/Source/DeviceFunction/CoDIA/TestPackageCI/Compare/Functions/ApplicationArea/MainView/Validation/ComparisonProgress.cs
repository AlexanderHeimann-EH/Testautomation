// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComparisonProgress.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Compare.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.Compare.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageCI.Compare.GUI.StatusArea.Statusbar;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for checking comparison progress
    /// </summary>
    public class ComparisonProgress : IComparisonProgress
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Checks if comparison is finished
        /// </summary>
        /// <returns>
        ///     <br>True: if comparison is finished</br>
        ///     <br>False: if comparison is not finished</br>
        /// </returns>
        public bool IsComparing()
        {
            bool result = true;
            Button button = new ActionElements().ButtonCompare;
            Button progressBar = new StatusbarElements().ComparisonProgress;
            if (button == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compare button is null and not available.");
            }
            else
            {
                if (button.Enabled || progressBar == null)
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Comparison is not in progress.");
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Comparison is in progress.");
                }
            }
            
            return result;
        }

        /// <summary>
        /// Wait until compare is finished within a specified time
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// Time within action must be finished
        /// </param>
        /// <returns>
        /// <br>True: if comparison is finished in time</br>
        ///     <br>False: if comparison is not finished in time</br>
        /// </returns>
        public bool WaitUntilCompareFinished(int timeOutInMilliseconds)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (this.IsComparing())
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Comparing not finished after " + timeOutInMilliseconds + " milliseconds");
                watch.Stop();
                return false;
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Comparing finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            return true;
        }

        #endregion
    }
}