//------------------------------------------------------------------------------
// <copyright file="IFrameExitWithoutSaving.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
/*
 * Created by Ranorex
 * User: Matthias Scherzinger
 * Date: 03.07.2012
 * Time: 14:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows
{
    /// <summary>
    ///     Provides methods for flow IFrameExitWithoutSaving
    /// </summary>
    public interface IFrameExitWithoutSaving
    {
        /// <summary>
        ///     Methods to start network creation
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Run();

        /// <summary>
        ///     Methods to start network creation
        /// </summary>
        /// <param name="timeOutInMilliseconds">Time until action must be finished</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Run(int timeOutInMilliseconds);
    }
}