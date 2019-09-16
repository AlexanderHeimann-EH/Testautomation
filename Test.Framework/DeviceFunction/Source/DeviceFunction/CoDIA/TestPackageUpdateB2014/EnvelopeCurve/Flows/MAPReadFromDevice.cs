//------------------------------------------------------------------------------
// <copyright file="MAPReadFromDevice.cs" company="Endress+Hauser Process Solutions AG">
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
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.MenuArea.Menubar;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;

    using Ranorex;

    /// <summary>
    ///     Flow: Read MAP from device and wait until reading finished
    /// </summary>
    public class MAPReadFromDevice : MarshalByRefObject, IMAPReadFromDevice
    {
        ///// <summary>
        /////     Read MAP from device
        ///// </summary>
        ///// <returns>
        /////     <br>True: If call worked fine</br>
        /////     <br>False: If an error occurred</br>
        ///// </returns>
        ////public bool Run()
        ////{
        //    try
        //    {
        //        if ((new GridColor()).IsGridYellow())
        //        {
        //            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Grid is yellow");
        //            if ((new RunEditMAP()).ViaMenu())
        //            {
        //                var watch = new Stopwatch();
        //                watch.Start();

        ////                bool isReading = true;
        ////                bool isReadingFinished = false;
        ////                bool isGridGreen = false;

        ////                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP reading is startet");

        ////                while (isReading)
        //                {
        //                    if (watch.ElapsedMilliseconds < DefaultValues.GeneralTimeout)
        //                    {
        //                        // prüfen ob Grid grün ist
        //                        if ((new GridColor()).IsGridGreen())
        //                        {
        //                            isGridGreen = true;
        //                        }
        //                        if ((new ReadAndWrite()).IsProgressbarVisible() == false)
        //                        {
        //                            isReadingFinished = true;
        //                        }
        //                        if (isGridGreen && isReadingFinished)
        //                        {
        //                            isReading = false;
        //                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP reading finished");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        isReading = false;
        //                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
        //                                    "MAP reading unfinished after timeout");
        //                    }
        //                }
        //                watch.Stop();

        ////                if ((isGridGreen == false) && isReadingFinished)
        //                {
        //                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP reading freezed.");
        //                    return false;
        //                }
        //                if (isGridGreen && (isReadingFinished == false))
        //                {
        //                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
        //                                   "Unfinished MAP reading after timeout.");
        //                    return false;
        //                }
        //                if (isGridGreen)
        //                {
        //                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP reading finished");
        //                    return true;
        //                }
        //                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unknown problem.");
        //                return false;
        //            }
        //            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
        //                           "Function is not Executiond. Ensure that at least one curve is previously read.");
        //            return false;
        //        }
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP is in Edit Mode.");
        //        return false;
        //    }
        //    catch (Exception exception)
        //    {
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        //        return false;
        //    }
        ////}

        /// <summary>
        ///     Read MAP from device
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run()
        {
            try
            {
                if (!Validation.IsEditMapActive.IsActive())
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Edit map is not active");
                    if ((new RunEditMAP()).ViaMenu())
                    {
                        var watch = new Stopwatch();
                        watch.Start();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP reading is started");

                        while (
                            DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation
                                                .ReadAndWrite.IsReading())
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.GeneralTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "MAP reading did not finish within " + DefaultValues.GeneralTimeout + "milliseconds"); 
                                watch.Stop();
                                return false;
                            }
                        }

                        watch.Stop();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP reading finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.GeneralTimeout + " milliseconds)");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Function is not Executiond. Ensure that at least one curve is previously read.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP is in Edit Mode.");
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