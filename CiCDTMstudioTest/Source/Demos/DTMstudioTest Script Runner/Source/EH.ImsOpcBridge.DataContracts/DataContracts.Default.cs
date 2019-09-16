// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContracts.Default.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The authentication.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.DataContracts
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using EH.ImsOpcBridge.Common.Utils;

    /// <summary>
    /// Class Authentication
    /// </summary>
    public partial class Authentication
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Authentication"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public Authentication(bool initialize)
        {
            if (initialize)
            {
                this.User = string.Empty;
                this.Password = string.Empty;
                this.Active = false;
            }
        }

        #endregion
    }

    /// <summary>
    /// Class Gateway
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = @"OK here.")]
    public partial class Gateway
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Gateway"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public Gateway(bool initialize)
        {
            if (initialize)
            {
                string stringValue;
                Utils.ReadAppSettings("GatewayModel", "OPCBridge", out stringValue);
                this.Model = stringValue;
                this.SerialNumber = string.Empty;
                this.ActivationKey = string.Empty;
            }
        }

        #endregion
    }

    /// <summary>
    /// Class OpcItem
    /// </summary>
    public partial class OpcItem
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcItem"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public OpcItem(bool initialize)
        {
            if (initialize)
            {
                this.Name = string.Empty;
                this.ItemId = string.Empty;
                this.Children = new OpcItems();
            }
        }

        #endregion
    }

    /// <summary>
    /// Class OpcServerItem
    /// </summary>
    public partial class OpcServerItem
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpcServerItem"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public OpcServerItem(bool initialize)
        {
            if (initialize)
            {
                this.Name = string.Empty;
                this.ClassId = Guid.Empty.ToString();
                this.IpAddress = string.Empty;
            }
        }

        #endregion
    }

    /// <summary>
    /// Class SupplyCareSettings
    /// </summary>
    public partial class SupplyCareSettings
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplyCareSettings"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public SupplyCareSettings(bool initialize)
        {
            if (initialize)
            {
                this.Authentication = new Authentication(true);
                string stringValue;

                Utils.ReadAppSettings("SCEPort", "8080", out stringValue);
                this.Port = Utils.ToLong(stringValue, 1, 65535, 8080);

                Utils.ReadAppSettings("SCETimeSchedule", "1", out stringValue);
                this.SamplingRate = Utils.ToLong(stringValue, 1, 10, 1);
            }
        }

        #endregion
    }

    /// <summary>
    /// Class ConfiguredMeasurementItem
    /// </summary>
    public partial class ConfiguredMeasurementItem
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguredMeasurementItem"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public ConfiguredMeasurementItem(bool initialize)
        {
            if (initialize)
            {
                this.Value = string.Empty;
                this.MappingType = MappingTypes.StaticType;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguredMeasurementItem"/> class.
        /// </summary>
        /// <param name="other">The object to copy.</param>
        /// <exception cref="System.ArgumentNullException">Exception raised if the argument is null.</exception>
        public ConfiguredMeasurementItem(ConfiguredMeasurementItem other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            // It is not required here to clone the string also.
            this.Value = other.Value;
            this.MappingType = other.MappingType;
        }

        #endregion
    }

    /// <summary>
    /// Class ConfiguredMeasurement
    /// </summary>
    public partial class ConfiguredMeasurement
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguredMeasurement"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public ConfiguredMeasurement(bool initialize)
        {
            if (initialize)
            {
                this.DeviceId = new ConfiguredMeasurementItem(true);
                this.SensorId = new ConfiguredMeasurementItem(true);
                this.Unit = new ConfiguredMeasurementItem(true);
                this.DataType = CommonFormatDataTypes.FloatType;
                this.Timestamp = new ConfiguredMeasurementItem(true);
                this.Quality = new ConfiguredMeasurementItem(true);
                this.Value = new ConfiguredMeasurementItem(true);
                this.Active = false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfiguredMeasurement"/> class.
        /// </summary>
        /// <param name="other">The object to copy.</param>
        /// <exception cref="System.ArgumentNullException">Exception raised if the argument is null.</exception>
        public ConfiguredMeasurement(ConfiguredMeasurement other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            this.DeviceId = new ConfiguredMeasurementItem(other.DeviceId);
            this.SensorId = new ConfiguredMeasurementItem(other.SensorId);
            this.Unit = new ConfiguredMeasurementItem(other.Unit);
            this.DataType = other.DataType;
            this.Timestamp = new ConfiguredMeasurementItem(other.Timestamp);
            this.Quality = new ConfiguredMeasurementItem(other.Quality);
            this.Value = new ConfiguredMeasurementItem(other.Value);
            this.Active = other.Active;
        }

        #endregion
    }

    /// <summary>
    /// Class RuntimeMeasurement
    /// </summary>
    public partial class RuntimeMeasurement
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeMeasurement"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public RuntimeMeasurement(bool initialize)
        {
            if (initialize)
            {
                this.RequestIndex = 0;
                this.DeviceId = string.Empty;
                this.SensorId = string.Empty;
                this.Unit = string.Empty;
                this.DataType = new DataTypeDisplayNames()[(int)CommonFormatDataTypes.FloatType];
                this.Timestamp = string.Empty;
                this.Quality = string.Empty;
                this.Value = string.Empty;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeMeasurement"/> class.
        /// </summary>
        /// <param name="other">The object to copy.</param>
        /// <exception cref="System.ArgumentNullException">Exception raised if the argument is null.</exception>
        public RuntimeMeasurement(RuntimeMeasurement other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            // It is not required here to clone the string also.
            this.RequestIndex = other.RequestIndex;
            this.DeviceId = other.DeviceId;
            this.SensorId = other.SensorId;
            this.Unit = other.Unit;
            this.DataType = other.DataType;
            this.Timestamp = other.Timestamp;
            this.Quality = other.Quality;
            this.Value = other.Value;
        }

        #endregion
    }

    /// <summary>
    /// Class InternetAddress
    /// </summary>
    public partial class InternetAddress
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InternetAddress"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public InternetAddress(bool initialize)
        {
            if (initialize)
            {
                this.Url = string.Empty;
                this.Port = 0;
            }
        }

        #endregion
    }

    /// <summary>
    /// Class FisSettings
    /// </summary>
    public partial class FisSettings
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FisSettings"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public FisSettings(bool initialize)
        {
            if (initialize)
            {
                string stringValue;
                ////long longValue;

                this.Enabled = false;
                this.InternetAddress = new InternetAddress(true);

                Utils.ReadAppSettings("FISUrl", "https://fis.endress.com", out stringValue);
                this.InternetAddress.Url = stringValue;

                Utils.ReadAppSettings("FISPort", "80", out stringValue);
                this.InternetAddress.Port = Utils.ToLong(stringValue, 1, 65535, 80);

                this.Authentication = new Authentication(true) { Active = true };
                Utils.ReadAppSettings("FISUser", "fis-m2m", out stringValue);
                this.Authentication.User = stringValue;
                Utils.ReadAppSettings("FISPassword", "m2m-fis", out stringValue);
                this.Authentication.Password = stringValue;

                Utils.ReadAppSettings(
                    "FISTimeSchedule", ((long)FisTimeSchedules.TimeSchedule15min).ToString(), out stringValue);
                this.TimeSchedule =
                    (FisTimeSchedules)
                    Utils.ToLong(
                        stringValue,
                        (long)FisTimeSchedules.TimeSchedule1min,
                        (long)FisTimeSchedules.TimeSchedule24h,
                        (long)FisTimeSchedules.TimeSchedule15min);
            }
        }

        #endregion
    }

    /// <summary>
    /// Class ProxySettings
    /// </summary>
    public partial class ProxySettings
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxySettings"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public ProxySettings(bool initialize)
        {
            if (initialize)
            {
                this.Enabled = false;
                this.InternetAddress = new InternetAddress(true);
                this.Authentication = new Authentication(true);
            }
        }

        #endregion
    }

    /// <summary>
    /// Class Configuration
    /// </summary>
    public partial class Configuration
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        /// <param name="initialize">if set to <c>true</c> [initialize].</param>
        public Configuration(bool initialize)
        {
            if (initialize)
            {
                this.Authentication = new Authentication(true);
                this.Gateway = new Gateway(true);
                this.SupplyCareSettings = new SupplyCareSettings(true);
                this.FisSettings = new FisSettings(true);
                this.ProxySettings = new ProxySettings(true);
                this.ConfiguredMeasurements = new ConfiguredMeasurements();

                string stringValue;
                Utils.ReadAppSettings("Language", "en-US", out stringValue);
                this.CurrentLanguage = stringValue;
            }
        }

        #endregion
    }
}