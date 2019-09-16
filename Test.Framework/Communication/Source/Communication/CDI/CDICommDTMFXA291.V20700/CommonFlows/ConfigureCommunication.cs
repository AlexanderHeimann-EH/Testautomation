// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureCommunication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implementation of IConfigureCommunication for
//   CDI Communication FXA291
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMFXA291.V20700.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.DataTypes;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Implementation of IConfigureCommunication for
    /// CDI Communication FXA291
    /// </summary>
    public class ConfigureCommunication : IConfigureCommunication
    {
        /// <summary>
        /// Performs the configuration of the CDI Communication FXA291 Communication DTM
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
            CommunicationSetting selectedComPort = communication.GetSpecificSetting("Selected COM port:");
            CommunicationSetting baudRate = communication.GetSpecificSetting("Baud rate:");

            bool isPassed = true;

            /* Execution:
             * 1) Check if module is ready
             * 2) Click the refresh button to make sure all comm units are recognized (can eventually be skipped)
             * 3) Set the comm unit (combobox list item will get selected after a string compare)
             * 4) Set the baud rate, if flag is set in preconditions
             */

            if (Functions.ApplicationArea.Validation.WaitUntilModuleIsReady.Run(30000))
            {
                if (SpecificFlows.ClickRefreshButton.Run())
                {
                    isPassed &= this.SetSelectedComPort(selectedComPort);
                    isPassed &= this.SetBaudRate(baudRate);
                }
                else
                {
                    isPassed = false;
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not click button [Refresh]");
                }
            }
            else
            {
                isPassed = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM was not ready after 30 seconds");
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration is done.");
            return isPassed;
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

        /// <summary>
        /// The set selected com port.
        /// </summary>
        /// <param name="selectedComPort">
        /// The selected com port.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetSelectedComPort(CommunicationSetting selectedComPort)
        {
            bool isPassed = true;
            if (selectedComPort != null)
            {
                if (selectedComPort.IsValidlyConfigured)
                {
                    // valide konfiguriert => starte das setzen des parameters
                    if (!SpecificFlows.SetCommunicationUnit.Run(selectedComPort.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + selectedComPort.SettingName + "] was not set correctly.");
                    }

                    isPassed &= true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + selectedComPort.SettingName + "] was set to [" + selectedComPort.SettingValue + "].");
                }
                else
                {
                    // invalide konfiguriert => test schlägt fehl
                    isPassed = false;
                }
            }
            else
            {
                isPassed &= true;
            }

            return isPassed;
        }

        /// <summary>
        /// The set baud rate.
        /// </summary>
        /// <param name="baudRate">
        /// The baud rate.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetBaudRate(CommunicationSetting baudRate)
        {
            bool isPassed = true;
            if (baudRate != null)
            {
                if (baudRate.IsValidlyConfigured)
                {
                    // valide konfiguriert => starte das setzen des parameters
                    if (!SpecificFlows.SetBaudRate.Run(baudRate.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + baudRate.SettingName + "] was not set correctly.");
                    }

                    isPassed &= true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + baudRate.SettingName + "] was set to [" + baudRate.SettingValue + "].");
                }
                else
                {
                    // invalide konfiguriert => test schlägt fehl
                    isPassed = false;
                }
            }
            else
            {
                isPassed &= true;
            }

            return isPassed;
        }
    }
}
