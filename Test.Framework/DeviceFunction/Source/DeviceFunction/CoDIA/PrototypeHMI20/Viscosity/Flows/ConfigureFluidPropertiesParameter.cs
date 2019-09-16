// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureFluidPropertiesParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ConfigureFluidPropertiesParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Viscosity.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class ConfigureFluidPropertiesParameter.
    /// </summary>
    public class ConfigureFluidPropertiesParameter : IConfigureFluidPropertiesParameter
    {
        /// <summary>
        /// Configures the parameter of the tab 'Fluid Properties'.
        /// </summary>
        /// <param name="dynamicViscosityUnit">The dynamic viscosity unit. Use string.empty if you want to skip this parameter.</param>
        /// <param name="temperatureUnit">The temperature unit. Use string.empty if you want to skip this parameter.</param>
        /// <param name="referenceTemperature">The reference temperature. Use string.empty if you want to skip this parameter.</param>
        /// <param name="firstColumn">The first column. Use string.empty if you want to skip this parameter.</param>
        /// <param name="secondColumn">The second column. Use string.empty if you want to skip this parameter.</param>
        /// <returns><c>true</c> if all parameter are configured successfully, <c>false</c> otherwise.</returns>
        public bool Run(string dynamicViscosityUnit, string temperatureUnit, string referenceTemperature, string firstColumn, string secondColumn)
        {
            bool result = DeviceFunctionLoader.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution.SelectTab.Run(0);

            if (this.IsValid(dynamicViscosityUnit))
            {
                new TabFluidProperties().ComboBoxViscosityUnit = dynamicViscosityUnit;
                if (dynamicViscosityUnit != new TabFluidProperties().ComboBoxViscosityUnit)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring failed at setting dynamic viscosity unit. Value doesn't match expectation.");
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), dynamicViscosityUnit + " != " + new TabFluidProperties().ComboBoxViscosityUnit);
                    result = false;
                }
            }

            if (this.IsValid(temperatureUnit))
            {
                new TabFluidProperties().ComboBoxReferenceTemperatureUnit = temperatureUnit;
                if (temperatureUnit != new TabFluidProperties().ComboBoxReferenceTemperatureUnit)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring failed at setting temperature unit. Value doesn't match expectation.");
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), temperatureUnit + " != " + new TabFluidProperties().ComboBoxReferenceTemperatureUnit);
                    result = false;
                }
            }

            if (this.IsValid(referenceTemperature))
            {
                new TabFluidProperties().NumericTextBoxReferenceTemperature = referenceTemperature;
                if (referenceTemperature != new TabFluidProperties().NumericTextBoxReferenceTemperature)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring failed at setting reference temperature. Value doesn't match expectation.");
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), referenceTemperature + " != " + new TabFluidProperties().NumericTextBoxReferenceTemperature);
                    result = false;
                }
            }

            if (this.IsValid(firstColumn))
            {
                new TabFluidProperties().ComboBoxAssignmentColumn1 = firstColumn;
                if (firstColumn != new TabFluidProperties().ComboBoxAssignmentColumn1)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring failed at setting first column. Value doesn't match expectation.");
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), firstColumn + " != " + new TabFluidProperties().ComboBoxAssignmentColumn1);
                    result = false;
                }
            }

            if (this.IsValid(secondColumn))
            {
                new TabFluidProperties().ComboBoxAssignmentColumn2 = secondColumn;
                if (secondColumn != new TabFluidProperties().ComboBoxAssignmentColumn2)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring failed at setting second column. Value doesn't match expectation.");
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), secondColumn + " != " + new TabFluidProperties().ComboBoxAssignmentColumn2);
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsValid(string value)
        {
            if (value.Length > 0 && !value.Equals(" "))
            {
                return true;
            }

            return false;
        }
    }
}
