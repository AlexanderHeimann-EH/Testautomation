//------------------------------------------------------------------------------
// <copyright file="ReadingFromDevicePaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Providess paths for frame dialog [Reading from device]
    /// </summary>
    public static class ReadingFromDevicePaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string ButtonHelpString;
        private static readonly string ProgressHelpString;

        // Reading From Device Dialog GUI
        public static string buttonCancel;
        public static string progressTop;
        public static string progressBottom;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static ReadingFromDevicePaths()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                ButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
                ProgressHelpString = "/form[@ProcessName='FMPProgressBar']/progressbar";
            }
            else
            {
                ButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
                ProgressHelpString = "/form[@ProcessName='FMPProgressBar']/progressbar[@childindex='5']";
            }

            // Project Browser
            buttonCancel = @ButtonHelpString + "[@childindex='3']";
            progressTop = @ProgressHelpString + "[@childindex='4']";
            progressBottom = @ProgressHelpString + "[@childindex='5']";

            #endregion
        }
    }
}