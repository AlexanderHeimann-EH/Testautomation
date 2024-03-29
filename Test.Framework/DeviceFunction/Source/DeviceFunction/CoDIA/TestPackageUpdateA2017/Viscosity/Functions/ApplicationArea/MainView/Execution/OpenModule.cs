﻿//------------------------------------------------------------------------------
// <copyright file="OpenModule.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    ///     Provides function to open module frame-independent
    /// </summary>
    public class OpenModule : MarshalByRefObject, IOpenModule
    {
        /// <summary>
        ///     Open module via frame menu
        /// </summary>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool ViaMenu()
        {
            return this.ViaMenu(new ModuleName().Name);
        }

        /// <summary>
        ///     Open module via frame menu within a specific time
        /// </summary>
        /// <param name="moduleToOpen">Module name, if it differs from intended name</param>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool ViaMenu(string moduleToOpen)
        {
            // string internModuleName = HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Validation.OpenAdditionalModule.ViaMenu(
            // moduleToOpen);

            // if (internModuleName.Length > 0)
            // {
            // EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module activated");
            // return true;
            // }
            if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.OpenAdditionalModule.ViaMenu(moduleToOpen))
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module activated");
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                "Loader.Frame.Functions.OpenAdditionalModule.ViaMenu executed with errors.");
            return false;
        }
    }
}