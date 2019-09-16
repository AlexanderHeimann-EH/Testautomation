// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSphericalTank.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureSphericalTank.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class ConfigureSphericalTank.
    /// </summary>
    public class ConfigureSphericalTank : IConfigureSphericalTank
    {
        /// <summary>
        /// Selects tank type 'Spherical tank' and configures its parameter if needed. Use empty strings if you do not want to configure a parameter.
        /// </summary>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="diameter">
        /// The diameter.
        /// </param>
        /// <returns>
        /// <c>true</c> if configuration was successful, <c>false</c> otherwise.
        /// </returns>
        public bool Run(string height, string diameter)
        {
            bool result = Execution.SelectTab.Run(1);

            result &= Execution.SetTankType.Run("Spherical tank");
            if (height != string.Empty)
            {
                result &= Execution.ConfigureTankParameter.SetSphericalTankHeight(height);
                result &= AssertFunctions.AreEqual(height, Execution.ConfigureTankParameter.GetSphericalTankHeight(), "Checking whether the height has been set correctly.");
            }

            if (diameter != string.Empty)
            {
                result &= Execution.ConfigureTankParameter.SetSphericalTankDiameter(diameter);
                result &= AssertFunctions.AreEqual(diameter, Execution.ConfigureTankParameter.GetSphericalTankDiameter(), "Checking whether the diameter has been set correctly.");
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
    }
}