// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpenHostApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Zander, Jan 
 * Date: 12.02.2014
 * Time: 16:00
 * Last: -
 * Reason: -
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows
{
    /// <summary>
    /// The OpenHostApplication interface.
    /// </summary>
    public interface IOpenHostApplication
    {
        #region Public Methods and Operators

        /// <summary>
        /// Opens HostApplication
        /// </summary>
        /// <returns>
        /// true in case of success;false in case of an error
        /// </returns>
        bool Run();

        /// <summary>
        /// Opens HostApplication
        /// </summary>
        /// <param name="path">
        /// installation path of the HostApplication
        /// </param>
        /// <returns>
        /// true in case of success;false in case of an error
        /// </returns>
        bool Run(string path);

        /// <summary>
        /// Opens HostApplication
        /// </summary>
        /// <param name="path">
        /// installation path of the HostApplication
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time for action to finish.
        /// </param>
        /// <returns>
        /// true in case of success;false in case of an error
        /// </returns>
        bool Run(string path, int timeOutInMilliseconds);

        #endregion
    }
}