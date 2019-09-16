// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Communication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Communication can hold information about a CommunicationDTM
//   including a list of communication settings
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.DataTypes
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    /// Communication can hold information about a CommunicationDTM
    /// including a list of communication settings
    /// </summary>
    public class Communication
    {
        #region Members

        /// <summary>
        /// The protocol parameter
        /// </summary>
        private string protocol = string.Empty;

        /// <summary>
        /// The communicationDriverName parameter
        /// </summary>
        private string communicationDriverName = string.Empty;

        /// <summary>
        /// The communicationHardwareName parameter
        /// </summary>
        private string communicationHardwareName = string.Empty;

        /// <summary>
        /// The communicationSettings list
        /// </summary>
        private List<CommunicationSetting> communicationSettings;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Communication"/> class.
        /// </summary>
        /// <param name="communicationConfiguration">
        /// The communication settings.
        /// </param>
        public Communication(string communicationConfiguration)
        {
            if (communicationConfiguration != string.Empty)
            {
                this.communicationSettings = new List<CommunicationSetting>();
                string[] parts = communicationConfiguration.Split(';');

                if (parts.Length > 2)
                {
                    this.protocol = parts[0];
                    this.communicationDriverName = parts[1];
                    this.communicationHardwareName = parts[2];
                }
                
                for (int counter = 3; counter < parts.Length; counter = counter + 2)
                {
                    if (counter + 1 < parts.Length)
                    {
                        CommunicationSetting buffer = new CommunicationSetting(parts[counter], parts[counter + 1]);
                        this.communicationSettings.Add(buffer);    
                    }
                    else
                    {
                        CommunicationSetting buffer = new CommunicationSetting(parts[counter], string.Empty);
                        this.communicationSettings.Add(buffer);    
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Communication"/> class. 
        /// </summary>
        /// <param name="protocolName">
        /// The name of the protocol
        /// </param>
        /// <param name="communicationDriverName">
        /// The name of the communication driver (modem)
        /// </param>
        public Communication(string protocolName, string communicationDriverName)
        {
            this.protocol = protocolName;
            this.communicationDriverName = communicationDriverName;
            this.communicationSettings = new List<CommunicationSetting>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Communication"/> class. 
        /// </summary>
        /// <param name="protocolName">
        /// The name of the protocol
        /// </param>
        /// <param name="communicationDriverName">
        /// The name of the communication driver
        /// </param>
        /// <param name="communicationHardwareName">
        /// The name of the communication hardware
        /// </param>
        public Communication(string protocolName, string communicationDriverName, string communicationHardwareName)
        {
            this.protocol = protocolName;
            this.communicationDriverName = communicationDriverName;
            this.communicationHardwareName = communicationHardwareName;
            this.communicationSettings = new List<CommunicationSetting>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Communication"/> class. 
        /// </summary>
        /// <param name="protocolName">
        /// The name of the protocol
        /// </param>
        /// <param name="communicationDriverName">
        /// The name of the communication driver
        /// </param>
        /// <param name="communicationHardwareName">
        /// The name of the communication hardware
        /// </param>
        /// <param name="communicationSettings">
        /// A list of <see cref="CommunicationSettings"/> objects which contain necessary settings
        /// </param>
        public Communication(string protocolName, string communicationDriverName, string communicationHardwareName, List<CommunicationSetting> communicationSettings)
        {
            this.protocol = protocolName;
            this.communicationDriverName = communicationDriverName;
            this.communicationHardwareName = communicationHardwareName;
            this.communicationSettings = communicationSettings;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the protocol parameter
        /// </summary>
        public string Protocol
        {
            get { return this.protocol; }
            set { this.protocol = value; }
        }

        /// <summary>
        /// Gets or sets the communication Driver Name parameter
        /// </summary>
        public string CommunicationDriverName
        {
            get { return this.communicationDriverName; }
            set { this.communicationDriverName = value; }
        }

        /// <summary>
        /// Gets or sets the communicationHardwareName parameter
        /// </summary>
        public string CommunicationHardwareName
        {
            get { return this.communicationHardwareName; }
            set { this.communicationHardwareName = value; }
        }

        /// <summary>
        /// Gets or sets the communicationSettings list
        /// </summary>
        public List<CommunicationSetting> CommunicationSettings
        {
            get { return this.communicationSettings; }
            set { this.communicationSettings = value; }
        }

        #endregion

        /// <summary>
        /// The Get Specific Setting function
        /// </summary>
        /// <param name="settingName">Setting to search for</param>
        /// <returns>Communication Settings object</returns>
        public CommunicationSetting GetSpecificSetting(string settingName)
        {
            bool foundInSettingNames = false;
            bool foundInSettingValues = false;
            CommunicationSetting returnValue = null;

            // Phase 1: search parameter name within names
            foreach (CommunicationSetting communicationSetting in this.CommunicationSettings)
            {
                if (communicationSetting.SettingName.Equals(settingName))
                {
                    foundInSettingNames = true;
                    communicationSetting.IsValidlyConfigured = true;
                    returnValue = communicationSetting;
                }
            }

            if (foundInSettingNames)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter [" + settingName + "] found on predefined location in Communication Settings string.");
                return returnValue;
            }
            
            // Phase 2: search parameter names within values to check for a missconfiguration
            foreach (CommunicationSetting settingsForValue in this.CommunicationSettings)
            {
                if (settingsForValue.SettingValue.Equals(settingName))
                {
                    foundInSettingValues = true;
                    settingsForValue.IsValidlyConfigured = false;
                    returnValue = settingsForValue;
                }
            }

            if (foundInSettingValues)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter [" + settingName + "] found on wrong location in Communication Settings string. It was found on a place for Setting Value instead of a place or Setting Name.");
                return returnValue;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not all paramaters have been configured by Communication Settings string.");
            return null;
        }
    }
}
