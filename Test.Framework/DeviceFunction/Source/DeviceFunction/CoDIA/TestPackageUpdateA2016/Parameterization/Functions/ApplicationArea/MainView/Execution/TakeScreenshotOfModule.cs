// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TakeScreenshotOfModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Takes a screenshot of the module
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView;

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
        public void OnlineParameterization()
        {
            Element moduleContainer = new ModuleContainerElements().ModuleContainerOnline;
            if (moduleContainer == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module Container is null. Taking screenshot from the entire Desktop");
                Log.Screenshot();
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Taking screenshot of the module OnlineParameterization");
                moduleContainer.EnsureVisible();
                Log.Screenshot(moduleContainer);
            }
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void OfflineParameterization()
        {
            Element moduleContainer = new ModuleContainerElements().ModuleContainerOffline;
            if (moduleContainer == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module Container is null. Taking screenshot from the entire Desktop");
                Log.Screenshot();
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Taking screenshot of the module OfflineParameterization");
                moduleContainer.EnsureVisible();
                Log.Screenshot(moduleContainer);
            }
        }

        #endregion
    }
}