//------------------------------------------------------------------------------
// <copyright file="FileBrowserPaths.cs" company="Endress+Hauser Process Solutions AG">
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
using Common.Tools;
using System.Reflection;

namespace FieldCare_2._09._01.GUI.Dialogs
{
    /// <summary>
    ///     Provide paths for Save As dialog
    /// </summary>
    public static class FileBrowserPaths
    {
        #region Declaration

        /// <summary>
        ///     Help-string
        /// </summary>
        private static readonly string GUIHelpString;

        /// <summary>
        ///     ComboBox pre path which is OS specific
        /// </summary>
        private static readonly string ComboBoxPrePath;

        /// <summary>
        ///     Path to button Close at Dialog File Browser
        /// </summary>
        public static string Close;

        /// <summary>
        ///     Path to button Save at Dialog File Browser
        /// </summary>
        public static string Save;

        /// <summary>
        ///     Path to button Open at Dialog File Browser
        /// </summary>
        public static string Open;

        /// <summary>
        ///     Path to button Cancel at Dialog File Browser
        /// </summary>
        public static string Cancel;

        /// <summary>
        ///     Path to text Filename at Dialog File Browser
        /// </summary>
        public static string Filename;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static FileBrowserPaths()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                GUIHelpString = "/form[@processname='FMPFrame']";
            }
            else
            {
                GUIHelpString = "/form[@processname='FMPFrame']";
            }

            if (SystemInformation.IsWin7 || SystemInformation.IsWin8)
            {
                ComboBoxPrePath = "/form[@processname='FMPFrame']/element/container/element";
            }
            else
            {
                if (SystemInformation.IsWinXP)
                {
                    ComboBoxPrePath = "/form[@processname='FMPFrame']";
                }
                else
                {
                    ComboBoxPrePath = string.Empty;
		    Ranorex.Report.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unkown Operating System. Canceling...");
                }
            }


            // Wizzard navigation
            Close = @GUIHelpString + "/titlebar/button[@childindex='1' and @AccessibleDescription='Closes the window']";
            Save = @GUIHelpString + "/button[@controlid='1']";
            Open = @GUIHelpString + "/button[@controlid='1']";
            Cancel = @GUIHelpString + "/button[@controlid='2']";
            Filename = @ComboBoxPrePath + "/combobox/text";

            #endregion
        }
    }
}