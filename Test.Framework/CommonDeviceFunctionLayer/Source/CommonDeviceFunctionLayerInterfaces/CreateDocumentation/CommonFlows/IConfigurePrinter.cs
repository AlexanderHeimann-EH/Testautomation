// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigurePrinter.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.CreateDocumentation.CommonFlows
{
    using System.Collections.Generic;

    /// <summary>
    /// The ConfigurePrinter interface.
    /// </summary>
    public interface IConfigurePrinter
    {
        /// <summary>
        /// Configure Printer function
        /// </summary>
        /// <param name="printerSettings">
        /// The printer Settings.
        /// </param>
        /// <returns>true: if successful; false: if an error occurred</returns>
        bool Run(List<string> printerSettings);
    }
}
