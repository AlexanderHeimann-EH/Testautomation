// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TakeScreenshotOfModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Takes a screenshot of the module
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Takes a screenshot of the module
    /// </summary>
    public class TakeScreenshotOfModule : ITakeScreenshotOfModule
    {
        #region Public Methods and Operators

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            Element moduleContainer = new ModuleContainerElements().ModuleContainer;
            if (moduleContainer == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module Container is null. Taking screenshot from the entire Desktop");
                Log.Screenshot();
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Taking screenshot of the module SaveRestore");
                moduleContainer.EnsureVisible();
                Log.Screenshot(moduleContainer);
            }
        }

        #endregion
    }
}