//------------------------------------------------------------------------------
// <copyright file="IFDTPrintAsPDF.cs" company="Endress+Hauser Process Solutions AG">
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
    ///     Interface for flow FDTPrintAsPDF.
    /// </summary>
    public interface IFdtPrintAsPdf
    {
        /// <summary>
        ///     Start flow
        /// </summary>
        /// <param name="reportType">Report Type to select</param>
        /// <param name="documentationName">Documentation name to enter</param>
        /// <param name="replaceProject">Boolean for file replacement</param>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Run(string reportType, string documentationName, bool replaceProject);
    }
}