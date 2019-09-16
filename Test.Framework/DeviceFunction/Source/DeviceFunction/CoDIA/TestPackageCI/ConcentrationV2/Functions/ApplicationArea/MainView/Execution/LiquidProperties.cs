// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LiquidProperties.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for tab liquid properties within module concentration
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for tab liquid properties within module concentration
    /// </summary>
    public class LiquidProperties : ILiquidProperties
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the fine tuning value1 unit.
        /// </summary>
        /// <value>The fine tuning value1 unit.</value>
        public string FineTuningValue1Unit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxFineTuningColumn1Unit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxFineTuningColumn1Unit, value);
            }
        }

        /// <summary>
        /// Gets or sets the fine tuning value2 unit.
        /// </summary>
        /// <value>The fine tuning value2 unit.</value>
        public string FineTuningValue2Unit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxFineTuningColumn2Unit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxFineTuningColumn2Unit, value);
            }
        }

        /// <summary>
        /// Gets or sets the fine tuning value3 unit.
        /// </summary>
        /// <value>The fine tuning value3 unit.</value>
        public string FineTuningValue3Unit
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxFineTuningColumn3Unit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxFineTuningColumn3Unit, value);
            }
        }

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
                (new CommonMethods()).SetParameterValue(new LiquidPropertiesElements().ComboBoxInputFormat, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxRow1);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxRow1, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).EditFieldRow1MaximumValue);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).EditFieldRow1MaximumValue, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).EditFieldRow1MinimumValue);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).EditFieldRow1MinimumValue, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxRow1Unit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxRow1Unit, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxColumn1);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxColumn1, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).EditFieldColumn1MaximumValue);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).EditFieldColumn1MaximumValue, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).EditFieldColumn1MinimumValue);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).EditFieldColumn1MinimumValue, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxColumn1Unit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxColumn1Unit, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxData);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxData, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).EditFieldDataMaximumValue);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).EditFieldDataMaximumValue, value);
            }
        }

        /// <summary>
        /// Gets or sets the value 3 min.
        /// </summary>
        public string Value3Min
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).EditFieldDataMinimumValue);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).EditFieldDataMinimumValue, value);
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
                return (new CommonMethods()).GetParameterValue((new LiquidPropertiesElements()).ComboBoxDataUnit);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new LiquidPropertiesElements()).ComboBoxDataUnit, value);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The recalculate.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Recalculate()
        {
            Element element = new LiquidPropertiesElements().ButtonRecalculate;
            if (element != null)
            {
                Mouse.Click(element);
                return true;
            }

            return false;
        }

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

        /// <summary>
        /// Sets all table values provided from a list.
        /// </summary>
        /// <param name="inputValues">
        /// The input values.
        /// </param>
        /// <returns>
        /// <c>true</c> if values have been set, <c>false</c> otherwise.
        /// </returns>
        public bool SetValues(List<string> inputValues)
        {
            if (inputValues.Count % 3 != 0)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Your list has an invalid number of values (three values per line). Please use a correct number of values.");
                return false;
            }

            Cell firstCell = new LiquidPropertiesElements().TableCell(0, 0);
            firstCell.DoubleClick(500);

            for (int counter = 0; counter < inputValues.Count / 3; counter++)
            {
                Keyboard.Press(inputValues[counter * 3]);
                Keyboard.Press(Keys.Enter);

                Thread.Sleep(500);
            }

            Keyboard.Press(Keys.Right);

            for (int i = 0; i < inputValues.Count / 3; i++)
            {
                Keyboard.Press(Keys.Up);
            }

            for (int counter = 0; counter < inputValues.Count / 2; counter++)
            {
                Keyboard.Press(inputValues[(counter * 3) + 1]);
                Keyboard.Press(Keys.Enter);
                Thread.Sleep(500);
            }

            return true;
        }

        #endregion
    }
}