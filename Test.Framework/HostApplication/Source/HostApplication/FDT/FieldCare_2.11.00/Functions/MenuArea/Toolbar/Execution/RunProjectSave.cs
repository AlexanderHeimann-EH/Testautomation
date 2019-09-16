// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RunProjectSave.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 30.04.2011
 * Time: 6:32 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.MenuArea.Toolbar.Execution;

    using Ranorex;

    /// <summary>
    ///     Start [Project Save]-functionality
    /// </summary>
    public class RunProjectSave : MarshalByRefObject, IRunProjectSave
    {
        /// <summary>
        /// Run via icon
        /// </summary>
        /// <returns><br>True: if call worked fine</br>
        /// <br>False: if an error occurred</br></returns>
        public bool ViaIcon()
        {
            try
            {
                // TODO: Toolbar-Icon-call to be implemented
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}