// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImsOpcBridgeSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ImsOpcBridgeSettings
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Configurator.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;

    using EH.ImsOpcBridge.Configuration;
    using EH.ImsOpcBridge.Configurator.ViewModel;

    /// <summary>
    /// Class ImsOpcBridgeSettings
    /// </summary>
    public class ImsOpcBridgeSettings : IReadOnlyImsOpcBridgeSettings
    {
        #region Constants

        /// <summary>
        /// The execution policy exception
        /// </summary>
        private const string ExecutionPolicyException = @"settings/executionPolicy/allowOn";

        /// <summary>
        /// The path allow culture change
        /// </summary>
        private const string PathAllowCultureChange = @"settings/culture/allowChange";

        /// <summary>
        /// The path culture name
        /// </summary>
        private const string PathCultureName = @"settings/culture/name";

        /// <summary>
        /// The path do logging commands
        /// </summary>
        private const string PathDoLoggingCommands = @"settings/support/doLoggingCommands";

        /// <summary>
        /// The path labeling manufacturer
        /// </summary>
        private const string PathLabelingManufacturer = @"settings/labeling/manufacturer";

        /// <summary>
        /// The path layout command alignment
        /// </summary>
        private const string PathLayoutCommandAlignment = @"settings/layout/commandAlignment";

        /// <summary>
        /// The path layout show device commands
        /// </summary>
        private const string PathLayoutShowDeviceCommands = @"settings/layout/showDeviceCommands";

        /// <summary>
        /// The path windows pos left
        /// </summary>
        private const string PathWindowsPosLeft = @"settings/mainWindow/position/left";

        /// <summary>
        /// The path windows pos top
        /// </summary>
        private const string PathWindowsPosTop = @"settings/mainWindow/position/top";

        /// <summary>
        /// The path windows size height
        /// </summary>
        private const string PathWindowsSizeHeight = @"settings/mainWindow/size/height";

        /// <summary>
        /// The path windows size width
        /// </summary>
        private const string PathWindowsSizeWidth = @"settings/mainWindow/size/width";

        #endregion

        #region Static Fields

        /// <summary>
        /// The sync root
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// The singleton
        /// </summary>
        private static volatile ImsOpcBridgeSettings singleton;

        #endregion

        #region Fields

        /// <summary>
        /// The config file info
        /// </summary>
        private FileInfo configFileInfo;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImsOpcBridgeSettings"/> class.
        /// </summary>
        public ImsOpcBridgeSettings()
        {
            this.Manufacturer = "Endress+Hauser";

            this.CommandAlignment = CommandAlignment.Left;
            this.ShowDeviceCommands = true;
            this.LoggingCommands = true;

            this.WindowsPosHeight = 0.0;
            this.WindowsPosWidth = 0.0;
            this.WindowsPosTop = 0.0;
            this.WindowsPosLeft = 0.0;

            this.CultureName = CultureInfo.InstalledUICulture.ToString();
            this.AllowCultureChange = true;

            this.configFileInfo = null;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the singleton.
        /// </summary>
        /// <value>The singleton.</value>
        public static IReadOnlyImsOpcBridgeSettings Singleton
        {
            get
            {
                if (singleton == null)
                {
                    lock (SyncRoot)
                    {
                        if (singleton == null)
                        {
                            singleton = new ImsOpcBridgeSettings();
                        }
                    }

                    singleton.Load();
                }

                return singleton;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether allow culture change.
        /// </summary>
        public bool AllowCultureChange { get; set; }

        /// <summary>
        /// Gets or sets the allow execution on machine.
        /// </summary>
        public string AllowExecutionOnMachine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether allow themes.
        /// </summary>
        public bool AllowThemes { get; set; }

        /// <summary>
        /// Gets or sets the command alignment.
        /// </summary>
        public CommandAlignment CommandAlignment { get; set; }

        /// <summary>
        /// Gets or sets the culture name.
        /// </summary>
        public string CultureName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [logging commands].
        /// </summary>
        /// <value><c>true</c> if [logging commands]; otherwise, <c>false</c>.</value>
        public bool LoggingCommands { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show device commands].
        /// </summary>
        /// <value><c>true</c> if [show device commands]; otherwise, <c>false</c>.</value>
        public bool ShowDeviceCommands { get; set; }

        /// <summary>
        /// Gets or sets the windows pos height.
        /// </summary>
        public double WindowsPosHeight { get; set; }

        /// <summary>
        /// Gets or sets the windows pos left.
        /// </summary>
        public double WindowsPosLeft { get; set; }

        /// <summary>
        /// Gets or sets the windows pos top.
        /// </summary>
        public double WindowsPosTop { get; set; }

        /// <summary>
        /// Gets or sets the windows pos width.
        /// </summary>
        public double WindowsPosWidth { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Loads this instance.
        /// </summary>
        public void Load()
        {
            lock (SyncRoot)
            {
                var assembly = Assembly.GetEntryAssembly();
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                AssemblyProductAttribute attribute = null;
                if (attributes.Length > 0)
                {
                    attribute = attributes[0] as AssemblyProductAttribute;
                }

                string productName = "unknown";
                if (attribute != null)
                {
                    productName = attribute.Product;
                }

                this.configFileInfo = ConfigurationFileSupport.GetConfigurationFileInfo(this.Manufacturer, productName, string.Empty, false, false, new string[] { }, "ImsOpcBridge.config", false);

                var xmlSettings = new ConfigStorage();
                xmlSettings.Load(this.configFileInfo.FullName);

                this.Manufacturer = xmlSettings.GetValue(PathLabelingManufacturer, this.Manufacturer);

                this.WindowsPosLeft = xmlSettings.GetValue(PathWindowsPosLeft, this.WindowsPosLeft);
                this.WindowsPosTop = xmlSettings.GetValue(PathWindowsPosTop, this.WindowsPosTop);
                this.WindowsPosWidth = xmlSettings.GetValue(PathWindowsSizeWidth, this.WindowsPosWidth);
                this.WindowsPosHeight = xmlSettings.GetValue(PathWindowsSizeHeight, this.WindowsPosHeight);

                this.CultureName = xmlSettings.GetValue(PathCultureName, this.CultureName);
                this.AllowCultureChange = xmlSettings.GetValue(PathAllowCultureChange, (bool?)true);

                this.AllowExecutionOnMachine = xmlSettings.GetValue(ExecutionPolicyException, string.Empty);

                this.ShowDeviceCommands = xmlSettings.GetValue(PathLayoutShowDeviceCommands, this.ShowDeviceCommands);
                this.LoggingCommands = xmlSettings.GetValue(PathDoLoggingCommands, this.LoggingCommands);

                try
                {
                    CommandAlignment temp;
                    if (!Enum.TryParse(xmlSettings.GetValue(PathLayoutCommandAlignment, "Left"), out temp))
                    {
                        temp = CommandAlignment.Left;
                    }

                    this.CommandAlignment = temp;
                }
                catch (ArgumentException)
                {
                    this.CommandAlignment = CommandAlignment.Left;
                }

                xmlSettings.Save();
                xmlSettings.Close();
            }
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            var xmlSettings = new ConfigStorage();
            xmlSettings.Load(this.configFileInfo.FullName);

            xmlSettings.SetValue(PathLabelingManufacturer, this.Manufacturer);

            xmlSettings.SetValue(PathWindowsPosLeft, this.WindowsPosLeft.ToString(CultureInfo.InvariantCulture));
            xmlSettings.SetValue(PathWindowsPosTop, this.WindowsPosTop.ToString(CultureInfo.InvariantCulture));
            xmlSettings.SetValue(PathWindowsSizeWidth, this.WindowsPosWidth.ToString(CultureInfo.InvariantCulture));
            xmlSettings.SetValue(PathWindowsSizeHeight, this.WindowsPosHeight.ToString(CultureInfo.InvariantCulture));

            xmlSettings.SetValue(PathCultureName, this.CultureName);
            xmlSettings.SetValue(PathAllowCultureChange, this.AllowCultureChange.ToString());

            xmlSettings.SetValue(PathLayoutShowDeviceCommands, this.ShowDeviceCommands.ToString(CultureInfo.InvariantCulture));
            xmlSettings.SetValue(PathLayoutCommandAlignment, this.CommandAlignment.ToString());

            xmlSettings.SetValue(PathDoLoggingCommands, this.LoggingCommands.ToString(CultureInfo.InvariantCulture));

            xmlSettings.Save();
            xmlSettings.Close();
        }

        #endregion
    }
}