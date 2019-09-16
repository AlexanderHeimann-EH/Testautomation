﻿//------------------------------------------------------------------------------
// <copyright file="UpdateDTMCatalogMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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

namespace FieldCare_2._09._01.GUI.Dialogs
{
    /// <summary>
    ///     UpdateDTMCatalogMessagePaths provides paths to messagebox [Update DTM Catalog]
    /// </summary>
    public static class UpdateDTMCatalogMessagePaths
    {
        private const string strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
        // MessageBox for Updating DTM Catalog
        public const string strUpdateCatalogHelp = @strButtonHelpString + "[@controlid='1']";
        public const string strUpdateCatalogUpdate = @strButtonHelpString + "[@controlid='3']";
        public const string strUpdateCatalogIgnore = @strButtonHelpString + "[@controlid='2']";
    }
}