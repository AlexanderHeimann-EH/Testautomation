// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureModularTanksCircular.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureModularTanksCircular.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class ConfigureModularTanksCircular.
    /// </summary>
    public class ConfigureModularTanksCircular : IConfigureModularTanksCircular
    {
        #region Public Methods and Operators

        /// <summary>
        /// Selects tank type 'Modular tank' and configures its parameter if needed. Use empty strings if you do not want to configure a parameter.
        /// </summary>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <returns>
        /// <c>true</c> if configuration was successful, <c>false</c> otherwise.
        /// </returns>
        public bool Run(string height)
        {
            bool result = Execution.SelectTab.Run(1);

            result &= Execution.SetTankType.Run("Modular tank (Circular)");
            if (height != string.Empty)
            {
                result &= Execution.ConfigureTankParameter.SetModularTankCircularHeight(height);
                result &= AssertFunctions.AreEqual(height, Execution.ConfigureTankParameter.GetModularTankCircularHeight(), "Checking whether the height has been set correctly.");
            }                 

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring finished successfully.");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occurred during configuring.");
            }

            return result;
        }

        #endregion
    }
}