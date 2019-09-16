//------------------------------------------------------------------------------
// <copyright file="FindDevicePaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 05.11.2010
 * Time: 9:47 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Common;

namespace FieldCare_2._09._01.GUI.Dialogs
{
    /// <summary>
    ///     Providess paths for frame dialogs and GUI-elements
    /// </summary>
    public static class FindDevicePaths
    {
        #region Declaration

        /// <summary>
        ///     Help-string
        /// </summary>
        private static readonly string strButtonHelpString;

        /// <summary>
        ///     Path to text Device at dialog FindDevice
        /// </summary>
        public static string strFindDeviceText;

        /// <summary>
        ///     Path to button Find at dialog FindDevice
        /// </summary>
        public static string strFindDeviceFind;

        /// <summary>
        ///     Path to button Cancel at dialog FindDevice
        /// </summary>
        public static string strFindDeviceCancel;

        /// <summary>
        ///     Path to button Help at dialog FindDevice
        /// </summary>
        public static string strFindDeviceHelp;

        /// <summary>
        ///     Path to button Close at dialog FindDevice
        /// </summary>
        public static string strFindDeviceClose;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static FindDevicePaths()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
            }
            else
            {
                strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
            }

            // Find Dialog at Edit -> Find
            strFindDeviceText = @"/form[@ProcessName='FMPFrame']/element/text";
            strFindDeviceFind = @strButtonHelpString + "[@controlid='6']";
            strFindDeviceCancel = @strButtonHelpString + "[@controlid='5']";
            strFindDeviceHelp = @strButtonHelpString + "[@controlid='4']";
            strFindDeviceClose = @"/form[@ProcessName='FMPFrame']/titlebar/button[@childindex='0']";

            #endregion
        }
    }
}