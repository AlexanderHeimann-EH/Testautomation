///////////////////////////////////////////////////////////////////////////////////////////////////
//
// This file is part of the  R A N O R E X  Project.
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////////////////////////

namespace EH.PCPS.TestAutomation.Common
{
    using System;
    using System.Data;
    using System.IO;

    /// <summary>
    ///     Represents a data connector to a CSV-file.
    /// </summary>
    public class CSVConnector
    {
        /// <summary>
        /// The Data Table
        /// </summary>
        private readonly DataTable dt;

        /// <summary>
        /// The file name
        /// </summary>
        private readonly string fileName;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CSVConnector()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CSVConnector" /> class.
        /// </summary>
        /// <param name="fileName">The path to the CSV file.</param>
        public CSVConnector(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            this.fileName = fileName;
            this.dt = new DataTable();
            this.ParseCSVData();
        }

        /// <summary>
        ///     Gets the data rows.
        /// </summary>
        public DataRowCollection Rows
        {
            get { return this.dt.Rows; }
        }

        /// <summary>
        ///     Gets the data columns.
        /// </summary>
        public DataColumnCollection Header
        {
            get { return this.dt.Columns; }
        }

        private void ParseCSVData()
        {
            try
            {
                String[] csvData = File.ReadAllLines(this.fileName);

                if (csvData.Length == 0)
                    return;

                String[] headings = csvData[0].Split(';');

                foreach (string header in headings)
                {
                    this.dt.Columns.Add(header, typeof (string));
                }

                for (int j = 1; j < csvData.Length; j++)
                {
                    DataRow row = this.dt.NewRow();

                    for (int i = 0; i < headings.Length; i++)
                    {
                        row[i] = csvData[j].Split(';')[i];
                    }
                    this.dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Failed to parse CSV file '" + this.fileName + "'.", ex);
            }
        }
    }
}