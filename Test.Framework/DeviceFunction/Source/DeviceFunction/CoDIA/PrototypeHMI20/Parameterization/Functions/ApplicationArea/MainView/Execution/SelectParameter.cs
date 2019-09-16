// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    ///     Description of SelectParameter.
    /// </summary>
    public class SelectParameter : ISelectParameter
    {
        /// <summary>
        /// Selects specified parameter
        /// </summary>
        /// <param name="pathToParameter">Path to parameter including parameter name. Use this form: Setup//Advanced setup//Locking status:</param>
        /// <returns>
        /// true: when parameter was found and selected
        /// false: if an error occurred
        /// </returns>
        public bool Run(string pathToParameter)
        {
            try
            {
                bool result = false;

                if (AppComController.Controller != null)
                {                    
                    AppComController.Controller.SelectItem(pathToParameter);
                    if (pathToParameter == "OfflineDeviceMenu" || pathToParameter == "OnlineDeviceMenu")
                    {
                        var watch = new Stopwatch();
                        watch.Start();
                        while (watch.ElapsedMilliseconds < 1000)
                        {
                            // Wait 1 seconds
                        }

                        watch.Stop();
                    }
                    else if (DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation.WaitForDisplayContentChangedAfterSelect.Run(15000, pathToParameter))
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Recognized display content update. Item '{0}' selected.", pathToParameter));
                        result = true;
                                                
                        var watch = new Stopwatch();
                        watch.Start();
                        while (watch.ElapsedMilliseconds < 500)
                        {
                            // Wait 0.5 seconds, maybe too fast?
                        }

                        watch.Stop();
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("No display content update. Item '{0}' not selected.", pathToParameter));
                    }
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Remote host not connected! Please establish a connection first.");
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}