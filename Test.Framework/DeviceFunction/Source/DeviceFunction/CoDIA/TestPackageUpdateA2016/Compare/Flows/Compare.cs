// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Compare.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Compare.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Compare.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Compare.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Flow: Run compare and wait until finished
    /// </summary>
    /// <returns>
    ///     <br>True: If call worked fine</br>
    ///     <br>False: If an error occurred</br>
    /// </returns>
    public class Compare : ICompare
    {
        #region Public Methods and Operators

        /// <summary>
        /// Method starts Compare and waits until compare button is enabled again or the user given timeout
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// Specified time for timeout, in seconds
        /// </param>
        /// <returns>
        /// <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            bool compareResult = (new Action()).StartCompare();

            if (compareResult)
            {
                if (timeOutInMilliseconds != 0)
                {
                    if ((new ComparisonProgress()).WaitUntilCompareFinished(timeOutInMilliseconds))
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Comparison finished in time.");
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occurred while comparison.");
                    return false;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Comparison started without waiting until finished.");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compare could not be started. Button not found.");
            return false;
        }

        /// <summary>
        ///     Method starts Compare with waiting until it is finished.
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run()
        {
            return this.Run(DefaultValues.GeneralTimeout);
        }

        #endregion
    }
}