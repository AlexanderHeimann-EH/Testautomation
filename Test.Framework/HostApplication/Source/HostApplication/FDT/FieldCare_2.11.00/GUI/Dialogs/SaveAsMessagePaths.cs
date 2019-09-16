// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveAsMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 18.04.2012
 * Time: 13:02 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using Common;

    /// <summary>
    ///     Provide paths for setup wizzard navigation
    /// </summary>
    public static class SaveAsMessagePaths
    {
        #region Declaration

        /// <summary>
        /// 
        /// </summary>
        private static readonly string GUIHelpString;

        /// <summary>
        /// 
        /// </summary>
        public static string Yes;
        /// <summary>
        /// 
        /// </summary>
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