//------------------------------------------------------------------------------
// <copyright file="ModuleName.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 7/22/2013
 * Time: 1:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.Functions.ApplicationArea.MainView.Validation
{
    using System;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Description of ModuleName.
    /// </summary>
    public class ModuleName : MarshalByRefObject, IModuleName
    {
        /// <summary>
        ///     Returns name of actual module
        /// </summary>
        public string moduleName
        {
            get { return "Save / Restore"; }
        }
    }
}