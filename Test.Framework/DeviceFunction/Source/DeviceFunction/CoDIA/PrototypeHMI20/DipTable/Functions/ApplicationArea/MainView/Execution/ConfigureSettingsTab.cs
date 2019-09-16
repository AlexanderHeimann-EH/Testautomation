// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSettingsTab.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureSettingsTab.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Class ConfigureSettingsTab.
    /// </summary>
    public class ConfigureSettingsTab : IConfigureSettingsTab
    {
        #region Public Methods and Operators

        /// <summary>
        /// Get date time
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetDateTime()
        {
            string result;
            Element element = new SettingsTabElements().DateTime;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Firmware version is null");
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Gets device name
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetDeviceName()
        {
            string result;
            Element element = new SettingsTabElements().DeviceName;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Firmware version is null");
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Gets firmware version
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetFirmwareVersion()
        {
            string result;
            Element element = new SettingsTabElements().FirmwareVersion;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Firmware version is null");
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Get operating time
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetOperatingTime()
        {
            string result;
            Element element = new SettingsTabElements().OperatingTime;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Firmware version is null");
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Gets order code
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetOrderCode()
        {
            string result;
            Element element = new SettingsTabElements().OrderCode;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Firmware version is null");
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        /// <summary>
        /// Gets serial number
        /// </summary>
        /// <returns>
        /// Text value.
        /// </returns>
        public string GetSerialNumber()
        {
            string result;
            Element element = new SettingsTabElements().SerialNumber;
            if (element == null)
            {
                result = string.Empty;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Firmware version is null");
            }
            else
            {
                result = element.GetAttributeValueText("Text");
            }

            return result;
        }

        #endregion
    }
}