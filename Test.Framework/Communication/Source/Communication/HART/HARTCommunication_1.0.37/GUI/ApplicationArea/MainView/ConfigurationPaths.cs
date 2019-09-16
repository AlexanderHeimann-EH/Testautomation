// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationPaths.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 10.11.2010
 * Time: 8:42 
 * Last: 25.11.2010
 * Reason: Code documentation
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HARTCommunication.V1037.GUI.ApplicationArea.MainView
{
    /// <summary>
    ///     Paths to GUI-elements-objects of [Hart Communication] CommDTM.
    /// </summary>
    public static class ConfigurationPaths
    {
        /// <summary>
        ///     Help string for controls at HART address dialog
        /// </summary>
        private const string StrButtonHelpString = @"/form/element/form/container/element/button";

        //public static string strHARTAddressModule 		= @"/form/element/form/container[@controlname='FDTView2']";
        /// <summary>
        ///     Path to button OK
        /// </summary>
        public const string StrHARTAddressOk = StrButtonHelpString + "[@controlid='4']";

        /// <summary>
        ///     Path to button Cancel
        /// </summary>
        public const string StrHARTAddressCancel = StrButtonHelpString + "[@controlid='5']";

        /// <summary>
        ///     Help string for controls at HART settings dialog
        /// </summary>
        private const string StrHARTSettingsHelpString = "/form/element/form/container/element/element";

        /// <summary>
        ///     Path to button Ok
        /// </summary>
        public const string StrHARTSettingsOk = StrHARTSettingsHelpString + "[@controlid='1']/button[@controlid='4']";

        /// <summary>
        ///     Path to button Cancel
        /// </summary>
        public const string StrHARTSettingsCancel =
            StrHARTSettingsHelpString + "[@controlid='1']/button[@controlid='3']";

        /// <summary>
        ///     Path to button Apply
        /// </summary>
        public const string StrHARTSettingsApply = StrHARTSettingsHelpString + "[@controlid='1']/button[@controlid='2']";

        /// <summary>
        ///     Path to combobox Communication
        /// </summary>
        public const string StrHARTSettingsComm =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='16']/element[@controlid='20']/combobox";

        /// <summary>
        ///     Path to combobox Baudrate
        /// </summary>
        public const string StrHARTSettingsBaudrate =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='16']/element[@controlid='21']/combobox";

        /// <summary>
        ///     Path to combobox RTS Control
        /// </summary>
        public const string StrHARTSettingsRtsControl =
            StrHARTSettingsHelpString + "[@controlid='5']/element/element[@controlid='14']/element/combobox";

        /// <summary>
        ///     Path to combobox Serial
        /// </summary>
        public const string StrHARTSettingsSerial =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='16']/element[@controlid='22']/combobox";

        /// <summary>
        ///     Path to combobox Master
        /// </summary>
        public const string StrHARTSettingsMaster =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='7']/element[@controlid='12']/combobox";

        /// <summary>
        ///     Path to combobox Preamble
        /// </summary>
        public const string StrHARTSettingsPreamble =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='7']/element[@controlid='11']/combobox";

        /// <summary>
        ///     Path to combobox Retries
        /// </summary>
        public const string StrHARTSettingsRetries =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='7']/element[@controlid='10']/combobox";

        /// <summary>
        ///     Path to combobox Start Address
        /// </summary>
        public const string StrHARTSettingsStartAddress =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='7']/element[@controlid='9']/combobox";

        /// <summary>
        ///     Path to combobox End Address
        /// </summary>
        public const string StrHARTSettingsEndAddress =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='7']/element[@controlid='8']/combobox";

        /// <summary>
        ///     Path to checkbox Multimaster
        /// </summary>
        public const string StrHARTSettingsMultimaster =
            StrHARTSettingsHelpString +
            "[@controlid='5']/element/element[@controlid='7']/element[@controlid='13']/checkbox";

        /// <summary>
        ///     Path to list
        /// </summary>
        public const string StrHARTSettingsList = @"/list/listitem";
    }
}