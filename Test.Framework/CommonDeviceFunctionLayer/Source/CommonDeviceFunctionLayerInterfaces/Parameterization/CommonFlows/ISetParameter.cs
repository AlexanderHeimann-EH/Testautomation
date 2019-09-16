// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISetParameter.cs" company="Endress+Hauser Process Solutions AG">
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
    /// The SetParameter interface.
    /// </summary>
    public interface ISetParameter
    {
        /// <summary>
        /// Load table
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// true: if successful; false: if an error occurred
        /// </returns>
        bool Run(Parameter parameter);

        /// <summary>
        /// Runs the specified parameter name.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        bool Run(string parameterName, string parameterValue);
    }
}
