// --------------------------------------------------------------------------------------------------------------------
// <copyright file="New.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Flows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.MenuArea.Toolbar;

    /// <summary>
    /// Provides methods for clearing Concentration data
    /// </summary>
    public class New : INew
    {
        #region Public Methods and Operators

        /// <summary>
        /// Clears Concentration data via New button, checks whether coefficients in coefficients overview are empty
        /// </summary>
        /// <returns>true: if Concentration data is cleared; false: if an error occurred</returns>
        public bool Run()
        {
            if (Execution.OpenNew.ViaIcon() == false)
            {
                return false;
            }

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Wait until toolbar icon indicates that function new is performed successfully
            while (!Validation.IsNewButtonEnabled.Run())
            {
                if (stopwatch.ElapsedMilliseconds > Common.DefaultValues.iTimeoutModules)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Toolbar-Icon [New] is not active after {0} milliseconds", Common.DefaultValues.iTimeoutModules));
                    return false;
                }
            }

            if (DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution.Container.SelectTabCoefficientsOverview() == false)
            {
                return false;
            }

            if (DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution.CoefficientsOverview.AreCoefficientsAvailable())
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients are available, Concentration data is not cleared");
                return false;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clearing Concentration data succeeded");
            return true;
        }

        #endregion
    }
}