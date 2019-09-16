//------------------------------------------------------------------------------
// <copyright file="CloseModule.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Historom.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Historom.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    ///     Provides function to close module frame-independent
    /// </summary>
    public class CloseModule : ICloseModule
    {
        #region methods

        /// <summary>
        ///     Open module via frame menu
        /// </summary>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool ViaWindow()
        {
            return this.ViaWindow(new ModuleName().Name());
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
            if (HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Execution.CloseAdditionalModule.ViaWindow(moduleToClose))
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed");
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                "DeviceFunction.Common.Functions.CloseDTMRelatedModule.CloseViaWindow Executiond with errors.");
            return false;
        }

        #endregion
    }
}