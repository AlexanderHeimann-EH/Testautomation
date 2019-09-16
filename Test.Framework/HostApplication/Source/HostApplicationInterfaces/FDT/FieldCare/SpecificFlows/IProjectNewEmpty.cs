//------------------------------------------------------------------------------
// <copyright file="IProjectNewEmpty.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 13.07.2011
 * Time: 9:58 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows
{
    /// <summary>
    ///     Interface for flow Project New Empty
    /// </summary>
    public interface IProjectNewEmpty
    {
        /// <summary>
        ///     Start flow
        /// </summary>
        /// <returns>
        ///     <br>True: if call worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        bool Run();
    }
}