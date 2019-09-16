// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenModuleOnline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides function to open module frame-independent
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Flows
{
    using System.Diagnostics;
    using System.Reflection;

    using Common;
    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution;

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
            bool result = new Functions.ApplicationArea.MainView.Execution.OpenModuleOnline().ViaMenu();            

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var connection = new ConnectToSoftwareUnderTest();
            while (connection.Run() == false)
            {
                if (watch.ElapsedMilliseconds >= 30000)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connecting to TestingInterface failed.");
                    result = false;
                    break;
                }
            }

            if (result)
            {
                // Is module ready in time
                if (Validation.WaitUntilModuleOnlineIsReady.Run(DefaultValues.iTimeoutModules) == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not ready in time.");
                    result = false;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is opened and ready to use.");
                }
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to open module.");
            }

            return result;
        }

        #endregion
    }
}