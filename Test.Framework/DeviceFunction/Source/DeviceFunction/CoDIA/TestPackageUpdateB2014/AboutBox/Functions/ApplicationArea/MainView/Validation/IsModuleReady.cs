//------------------------------------------------------------------------------
// <copyright file="IsModuleReady.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.AboutBox.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.AboutBox.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    ///     Provides Validation methods which determine whether the module is ready or not
    /// </summary>
    public class IsModuleReady : IIsModuleReady
    {
        /// <summary>
        /// Checks if button [About] is available
        /// </summary>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool Run()
        {
            bool result = false;
            Button button = new MainViewElements().CopyToClipboardButton;

            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The button [Copy To Clipboard] is not available");
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}