//------------------------------------------------------------------------------
// <copyright file="ReadFromDeviceMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 20.04.2012
 * Time: 13:02 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Common;

namespace FieldCare_2._09._01.GUI.Dialogs
{
    /// <summary>
    ///     Provide paths for setup wizzard navigation
    /// </summary>
    public static class ReadFromDeviceMessagePaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string ButtonHelpString;

        // Save Restore GUI
        public static string buttonYes;
        public static string buttonNo;
        public static string buttonClose;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static ReadFromDeviceMessagePaths()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                ButtonHelpString = "/form[@processname='FMPFrame']";
            }
            else
            {
                ButtonHelpString = "/form[@processname='FMPFrame']";
            }

            buttonYes = @ButtonHelpString + "/button[@childindex='0']";
            buttonNo = @ButtonHelpString + "/button[@childindex='1']";
            buttonClose = @ButtonHelpString + "/titlebar/button[@childindex='0']";

            #endregion
        }
    }
}