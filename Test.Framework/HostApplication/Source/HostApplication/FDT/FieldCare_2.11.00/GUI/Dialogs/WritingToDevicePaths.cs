// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WritingToDevicePaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Providess paths for frame dialog [Writing to device]
    /// </summary>
    public static class WritingToDevicePaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string ButtonHelpString;
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
        static WritingToDevicePaths()
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
                ProgressHelpString = "/form[@ProcessName='FMPProgressBar']/progressbar";
            }

            // Project Browser
            buttonCancel = @ButtonHelpString + "[@childindex='3']";
            progressTop = @ProgressHelpString + "[@childindex='4']";
            progressBottom = @ProgressHelpString + "[@childindex='5']";

            #endregion
        }
    }
}