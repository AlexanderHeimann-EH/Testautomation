// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenModuleOffline.cs" company="Endress+Hauser Process Solutions AG">
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

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    ///     Provides function to open module frame-independent
    /// </summary>
    public class OpenModuleOffline : IOpenModuleOffline
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
            string internModuleName = HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.OpenOfflineParameterization.ViaMenu();

            if (internModuleName.Length > 0)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module activated");
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Loader.Frame.Functions.OpenAdditionalModule.ViaMenu executed with errors.");
            return false;
        }
    }
}