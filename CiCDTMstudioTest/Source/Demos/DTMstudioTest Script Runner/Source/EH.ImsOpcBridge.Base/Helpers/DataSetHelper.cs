// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base
// Author           : I02423401
// Created          : 06-18-2012
//
// Last Modified By : I02423401
// Last Modified On : 07-20-2012
// ***********************************************************************
// <copyright file="DataSetHelper.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Helpers
{
    using System;
    using System.Data;
    using System.Globalization;
    using System.Reflection;
    using System.Text;

    using EH.ImsOpcBridge.Properties;

    using log4net;

    /// <summary>
    /// Helper methods to work with ADO.NET DataSets.
    /// </summary>
    public static class DataSetHelper
    {
        #region Constants and Fields

        /// <summary>
        /// Logger to be used for logging purposes.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Compares two dates for equality. This comparison only compares the dates
        /// down to the seconds.
        /// </summary>
        /// <param name="left">Left value to be compared.</param>
        /// <param name="right">Right value to be compared.</param>
        /// <returns>True if the two dates are equal, otherwise false.</returns>
        public static bool AreDatesEqualToSeconds(DateTime? left, DateTime? right)
        {
            // ReSharper disable LocalizableElement
            var leftDate = string.Format(CultureInfo.InvariantCulture, @"{0:s}", left);
            var rightDate = string.Format(CultureInfo.InvariantCulture, @"{0:s}", right);

            // ReSharper restore LocalizableElement
            return leftDate == rightDate;
        }

        /// <summary>
        /// Logs all table errors.
        /// </summary>
        /// <param name="dataSet">DataSet to be analyzed.</param>
        public static void DisplayTableErrors(DataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException(@"dataSet");
            }
            
            if (Logger.IsDebugEnabled)
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.AppendLine(Resources.DisplayTableErrorsErrorsInDataSet);
                stringBuilder.AppendLine();

                foreach (DataTable table in dataSet.Tables)
                {
                    var errorRows = table.GetErrors();

                    foreach (var errorRow in errorRows)
                    {
                        stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, Resources.DisplayTableErrorsTable_, table.TableName));
                        stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, Resources.DisplayTableErrorsRowError_, errorRow.RowError));

                        var errorColumns = errorRow.GetColumnsInError();

                        foreach (var errorColumn in errorColumns)
                        {
                            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, Resources.DisplayTableErrorsColumn_, errorColumn.ColumnName));
                            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, Resources.DisplayTableErrorsColumnError_, errorRow.GetColumnError(errorColumn)));
                        }
                    }
                }

                Logger.Debug(stringBuilder.ToString());
            }
        }

        /// <summary>
        /// Converts a DateTime struct to a safe DB representation, only containing
        /// the date down to milliseconds without any ticks because these would be
        /// cut away by ADO.NET and this would lead to failure of subsequent select
        /// queries
        /// </summary>
        /// <param name="dateTime">DateTime struct</param>
        /// <returns>Safe DateTime struct</returns>
        public static DateTime? ToSafeDbDateTime(DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            double dft = dateTime.Value.ToFileTime();
            dft = dft * 1E-6;
            dft = Math.Round(dft);
            dft = dft * 1E+6;

            return DateTime.FromFileTime((long)dft);
        }

        /// <summary>
        /// Converts a DateTime struct for use as a select part on a DataTable
        /// </summary>
        /// <param name="dateTime">DateTime struct</param>
        /// <returns>String, which can be used as a select part on a DataTable</returns>
        public static string ToStringForSelect(object dateTime)
        {
            if (dateTime == null)
            {
                throw new ArgumentNullException(@"dateTime");
            }
            
            if (dateTime.GetType() != typeof(DateTime))
            {
                return string.Empty;
            }

            var localDateTime = (DateTime)dateTime;

            // ReSharper disable LocalizableElement
            return localDateTime.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);

            // ReSharper restore LocalizableElement
        }

        #endregion
    }
}
