//------------------------------------------------------------------------------
// <copyright file="IGetOpenedModule.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.Collections.Generic;

    using Ranorex;

    /// <summary>
    /// 
    /// </summary>
    public interface IGetOpenedModules
    {
        /// <summary>
        ///     Get list of already opened modules
        /// </summary>
        /// <returns>
        ///     <br>List of forms for opened modules: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        IList<Form> Run();
    }
}