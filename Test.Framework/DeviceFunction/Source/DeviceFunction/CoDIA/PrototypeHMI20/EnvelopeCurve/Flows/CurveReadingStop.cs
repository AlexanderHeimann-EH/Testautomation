//------------------------------------------------------------------------------
// <copyright file="CurveReadingStop.cs" company="Endress+Hauser Process Solutions AG">
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

    /// <summary>
    ///     Description of CurveReadingStopViaMenu.
    /// </summary>
    public class CurveReadingStop : ICurveReadingStop
    {
        /// <summary>
        ///     Stop curve reading via menu
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaMenu()
        {
            try
            {
                if ((new ReadAndWrite()).IsReading())
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

                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Curve reading did not finish within " + DefaultValues.GeneralTimeout + " milliseconds");
                            watch.Stop();
                            return false;
                        }

                        watch.Stop();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading is finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.GeneralTimeout + " milliseconds)");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not Executiond.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No curve is currently read");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Stop curve reading via icon
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool RunViaIcon()
        {
            try
            {
                if ((new ReadAndWrite()).IsReading())
                {
                    if ((new Functions.MenuArea.Toolbar.Execution.RunEndReadWrite()).ViaIcon())
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
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Curve reading cannot be stopped.");
                            watch.Stop();
                            return false;
                        }

                        watch.Stop();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading is stopped.");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not Executiond.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No curve is currently read");
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