// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckDiagram.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CheckDiagram.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Flows
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;

    /// <summary>
    /// Class CheckDiagram.
    /// </summary>
    public class CheckDiagram : ICheckDiagram
    {
        /// <summary>
        /// Selects the tab diagram data and makes a screenshot.
        /// </summary>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            bool result = DeviceFunctionLoader.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution.RunSelectTab.Run(1);
            DeviceFunctionLoader.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution.TakeScreenshotOfModule.Run();

            return result;
        }
    }
}