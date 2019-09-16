using System;
using System.Collections.Generic;
using System.Reflection;

using EH.PCPS.TestAutomation.Common.DataTypes;
using EH.PCPS.TestAutomation.Common.Tools;
using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;


namespace EH.PCPS.TestAutomation.RSG45HARTCommunication.V1011436.CommonFlows
{
    /// <summary>
    /// Implementation of IConfigureCommunication for
    /// RSG45 HART Communication
    /// </summary>
    public class ConfigureCommunication : IConfigureCommunication
    {
        /// <summary>
        /// Performs the configuration of the RSG45 HART Communication DTM
        /// </summary>
        /// <returns>
        /// <br>True: if configuration was successful</br>
        /// <br>False: if configuration was unsuccessful or errors occurred</br>
        /// </returns>
        public bool Run(Communication communication)
        {

            /* Class initialization
             */
            var parser = new Functions.ApplicationArea.Execution.SettingParser();
            var clickApply = new SpecificFlows.ClickButtonApply();
            var isApplyEnabled = new SpecificFlows.IsApplyButtonEnabled();
            var setEndAddress = new SpecificFlows.SetEndAddress();
            var setStartAddress = new SpecificFlows.SetStartAddress();
            var setIPAddress = new SpecificFlows.SetIPAddress();
            var setPort = new SpecificFlows.SetPort();
            var setTimeout = new SpecificFlows.SetTimeout();

            var isModuleReady = new Functions.ApplicationArea.Validation.WaitUntilModuleIsReady();

            List<bool> executionResults = new List<bool>();

            bool isDefaultConfig = false;
            
            string commUnit = communication.CommunicationHardwareName;

            /*  Precondition:
             *  Check communication for settings and set bools accordingly:
             *  Check for start address
             *  Check for end address
             *  
             * If not found, do a default scan from 0 to 0
             */

            if (string.IsNullOrEmpty(commUnit))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Communication Unit value is null. Not possible to configure correctly");
                return false;
            }

            //default config
            if (communication.CommunicationSettings.Count == 0)
            {
                isDefaultConfig = true;
            }

            /* Execution:
             * 1) Check if module is ready
             * 2) set the ip
             * 3) Set port, start/end address and timeout, if flags are set in preconditions
             * 4) Click button apply
             */
            
            if (isModuleReady.Run(30000))
            {
                if (setIPAddress.Run(commUnit))
                {
                    if (isApplyEnabled.Run())
                    {
                        if (!isDefaultConfig)
                        {
                            bool result = true;
                            // do extended config
                            foreach (var st in communication.CommunicationSettings)
                            {
                                if (st.SettingValue != "")
                                {
                                    switch (parser.Parse(st.SettingName))
                                    {
                                        case "start address":
                                            executionResults.Add(setStartAddress.Run(st.SettingValue));
                                            break;
                                        case "end address":
                                            executionResults.Add(setEndAddress.Run(st.SettingValue));
                                            break;
                                        case "timeout":
                                            executionResults.Add(setTimeout.Run(st.SettingValue));
                                            break;
                                        case "port":
                                            executionResults.Add(setPort.Run(st.SettingValue));
                                            break;
                                    }
                                }
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The value for the setting " + st.SettingName + " is empty. Skipping configuration for this setting");
                            }
                            // check for execution results
                            for (int i = 0; i < executionResults.Count; i++)
                            {
                                if (!executionResults[i])
                                {
                                    result = false;
                                }
                            }
                            if (result)
                            {
                                if (clickApply.Run())
                                {
                                    Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration finished without errors");
                                    return true;
                                }
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Apply button is not enabled. Cannot save configuration");
                                return false;
                            }
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration finished with errors");
                            int failCounter = 0;
                            foreach (var bla in executionResults)
                            {
                                if (!bla)
                                {
                                    failCounter++;
                                }
                            }
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("{0} out of {1} configurations finished with status failed", failCounter, executionResults.Count));
                            clickApply.Run();
                            return false;
                        }
                        else
                        {
                            if (clickApply.Run())
                            {
                                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration finished without errors");
                                return true;
                            }
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Apply button is not enabled. Cannot save configuration");
                            return false;  
                        }
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Apply button is not enabled though a parameter was already changed");
                        return false;
                    }
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "IP was not correctly set");
                    return false;
                }
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module was not ready in time");
                return false;
            }
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
