// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureModularTank.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureModularTank.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class ConfigureModularTank.
    /// </summary>
    public class ConfigureModularTank : IConfigureModularTank
    {
        #region Public Methods and Operators

        /// <summary>
        /// Selects tank type 'Modular tank' and configures its parameter if needed. Use empty strings if you do not want to configure a parameter.
        /// </summary>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="view">
        /// The view.
        /// </param>
        /// <returns>
        /// <c>true</c> if configuration was successful, <c>false</c> otherwise.
        /// </returns>
        public bool Run(string height, string view)
        {
            bool result = Execution.SelectTab.Run(1);

            result &= Execution.SetTankType.Run("Modular tank");
            if (height != string.Empty)
            {
                result &= Execution.ConfigureTankParameter.SetModularTankHeight(height);
                result &= AssertFunctions.AreEqual(height, Execution.ConfigureTankParameter.GetModularTankHeight(), "Checking whether the height has been set correctly.");
            }

            if (view != string.Empty)
            {
                result &= Execution.ConfigureTankParameter.SetModularTankView(view);
                result &= AssertFunctions.AreEqual(view, Execution.ConfigureTankParameter.GetModularTankView(), "Checking whether the view has been set correctly.");
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