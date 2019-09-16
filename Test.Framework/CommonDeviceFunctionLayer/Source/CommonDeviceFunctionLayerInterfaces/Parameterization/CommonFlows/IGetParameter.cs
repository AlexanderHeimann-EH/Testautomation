// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetParameter.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.CommonDeviceFunctionLayerInterfaces.Parameterization.CommonFlows
{
    using EH.PCPS.TestAutomation.Common;

    /// <summary>
    /// The GetParameter interface.
    /// </summary>
    public interface IGetParameter
    {
        /// <summary>
        /// Get parameter
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// true: if successful; false: if an error occurred
        /// </returns>
        Parameter Run(Parameter parameter);

        /// <summary>
        /// Get parameter
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>Parameter: if successful, null: if an error occured</returns>
        Parameter Run(string parameter);
    }
}
