// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaitUntilDTMIsConnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of Application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.Functions.StatusArea.Statusbar.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.StatusArea.Statusbar.Validation;

    /// <summary>
    ///     Description of Application.
    /// </summary>
    public class WaitUntilDtmIsConnected : IWaitUntilDtmIsConnected
    {
        #region Public Methods and Operators

        /// <summary>
        /// Wait until DTM connection is established and shown by GUI
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// Time until action must be performed
        /// </param>
        /// <returns>
        /// <br>True: if module is connected</br>
        ///     <br>False: if module is not connected</br>
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while (new IsDtmConnected().Run() == false)
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection is not established after: >" + timeOutInMilliseconds + "Milliseconds.");
                result = false;
                break;
            }

            watch.Stop();

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection established  after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            }

            return result;
        }

        #endregion
    }
}