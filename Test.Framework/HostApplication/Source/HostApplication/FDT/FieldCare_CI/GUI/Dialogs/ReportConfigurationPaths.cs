//------------------------------------------------------------------------------
// <copyright file="ReportConfigurationPaths.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 17.04.2012
 * Time: 9:47 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Common;

namespace FieldCare_2._09._01.GUI.Dialogs
{
    /// <summary>
    ///     Providess paths for dialog [Report Configuration]
    /// </summary>
    public static class ReportConfigurationPaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string strButtonHelpString;
        private static readonly string strGUIHelpString;

        // Report Configuration
        public static string strButtonPrint;
        public static string strButtonSaveAs;
        public static string strComboBoxReportType;
        public static string strListItemReportType;
        public static string strListItemsReportType;
        public static string strButtonCancel;
//		public static string strSave;
//		public static string strDelete;
//		public static string strUserInformation;
//		public static string strHelp;
//		public static string strPrintSetup;
//		public static string strPreview;
//		public static string strPrint;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static ReportConfigurationPaths()
        {
            #region Initializations

            if (SystemInformation.Is64Bit)
            {
                strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
                strGUIHelpString = "/form[@ProcessName='FMPFrame']/";
            }
            else
            {
                strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
                strGUIHelpString = "/form[@ProcessName='FMPFrame']/";
            }

            // ReportConfigurationPaths
            strButtonPrint = @strButtonHelpString + "[@controlid='4']";
            strButtonSaveAs = @strButtonHelpString + "[@controlid='2']";
            strButtonCancel = @strButtonHelpString + "[@controlid='3']";
            strComboBoxReportType = @strGUIHelpString + "element[@controlid='11']/combobox";
            strListItemReportType = @"/listitem[@text='REPORTTYPE']";
            strListItemsReportType = @"/list/listitem";

            #endregion
        }
    }
}