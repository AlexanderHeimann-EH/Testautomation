﻿
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurveShed.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.EnvelopeCurveShed.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurveShed.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Provides function to open module frame-independent
    /// </summary>
    public class OpenModuleOnline : IOpenModuleOnline
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Open module via frame menu within a default time
        /// </summary>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run()
        {
            return this.Run(DefaultValues.iTimeoutModules);
        }

        /// <summary>
        /// Open module via frame menu within a default time
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds for the module opening.
        /// </param>
        /// <returns>
        /// <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(int timeoutInMilliseconds)
        {
            bool result = false;

            // check if module is already open
            if (Validation.ModuleOpeningAndClosing.IsModuleAlreadyOpened())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is already opened");
                result = true;
            }
            else
            {
                // Try to open module
                if (CommonFlows.OpenAdditionalFunction.Run((new ModuleName()).Name()) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening module failed");
                }
                else
                {
                    // Is module opening in time
                    if (Validation.ModuleOpeningAndClosing.WaitUntilModuleIsOpen(timeoutInMilliseconds) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not opened in time.");
                    }
                    else
                    {
                        // Is module online in time
                        if (DeviceFunctionLoader.CoDIA.EnvelopeCurveShed.Functions.StatusArea.Statusbar.Validation.WaitUntilDtmIsConnected.Run(DefaultValues.iTimeoutModules) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not online in time.");
                        }
                        else
                        {
                            // Is module ready in time
                            if (Validation.WaitUntilModuleOnlineIsReady.Run(DefaultValues.iTimeoutModules) == false)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not ready in time.");
                            }
                            else
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is opened and ready to use.");
                                result = true;
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion
    }
}