// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateDTMCatalogPaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Providess paths for dialog [Update DTM Catalog]
    /// </summary>
    public static class UpdateDTMCataloguePaths
    {
        #region Declaration

        // Help-Strings
        private static readonly string strButtonHelpString;

        // Update DTM Catalog
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalog;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogOk;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogCancel;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogMove;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogUpdate;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogHelp;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogLeft;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogRight;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogLeftStatus;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogLeftRow;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogLeftDevice;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogRightStatus;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogRightDevice;
        /// <summary>
        /// 
        /// </summary>
        public static string strUpdateDTMCatalogInProgress;
        /// <summary>
        /// 
        /// </summary>
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