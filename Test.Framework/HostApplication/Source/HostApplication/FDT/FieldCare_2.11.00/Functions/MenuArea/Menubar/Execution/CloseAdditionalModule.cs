// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseAdditionalModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 02.11.2012
 * Time: 1:11 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21100.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Execution;

    using Ranorex;

    /// <summary>
    ///     Provides function to open module available at [Additional Functions]
    /// </summary>
    public class CloseAdditionalModule : MarshalByRefObject, ICloseAdditionalModule
    {
        // /// <summary>
        // ///     Open module from [Additional Functions Submenu] via menu
        // /// </summary>
        // /// <remarks>
        // ///     Closes module via related MDIclient. Exception is only thrown by last module to close in a row.
        // ///     If Exception is thrown, title of Form to close is checked every second for 60 seconds. If module
        // ///     is closed within this time the exception is ignored. Otherwise the exception is shown in EH.PCPS.TestAutomation.Common.Tools.Log.
        // /// </remarks>
        // /// <param name="moduleToClose">Name of module to close</param>
        // /// <returns>
        // ///     <br>True: If call worked fine</br>
        // ///     <br>False: If an error occurred</br>
        // /// </returns>
        // public string ViaWindow(string moduleToClose)
        // {
        //    return ViaWindow(moduleToClose, true);
        // }

        /// <summary>
        ///     Open module from [Additional Functions Submenu] via menu
        /// </summary>
        /// <remarks>
        ///     Closes module via related MDI client. Exception is only thrown by last module to close in a row.
        ///     If Exception is thrown, title of Form to close is checked every second for 60 seconds. If module
        ///     is closed within this time the exception is ignored. Otherwise the exception is shown in EH.PCPS.TestAutomation.Common.Tools.Log.
        /// </remarks>
        /// <param name="moduleToClose">Name of module to close</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaWindow(string moduleToClose)
        {
            return this.ViaWindow(moduleToClose, true);
        }

        // /// <summary>
        // ///     Open module from [Additional Functions Submenu] via menu
        // /// </summary>
        // /// <remarks>
        // ///     Closes module via related MDIclient. Exception is only thrown by last module to close in a row.
        // ///     If Exception is thrown, title of Form to close is checked every second for 60 seconds. If module
        // ///     is closed within this time the exception is ignored. Otherwise the exception is shown in EH.PCPS.TestAutomation.Common.Tools.Log.
        // /// </remarks>
        // /// <param name="moduleToClose">Name of module to close</param>
        // /// <param name="closeExpected">Set this flag if you expected that the module should be closed</param>
        // /// <returns>
        // ///     <br>True: If call worked fine</br>
        // ///     <br>False: If an error occurred</br>
        // /// </returns>
        // public string ViaWindow(string moduleToClose, bool closeExpected)
        // {
        //    IList<Form> formList;
        //    Form formToClose = null;
        //    string moduleName = "";
        //    try
        //    {
        //        // get list of opened modules
        //        formList = (new GetOpenedModules().Run());
        //        if (formList != null && formList.Count > 0)
        //        {
        //            // search at all opened modules
        //            foreach (Form form in formList)
        //            {
        //                if (form != null)
        //                {
        //                    // if searched module to close is found
        //                    if (form.Title.Contains(moduleToClose))
        //                    {
        //                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
        //                                    "Found module to close [" + moduleToClose + "].");
        //                        moduleName = moduleToClose;
        //                        formToClose = form;
        //                    }
        //                }
        //                //else
        //                //{
        //                //    break;
        //                //}
        //            }
        //            // if module is not found
        //            if (moduleName.Length == 0)
        //            {
        //                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod())
        //                               , "Module is not available to close");
        //                return "";
        //            }
        //            if (formToClose != null) formToClose.Close();
        //            //return EndProcedure(formToClose, moduleToClose);
        //            return moduleName;
        //        }
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod())
        //                       , "Module [" + moduleToClose + "] is not available and could not be closed.");
        //        return "";
        //    }
        //    catch (ActionFailedException actionFailedException)
        //    {
        //        if (closeExpected)
        //        {
        //            bool isOpen = true;
        //            int timeOutInMilliseconds = DefaultValues.GeneralTimeout;

        // var watch = new Stopwatch();
        //            watch.Start();

        // // while module is still open
        // while (isOpen)
        //            {
        //                // if time is not over
        //                if (watch.ElapsedMilliseconds < timeOutInMilliseconds)
        //                {
        //                    // search for module
        //                    formList = (new GetOpenedModules().Run());
        //                    // if any open module is found
        //                    if (formList != null && formList.Count > 0)
        //                    {
        //                        // suggest, module is closed
        //                        isOpen = false;
        //                        // search at all opened modules
        //                        foreach (Form form in formList)
        //                        {
        //                            if (form != null)
        //                            {
        //                                try
        //                                {
        //                                    // if searched module to close is found
        //                                    if (form.Title.Contains(moduleToClose))
        //                                    {
        //                                        // fact, module is not closed
        //                                        isOpen = true;
        //                                        moduleName = "";
        //                                    }
        //                                }
        //                                catch (NullReferenceException)
        //                                {
        //                                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod())
        //                                                , "Module closed.");
        //                                    moduleName = moduleToClose;
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        isOpen = false;
        //                        moduleName = moduleToClose;
        //                    }
        //                }
        //                else
        //                {
        //                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod())
        //                                , actionFailedException.Message);
        //                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod())
        //                                   ,
        //                                   "Module is not closed within " + timeOutInMilliseconds.ToString() +
        //                                   " milliseconds");
        //                    isOpen = false;
        //                    moduleName = "";
        //                }
        //            }
        //            watch.Stop();
        //        }
        //        else
        //        {
        //            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod())
        //                        , "Module not closed, but isn't expected, maybe a close dialog appeared");
        //        }
        //        return moduleName;
        //    }
        //    catch (Exception exception)
        //    {
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        //        return "";
        //    }
        // }

        /// <summary>
        ///     Open module from [Additional Functions Submenu] via menu
        /// </summary>
        /// <remarks>
        ///     Closes module via related MDI client. Exception is only thrown by last module to close in a row.
        ///     If Exception is thrown, title of Form to close is checked every second for 60 seconds. If module
        ///     is closed within this time the exception is ignored. Otherwise the exception is shown in EH.PCPS.TestAutomation.Common.Tools.Log.
        /// </remarks>
        /// <param name="moduleToClose">Name of module to close</param>
        /// <param name="closeExpected">Set this flag if you expected that the module should be closed</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaWindow(string moduleToClose, bool closeExpected)
        {
            IList<Form> formList;
            Form formToClose = null;
            string moduleName = string.Empty;
            try
            {
                // get list of opened modules
                formList = (new GetOpenedModules()).Run();
                if (formList != null && formList.Count > 0)
                {
                    // search at all opened modules
                    foreach (Form form in formList)
                    {
                        if (form != null)
                        {
                            // if searched module to close is found
                            if (form.Title.Contains(moduleToClose))
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Found module to close [" + moduleToClose + "].");
                                moduleName = moduleToClose;
                                formToClose = form;
                            }
                        }
                    }

                    // if module is not found
                    if (moduleName.Length == 0)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not available to close");
                        return false;
                    }

                    if (formToClose != null)
                    {
                        formToClose.Close();
                    }

                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module [" + moduleToClose + "] is not available and could not be closed.");
                return false;
            }
            catch (ActionFailedException actionFailedException)
            {
                if (closeExpected)
                {
                    bool isOpen = true;
                    int timeOutInMilliseconds = DefaultValues.GeneralTimeout;

                    var watch = new Stopwatch();
                    watch.Start();

                    // while module is still open
                    while (isOpen)
                    {
                        // if time is not over
                        if (watch.ElapsedMilliseconds < timeOutInMilliseconds)
                        {
                            // search for module
                            formList = new GetOpenedModules().Run();

                            // if any open module is found
                            if (formList != null && formList.Count > 0)
                            {
                                // suggest, module is closed
                                isOpen = false;

                                // search at all opened modules
                                foreach (Form form in formList)
                                {
                                    if (form != null)
                                    {
                                        try
                                        {
                                            // if searched module to close is found
                                            if (form.Title.Contains(moduleToClose))
                                            {
                                                // fact, module is not closed
                                                isOpen = true;
                                            }
                                        }
                                        catch (NullReferenceException)
                                        {
                                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module closed.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                isOpen = false;
                            }
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), actionFailedException.Message);
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module [" + moduleToClose + "] is not closed within " + timeOutInMilliseconds + " Milliseconds");
                            isOpen = false;
                        }
                    }

                    watch.Stop();
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module [" + moduleToClose + "] not closed, but isn't expected, may a close dialog appeared");
                }

                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}