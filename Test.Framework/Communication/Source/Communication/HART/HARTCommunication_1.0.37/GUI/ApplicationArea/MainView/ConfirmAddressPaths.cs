// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmAddressPaths.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 09.03.2011
 * Time: 14:00 
 * Last: -
 * Reason: Code documentation
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HARTCommunication.V1037.GUI.ApplicationArea.MainView
{
    /// <summary>
    ///     Paths to GUI-elements-objects of [Confirm Address]-dialog of CommDTM.
    /// </summary>
    public static class ConfirmAddressPaths
    {
        /// <summary>
        ///     Button help string
        /// </summary>
        public const string StrButtonHelpString = @"/form/element/form/container/element";

        /// <summary>
        ///     Path to text DTM Tag
        /// </summary>
        public const string StrHARTAddressDTMTag =
            StrButtonHelpString + "/element[@controlid='3']/text[@childindex='0']";

        /// <summary>
        ///     Path to comboBox Polling
        /// </summary>
        public const string StrHARTAddressDTMPolling = StrButtonHelpString + "/element[@controlid='1']/combobox";

        /// <summary>
        ///     Path to list
        /// </summary>
        public const string StrHARTAddressList = @"/list/listitem";

        /// <summary>
        ///     Path to button OK
        /// </summary>
        public static string StrHARTAddressOk = StrButtonHelpString + "/button[@controlid='4']";

        /// <summary>
        ///     Path to button Cancel
        /// </summary>
        public static string StrHARTAddressCancel = StrButtonHelpString + "/button[@controlid='5']";
    }
}