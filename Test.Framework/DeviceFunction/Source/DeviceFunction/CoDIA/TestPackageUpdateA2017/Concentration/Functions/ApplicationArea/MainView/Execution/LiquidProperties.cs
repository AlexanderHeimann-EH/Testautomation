// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LiquidProperties.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Concentration.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Concentration.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for tab liquid properties within module concentration
    /// </summary>
    public class LiquidProperties : ILiquidProperties
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the fine tuning value 1 unit.
        /// </summary>
        public string FineTuningValue1Unit { get; set; }

        /// <summary>
        /// Gets or sets the fine tuning value 2 unit.
        /// </summary>
        public string FineTuningValue2Unit { get; set; }

        /// <summary>
        /// Gets or sets the fine tuning value 3 unit.
        /// </summary>
        public string FineTuningValue3Unit { get; set; }

        /// <summary>
        /// Gets or sets the input format.
        /// </summary>
        /// <value>The input format.</value>
        public string InputFormat
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxInputFormat);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxInputFormat, value);
            }
        }

        /// <summary>
        /// Gets or sets the spreadsheet.
        /// </summary>
        /// <value>The spreadsheet.</value>
        public string Spreadsheet
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxSpreadsheet);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxSpreadsheet, value);
            }
        }

        /// <summary>
        /// Gets or sets the value1.
        /// </summary>
        /// <value>The value1.</value>
        public string Value1
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxValue1);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxValue1, value);
            }
        }

        /// <summary>
        /// Gets or sets the value1 maximum.
        /// </summary>
        /// <value>The value1 maximum.</value>
        public string Value1Max
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).TextValue1Max);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).TextValue1Max, value);
            }
        }

        /// <summary>
        /// Gets or sets the value1 minimum.
        /// </summary>
        /// <value>The value1 minimum.</value>
        public string Value1Min
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).TextValue1Min);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).TextValue1Min, value);
            }
        }

        /// <summary>
        /// Gets or sets the value1 unit.
        /// </summary>
        /// <value>The value1 unit.</value>
        public string Value1Unit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxValue1Unit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxValue1Unit, value);
            }
        }

        /// <summary>
        /// Gets or sets the value2.
        /// </summary>
        /// <value>The value2.</value>
        public string Value2
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxValue2);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxValue2, value);
            }
        }

        /// <summary>
        /// Gets or sets the value2 maximum.
        /// </summary>
        /// <value>The value2 maximum.</value>
        public string Value2Max
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).TextValue2Max);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).TextValue2Max, value);
            }
        }

        /// <summary>
        /// Gets or sets the value2 minimum.
        /// </summary>
        /// <value>The value2 minimum.</value>
        public string Value2Min
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).TextValue2Min);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).TextValue2Min, value);
            }
        }

        /// <summary>
        /// Gets or sets the value2 unit.
        /// </summary>
        /// <value>The value2 unit.</value>
        public string Value2Unit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxValue2Unit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxValue2Unit, value);
            }
        }

        /// <summary>
        /// Gets or sets the value3.
        /// </summary>
        /// <value>The value3.</value>
        public string Value3
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxValue3);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxValue3, value);
            }
        }

        /// <summary>
        /// Gets or sets the value3 maximum.
        /// </summary>
        /// <value>The value3 maximum.</value>
        public string Value3Max
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).TextValue3Max);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).TextValue3Max, value);
            }
        }

        /// <summary>
        /// Gets or sets the value 3 min.
        /// </summary>
        public string Value3Min
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).TextValue3Min);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).TextValue3Min, value);
            }
        }

        /// <summary>
        /// Gets or sets the value3 unit.
        /// </summary>
        /// <value>The value3 unit.</value>
        public string Value3Unit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxValue3Unit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxValue3Unit, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Fills list with random numbers between 0-100
        /// </summary>
        public void FillList()
        {
            var rand = new Random();
            Element tableGridControl = new LiquidPropertiesElements().TableGridControl;

            // Click in the center of grid control to activate edit fields, then move cursor to first field via keyboard
            Mouse.Click(tableGridControl);
            for (int i = 0; i < 6; i++)
            {
                Keyboard.Press(Keys.Up);
            }

            Keyboard.Press(Keys.Left);

            /*
             Set the first value and confirm it with enter, then go to the second field (this is needed to "activate" the 11th row in the table,
             otherwise, if not confirmed with enter, only 10 rows are shown and the table cannot be filled correctly
            */
            Keyboard.Press(rand.Next(0, 100).ToString(CultureInfo.InvariantCulture));
            Keyboard.Press(Keys.Enter);
            Keyboard.Press(Keys.Right);
            Keyboard.Press(Keys.Enter);

            // fill the other 32 field with random numbers and confirm with enter
            for (int i = 2; i < 34; i++)
            {
                Keyboard.Press(rand.Next(0, 100).ToString(CultureInfo.InvariantCulture));
                Keyboard.Press(Keys.Tab);
            }

            Keyboard.Press(Keys.Enter);
        }

        #endregion
    }
}