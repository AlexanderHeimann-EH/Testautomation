// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetValuesFromTable.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class GetValuesFromTable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class GetValuesFromTable.
    /// </summary>
    public class GetValuesFromTable : IGetValuesFromTable
    {
        #region Public Methods and Operators

        /// <summary>
        /// TODO: Funktion mit Logik füllen sobald auf die Tabelle zugegriffen werden kann
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> AllValues()
        {
            var result = new List<string>();

            return result;
        }

        /// <summary>
        /// The print all values in report.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void PrintAllValuesInReport()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO: Funktion mit Logik füllen sobald auf die Tabelle zugegriffen werden kann
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// System.String.
        /// </returns>
        public string SingleValue(int row, int column)
        {
            string result = string.Empty;

            return result;
        }

        #endregion
    }
}