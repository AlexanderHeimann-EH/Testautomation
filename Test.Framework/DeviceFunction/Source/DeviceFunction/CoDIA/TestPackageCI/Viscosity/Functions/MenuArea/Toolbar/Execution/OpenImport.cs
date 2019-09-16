// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenImport.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Viscosity.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Viscosity.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    ///     Provides methods to start import
    /// </summary>
    public class OpenImport : MarshalByRefObject, IOpenImport
    {
        /// <summary>
        ///     Start import via related toolbar-icon
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ViaIcon()
        {
            try
            {
                Button button = (new ToolbarElements()).ImportButton;
                if (button != null && button.Enabled)
                {
                    button.Focus();
                    button.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessible");
                return false;
            }
            catch (Exception excException)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), excException.Message);
                return false;
            }
        }
    }
}