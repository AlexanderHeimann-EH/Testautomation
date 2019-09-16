//------------------------------------------------------------------------------
// <copyright file="WriteToDeviceWarningMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using EH.PCPS.TestAutomation.Common;

    /// <summary>
    ///     Provide paths for FDT Download messagebox
    /// </summary>
    public static class WriteToDeviceWarningMessagePaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string ButtonHelpString;

        // Save Restore GUI
        /// <summary>
        /// 
        /// </summary>
        public static string buttonYes;
        /// <summary>
        /// 
        /// </summary>
        public static string buttonNo;
        /// <summary>
        /// 
        /// </summary>
        public static string buttonClose;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static WriteToDeviceWarningMessagePaths()
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