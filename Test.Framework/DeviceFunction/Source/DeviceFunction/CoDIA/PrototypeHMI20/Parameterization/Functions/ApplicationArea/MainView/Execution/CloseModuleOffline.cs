﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseModuleOffline.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
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

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar;

    /// <summary>
    ///     Provides function to close module frame-independent
    /// </summary>
    public class CloseModuleOffline : ICloseModuleOffline
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
            //return this.ViaWindow((new ModuleName()).ModuleNameOffline());
            return Execution.RunCloseAllWindows.ViaMenu();
        }

        /// <summary>
        ///     Close module via tab at related tab control
        /// </summary>
        /// <param name="moduleToClose">Module name, if it differs from intended name</param>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool ViaWindow(string moduleToClose)
        {
            if (Execution.CloseAdditionalModule.ViaWindow(moduleToClose))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "DeviceFunction.Common.Functions.CloseDTMRelatedModule.CloseViaWindow executed with errors.");
            return false;
        }

        #endregion
    }
}