// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsModuleReady.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides Validation methods which determine whether the module is ready or not
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.AboutBox.Functions.ApplicationArea.MainView.Validation
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.AboutBox.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    ///     Provides Validation methods which determine whether the module is ready or not
    /// </summary>
    public class IsModuleReady : IIsModuleReady
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks if button [About] is available
        /// </summary>
        /// <returns>
        /// <br>True: if module is ready</br>
        ///     <br>False: if module is not ready</br>
        /// </returns>
        public bool Run()
        {
            bool result = true;
            Button button = new MainViewElements().CopyToClipboardButton;

            if (button == null)
            {
                result = false;
            }

            return result;
        }

        #endregion
    }
}