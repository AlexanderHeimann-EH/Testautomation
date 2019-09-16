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

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    /// Class GetNumberOfOpenedModules.
    /// </summary>
    public class GetNumberOfOpenedModules : MarshalByRefObject, IGetNumberOfOpenedModules
    {
        /// <summary>
        ///     Get number of opened modules
        /// </summary>
        /// <returns>
        ///     <br>Value >= 0: If call worked fine</br>
        ///     <br>-1: If an error occurred</br>
        /// </returns>
        public int Run()
        {
            try
            {
                IList<Form> formList = (new GetOpenedModules()).Run();
                if (formList != null)
                {
                    return formList.Count;
                }

                return 0;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return -1;
            }
        }
    }
}