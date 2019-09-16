﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClickOnExport.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The click on export.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.DipTable.Functions.MenuArea.Toolbar.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.DipTable.GUI.MenuArea.Toolbar;

    using Ranorex;

    /// <summary>
    /// The click on export.
    /// </summary>
    public class ClickOnExport : IClickOnExport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Mouse click on the button Export
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            bool result = true;

            Button button = (new ToolbarElements()).ExportButton;
            if (button == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Export button is not accessible, please check the Ranorex path in the repository");
                result = false;
            }
            else
            {
                if (button.Enabled == false)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Export button is not enabled, please check the preconditions");
                    result = false;
                }
                else
                {
                    button.Focus();
                    Mouse.MoveTo(button, 500);
                    button.Click(DefaultValues.locDefaultLocation);
                }
            }

            return result;
        }

        #endregion
    }
}