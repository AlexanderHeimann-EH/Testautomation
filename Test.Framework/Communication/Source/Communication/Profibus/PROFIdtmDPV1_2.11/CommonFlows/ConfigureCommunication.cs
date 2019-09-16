// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureCommunication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implementation of IConfigureCommunication for
//   PROFIdtm DPV1 Communication
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PROFIdtmDPV1.V211.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.DataTypes;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Implementation of IConfigureCommunication for PROFIdtm DPV1 Communication
    /// </summary>
    public class ConfigureCommunication : IConfigureCommunication
    {
        /// <summary>
        /// Performs the configuration of the PROFIdtmDPV1 Communication DTM
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
            /* Class initialization */
            var setBoard = new SpecificFlows.SetBoardName();
            var setBaudRate = new SpecificFlows.SetBaudRate();
            var setStartAddress = new SpecificFlows.SetStartAddress();
            var setEndAddress = new SpecificFlows.SetEndAddress();
            var setHighestStationAddress = new SpecificFlows.SetHighestStationAddress();
            var setStationAddress = new SpecificFlows.SetStationAddress();

            var pressOk = new SpecificFlows.ClickButtonOk();
            var pressDefaults = new SpecificFlows.ClickButtonDefaults();
            var pressCancel = new SpecificFlows.ClickButtonCancel();
            var pressApply = new SpecificFlows.ClickButtonApply();

            var waitForReady = new Functions.ApplicationArea.Validation.WaitUntilModuleIsReady();

            var parser = new Functions.ApplicationArea.Execution.SettingParser();

            string commUnit = communication.CommunicationHardwareName;
            string baudRate = string.Empty;
            string stationAddress = string.Empty;
            string highestStationAddress = string.Empty;
            string startAddress = string.Empty;
            string endAddress = string.Empty;

            bool baudRateSet = false;
            bool stationAddressSet = false;
            bool highestStationAddressSet = false;
            bool startAddressSet = false;
            bool endAddressSet = false;
            bool defaultConfig = false;

            /* Preconditions:
             * Check if commUnit is nullOrEmpty
             * Check for communication settings:
             * Baud Rate, Station Address, Highest Station Address, Start Address, End Address
             * 
             * If no comm settings are present -> click defaults, set board and finish
             */

            if (communication.CommunicationSettings.Count <= 0)
            {
                defaultConfig = true;
            }
            else
            {
                foreach (CommunicationSetting cs in communication.CommunicationSettings)
                {
                    if (parser.Parse(cs.SettingName) == "baud rate")
                    {
                        if (!string.IsNullOrEmpty(cs.SettingValue))
                        {
                            baudRateSet = true;
                            baudRate = cs.SettingValue;
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A configuration for \"Baud Rate\" exists but value is empty and will therefore be skipped");
                        }
                    }

                    if (parser.Parse(cs.SettingName) == "station address")
                    {
                        if (!string.IsNullOrEmpty(cs.SettingValue))
                        {
                            stationAddressSet = true;
                            stationAddress = cs.SettingValue;
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A configuration for \"Station Address\" exists but value is empty and will therefore be skipped");
                        }
                    }

                    if (parser.Parse(cs.SettingName) == "highest station address")
                    {
                        if (!string.IsNullOrEmpty(cs.SettingValue))
                        {
                            highestStationAddressSet = true;
                            highestStationAddress = cs.SettingValue;
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A configuration for \"Highest Station Address\" exists but value is empty and will therefore be skipped");
                        }
                    }

                    if (parser.Parse(cs.SettingName) == "start address")
                    {
                        if (!string.IsNullOrEmpty(cs.SettingValue))
                        {
                            startAddressSet = true;
                            startAddress = cs.SettingValue;
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A configuration for \"Start Address\" exists but value is empty and will therefore be skipped");
                        }
                    }

                    if (parser.Parse(cs.SettingName) == "end address")
                    {
                        if (!string.IsNullOrEmpty(cs.SettingValue))
                        {
                            endAddressSet = true;
                            endAddress = cs.SettingValue;
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A configuration for \"End Address\" exists but value is empty and will therefore be skipped");
                        }
                    }
                }
            }

            /* Execution:
             * 1) Check if module is ready
             * 2) check if default flag is set, if so -> default config (press defaults, set board, apply, ok)
             * 3) Set link device
             * 4) Click button OK
             */

            if (waitForReady.Run(30000))
            {
                if (setBoard.Run(commUnit))
                {
                    if (defaultConfig)
                    {
                        // default config
                        pressDefaults.Run();
                        pressApply.Run();
                        Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Default Configuration finished without errors");
                        return true;
                    }

                    bool result = true;

                    if (baudRateSet)
                    {
                        if (setBaudRate.Run(baudRate))
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Baud rate " + baudRate + " correctly set");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Baud rate " + baudRate + " not correctly set");
                            result = false;
                        }
                    }

                    if (stationAddressSet)
                    {
                        if (setStationAddress.Run(stationAddress))
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Station address " + baudRate + " correctly set");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Station address " + baudRate + " not correctly set");
                            result = false;
                        }
                    }

                    if (highestStationAddressSet)
                    {
                        if (setHighestStationAddress.Run(highestStationAddress))
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Highest station address " + highestStationAddress + " correctly set");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Highest station address " + highestStationAddress + " not correctly set");
                            result = false;
                        }
                    }

                    if (startAddressSet)
                    {
                        if (setStartAddress.Run(startAddress))
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start address " + startAddress + " correctly set");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Start address " + startAddress + " not correctly set");
                            result = false;
                        }
                    }

                    if (endAddressSet)
                    {
                        if (setEndAddress.Run(endAddress))
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End address " + endAddress + " correctly set");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "End address " + endAddress + " not correctly set");
                            result = false;
                        }
                    }

                    if (result)
                    {
                        Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration finished without errors");
                        pressApply.Run();
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration finished with errors");
                    pressApply.Run();
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The board could not be set. Terminating the configuration");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module was not ready in time. Terminating the configuration");
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
