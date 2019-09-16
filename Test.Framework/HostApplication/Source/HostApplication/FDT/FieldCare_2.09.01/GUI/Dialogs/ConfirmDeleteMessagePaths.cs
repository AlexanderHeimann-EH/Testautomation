//------------------------------------------------------------------------------
// <copyright file="ConfirmDeleteMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     ConfirmDeleteMessagePaths provides paths to messagebox [Confirm Delete]
    /// </summary>
    public static class ConfirmDeleteMessagePaths
    {
        /// <summary>
        ///     Help-string
        /// </summary>
        private const string strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";

        /// <summary>
        ///     Path to button yes in messagebox Confirm Delete Device
        /// </summary>
        public const string strConfirmDeleteYes = @strButtonHelpString + "[@controlid='206']";

        /// <summary>
        ///     Path to button no in messagebox Confirm Delete Device
        /// </summary>
        public const string strConfirmDeleteNo = @strButtonHelpString + "[@controlid='207']";
    }
}