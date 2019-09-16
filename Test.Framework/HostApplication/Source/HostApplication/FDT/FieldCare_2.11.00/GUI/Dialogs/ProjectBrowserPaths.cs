// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectBrowserPaths.cs" company="Endress+Hauser Process Solutions AG">
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
    using Common;

    /// <summary>
    ///     Providess paths for frame dialog [Project Browser]
    /// </summary>
    public static class ProjectBrowserPaths
    {
        #region Declaration

        /// <summary>
        /// 
        /// </summary>
        private static readonly string strButtonHelpString;

        // Project Browser GUI
        /// <summary>
        /// 
        /// </summary>
        public static string strProjectBrowserOpen;
        /// <summary>
        /// 
        /// </summary>
        public static string strProjectBrowserSave;
        /// <summary>
        /// 
        /// </summary>
        public static string strProjectBrowserCancel;
        /// <summary>
        /// 
        /// </summary>
        public static string strProjectBrowserHelp;
        /// <summary>
        /// 
        /// </summary>
        public static string strProjectBrowserClose;
        /// <summary>
        /// 
        /// </summary>
        public static string strProjectBrowserEmpty;
        /// <summary>
        /// 
        /// </summary>
        public static string strProjectBrowserName;
        /// <summary>
        /// 
        /// </summary>
        public static string strProjectBrowserText;
        /// <summary>
        /// 
        /// </summary>
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