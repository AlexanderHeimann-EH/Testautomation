//------------------------------------------------------------------------------
// <copyright file="CurveReadingSingle.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Flows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Flow: Read a single curve
    /// </summary>
    public class CurveReadingSingle : MarshalByRefObject, ICurveReadingSingle
    {
        /// <summary>
        /// Read single curve and check if curve data are updated.
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
                // 2013-06-26 - EC - Changed Type Text to Element
                Element text = (new DiagramElements()).CurveDataNumber;
                if (new IsDTMConnected().Run())
                {
                    if ((new RunReadCurve()).ViaMenu())
                    {
                        // Report info that reading has started
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single reading started");

                        // If should be wait until reading is finished
                        if (waitUntilFinished)
                        {
                            // Check availability of curve number
                            if (text != null)
                            {
                                var watch = new Stopwatch();
                                watch.Start();

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

                                // ReSharper disable RedundantAssignment
                                int curvesNewCount = Convert.ToInt16(curvesNew);
                                // ReSharper restore RedundantAssignment
                                bool isCurveNumberUpdated = false;
                                bool isReadingFinished = false;
                                bool isReading = true;

                                while (isReading)
                                {
                                    if (watch.ElapsedMilliseconds < DefaultValues.GeneralTimeout)
                                    {
                                        // 2013-06-26 - EC - Code replaces code below
                                        curvesNew = text.GetAttributeValueText("WindowText");

                                        // curvesNew = text.TextValue;
                                        separatorPositionNew = curvesNew.IndexOf(Separator, StringComparison.Ordinal);
                                        curvesNew = curvesNew.Substring(0, separatorPositionNew);
                                        curvesNewCount = Convert.ToInt16(curvesNew);

                                        // Prüfe Kurvenzahl
                                        if (curvesNewCount < (curvesIniCount + 1))
                                        {
                                            isCurveNumberUpdated = false;
                                        }
                                        else
                                        {
                                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Curve number updated");
                                            isCurveNumberUpdated = true;
                                        }

                                        if ((new ReadAndWrite()).IsReading())
                                        {
                                            isReadingFinished = false;
                                        }
                                        else
                                        {
                                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Progressbar disabled");
                                            isReadingFinished = true;
                                        }

                                        // Auswertung des bisherigen Ergebnisses
                                        if (isCurveNumberUpdated && isReadingFinished)
                                        {
                                            isReading = false;
                                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                                LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                                "Single reading finished");
                                        }
                                    }
                                    else
                                    {
                                        isReading = false;
                                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                            "Single reading unfinished after timeout");
                                    }
                                }

                                watch.Stop();

                                if (isCurveNumberUpdated == false && isReadingFinished)
                                {
                                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single reading did not finish within " + DefaultValues.GeneralTimeout + " milliseconds");
                                    return false;
                                }

                                if (isCurveNumberUpdated && isReadingFinished == false)
                                {
                                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                        "Unfinished curve reading after timeout.");
                                    return false;
                                }

                                if (isCurveNumberUpdated)
                                {
                                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single reading finished after "  + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.GeneralTimeout + " milliseconds)");
                                    return true;
                                }

                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unknown problem.");
                                return false;
                            }

                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield is not accessable.");
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

        /// <summary>
        /// Read single curve and check if curve data are updated.
        /// </summary>
        /// <param name="waitUntilFinished">
        /// The wait Until Finished.
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaIcon(bool waitUntilFinished)
        {
            try
            {
                // 2013-06-26 - EC - Changed Type Text to Element
                Element text = (new DiagramElements()).CurveDataNumber;

                // HACK:
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                while ((new IsDTMConnected()).Run() == false
                       && stopwatch.ElapsedMilliseconds <= DefaultValues.iTimeoutShort)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM is not connected after " + DefaultValues.iTimeoutMedium + " milliseconds");
                }

                stopwatch.Stop();

                // Check connectivity
                if (new IsDTMConnected().Run())
                {
                    // Start reading via Icon
                    if ((new Functions.MenuArea.Toolbar.Execution.RunReadCurve()).ViaIcon())
                    {
                        // Report info that reading has started
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single reading started");

                        // If should be wait until reading is finished
                        if (waitUntilFinished)
                        {
                            // Check availability of curve number
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Entered if(waituntilFinished)");

                            if (text != null)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Entered if(text != null)");

                                var watch = new Stopwatch();
                                watch.Start();

                                const string Separator = "/";

                                // 2013-06-26 - EC - Code replaces code below
                                string curvesIni = text.GetAttributeValueText("WindowText");

                                // curvesIni = text.textvalue;
                                // 2013-06-26 - EC - Code replaces code below
                                string curvesNew = text.GetAttributeValueText("WindowText");

                                // curvesNew = text.TextValue;
                                int separatorPositionIni = curvesIni.IndexOf(Separator, StringComparison.Ordinal);
                                int separatorPositionNew = curvesNew.IndexOf(Separator, StringComparison.Ordinal);
                                curvesIni = curvesIni.Substring(0, separatorPositionIni);
                                curvesNew = curvesNew.Substring(0, separatorPositionNew);
                                int curvesIniCount = Convert.ToInt16(curvesIni);
                                // ReSharper disable RedundantAssignment
                                int curvesNewCount = Convert.ToInt16(curvesNew);

                                bool isCurveNumberUpdated = false;
                                bool isReadingFinished = false;
                                bool isReading = true;

                                while (isReading)
                                {
                                    if (watch.ElapsedMilliseconds < DefaultValues.GeneralTimeout)
                                    {
                                        // 2013-06-26 - EC - Code replaces code below
                                        curvesNew = text.GetAttributeValueText("WindowText");

                                        // curvesNew = text.TextValue;
                                        separatorPositionNew = curvesNew.IndexOf(Separator, StringComparison.Ordinal);
                                        curvesNew = curvesNew.Substring(0, separatorPositionNew);
                                        curvesNewCount = Convert.ToInt16(curvesNew);

                                        // Prüfe Kurvenzahl
                                        if (curvesNewCount < (curvesIniCount + 1))
                                        {
                                            isCurveNumberUpdated = false;
                                        }
                                        else
                                        {
                                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Curve number updated");
                                            isCurveNumberUpdated = true;
                                        }

                                        if ((new ReadAndWrite()).IsReading())
                                        {
                                            isReadingFinished = false;
                                        }
                                        else
                                        {
                                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Progressbar disabled");
                                            isReadingFinished = true;
                                        }

                                        // Auswertung des bisherigen Ergebnisses
                                        if (isCurveNumberUpdated && isReadingFinished)
                                        {
                                            isReading = false;
                                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                                LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                                "Single reading finished");
                                        }
                                    }
                                    else
                                    {
                                        isReading = false;
                                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                            "Single reading unfinished after timeout");
                                    }
                                }

                                watch.Stop();

                                if (isCurveNumberUpdated == false && isReadingFinished)
                                {
                                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single reading freezed.");
                                    return false;
                                }

                                if (isCurveNumberUpdated && isReadingFinished == false)
                                {
                                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                        "Unfinished curve reading after timeout.");
                                    return false;
                                }

                                if (isCurveNumberUpdated)
                                {
                                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Single reading finished");
                                    return true;
                                }

                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unknown problem.");
                                return false;
                            }

                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield is not accessable.");
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