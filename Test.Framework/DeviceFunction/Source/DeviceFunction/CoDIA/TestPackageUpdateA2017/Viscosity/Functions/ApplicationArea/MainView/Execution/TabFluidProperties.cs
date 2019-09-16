//------------------------------------------------------------------------------
// <copyright file="TabFluidProperties.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.GUI.ApplicationArea.MainView;

    /// <summary>
    /// Provides methods for configuring tab fluid properties
    /// </summary>
    public class TabFluidProperties : ITabFluidProperties
    {
        #region comboBox

        /// <summary>
        /// Gets or sets Combo box Assignment Column 1
        /// </summary>
        public string ComboBoxAssignmentColumn1
        {
            get { return (new EditParameter()).GetParameterValue((new FluidPropertiesElements()).ComboBoxAssignmentColumn1); }
            set { (new EditParameter()).SetParameterValue((new FluidPropertiesElements()).ComboBoxAssignmentColumn1, value); }
        }

        /// <summary>
        /// Gets or sets Combo box Assignment Column 2
        /// </summary>
        public string ComboBoxAssignmentColumn2
        {
            get { return (new EditParameter()).GetParameterValue((new FluidPropertiesElements()).ComboBoxAssignmentColumn2); }
            set { (new EditParameter()).SetParameterValue((new FluidPropertiesElements()).ComboBoxAssignmentColumn2, value); }
        }

        /// <summary>
        /// Gets or sets Combo Box Reference Temperature Unit
        /// </summary>
        public string ComboBoxReferenceTemperatureUnit
        {
            get { return (new EditParameter()).GetParameterValue((new FluidPropertiesElements()).ComboBoxReferenceTemperatureUnit); }
            set { (new EditParameter()).SetParameterValue((new FluidPropertiesElements()).ComboBoxReferenceTemperatureUnit, value); }
        }

        /// <summary>
        /// Gets or sets Combo Box Spreadsheet
        /// </summary>
        public string ComboBoxSpreadsheet
        {
            get { return (new EditParameter()).GetParameterValue((new FluidPropertiesElements()).ComboBoxSpreadsheet); }
            set { (new EditParameter()).SetParameterValue((new FluidPropertiesElements()).ComboBoxSpreadsheet, value); }
        }

        /// <summary>
        /// Gets or sets Combo Box Viscosity Unit
        /// </summary>
        public string ComboBoxViscosityUnit
        {
            get { return (new EditParameter()).GetParameterValue((new FluidPropertiesElements()).ComboBoxViscosityUnit); }
            set { (new EditParameter()).SetParameterValue((new FluidPropertiesElements()).ComboBoxViscosityUnit, value); }
        }

        #endregion

        #region TextBoxes

        /// <summary>
        /// Gets or sets Numeric TextBox Reference Temperature
        /// </summary>
        public string NumericTextBoxReferenceTemperature
        {
            get { return (new EditParameter()).GetParameterValue((new FluidPropertiesElements()).NumericTextBoxReferenceTemperature); }
            set { (new EditParameter()).SetParameterValue((new FluidPropertiesElements()).NumericTextBoxReferenceTemperature, value); }
        }

        /// <summary>
        /// Gets edit Control Reference Viscosity
        /// </summary>
        public string EditControlReferenceViscosity
        {            
            get { return (new EditParameter()).GetParameterValue((new FluidPropertiesElements()).EditControlReferenceViscosity); }
        }

        #endregion
    }
}
