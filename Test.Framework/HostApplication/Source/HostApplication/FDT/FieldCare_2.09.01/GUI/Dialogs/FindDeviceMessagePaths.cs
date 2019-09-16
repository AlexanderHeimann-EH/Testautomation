//------------------------------------------------------------------------------
// <copyright file="FindDeviceMessagePaths.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     FindDeviceMessagePaths provides paths to messagebox [Find Device]
    /// </summary>
    public static class FindDeviceMessagePaths
    {
        /// <summary>
        ///     Help-string
        /// </summary>
        private const string strButtonHelpString = "/form[@ProcessName='FMPFrame']/button";

        /// <summary>
        ///     Path to button OK at messagebox FindUnavailbleDevice
        /// </summary>
        public const string strFindUnavailableDeviceOk = @strButtonHelpString + "[@controlid='202']";
    }
}