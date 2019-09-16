// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmAddressElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 03.03.2011
 * Time: 15:11 
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
    ///     It contains GUI-controls of DTM-page [Communication].
    /// </summary>
    public static class ConfirmAddressElements
    {
        /*/// <summary>
		/// Get [HART Communication]-Module.Container.HARTComm-object
		/// It is needed to ...
		/// </summary>
		public static Container ModuleHartComm_ModModule
		{get{
			try {
				Container cntModule = Host.Local.FindSingle(PathsModuleHARTComm.strHARTAddressModule, DefaultValues.iTimeoutShort);
				return cntModule;
			} catch (Exception exception) {
				EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);	
				return null;
			}
		}}*/


        /// <summary>
        ///     Get [Confirm Address]-Dialog.Button.Ok-object
        ///     It is needed to confirm a proposed configuration
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Button BtnOk
        {
            get
            {
                try
                {
                    Button btnButton = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTAddressOk, DefaultValues.iTimeoutMedium,
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
        ///     Get [Confirm Address]-Dialog.Button.Cancel-object
        ///     It is needed to cancel a proposed configuration
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Button BtnCancel
        {
            get
            {
                try
                {
                    Button btnButton = null;
                    Host.Local.TryFindSingle(ConfigurationPaths.StrHARTAddressCancel, DefaultValues.iTimeoutMedium,
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
        ///     Get [Confirm Address]-Dialog.Combobox.DTM Polling Address-combobox
        ///     It is needed to set an HART Address for added device
        /// </summary>
        /// <returns>
        ///     <br>Combobox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ComboBox cobDTMPollingAddress
        {
            get
            {
                try
                {
                    ComboBox comboBox = null;
                    Host.Local.TryFindSingle(ConfirmAddressPaths.StrHARTAddressDTMPolling, DefaultValues.iTimeoutMedium,
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
        ///     Get [Confirm Address]-Dialog.Combobox.ListItem-object
        ///     It is needed to get a list-entry of a combobox
        /// </summary>
        /// <returns>
        ///     <br>ListItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static ListItem liComboboxList(string strAddress)
        {
            try
            {
                ListItem listItem = null;
                Host.Local.TryFindSingle(ConfirmAddressPaths.StrHARTAddressList + "[@text~'" + strAddress + "']",
                                         DefaultValues.iTimeoutMedium, out listItem);
                return listItem;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        ///     Get [Confirm Address]-Dialog.Textfield-object
        ///     It is needed to set a DTM Tag
        /// </summary>
        /// <returns>
        ///     <br>Text: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public static Text txtDTMTag()
        {
            try
            {
                Text text = null;
                Host.Local.TryFindSingle(ConfirmAddressPaths.StrHARTAddressDTMTag, DefaultValues.iTimeoutMedium,
                                         out text);
                return text;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}