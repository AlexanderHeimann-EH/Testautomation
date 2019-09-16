﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TakeScreenshotOfModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//  Takes a screenshot of the module
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Takes a screenshot of the module
    /// </summary>
    public class TakeScreenshotOfModule : ITakeScreenshotOfModule
    {
        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            Ranorex.Core.Element moduleContainer = new EnvelopeCurve.GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainer;
            if (moduleContainer == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module Container is null. Taking screenshot from the entire Desktop");
                Log.Screenshot();
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Taking screenshot of the module EnvelopeCurve");
                moduleContainer.EnsureVisible();
                Log.Screenshot(moduleContainer);
            }
        }
    }
}