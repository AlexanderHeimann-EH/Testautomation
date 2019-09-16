// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureCommunication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implementation of IConfigureCommunication for
//   FF H1 Communication
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FFH1CommDTM.V1542.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.DataTypes;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Implementation of IConfigureCommunication for
    /// FF H1 Communication
    /// </summary>
    public class ConfigureCommunication : IConfigureCommunication
    {
        /// <summary>
        /// Performs the configuration of the FF H1 Communication DTM
        /// </summary>
        /// <param name="communication">
        /// The communication.
        /// </param>
        /// <returns>
        /// <br>True: if configuration was successful</br>
        /// <br>False: if configuration was unsuccessful or errors occurred</br>
        /// </returns>
        public bool Run(Communication communication)
        {
            /* Class initialization
             */
            var clickOk = new SpecificFlows.ClickButtonOk();
            var clickCancel = new SpecificFlows.ClickButtonCancel();
            var closeDialog = new SpecificFlows.AcknowledgeMissingLinkDeviceDialog();
            var selectLinkDev = new SpecificFlows.SelectLinkDevice();
            var waitForReady = new Functions.ApplicationArea.Validation.WaitUntilModuleIsReady();
            var checkDialog = new SpecificFlows.CheckIfDialogIsShown();

            /* Preconditions:
             * Check if commUnit is nullOrEmpty
             * There are no valid CommunicationSettings that need to be checked
             */
            string commUnit = communication.CommunicationHardwareName;

            if (string.IsNullOrEmpty(commUnit))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Communication Unit value is null. Not possible to configure correctly");
                return false;
            }

            /* Execution:
             * 1) Check if dialog pops up. If so -> terminate
             * 2) Check if module is ready
             * 3) Set link device
             * 4) Click button OK
             */
            if (!checkDialog.IsDialogShown())
            {
                if (waitForReady.Run(30000))
                {
                    // TODO: Find a solution to correctly select an interface when more than one is connected
                    if (selectLinkDev.Run(commUnit))
                    {
                        Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration done");
                        return true;
                    }
                    
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The link device could not be selected. Configuration will abort");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The module was not ready in time. Configuration will abort");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The communication manager is not started. Configuration will abort");
            closeDialog.Run();
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="communication">
        /// The communication configuration.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string communication)
        {
            Communication communicationObject = new Communication(communication);
            return this.Run(communicationObject);
        }
    }
}
