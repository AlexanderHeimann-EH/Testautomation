//------------------------------------------------------------------------------
// <copyright file="IFDTDownload.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 19.04.2012
 * Time: 9:25 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows
{
    /// <summary>
    ///     Interface for flow FDT Download
    /// </summary>
    public interface IFdtDownload
    {
        /// <summary>
        ///     Start flow
        /// </summary>
        /// <returns></returns>
        bool Run();

        /// <summary>
        ///     Return after Percent
        /// </summary>
        /// <param name="percent">Percentage after which should be returned</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ReturnAfterPercent(int percent);

        /// <summary>
        ///     Wait until Progressbar is invisible
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool WaitForProgressBarInvisible();

        /// <summary>
        ///     Report meassured time
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool ReportMeasureTime();
    }
}