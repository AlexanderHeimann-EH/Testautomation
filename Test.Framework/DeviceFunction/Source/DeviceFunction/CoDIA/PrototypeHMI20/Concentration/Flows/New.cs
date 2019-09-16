// --------------------------------------------------------------------------------------------------------------------
// <copyright file="New.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Concentration.Functions.MenuArea.Toolbar;

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

            if (DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.Container.SelectTabCoefficientsOverview() == false)
            {
                return false;
            }

            if (DeviceFunctionLoader.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution.CoefficientsOverview.AreCoefficientsAvailable())
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