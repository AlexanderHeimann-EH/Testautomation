// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseModuleOffline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to close module frame-independent
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Flows
{
    using System.Diagnostics;

    using Common;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides function to close module frame-independent
    /// </summary>
    public class CloseModuleOffline : ICloseModuleOffline
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
        /// The timeout In Milliseconds for the module closing.
        /// </param>
        /// <returns>
        /// <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(int timeoutInMilliseconds)
        {
            new DisconnectSoftwareUnderTest().Run();
            bool result = new Functions.ApplicationArea.MainView.Execution.CloseModuleOffline().ViaWindow();

            //Hier sicherstellen, dass die obige Aktion abgeschlossen
            var watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < 10000)
            {
                //wait
            }

            watch.Stop();

            return result;
        }

        #endregion

        ///// <summary>
        ///// Close module via frame menu within a default time
        ///// </summary>
        ///// <param name="timeoutInMilliseconds">
        ///// The timeout In Milliseconds for the module closing.
        ///// </param>
        ///// <returns>
        ///// <br>True: if everything worked fine</br>
        /////     <br>False: if an error occurred</br>
        ///// </returns>
        //public bool Run(int timeoutInMilliseconds)
        //{
        //    bool result = true;

        //    // Is module already closed?
        //    if (Validation.ModuleOpeningAndClosing.IsOnlineModuleClosed())
        //    {
        //        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is already closed.");
        //        result = false;
        //    }
        //    else
        //    {
        //        // Try to close module
        //        if (CommonFlows.CloseFunction.Run(new ModuleName().ModuleNameOnline()) == false)
        //        {
        //            result = false;
        //        }
        //        else
        //        {
        //            // Is module closed in time
        //            if (Validation.ModuleOpeningAndClosing.WaitUntilOnlineModuleIsClosed(timeoutInMilliseconds) == false)
        //            {
        //                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not closed in time.");
        //                result = false;
        //            }
        //            else
        //            {
        //                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed.");
        //            }
        //        }
        //    }

        //    return result;
        //}
    }
}