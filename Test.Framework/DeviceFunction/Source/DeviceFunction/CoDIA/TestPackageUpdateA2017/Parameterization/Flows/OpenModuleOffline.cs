// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenModuleOffline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to open module frame-independent
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Provides function to open module frame-independent
    /// </summary>
    public class OpenModuleOffline : IOpenModuleOffline
    {
        #region Public Methods and Operators

        /// <summary>
        ///  Open module via frame menu within a default time
        /// </summary>
        /// <returns>
        /// <br>True: if everything worked fine</br>
        /// <br>False: if an error occurred</br>
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
        /// <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(int timeoutInMilliseconds)
        {
            bool result = false;

            // check if module is already open
            if (Validation.ModuleOpeningAndClosing.IsOfflineModuleAlreadyOpened())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is already opened");
                result = true;
            }
            else
            {
                // Try to open module
                if (CommonFlows.OpenFunction.Run((new ModuleName()).ModuleNameOffline()) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening module failed");
                }
                else
                {
                    // Is module opening in time
                    if (Validation.ModuleOpeningAndClosing.WaitUntilOfflineModuleIsOpen(timeoutInMilliseconds) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not opened in time.");
                    }
                    else
                    {
                        // Is module ready in time
                        if (Validation.WaitUntilModuleOfflineIsReady.Run(DefaultValues.iTimeoutModules) == false)
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

            return result;
        }

        #endregion
    }
}