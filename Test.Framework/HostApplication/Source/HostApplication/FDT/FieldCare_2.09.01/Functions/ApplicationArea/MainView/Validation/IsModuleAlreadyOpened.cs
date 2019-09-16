//------------------------------------------------------------------------------
// <copyright file="IsModuleAlreadyOpened.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    /// Class IsModuleAlreadyOpened.
    /// </summary>
    public class IsModuleAlreadyOpened : MarshalByRefObject, IIsModuleAlreadyOpened
    {
        /// <summary>
        ///     Checks if a specified module is already open
        /// </summary>
        /// <param name="moduleName">Name of module </param>
        /// <returns>
        ///     <br>True: if module is already open</br>
        ///     <br>False: if module is not already opened</br>
        /// </returns>
        public bool Run(string moduleName)
        {
            try
            {
                bool isModuleAlreadyOpened = false;
                IList<Form> moduleList = (new GetOpenedModules()).Run();

                if (moduleList != null && moduleList.Count >= 0)
                {
                    foreach (Form form in moduleList)
                    {
                        if (form.Title.Contains(moduleName))
                        {
                            isModuleAlreadyOpened = true;
                        }
                    }

                    return isModuleAlreadyOpened;
                }

                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}