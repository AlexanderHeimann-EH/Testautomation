// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingleItemRule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Validates an int.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Rules
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Controls;

    using EH.ImsOpcBridge.Configurator.Model;
    using EH.ImsOpcBridge.Configurator.Properties;

    /// <summary>
    /// Class SingleItemRule
    /// </summary>
    public class SingleItemRule : ValidationRule
    {
        #region Const

        /// <summary>
        /// The maximum length.
        /// </summary>
        private const int MaxLength = 32;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleItemRule"/> class.
        /// </summary>
        public SingleItemRule()
        {
            this.Row = -1;
            this.Column = -1;
            this.ConfiguredMeasurements = new ObservableCollection<ConfiguredMeasurementData>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>The column.</value>
        public int Column { get; set; }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <value>The row.</value>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the configured measurements.
        /// </summary>
        /// <value>The configured measurements.</value>
        public ObservableCollection<ConfiguredMeasurementData> ConfiguredMeasurements { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// When overridden in a derived class, performs validation checks on a value.
        /// </summary>
        /// <param name="value">The value from the binding target to check.</param>
        /// <param name="cultureInfo">The culture to use in this rule.</param>
        /// <returns>A <see cref="T:System.Windows.Controls.ValidationResult" /> object.</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var errorMessage = Resources.ThisEntryCannotBeNullOrEmpty;

            try
            {
                var text = (string)value;
                if (string.IsNullOrEmpty(text))
                {
                    return new ValidationResult(false, errorMessage);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, Resources.IllegalCharactersOr + @" " + e.Message);
            }

            errorMessage = string.Format(Resources.EntryTooLong, MaxLength);

            try
            {
                var text = (string)value;
                if (text.Length > MaxLength)
                {
                    return new ValidationResult(false, errorMessage);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, Resources.IllegalCharactersOr + @" " + e.Message);
            }

            if (this.ConfiguredMeasurements == null)
            {
                return new ValidationResult(false, Resources.MeasurementItemNotAvailable);
            }

            if (this.FindItem((string)value))
            {
                return new ValidationResult(false, Resources.MeasurementItemAlreadyExists);
            }

            return new ValidationResult(true, null);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks the device id.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckDeviceId(string value)
        {
            var retVal = false;

            // Get corresponding sensorId
            var sensorId = string.Empty;

            if ((this.Row != -1) && (this.Row < this.ConfiguredMeasurements.Count))
            {
                sensorId = this.ConfiguredMeasurements[this.Row].SensorId;
            }

            // search for identical deviceId names
            foreach (var item in this.ConfiguredMeasurements)
            {
                if (item.DeviceId == value)
                {
                    // Break if SensorId is also identical
                    if ((item.SensorId == sensorId) && (this.Row != this.ConfiguredMeasurements.IndexOf(item)))
                    {
                        retVal = true;
                        break;
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Checks the sensor id.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool CheckSensorId(string value)
        {
            var retVal = false;

            // Get corresponding device id
            var deviceId = string.Empty;

            if ((this.Row != -1) && (this.Row < this.ConfiguredMeasurements.Count))
            {
                deviceId = this.ConfiguredMeasurements[this.Row].DeviceId;
            }

            // search for identical sensorId names
            foreach (var item in this.ConfiguredMeasurements)
            {
                if (item.SensorId == value)
                {
                    // Break if DeviceId is also identical
                    if ((item.DeviceId == deviceId) && (this.Row != this.ConfiguredMeasurements.IndexOf(item)))
                    {
                        retVal = true;
                        break;
                    }
                }
            }

            return retVal;
        }

        /// <summary>
        /// Finds the item.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool FindItem(string value)
        {
            var retVal = false;

            // Filtered items are hidden -> No error although identical values are available in the base data set
            if (this.Column == -1 || !this.ConfiguredMeasurements.Any())
            {
                return false;
            }

            if (this.Column == 1)
            {
                retVal = this.CheckDeviceId(value);
            }
            else if (this.Column == 2)
            {
                retVal = this.CheckSensorId(value);
            }

            return retVal;
        }

        #endregion
    }
}