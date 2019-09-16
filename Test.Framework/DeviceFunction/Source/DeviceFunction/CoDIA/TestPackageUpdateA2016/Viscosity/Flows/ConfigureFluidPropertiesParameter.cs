
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Functions.ApplicationArea.MainView.Execution;

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
            
            if (dynamicViscosityUnit != string.Empty)
            {
                new TabFluidProperties().ComboBoxViscosityUnit = dynamicViscosityUnit;
                result &= dynamicViscosityUnit == new TabFluidProperties().ComboBoxViscosityUnit;
            }

            if (temperatureUnit != string.Empty)
            {
                new TabFluidProperties().ComboBoxReferenceTemperatureUnit = temperatureUnit;
                result &= temperatureUnit == new TabFluidProperties().ComboBoxReferenceTemperatureUnit;
            }


            if (referenceTemperature != string.Empty)
            {
                new TabFluidProperties().NumericTextBoxReferenceTemperature = referenceTemperature;
                result &= referenceTemperature == new TabFluidProperties().NumericTextBoxReferenceTemperature;
            }

            if (firstColumn != string.Empty)
            {
                new TabFluidProperties().ComboBoxAssignmentColumn1 = firstColumn;
                result &= firstColumn == new TabFluidProperties().ComboBoxAssignmentColumn1;
            }

            if (secondColumn != string.Empty)
            {
                new TabFluidProperties().ComboBoxAssignmentColumn2 = secondColumn;
                result &= secondColumn == new TabFluidProperties().ComboBoxAssignmentColumn2;
            }

            return result;
        }
    }
}
