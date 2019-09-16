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

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    /// <summary>
    ///     ReplaceProjectMessagePaths provides paths to messagebox [Replace Project]
    /// </summary>
    public static class ReplaceProjectMessagePaths
    {
        /// <summary>
        /// 
        /// </summary>
        private const string strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
        // MessageBox for overwriting already existing project
        /// <summary>
        /// 
        /// </summary>
        public const string strReplaceProjectYes = @strButtonHelpString + "[@controlid='206']";
        /// <summary>
        /// 
        /// </summary>
        public const string strReplaceProjectNo = @strButtonHelpString + "[@controlid='207']";
        /// <summary>
        /// 
        /// </summary>
        public const string strReplaceProjectCancel = @strButtonHelpString + "[@controlid='203']";
    }
}