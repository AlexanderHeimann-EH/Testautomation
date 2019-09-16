//------------------------------------------------------------------------------
// <copyright file="ShutdownDTMsMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     ShutdownDTMsMessagePaths provides paths to messagebox [Shutdown DTMs]
    /// </summary>
    public static class ShutdownDTMsMessagePaths
    {
        private const string StrButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
        // MessageBox for shutdown DTMs by closing project
        /// <summary>
        /// 
        /// </summary>
        public const string StrShutdownDTMsOk = StrButtonHelpString + "[@controlid='202']";
        /// <summary>
        /// 
        /// </summary>
        public const string StrShutdownDTMsCancel = StrButtonHelpString + "[@controlid='203']";
    }
}