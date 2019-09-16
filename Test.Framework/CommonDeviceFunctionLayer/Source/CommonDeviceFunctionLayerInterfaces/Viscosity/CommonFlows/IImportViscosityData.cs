// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IImportViscosityData.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.Viscosity.CommonFlows
{
    /// <summary>
    /// The ImportViscosityData interface.
    /// </summary>
    public interface IImportViscosityData
    {
        /// <summary>
        /// Import viscosity data
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <returns>true: if successful; false: if an error occurred</returns>
        bool Run(string fileName);
    }
}
