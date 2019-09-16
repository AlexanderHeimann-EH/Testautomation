// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISaveWithUpload.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 13.07.2015
 * Time: 10:00
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.SaveRestore.CommonFlows
{
    /// <summary>
    /// The SaveWithUpload interface.
    /// </summary>
    public interface ISaveWithUpload
    {
        /// <summary>
        /// Perform Save with upload
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>true: if successful; false: if an error occurred</returns>
        bool Run(string fileName);
    }
}
