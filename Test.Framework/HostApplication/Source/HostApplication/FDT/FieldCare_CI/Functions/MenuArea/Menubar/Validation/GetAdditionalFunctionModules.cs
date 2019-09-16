//------------------------------------------------------------------------------
// <copyright file="GetAdditionalFunctionModules.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.CI.Functions.MenuArea.Menubar.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.MenuArea.MenuBar;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Menubar.Validation;

    using Ranorex;

    /// <summary>
    /// Class GetAdditionalFunctionModules.
    /// </summary>
    public class GetAdditionalFunctionModules : MarshalByRefObject, IGetAdditionalFunctionModules
    {
        /// <summary>
        ///     Get additional function modules at runtime
        /// </summary>
        /// <returns>
        ///     <br>List of button for available modules: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        public IList<Button> Run()
        {
            try
            {
                return (new Elements()).ListOfModules;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}