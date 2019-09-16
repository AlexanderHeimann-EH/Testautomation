// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Flow: Empty diagram for new Curves at module Envelope Curve
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    ///     Flow: Empty diagram for new Curves at module Envelope Curve
    /// </summary>
    public class CloseModule : ICloseModule
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Close module via frame menu within a default time
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
        /// Close module via frame menu within a default time
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds.
        /// </param>
        /// <returns>
        /// <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(int timeoutInMilliseconds)
        {
            bool result = true;

            // Is module already closed?
            if (Validation.ModuleOpeningAndClosing.IsModuleClosed())
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is already closed.");
                result = false;
            }
            else
            {
                // Try to close module
                if (CommonFlows.CloseFunction.Run(new ModuleName().Name()) == false)
                {
                    result = false;
                }
                else
                {
                    // Is module closed in time
                    if (Validation.ModuleOpeningAndClosing.WaitUntilModuleIsClosed(timeoutInMilliseconds) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not closed in time.");
                        result = false;
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed.");
                    }
                }
            }

            return result;
        }

        #endregion
    }
}