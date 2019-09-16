// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseHostApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Execution;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The close host application.
    /// </summary>
    public class CloseHostApplication : ICloseHostApplication
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (Functions.ApplicationArea.MainView.Validation.HostApplication.WaitUntilHostApplicationOpened())
            {
                if (HostApplication.CloseHostApplication())
                {
                    if (Functions.ApplicationArea.MainView.Validation.HostApplication.WaitUntilHostApplicationClosed())
                    {
                        Reporting.Debug("Closing DeviceCare was successful.");
                        return true;
                    }
                }
            }

            Reporting.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Closing DeviceCare was not successful.");
            Reporting.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DeviceCare process is still running.");
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// The time out in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(int timeOutInMilliseconds)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            if (Functions.ApplicationArea.MainView.Validation.HostApplication.WaitUntilHostApplicationOpened(timeOutInMilliseconds))
            {
                if (HostApplication.CloseHostApplication())
                {
                    if (Functions.ApplicationArea.MainView.Validation.HostApplication.WaitUntilHostApplicationClosed(timeOutInMilliseconds))
                    {
                        Reporting.Debug("Closing DeviceCare was successful.");
                        return true;
                    }
                }
            }

            Reporting.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Closing DeviceCare was not successful.");
            Reporting.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DeviceCare process is still running.");

            return false;
        }
    }
}
