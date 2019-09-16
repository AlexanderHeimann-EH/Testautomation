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

namespace FieldCare_2._09._01.GUI.Dialogs
{
    /// <summary>
    ///     SaveProjectMessagePaths provides paths to messagebox [Save Project]
    /// </summary>
    public static class SaveProjectMessagePaths
    {
        private const string StrButtonHelpString = "/form[@ProcessName='FMPFrame']/button";

        // MessageBox for saving project before closing
        public const string StrSaveProjectYes = StrButtonHelpString + "[@controlid='206']";
        public const string StrSaveProjectNo = StrButtonHelpString + "[@controlid='207']";
        public const string StrSaveProjectCancel = StrButtonHelpString + "[@controlid='203']";
    }
}