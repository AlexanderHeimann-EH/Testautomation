// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureCommunication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Implementation of IConfigureCommunication for
//   HART Communication
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HARTCommunication.V1052.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.DataTypes;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonCommunicationLayerInterfaces.CommonFlows;

    /// <summary>
    /// Implementation of IConfigureCommunication for
    /// HART Communication
    /// </summary>
    public class ConfigureCommunication : IConfigureCommunication
    {
        /// <summary>
        /// Performs the configuration of the HART Communication DTM
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
            SpecificFlows.ClickButtonApply clickApply = new SpecificFlows.ClickButtonApply();
            SpecificFlows.SetSerialInterface setModem = new SpecificFlows.SetSerialInterface();
            SpecificFlows.SetStartAddress setStartAddress = new SpecificFlows.SetStartAddress();
            SpecificFlows.SetEndAddress setEndAddress = new SpecificFlows.SetEndAddress();
            SpecificFlows.SetCommunicationInterface setCommInterface = new SpecificFlows.SetCommunicationInterface();
            Functions.ApplicationArea.Validation.WaitUntilModuleIsReady waitForReady = new Functions.ApplicationArea.Validation.WaitUntilModuleIsReady();

            CommunicationSetting communicationInterface = communication.GetSpecificSetting("Communication interface");
            CommunicationSetting serialInterface        = communication.GetSpecificSetting("Serial Interface");
            // CommunicationSetting master                 = communication.GetSpecificSetting("Master");
            // CommunicationSetting preamble               = communication.GetSpecificSetting("Preamble");
            // CommunicationSetting retries                = communication.GetSpecificSetting("Number of communication retries");
            CommunicationSetting startAddress           = communication.GetSpecificSetting("Start address");
            CommunicationSetting endAddress             = communication.GetSpecificSetting("End address");

            bool isPassed = true;

            if (waitForReady.Run(30000))
            {
                if (communicationInterface != null)
                {
                    if (!setCommInterface.Run(communicationInterface.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), communicationInterface.SettingName + " was not set correctly.");
                    }
                }

                if (serialInterface != null)
                {
                    if (!setModem.Run(serialInterface.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), serialInterface.SettingName + " was not set correctly.");
                    }
                }

                //if (master != null)
                //{
                //    if (!setMaster.Run(master.SettingValue))
                //    {
                //        isPassed = false;;       
                //        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), master.SettingName + " was not set correctly.");
                //    }
                //}

                //if (preamble != null)
                //{
                //    if (!setPreamble.Run(preamble.SettingValue))
                //    {
                //        isPassed = false;
                //        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), preamble.SettingName + " was not set correctly.");
                //    }
                //}

                //if (retries != null)
                //{
                //    if (!setRetries.Run(retries.SettingValue))
                //    {
                //        isPassed = false;
                //        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), retries.SettingName + " was not set correctly.");
                //    }
                //}

                if (startAddress != null)
                {
                    if (!setStartAddress.Run(startAddress.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), startAddress.SettingName + " was not set correctly.");
                    }
                }

                if (endAddress != null)
                {
                    if (!setEndAddress.Run(endAddress.SettingValue))
                    {
                        isPassed = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), endAddress.SettingName + " was not set correctly.");
                    }
                }

                if (clickApply.Run())
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuration done");
                }
            }
            else
            {
                isPassed = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DTM was not ready after 30 seconds");
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
    }
}
