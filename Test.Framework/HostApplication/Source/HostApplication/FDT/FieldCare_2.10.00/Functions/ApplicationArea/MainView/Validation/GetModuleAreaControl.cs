//------------------------------------------------------------------------------
// <copyright file="GetModuleAreaControl.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V21000.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class GetModuleAreaControl.
    /// </summary>
    public class GetModuleAreaControl : MarshalByRefObject, IGetModuleAreaControl
    {
        /// <summary>
        ///     Get module area control
        /// </summary>
        /// <returns>
        ///     <br>Element: if call worked fine</br>
        ///     <br>Null: If an error occurred</br>
        /// </returns>
        public Element Run()
        {
            try
            {
                return (new DtmViewElements()).ModuleArea;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}