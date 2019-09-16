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

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using EH.PCPS.TestAutomation.Common;

    /// <summary>
    ///     Providess paths for frame dialog [Reading from device]
    /// </summary>
    public static class ReadingFromDevicePaths
    {
        #region Declaration

        /// <summary>
        /// 
        /// </summary>
        private static readonly string ButtonHelpString;
        /// <summary>
        /// 
        /// </summary>
        private static readonly string ProgressHelpString;

        // Reading From Device Dialog GUI
        /// <summary>
        /// 
        /// </summary>
        public static string buttonCancel;
        /// <summary>
        /// 
        /// </summary>
        public static string progressTop;
        /// <summary>
        /// 
        /// </summary>
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