// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaitUntilDTMIsDisconnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The wait until dtm is disconnected.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.StatusArea.Statusbar.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.StatusArea.Statusbar.Validation;

    /// <summary>
    /// The wait until dtm is disconnected.
    /// </summary>
    internal class WaitUntilDTMIsDisconnected : IWaitUntilDTMIsDisconnected
    {
        #region Public Methods and Operators

        /// <summary>
        /// Wait until DTM connection is established and shown by GUI
        /// </summary>
        /// ///
        /// <param name="timeOutInMilliseconds">
        /// Time until action must be performed
        /// </param>
        /// <returns>
        /// <br>True: if module is disconnected</br>
        ///     <br>False: if module is not disconnected</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while ((new IsDTMDisconnected()).Run() == false)
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection is not disconnected after: >" + timeOutInMilliseconds + "Milliseconds.");
                result = false;
                break;
            }

            watch.Stop();

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection disconnected after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            }

            return result;
        }

        #endregion
    }
}