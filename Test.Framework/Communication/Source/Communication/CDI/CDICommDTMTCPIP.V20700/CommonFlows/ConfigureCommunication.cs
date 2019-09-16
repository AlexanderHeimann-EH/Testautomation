// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureCommunication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implementation of IConfigureCommunication for
//   CDI Communication FXA291
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.CommonFlows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.Functions.ApplicationArea.Validation;
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
        [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1513:ClosingCurlyBracketMustBeFollowedByBlankLine", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(Communication communication)
        {
            CommunicationSetting ipAddress      = communication.GetSpecificSetting("IP Address");
            CommunicationSetting foundDevice    = communication.GetSpecificSetting("Found devices");
            CommunicationSetting port           = communication.GetSpecificSetting("Port");
            CommunicationSetting timeout        = communication.GetSpecificSetting("Timeout");

            bool isPassed = true;

            /* Execution:
             * 1) Check if module is ready
             * 2) Click the refresh button to make sure all comm units are recognized (can eventually be skipped)
             * 3) Set parameters
             */

            if (WaitUntilModuleIsReady.Run(Common.DefaultValues.GeneralTimeout))
            {
                isPassed &= this.SetIpAddress(ipAddress);
                isPassed &= this.SetFoundDevice(foundDevice);
                isPassed &= this.SetPort(port);
                isPassed &= this.SetTimeout(timeout);
            }
            else
            {
                isPassed = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM was not ready after " + Common.DefaultValues.GeneralTimeout + " seconds");
            }

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
        /// The set IP address.
        /// </summary>
        /// <param name="ipAddress">
        /// The ip address.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetIpAddress(CommunicationSetting ipAddress)
        {
            bool isPassed = true;
            if (ipAddress != null)
            {
                if (ipAddress.IsValidlyConfigured)
                {
                    // valide konfiguriert => starte das setzen des parameters
                    if (!SpecificFlows.SetIpAddress.Run(ipAddress.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + ipAddress.SettingName + "] was not set correctly.");
                    }

                    isPassed &= true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + ipAddress.SettingName + "] was set to [" + ipAddress.SettingValue + "].");
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
        /// The set found device.
        /// </summary>
        /// <param name="foundDevice">
        /// The found device.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetFoundDevice(CommunicationSetting foundDevice)
        {
            bool isPassed = true;
            if (foundDevice != null)
            {
                if (foundDevice.IsValidlyConfigured)
                {
                    // valide konfiguriert => starte das setzen des parameters
                    if (!SpecificFlows.SetFoundDevice.Run(foundDevice.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + foundDevice.SettingName + "] was not set correctly.");
                    }

                    isPassed &= true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + foundDevice.SettingName + "] was set to [" + foundDevice.SettingValue + "].");
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
        /// The set port.
        /// </summary>
        /// <param name="port">
        /// The port.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetPort(CommunicationSetting port)
        {
            bool isPassed = true;
            if (port != null)
            {
                if (port.IsValidlyConfigured)
                {
                    // valide konfiguriert => starte das setzen des parameters
                    if (!SpecificFlows.SetPort.Run(port.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + port.SettingName + "] was not set correctly.");
                    }

                    isPassed &= true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + port.SettingName + "] was set to [" + port.SettingValue + "].");
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
        /// The set timeout.
        /// </summary>
        /// <param name="timeout">
        /// The timeout.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool SetTimeout(CommunicationSetting timeout)
        {
            bool isPassed = true;
            if (timeout != null)
            {
                if (timeout.IsValidlyConfigured)
                {
                    // valide konfiguriert => starte das setzen des parameters
                    if (!SpecificFlows.SetTimeout.Run(timeout.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + timeout.SettingName + "] was not set correctly.");
                    }

                    isPassed &= true;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "[" + timeout.SettingName + "] was set to [" + timeout.SettingValue + "].");
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