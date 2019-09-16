

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Class WaitXSeconds.
    /// </summary>
    public static class WaitXSeconds
    {
        /// <summary>
        /// Waits for 10 seconds.
        /// </summary>
        /// <returns><c>true</c> if waiting finished.</returns>
        public static bool Run()
        {
            bool waitingFinished = false;
            var watch = new Stopwatch();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting for 10 seconds.");
            watch.Start();
            while (waitingFinished == false)
            {
                if (watch.ElapsedMilliseconds >= 10000)
                {
                    waitingFinished = true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting finished.");
                }
            }

            return true;
        }

        /// <summary>
        /// Waits for a specified amount of seconds.
        /// </summary>
        /// <param name="secondsToWait">
        /// The amount of seconds to wait.
        /// </param>
        /// <returns>
        /// <c>true</c> if waiting finished.
        /// </returns>
        public static bool Run(int secondsToWait)
        {
            bool waitingFinished = false;
            var watch = new Stopwatch();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting for " + secondsToWait + " seconds.");
            watch.Start();
            while (waitingFinished == false)
            {
                if (watch.ElapsedMilliseconds >= secondsToWait)
                {
                    waitingFinished = true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Waiting finished.");
                }
            }

            return true;
        }
    }
}
