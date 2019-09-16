// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 02.11.2012
 * Time: 7:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Provides function to close module frame-independent
    /// </summary>
    public class CloseModule : MarshalByRefObject, ICloseModule
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Close module via DTM window
        /// </summary>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool ViaWindow()
        {
            return this.ViaWindow(new ModuleName().moduleName);
        }

        /// <summary>
        /// Close module via tab at related tab control
        /// </summary>
        /// <param name="moduleToClose">
        /// Module name, if it differs from intended name
        /// </param>
        /// <returns>
        /// <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool ViaWindow(string moduleToClose)
        {
            // string internModuleName = HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Validation.CloseAdditionalModule.ViaWindow
            // (moduleToClose);

            // if (internModuleName.Length > 0)
            // {
            // EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed");
            // return true;
            // }
            if (Execution.CloseAdditionalModule.ViaWindow(moduleToClose))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Closing Executiond with errors.");
            return false;
        }

        #endregion
    }
}