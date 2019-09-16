//------------------------------------------------------------------------------
// <copyright file="CurveReadingCyclic.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.Flows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Flows;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    ///     Flow: Cyclic reading that stops after a specified number of recorded curves.
    /// </summary>
    /// <returns>
    ///     <br>True: If call worked fine</br>
    ///     <br>False: If an error occurred</br>
    /// </returns>
    public class CurveReadingCyclic : ICurveReadingCyclic
    {
        /// <summary>
        ///     Run cyclic curve reading
        /// </summary>
        /// <param name="numberOfCurves">Number of curves to read</param>
        /// <param name="waitUntilFinished">Configure if should be waited until a curve is read or not</param>
        /// <returns>true: if execution worked, false: if an error occurred</returns>
        public bool RunViaMenu(int numberOfCurves, bool waitUntilFinished)
        {
            try
            {
                // 2013-06-26 - EC - Changed Type Text to Element
                Element text = (new DiagramElements()).CurveDataNumber;
                if (new IsDTMConnected().Run())
                {
                    if ((new RunCyclicRead()).ViaMenu())
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cyclic reading started");
                        if (text != null)
                        {
                            const string Separator = "/";

                            // 2013-06-26 - EC - Code replaces code below
                            string curvesIni = text.GetAttributeValueText("WindowText");

                            // curvesIni = text.TextValue;
                            // 2013-06-26 - EC - Code replaces code below
                            string curvesNew = text.GetAttributeValueText("WindowText");

                            // curvesNew = text.TextValue;
                            int separatorPositionIni = curvesIni.IndexOf(Separator, StringComparison.Ordinal);
                            int separatorPositionNew = curvesNew.IndexOf(Separator, StringComparison.Ordinal);
                            curvesIni = curvesIni.Substring(0, separatorPositionIni);
                            curvesNew = curvesNew.Substring(0, separatorPositionNew);
                            int curvesIniCount = Convert.ToInt16(curvesIni);
                            int curvesNewCount = Convert.ToInt16(curvesNew);
                            while (curvesNewCount < (curvesIniCount + numberOfCurves))
                            {
                                // 2013-06-26 - EC - Code replaces code below
                                curvesNew = text.GetAttributeValueText("WindowText");

                                // curvesNew = text.TextValue;
                                separatorPositionNew = curvesNew.IndexOf(Separator, StringComparison.Ordinal);
                                curvesNew = curvesNew.Substring(0, separatorPositionNew);
                                curvesNewCount = Convert.ToInt16(curvesNew);
                            }

                            if (waitUntilFinished)
                            {
                                if ((new RunEndReadWrite()).ViaMenu())
                                {
                                    var watch = new Stopwatch();
                                    watch.Start();
                                    while ((new ReadAndWrite()).IsReading())
                                    {
                                        if (watch.ElapsedMilliseconds <= DefaultValues.GeneralTimeout)
                                        {
                                            continue;
                                        }

                                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cyclic reading did not finish within " + DefaultValues.GeneralTimeout + " milliseconds");
                                        watch.Stop();
                                        return false;
                                    }

                                    watch.Stop();
                                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cyclic reading finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.GeneralTimeout + " milliseconds)");
                                    return true;
                                }

                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "Function [RunEndReadWrite.ViaMenu] was not Executiond.");
                                return false;
                            }

                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cyclic reading started");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield is not accessable.");
                        return false;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Function [RunCyclicReading.ViaMenu] was not Executiond.");
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