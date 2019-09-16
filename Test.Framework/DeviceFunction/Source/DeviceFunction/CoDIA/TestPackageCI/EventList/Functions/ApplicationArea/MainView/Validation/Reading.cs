// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Reading.cs" company="PCPS">
//  Endress + Hauser 
// </copyright>
// <summary>
//   The reading.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.EventList.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EventList.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.EventList.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// The reading.
    /// </summary>
    public class Reading : IReading
    {
        /// <summary>
        ///     Waits until reading is finished
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time within module should be ready</param>
        /// <returns>
        ///     <br>True: if reading is finished in time</br>
        ///     <br>False: if module is not finished in time</br>
        /// </returns>
        public bool WaitUntilReadingFinished(int timeOutInMilliseconds)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (this.IsReading())
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Data reading did not finish within " + timeOutInMilliseconds + " milliseconds");
                watch.Stop();
                return false;
            }

            watch.Stop();
            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Data reading finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            return true;
        }

        /// <summary>
        ///     Checks if reading is active
        /// </summary>
        /// <returns>
        ///     <br>True: if reading is active</br>
        ///     <br>False: if reading is inactive</br>
        /// </returns>
        public bool IsReading()
        {
            Element element = (new ActionElements()).Refresh;
            if (element != null)
            {
                return !element.Enabled;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button was not available.");
            return true;
        }
    }
}