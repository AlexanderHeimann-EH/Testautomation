//------------------------------------------------------------------------------
// <copyright file="ModuleName.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 7/9/2013
 * Time: 3:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    /// <summary>
    ///     Description of ModuleName.
    /// </summary>
    public class ModuleName
    {
        /// <summary>
        ///     Returns name of actual module
        /// </summary>
        public string ModuleNameOnline
        {
            get { return "Online Parameterize"; }
        }

        /// <summary>
        ///     Returns name of actual module
        /// </summary>
        public string ModuleNameOffline
        {
            get { return "Offline Parameterize"; }
        }
    }
}