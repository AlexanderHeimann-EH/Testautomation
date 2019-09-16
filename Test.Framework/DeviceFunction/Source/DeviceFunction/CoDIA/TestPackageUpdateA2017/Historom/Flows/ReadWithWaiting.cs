//------------------------------------------------------------------------------
// <copyright file="ReadWithWaiting.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Flows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.StatusArea.Statusbar.Validation;

    using Ranorex;

    /// <summary>
    ///     Flow: Reading event list with waiting until reading is finished
    /// </summary>
    public class ReadWithWaiting : IReadWithWaiting
    {
        /// <summary>
        ///     Read event list within a default time
        /// </summary>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool RunViaIcon()
        {
            return this.RunViaIcon(DefaultValues.GeneralTimeout);
        }

        /// <summary>
        ///     Read event list within a specific time
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time within reading must be finished</param>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool RunViaIcon(int timeOutInMilliseconds)
        {
            try
            {
                if (new IsDTMConnected().Run())
                {
                    if (new RunRead().ViaIcon())
                    {
                        if (new EventlistOperations().IsReadStarted(DefaultValues.iTimeoutLong))
                        {
                            if (new EventlistOperations().WaitUntilReadFinished(timeOutInMilliseconds))
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading finished");
                                return true;
                            }

                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                "Reading did not finish within given time");
                            return false;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading did not start");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read icon could not be clicked");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM not connected! ");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}