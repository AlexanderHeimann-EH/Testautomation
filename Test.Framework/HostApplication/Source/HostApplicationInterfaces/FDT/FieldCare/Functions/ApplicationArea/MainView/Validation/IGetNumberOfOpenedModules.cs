//------------------------------------------------------------------------------
// <copyright file="GetNumberOfOpenedModules.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 16:00 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGetNumberOfOpenedModules
    {
        /// <summary>
        ///     Get number of opened modules
        /// </summary>
        /// <returns>
        ///     <br>Value >= 0: If call worked fine</br>
        ///     <br>-1: If an error occurred</br>
        /// </returns>
        int Run();
    }
}