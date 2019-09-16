//------------------------------------------------------------------------------
// <copyright file="IReportConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 17.04.2012
 * Time: 9:47 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ReportConfiguration.Execution
{
    /// <summary>
    ///     Interface for dialog Report Configuration
    /// </summary>
    public interface IReportConfiguration
    {
        /// <summary>
        ///     Cancel dialog
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Cancel();

        /// <summary>
        ///     Start printing
        /// </summary>
        /// <param name="reportType">Report type to print</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Print(string reportType);

        /// <summary>
        ///     Start printing as PDF
        /// </summary>
        /// <param name="reportType">Report type to print</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool SaveAsPDF(string reportType);

        /// <summary>
        ///     Select report type
        /// </summary>
        /// <param name="reportType">Report type to select</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool SelectReportType(string reportType);
    }
}