// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetValuesFromTable.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class GetValuesFromTable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Concentration.Functions.ApplicationArea.MainView.Execution
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Concentration.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Class GetValuesFromTable.
    /// </summary>
    public class GetValuesFromTable : IGetValuesFromTable
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets all values from Concentration table within Liquid properties and stores them in a list. This will only work if you selected List as input form.
        /// </summary>
        /// <returns>List with all table values.</returns>
        public List<string> AllValues()
        {
            var result = new List<string>();

            var list = new LiquidPropertiesElements().TableCells;
            foreach (Element cell in list)
            {
                if (cell.GetAttributeValueText("AccessibleName").Contains(";0") || cell.GetAttributeValueText("AccessibleName").Contains(";1") || cell.GetAttributeValueText("AccessibleName").Contains(";2"))
                {
                    result.Add(cell.GetAttributeValueText("AccessibleValue"));
                }
            }

            if (result.Count == 0)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to store values in list.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Finished storing table values in list");
            }

            return result;
        }

        /// <summary>
        /// Prints all linearization table values in report.
        /// </summary>
        public void PrintAllValuesInReport()
        {
            var list = this.AllValues();
            var output = new StringBuilder();
            int rowIndex = 1;
            for (int i = 0; i < list.Count - 2; i++)
            {
                output.AppendLine("Row " + rowIndex + ": " + list[i] + ";" + list[i + 1] + ";" + list[i + 2]);
                i = i + 2;
                rowIndex++;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), output.ToString());
        }

        /// <summary>
        /// Returns the value for a specified row and column
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The value for the row and column.
        /// </returns>
        public string SingleValue(int row, int column)
        {
            string result = string.Empty;

            var list = new LiquidPropertiesElements().TableCells;
            foreach (Element cell in list)
            {
                if (cell.GetAttributeValueText("AccessibleName") == (row - 1) + ";" + (column - 1))
                {
                    result = cell.GetAttributeValueText("AccessibleValue");
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Value for row " + row + " column " + column + " = " + result);
                    break;
                }
            }

            if (result == string.Empty)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to get value for row " + row + " column " + column);
            }

            return result;
        }

        #endregion
    }
}