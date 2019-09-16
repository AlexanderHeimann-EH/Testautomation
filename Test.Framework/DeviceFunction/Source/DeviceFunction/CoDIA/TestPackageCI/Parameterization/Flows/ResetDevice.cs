// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetDevice.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ResetDevice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Flows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    using Validation = EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.StatusArea.Statusbar.Validation;

    /// <summary>
    /// Class ResetDevice.
    /// </summary>
    public class ResetDevice : IResetDevice
    {
        #region Public Methods and Operators

        /// <summary>
        /// Reset a device via Online Parameterization.
        /// </summary>
        /// <param name="pathToResetParameter">
        /// The path to the reset parameter. Use this form: Promass 100//Expert//System//Administration//Device reset:
        /// </param>
        /// <param name="value">
        /// Value for the reset. Use this form: To delivery settings
        /// </param>
        /// <param name="waitingTimeForDisconnect">
        /// The waiting period (in milliseconds) until the dtm has to be disconnected after a device restart. This can take some time with slower communication protocols. USE 0 IF THE DEVICE WILL NOT RESTART.
        /// </param>
        /// <param name="waitingTimeForReconnect">
        /// The waiting period (in milliseconds) until the dtm has to be reconnected after a device restart. This can take some time with slower communication protocols.
        /// </param>
        /// <returns>
        /// True if reset is finished and Dtm is ready, false if otherwise
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(string pathToResetParameter, string value, int waitingTimeForDisconnect, int waitingTimeForReconnect)
        {
            bool result = true;

            // Start reset via set parameter
            if (Execution.SetParameter.Run(pathToResetParameter, value) == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Setting reset parameter failed.");
                result = false;
            }        
            else if (waitingTimeForDisconnect > 0)
            {
                // Wait for disconnect and reconnect.
                if (Validation.WaitUntilDtmIsDisconnected.Run(waitingTimeForDisconnect))
                {
                    result &= Validation.WaitUntilDtmIsConnected.Run(waitingTimeForReconnect);
                }
                else
                {
                    result = false;
                }
            }                                                  

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reset finished. Device ready.");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reset device failed.");
            }

            return result;
        }

        #endregion
    }
}