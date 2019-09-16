//------------------------------------------------------------------------------
// <copyright file="CurveReadingReference.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.Flows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Flows;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.Functions.StatusArea.Statusbar.Validation;

    /// <summary>
    ///     Flow: Read ref curve
    /// </summary>
    public class CurveReadingReference : ICurveReadingReference
    {
        /// <summary>
        /// Read ref curve
        /// </summary>
        /// <param name="waitUntilFinished">
        /// The wait Until Finished.
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu(bool waitUntilFinished)
        {
            try
            {
                if (new IsDTMConnected().Run())
                {
                    if ((new RunReadReferenceCurve()).ViaMenu())
                    {
                        // Report info that reading has started
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ref curve reading started");

                        // wait until reading is finished
                        if (waitUntilFinished)
                        {
                            var watch = new Stopwatch();
                            watch.Start();

                            bool isReadingFinished = false;
                            bool isReading = true;

                            while (isReading)
                            {
                                if (watch.ElapsedMilliseconds < DefaultValues.GeneralTimeout)
                                { 
                                    if (!(new ReadAndWrite()).IsReading())
                                    {
                                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Progressbar disabled");
                                        isReadingFinished = true;
                                    }

                                    // Auswertung des bisherigen Ergebnisses
                                    if (isReadingFinished)
                                    {
                                        isReading = false;
                                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                            "ref curve reading finished");
                                    }
                                }
                                else
                                {
                                    isReading = false;
                                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                        "Single reading did not finish within " + DefaultValues.GeneralTimeout + " milliseconds");
                                }
                            }

                            watch.Stop();

                            if (isReadingFinished)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ref reading finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.GeneralTimeout + " milliseconds)");
                                return true;
                            }

                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unknown problem.");
                            return false;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single reading started");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Function [RunReadSingleCurve.ViaMenu] was not Executiond.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not online.");
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