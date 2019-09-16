// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddDevicePaths.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 05.11.2010
 * Time: 9:47 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using EH.PCPS.TestAutomation.Common;

    /// <summary>
    ///     Providess paths for dialog [Add Device]
    /// </summary>
    public static class AddDevicePaths
    {
        #region properties

        /// <summary>
        ///     Help-String for buttons
        /// </summary>
        private static readonly string strButtonHelpString;

        /// <summary>
        ///     Provides path to cell Device Name of FieldCare 2.09.00 dialog Add Device
        /// </summary>
        public static string strAddDeviceName;

        /// <summary>
        ///     Provides path to button Ok of FieldCare 2.09.00 dialog Add Device
        /// </summary>
        public static string strAddDeviceOk;

        /// <summary>
        ///     Provides path to button Cancel of FieldCare 2.09.00 dialog Add Device
        /// </summary>
        public static string strAddDeviceCancel;

        /// <summary>
        ///     Provides path to button Help of FieldCare 2.09.00 dialog Add Device
        /// </summary>
        public static string strAddDeviceHelp;

        /// <summary>
        ///     Provides path to button Close (x) of FieldCare 2.09.00 dialog Add Device
        /// </summary>
        public static string strAddDeviceClose;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static AddDevicePaths()
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

            // Add Device Dialog at Device Operation -> Add Device
            strAddDeviceName = @"/form[@ProcessName='FMPFrame']/table/row/cell[@childindex='0']";
            strAddDeviceOk = @strButtonHelpString + "[@controlid='3']";
            strAddDeviceCancel = @strButtonHelpString + "[@controlid='2']";
            strAddDeviceHelp = @strButtonHelpString + "[@controlid='1']";
            strAddDeviceClose = @"/form[@ProcessName='FMPFrame']/titlebar/button[@childindex='2']";

            #endregion
        }
    }
}