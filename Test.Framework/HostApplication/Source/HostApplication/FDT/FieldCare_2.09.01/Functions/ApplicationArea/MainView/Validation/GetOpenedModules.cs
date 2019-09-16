//------------------------------------------------------------------------------
// <copyright file="GetOpenedModules.cs" company="Endress+Hauser Process Solutions AG">
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
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    /// Class GetOpenedModules.
    /// </summary>
    public class GetOpenedModules : MarshalByRefObject, IGetOpenedModules
    {
        /// <summary>
        ///     Get list of already opened modules
        /// </summary>
        /// <returns>
        ///     <br>List of forms for opened modules: If call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        public IList<Form> Run()
        {
            try
            {
                return (new DtmViewElements()).Modules;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}