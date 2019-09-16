// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopyToClipboard.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Copy about box information to clipboard.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.AboutBox.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.AboutBox.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Copy about box information to clipboard.
    /// </summary>
    public class CopyToClipboard : ICopyToClipboard
    {
        #region Public Methods and Operators

        /// <summary>
        /// Starts execution
        /// </summary>
        /// <returns>
        /// true if button is found and clicked, false if an error occurred
        /// </returns>
        public bool Run()
        {
            this.FocusOnAboutBox();
            bool result = false;
            Button button = new MainViewElements().CopyToClipboardButton;

            if (button == null || button.Enabled == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button [Copy To Clipboard] is not available");
            }
            else
            {
                Mouse.Click(button);
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button [Copy To Clipboard] found and clicked");
                result = true;
            }

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets focus on the AboutBox and ensures the container is visible. Information is not copied to clipboard if module is not in focus.
        /// </summary>
        private void FocusOnAboutBox()
        {
            Element element = new ModuleContainerElements().ModuleContainer;
            if (element != null)
            {
                element.EnsureVisible();
                element.Focus();
            }
        }

        #endregion
    }
}