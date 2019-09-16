//------------------------------------------------------------------------------
// <copyright file="SaveProjectMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    /// <summary>
    ///     SaveProjectMessagePaths provides paths to messagebox [Save Project]
    /// </summary>
    public static class SaveProjectMessagePaths
    {
        /// <summary>
        /// 
        /// </summary>
        private const string StrButtonHelpString = "/form[@ProcessName='FMPFrame']/button";

        // MessageBox for saving project before closing
        /// <summary>
        /// 
        /// </summary>
        public const string StrSaveProjectYes = StrButtonHelpString + "[@controlid='206']";
        /// <summary>
        /// 
        /// </summary>
        public const string StrSaveProjectNo = StrButtonHelpString + "[@controlid='207']";
        /// <summary>
        /// 
        /// </summary>
        public const string StrSaveProjectCancel = StrButtonHelpString + "[@controlid='203']";
    }
}