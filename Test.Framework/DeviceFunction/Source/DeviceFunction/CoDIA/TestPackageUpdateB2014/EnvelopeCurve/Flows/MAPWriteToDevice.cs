//------------------------------------------------------------------------------
// <copyright file="MAPWriteToDevice.cs" company="Endress+Hauser Process Solutions AG">
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
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;

    using Ranorex;

    /// <summary>
    ///     Description of MAPWriteToDevice.
    /// </summary>
    public class MAPWriteToDevice : IMAPWriteToDevice
    {
        /// <summary>
        ///     Write MAP to device
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        ////public bool Run()
        ////{
        //    try
        //    {
        //        if ((new GridColor()).IsGridGreen())
        //        {
        //            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Grid is green");
        //            if ((new RunWriteMAPToDevice()).ViaMenu())
        //            {
        //                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP writing is startet");
        //                if ((new GridColor()).IsGridYellow())
        //                {
        //                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Grid is yellow");
        //                    while (!(new ReadAndWrite()).IsProgressbarVisible())
        //                    {
        //                        Debug.Print(DateTime.Now.ToString(CultureInfo.InvariantCulture) +
        //                                    " Warte auf Progressbar.");
        //                    }

        ////                    var watch = new Stopwatch();
        //                    watch.Start();
        //                    while ((new ReadAndWrite()).IsWritingMAP())
        //                    {
        //                        Debug.Print(watch.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture));
        //                        if (watch.ElapsedMilliseconds <= DefaultValues.GeneralTimeout) continue;
        //                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
        //                                       "MAP writing freezed.");
        //                        watch.Stop();
        //                        return false;
        //                    }
        //                    watch.Stop();
        //                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP writing finished.");
        //                    return true;
        //                }
        //                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP is in Edit Mode.");
        //                return false;
        //            }
        //            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not Executiond.");
        //            return false;
        //        }
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP is not in Edit MAP mode.");
        //        return false;
        //    }
        //    catch (Exception exception)
        //    {
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        //        return false;
        //    }
        ////}

        public bool Run()
        {
            try
            {
                if (
                    DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.MenuArea.Menubar.Validation.IsEditMapActive
                                        .IsActive())
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "EditMap is active");
                    if ((new RunWriteMAPToDevice()).ViaMenu())
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP writing is startet");
                        var watch = new Stopwatch();
                        watch.Start();
                        while (DeviceFunctionLoader.CoDIA.EnvelopeCurve.Functions.ApplicationArea.MainView.Validation
                                                .ReadAndWrite.IsWritingMAP())
                        {
                            if (watch.ElapsedMilliseconds > DefaultValues.GeneralTimeout)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP writing did not finish within " + DefaultValues.GeneralTimeout + " milliseconds");
                                watch.Stop();
                                return false;
                            }
                        }

                        watch.Stop();
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP writing finished after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + DefaultValues.GeneralTimeout + " milliseconds)");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not Executiond.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MAP is not in Edit MAP mode.");
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