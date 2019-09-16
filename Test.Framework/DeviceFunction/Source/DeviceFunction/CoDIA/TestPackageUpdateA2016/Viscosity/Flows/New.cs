//------------------------------------------------------------------------------
// <copyright file="New.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Flows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;

    using Ranorex;

    /// <summary>
    ///  Provides methods for clearing Viscosity data
    /// </summary>
    public class New : MarshalByRefObject, INew
    {
        /// <summary>
        /// Clears Viscosity data via New button
        /// </summary>
        /// <returns>true: if Viscosity data is cleared; false: if an error occurred</returns>
        public bool Run()
        {
            Stopwatch watch = new Stopwatch();

            if (DeviceFunctionLoader.CoDIA.Viscosity.Functions.MenuArea.Toolbar.Execution.OpenNew.ViaIcon() == false)
            {
                return false;
            }

            // Wait until Data is cleared
            watch.Start();

            while ((new GUI.MenuArea.Toolbar.ToolbarElements()).NewButton.Enabled &&
                   watch.ElapsedMilliseconds <= DefaultValues.iTimeoutMedium)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Viscosity Data is not cleared");
            }

            watch.Stop();

            if ((new GUI.MenuArea.Toolbar.ToolbarElements()).NewButton.Enabled)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clearing Viscosity Data failed -> New button is still enabled");
                return false;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clearing Viscosity data succeeded");
            return true;
        }
    }
}
