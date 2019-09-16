//------------------------------------------------------------------------------
// <copyright file="ReplaceProjectMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     ReplaceProjectMessagePaths provides paths to messagebox [Replace Project]
    /// </summary>
    public static class ReplaceProjectMessagePaths
    {
        private const string strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
        // MessageBox for overwriting already existing project
        public const string strReplaceProjectYes = @strButtonHelpString + "[@controlid='206']";
        public const string strReplaceProjectNo = @strButtonHelpString + "[@controlid='207']";
        public const string strReplaceProjectCancel = @strButtonHelpString + "[@controlid='203']";
    }
}