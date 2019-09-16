//------------------------------------------------------------------------------
// <copyright file="OpenUnavailableProjectMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     FrameMessagesMessagePaths provides paths to messagebox [Open Unavailable Project]
    /// </summary>
    public static class OpenUnavailableProjectMessagePaths
    {
        /// <summary>
        /// The Button Help String
        /// </summary>
        private const string strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
        // MessageBox for opening unavailable project

        /// <summary>
        /// The Open Unavailable Projects Ok
        /// </summary>
        public const string strOpenUnavailableProjectsOk = @strButtonHelpString + "[@controlid='202']";
    }
}