//------------------------------------------------------------------------------
// <copyright file="UpdateProcessMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     UpdateProcessMessagePaths provides paths to messagebox [Update Process Pahts]
    /// </summary>
    public static class UpdateProcessMessagePaths
    {
        private const string strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";
        // Messagebox for Update Process
        /// <summary>
        /// 
        /// </summary>
        public const string strUpateProcessCancel = @strButtonHelpString + "[@controlid='2']";
    }
}