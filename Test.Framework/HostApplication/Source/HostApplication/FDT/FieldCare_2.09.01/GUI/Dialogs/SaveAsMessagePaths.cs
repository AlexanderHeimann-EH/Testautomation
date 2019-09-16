//------------------------------------------------------------------------------
// <copyright file="SaveAsMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 18.04.2012
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
    public static class SaveAsMessagePaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string GUIHelpString;

        // Save Restore GUI
        public static string Yes;
        public static string No;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static SaveAsMessagePaths()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                GUIHelpString = "/form[@processname='FMPFrame']/button";
            }
            else
            {
                GUIHelpString = "/form[@processname='FMPFrame']/button";
            }

            Yes = @GUIHelpString + "[@childindex='0']";
            No = @GUIHelpString + "[@childindex='1']";

            #endregion
        }
    }
}