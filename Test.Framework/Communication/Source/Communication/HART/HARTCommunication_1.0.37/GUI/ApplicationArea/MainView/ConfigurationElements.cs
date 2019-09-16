// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationElements.cs" company="Endress+Hauser Process Solutions AG">
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
 * Time: 1:39 
 * Last: 25.11.2010
 * Reason: Code documentation
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HARTCommunication.V1037.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     This class represents parts of [HART Communication] CommDTM.
    ///     It contains GUI-element-objects of page [Settings].
    /// </summary>
    public static class ConfigurationElements
    {
        /// <summary>
        ///     Get [HART Comm Settings]-Module.Button.Ok-object
        ///     It is needed to confirm settings and close page
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Button btnOk
        {
            get
            {
                try
                {
                    Button btnButton = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsOk, DefaultValues.iTimeoutShort,
                                             out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Button.Cancel-object
        ///     It is needed to cancel settings and close page
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Button btnCancel
        {
            get
            {
                try
                {
                    Button btnButton = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsCancel, DefaultValues.iTimeoutShort,
                                             out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Get [HART Comm Settings]-Module.Button.Apply-object
        ///     It is needed to apply settings
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Button btnApply
        {
            get
            {
                try
                {
                    Button btnButton = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsApply, DefaultValues.iTimeoutShort,
                                             out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.CommunicationInterface-object
        ///     It is needed to configure [Communication Interface]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobCommunicationInterface
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsComm, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.Baudrate-object
        ///     It is needed to configure [Baudrate]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobBaudrate
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsBaudrate, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.RTSControl-object
        ///     It is needed to configure [RTS Control]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobRTSControl
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsRtsControl, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.SerialInterface-object
        ///     It is needed to configure [Serial Interface]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobSerial
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsSerial, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.Master-object
        ///     It is needed to select a [Master]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobMaster
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsMaster, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.Preamble-object
        ///     It is needed to configure [Preamble]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobPreamble
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsPreamble, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.Retries-object
        ///     It is needed to configure [Retries]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobRetries
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsRetries, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.StartAddress-object
        ///     It is needed to configure [Start Address]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobStartAddress
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsStartAddress, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Get [HART Comm Settings]-Module.Combobox.EndAddress-object
        ///     It is needed to configure [End Address]
        /// </summary>
        /// <returns>
        ///     <br>ComboBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobEndAddress
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsEndAddress, DefaultValues.iTimeoutShort,
                                             out comboBox);
                    return comboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        ///     Get [HART Comm Settings]-Module.Checkbox.Multimaster and Burst-object
        ///     It is needed to select [Multimaster and Burst-mode support]
        /// </summary>
        /// <returns>
        ///     <br>CheckBox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static CheckBox chbMultimaster
        {
            get
            {
                try
                {
                    CheckBox checkBox = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsMultimaster, DefaultValues.iTimeoutShort,
                                             out checkBox);
                    return checkBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Get [HART Comm Settings]-Module.ListItem.Combobox-object
        ///     It is needed to get a list-entry of a combobox
        /// </summary>
        /// <returns>
        ///     <br>ListItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ListItem liComboboxList(string strEntry)
        {
            try
            {
                ListItem listItem = null;
                Host.Local.TryFindSingle(ConfigurationPaths.StrHARTSettingsList, DefaultValues.iTimeoutShort,
                                         out listItem);
                return listItem;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}