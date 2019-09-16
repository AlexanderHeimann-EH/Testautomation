// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommunicationSetting.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   CommunicationSetting represents a single communication setting
//   which can be used to configure Communication DTMs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.DataTypes
{
    /// <summary>
    /// CommunicationSetting represents a single communication setting
    /// which can be used to configure Communication DTMs
    /// </summary>
    public class CommunicationSetting
    {
        /// <summary>
        /// The name parameter
        /// </summary>
        private string settingName = string.Empty;

        /// <summary>
        /// The value parameter
        /// </summary>
        private string settingValue = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationSetting"/> class. 
        /// </summary>
        /// <param name="settingName">
        /// The name of the setting
        /// </param>
        /// <param name="settingValue">
        /// The value of the setting
        /// </param>
        public CommunicationSetting(string settingName, string settingValue)
        {
            this.settingName = settingName;
            this.settingValue = settingValue;
            this.IsValidlyConfigured = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether is validly configured.
        /// </summary>
        public bool IsValidlyConfigured { get; set; }

        /// <summary>
        /// Gets or sets the setting name.
        /// </summary>
        public string SettingName
        {
            get { return this.settingName; }
            set { this.settingName = value; }
        }

        /// <summary>
        /// Gets or sets the setting value.
        /// </summary>
        public string SettingValue
        {
            get { return this.settingValue; }
            set { this.settingValue = value; }
        }
    }
}
