//------------------------------------------------------------------------------
// <copyright file="IReadingFromDevice.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 20.04.2012
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ReadingFromDevice.Execution
{
    /// <summary>
    ///     Interface for dialog Reading From Device
    /// </summary>
    public interface IReadingFromDevice
    {
        /// <summary>
        ///     Progress bar value in percentage
        /// </summary>
        double ProgressBarValuePercent { get; }

        /// <summary>
        ///     Cancel dialog
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Cancel();
    }
}