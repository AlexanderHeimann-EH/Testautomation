//------------------------------------------------------------------------------
// <copyright file="Refresh.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EventList.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EventList.Flows;
    using EH.PCPS.TestAutomation.TestPackageCI.EventList.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.EventList.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    ///     Flow: Refresh data and wait until reading finished
    /// </summary>
    /// <returns>
    ///     <br>True: If call worked fine</br>
    ///     <br>False: If an error occurred</br>
    /// </returns>
    public class Refresh : IRefresh
    {
        /// <summary>
        ///     Method starts refresh, with a default waiting period
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run()
        {
            return this.Run(DefaultValues.iTimeoutLong);
        }

        /// <summary>
        ///     Method starts refresh and waits until refresh button is enabled again or the user given timeout
        /// </summary>
        /// <param name="timeoutInSeconds">Specified time for timeout, in seconds</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(int timeoutInSeconds)
        {
            bool refreshResult = (new RunRefresh()).Run();

            if (refreshResult)
            {
                if (timeoutInSeconds != 0)
                {
                    if ((new WaitUntilModuleOnlineIsReady()).Run(timeoutInSeconds))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Refreshing finished in time.");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occurred while refreshing.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Refreshing started without waiting until finished.");
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Refresh could not be startet. Button not found.");
            return false;
        }
    }
}