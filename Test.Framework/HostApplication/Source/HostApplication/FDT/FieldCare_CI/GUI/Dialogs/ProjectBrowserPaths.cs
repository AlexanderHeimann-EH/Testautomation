//------------------------------------------------------------------------------
// <copyright file="ProjectBrowserPaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Providess paths for frame dialog [Project Browser]
    /// </summary>
    public static class ProjectBrowserPaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string strButtonHelpString;

        // Project Browser GUI
        public static string strProjectBrowserOpen;
        public static string strProjectBrowserSave;
        public static string strProjectBrowserCancel;
        public static string strProjectBrowserHelp;
        public static string strProjectBrowserClose;
        public static string strProjectBrowserEmpty;
        public static string strProjectBrowserName;
        public static string strProjectBrowserText;
        public static string strProjectBrowserList;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static ProjectBrowserPaths()
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

            // Project Browser
            strProjectBrowserOpen = @strButtonHelpString + "[@controlid='1']";
            strProjectBrowserSave = @strButtonHelpString + "[@controlid='1']";
            strProjectBrowserCancel = @strButtonHelpString + "[@controlid='2']";
            strProjectBrowserHelp = @strButtonHelpString + "[@controlid='4']";
            strProjectBrowserClose = @"/form[@ProcessName='FMPFrame']/titlebar/button[@childindex='0']";
            strProjectBrowserEmpty = @"/form[@ProcessName='FMPFrame']/element/container/list/listitem[@childindex='0']";
            strProjectBrowserList = @"/form[@ProcessName='FMPFrame']/element/container/list/";
            strProjectBrowserName = @"/form[@ProcessName='FMPFrame']/element/table/row/cell";
            strProjectBrowserText = @"/form[@ProcessName='FMPFrame']/element/element/text";

            #endregion
        }
    }
}