//------------------------------------------------------------------------------
// <copyright file="IGetAdditionalFunctionModules.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Jan Zander
 * Date: 13.02.2014
 * Time: 15:54 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Validation
{
    using System.Collections.Generic;

    using Ranorex;

    /// <summary>
    /// 
    /// </summary>
    public interface IGetAdditionalFunctionModules
    {
        /// <summary>
        ///     Get additional function modules at runtime
        /// </summary>
        /// <returns>
        ///     <br>List of button for available modules: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        IList<Button> Run();
    }
}