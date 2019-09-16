//------------------------------------------------------------------------------
// <copyright file="UpdateDTMCatalogPaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Providess paths for dialog [Update DTM Catalog]
    /// </summary>
    public static class UpdateDTMCataloguePaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string strButtonHelpString;

        // Update DTM Catalog
        public static string strUpdateDTMCatalog;
        public static string strUpdateDTMCatalogOk;
        public static string strUpdateDTMCatalogCancel;
        public static string strUpdateDTMCatalogMove;
        public static string strUpdateDTMCatalogUpdate;
        public static string strUpdateDTMCatalogHelp;
        public static string strUpdateDTMCatalogLeft;
        public static string strUpdateDTMCatalogRight;
        public static string strUpdateDTMCatalogLeftStatus;
        public static string strUpdateDTMCatalogLeftRow;
        public static string strUpdateDTMCatalogLeftDevice;
        public static string strUpdateDTMCatalogRightStatus;
        public static string strUpdateDTMCatalogRightDevice;
        public static string strUpdateDTMCatalogInProgress;
        public static string strUpdateDTMCatalogDeviceRemoved;

        #endregion

        /// <summary>
        ///     Static constructor to load operating system dependent path
        /// </summary>
        static UpdateDTMCataloguePaths()
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

            // Update DTM Catalog
            strUpdateDTMCatalogOk = @strButtonHelpString + "[@controlid='9']";
            strUpdateDTMCatalogCancel = @strButtonHelpString + "[@controlid='5']";
            strUpdateDTMCatalogMove = @strButtonHelpString + "[@controlid='1']";
            strUpdateDTMCatalogUpdate = @strButtonHelpString + "[@controlid='7']";
            strUpdateDTMCatalogHelp = @strButtonHelpString + "[@controlid='6']";
            strUpdateDTMCatalogLeft = @"/form[@ProcessName='FMPFrame']/element[@controlid='3']/table";
            strUpdateDTMCatalogRight = @"/form[@ProcessName='FMPFrame']/element[@controlid='2']/table";
            strUpdateDTMCatalogLeftRow = @strUpdateDTMCatalogLeft + "/row";
            strUpdateDTMCatalogLeftStatus = @strUpdateDTMCatalogLeft + "/column[@index='0']/cell";
            strUpdateDTMCatalogLeftDevice = @strUpdateDTMCatalogLeft + "/column[@index='1']/cell";
            strUpdateDTMCatalogRightStatus = @strUpdateDTMCatalogRight + "/column[@index='0']/cell";
            strUpdateDTMCatalogRightDevice = @strUpdateDTMCatalogRight + "/column[@index='1']/cell";
            strUpdateDTMCatalog = "/form[@title='Update DTM Catalog']";
            strUpdateDTMCatalogDeviceRemoved = "/form[@title~'^Device\\ type\\ removed\\ from\\ ']";
            strUpdateDTMCatalogInProgress = "/form[@title='Update progress']";

            #endregion
        }
    }
}