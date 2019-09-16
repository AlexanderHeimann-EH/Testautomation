// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CurveReadingCyclic.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.Flows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.GUI.ApplicationArea.MainView;

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
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cyclic reading started");
                        if (text != null)
                        {
                            const string Separator = "/";

                            string curvesIni = text.GetAttributeValueText("WindowText");
                            string curvesNew = text.GetAttributeValueText("WindowText");
                            int separatorPositionIni = -1;
                            int curvesIniCount = -1;
                            int separatorPositionNew = -1;
                            int curvesNewCount = -1;

                            if (curvesIni != null)
                            {
                                separatorPositionIni = curvesIni.IndexOf(Separator, StringComparison.Ordinal);
                                curvesIni = curvesIni.Substring(0, separatorPositionIni);
                                curvesIniCount = Convert.ToInt16(curvesIni);
                            }

                            if (curvesNew != null)
                            {
                                separatorPositionNew = curvesNew.IndexOf(Separator, StringComparison.Ordinal);
                                curvesNew = curvesNew.Substring(0, separatorPositionNew);
                                curvesNewCount = Convert.ToInt16(curvesNew);
                            }
                            
                            while (curvesNewCount < (curvesIniCount + numberOfCurves))
                            {
                                string curveReminder = curvesNew;
                                curvesNew = text.GetAttributeValueText("WindowText");

                                if (curvesNew != null)
                                {
                                    separatorPositionNew = curvesNew.IndexOf(Separator, StringComparison.Ordinal);
                                    curvesNew = curvesNew.Substring(0, separatorPositionNew);
                                    curvesNewCount = Convert.ToInt16(curvesNew);
                                }
                                else
                                {
                                    curvesNew = curveReminder;
                                }
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

                                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cyclic reading did not finish within " + DefaultValues.GeneralTimeout + " milliseconds");
                                        watch.Stop();
                                        return false;
                                    }

                                    watch.Stop();
                                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cyclic reading finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.GeneralTimeout + " milliseconds)");
                                    return true;
                                }

                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function [RunEndReadWrite.ViaMenu] was not Executiond.");
                                return false;
                            }

                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cyclic reading started");
                            return true;
                        }

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield is not accessable.");
                        return false;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function [RunCyclicReading.ViaMenu] was not Executiond.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not online.");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}