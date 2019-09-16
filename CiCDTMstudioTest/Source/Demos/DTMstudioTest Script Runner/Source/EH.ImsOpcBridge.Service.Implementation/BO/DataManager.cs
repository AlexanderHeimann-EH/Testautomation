// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataManager.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Implements the data manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.ImsOpcBridge.Service.Implementation.BO
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using EH.ImsOpcBridge.Common.Data;
    using EH.ImsOpcBridge.Common.Serialization;
    using EH.ImsOpcBridge.DataContracts;
    using EH.ImsOpcBridge.Service.Implementation.Diagnostics;
    using EH.ImsOpcBridge.Service.Implementation.Logging;

    /// <summary>
    /// A delegate type for hooking up change notifications.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    public delegate void ConfigurationChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Class DataManager
    /// </summary>
    internal class DataManager
    {
        #region Constants

        /// <summary>
        /// The configuration file name
        /// </summary>
        private const string ConfigurationFileName = @"\Configuration.xml";

        #endregion

        #region Fields

        /// <summary>
        /// The configuration.
        /// </summary>
        private Configuration configuration;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManager"/> class.
        /// </summary>
        public DataManager()
        {
            // Tries to load the last saved configuration.
            uint error;
            Exception exception;

            if (!this.TryLoadConfiguration(out error, out exception))
            {
                Logger.ErrorException(this, "Load configuration error.", exception);

                // Creates default configuration.
                this.Configuration = new Configuration(true);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the configuration has changed.
        /// </summary>
        public event ConfigurationChangedEventHandler ConfigurationChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public Configuration Configuration
        {
            get
            {
                return this.configuration;
            }

            private set
            {
                if (this.configuration != value)
                {
                    this.configuration = value;
                    this.OnConfigurationChanged(null);                    
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Tries the export configuration.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="localConfiguration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool TryExportConfiguration(string fileName, Configuration localConfiguration, out uint error, out Exception exception)
        {
            if (localConfiguration == null || string.IsNullOrEmpty(fileName))
            {
                error = ResultCodes.MissingArgument;
                exception = null;
                return false;
            }

            // Export to official data is forbidden. The 'Save' use case performs additional things.
            var m = new ApplicationDataFoldersManager();
            IList<string> folders;
            var result = m.TryCreateFolders(out folders, out exception);
            if (!result)
            {
                Logger.ErrorException(this, "Error creating application data folders.", exception);
                DiagnosticsCollection.Instance.AddMessage("Error creating application data folders.");
                DiagnosticsCollection.Instance.AddMessage(exception);
                error = ResultCodes.CreateAppDataFolderError;
                return false;
            }

            var configurationFilePath = folders[1] + ConfigurationFileName;
            if (configurationFilePath.Equals(fileName))
            {
                error = ResultCodes.ExportDenied;
                exception = null;
                return false;
            }

            result = this.InternalTrySaveConfiguration(fileName, localConfiguration, out error, out exception);

            if (!result)
            {
                Logger.ErrorException(this, "Error exporting configuration.", exception);
                DiagnosticsCollection.Instance.AddMessage(string.Format("Error exporting configuration: {0}", fileName));
                DiagnosticsCollection.Instance.AddMessage(exception);
            }

            return result;
        }

        /// <summary>
        /// Tries the import configuration.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="localConfiguration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool TryImportConfiguration(string fileName, out Configuration localConfiguration, out uint error, out Exception exception)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                localConfiguration = null;
                error = ResultCodes.MissingArgument;
                exception = null;
                return false;
            }

            var result = this.InternalTryLoadConfiguration(fileName, out localConfiguration, out error, out exception);

            if (!result)
            {
                Logger.ErrorException(this, "Error importing configuration.", exception);
                DiagnosticsCollection.Instance.AddMessage(string.Format("Error importing configuration: {0}", fileName));
                DiagnosticsCollection.Instance.AddMessage(exception);
            }

            return result;
        }

        /// <summary>
        /// Tries the save configuration.
        /// </summary>
        /// <param name="localConfiguration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool TrySaveConfiguration(Configuration localConfiguration, out uint error, out Exception exception)
        {
            if (localConfiguration == null)
            {
                error = ResultCodes.MissingArgument;
                exception = null;
                return false;
            }

            // Try to save.
            var m = new ApplicationDataFoldersManager();
            IList<string> folders;
            var result = m.TryCreateFolders(out folders, out exception);
            if (!result)
            {
                Logger.ErrorException(this, "Error creating application data folders.", exception);
                DiagnosticsCollection.Instance.AddMessage("Error creating application data folders.");
                DiagnosticsCollection.Instance.AddMessage(exception);
                error = ResultCodes.CreateAppDataFolderError;
                return false;
            }

            if ((result = this.InternalTrySaveConfiguration(folders[1] + ConfigurationFileName, localConfiguration, out error, out exception)) == true)
            {
                // Configuration saved successfully.
                this.Configuration = localConfiguration;
            }
            else
            {
                Logger.ErrorException(this, "Error saving current configuration.", exception);
                DiagnosticsCollection.Instance.AddMessage("Error saving current configuration.");
                DiagnosticsCollection.Instance.AddMessage(exception);
            }

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Encodes a visible string.
        /// </summary>
        /// <param name="source">The string to encode.</param>
        /// <returns>The encoded string.</returns>
        private static string Encode(string source)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(source) && !string.IsNullOrWhiteSpace(source))
            {
                var encription = new Encription();
                result = encription.Encrypt(source);
            }

            return result;
        }

        /// <summary>
        /// Decodes an encrypted string.
        /// </summary>
        /// <param name="source">The string to decode.</param>
        /// <returns>The decoded string.</returns>
        private static string Decode(string source)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(source) && !string.IsNullOrWhiteSpace(source))
            {
                var encription = new Encription();
                result = encription.Decrypt(source);
            }

            return result;
        }

        /// <summary>
        /// Internals the try load configuration.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="localConfiguration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool InternalTryLoadConfiguration(string fileName, out Configuration localConfiguration, out uint error, out Exception exception)
        {
            var serializer = new Serializer();
            object cnf;
            var result = serializer.Deserialize(typeof(Configuration), fileName, out cnf, out exception);

            if (!result)
            {
                // Errors.
                Logger.ErrorException(typeof(DataManager).Name, "Error loading current configuration.", exception);
                localConfiguration = null;
                error = ResultCodes.DeserializeError;
            }
            else
            {
                // Configuration loaded.
                localConfiguration = (Configuration)cnf;
                this.OnDeserialized(localConfiguration);
                error = ResultCodes.Success;
                exception = null;
            }

            return result;
        }

        /// <summary>
        /// Internals the try save configuration.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="localConfiguration">The configuration.</param>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool InternalTrySaveConfiguration(string fileName, Configuration localConfiguration, out uint error, out Exception exception)
        {
            var serializer = new Serializer();
            this.OnSerializing(localConfiguration);
            var result = serializer.Serialize(localConfiguration, fileName, out exception);
            this.OnDeserialized(localConfiguration);

            if (!result)
            {
                // Errors.
                Logger.ErrorException(typeof(DataManager).Name, "Error saving current configuration.", exception);
                error = ResultCodes.SerializeError;
            }
            else
            {
                // Configuration saved.
                error = ResultCodes.Success;
                exception = null;
            }

            return result;
        }

        /// <summary>
        /// Performs changes after deserialization.
        /// </summary>
        /// <param name="localConfiguration">The configuration.</param>
        /// <remarks>
        /// This method is coded here to avoid implementing clone for each possible object in the configuration.
        /// The configuration object is always the active one, therefore we cannot do permanent changes inside.
        /// </remarks>
        private void OnDeserialized(Configuration localConfiguration)
        {
            if (localConfiguration != null)
            {
                localConfiguration.Authentication.Password = Decode(localConfiguration.Authentication.Password);
                localConfiguration.SupplyCareSettings.Authentication.Password = Decode(localConfiguration.SupplyCareSettings.Authentication.Password);
                localConfiguration.FisSettings.Authentication.Password = Decode(localConfiguration.FisSettings.Authentication.Password);
                localConfiguration.ProxySettings.Authentication.Password = Decode(localConfiguration.ProxySettings.Authentication.Password);
            }
        }

        /// <summary>
        /// Performs changes before serialization.
        /// </summary>
        /// <param name="localConfiguration">The configuration.</param>
        /// <remarks>
        /// This method is coded here to avoid implementing clone for each possible object in the configuration.
        /// The configuration object is always the active one, therefore we cannot do permanent changes inside.
        /// </remarks>
        private void OnSerializing(Configuration localConfiguration)
        {
            if (localConfiguration != null)
            {
                // emilio temp this issue is still open!!!
                // the GUI does not receive the FIS settings runtime, therefore they should not be saved, the valid ones are only in the Service!!!
                localConfiguration.FisSettings.Authentication.User =
                    this.Configuration.FisSettings.Authentication.User;
                localConfiguration.FisSettings.Authentication.Password =
                    this.Configuration.FisSettings.Authentication.Password;

                localConfiguration.Authentication.Password = Encode(localConfiguration.Authentication.Password);
                localConfiguration.SupplyCareSettings.Authentication.Password = Encode(localConfiguration.SupplyCareSettings.Authentication.Password);
                localConfiguration.FisSettings.Authentication.Password = Encode(localConfiguration.FisSettings.Authentication.Password);
                localConfiguration.ProxySettings.Authentication.Password = Encode(localConfiguration.ProxySettings.Authentication.Password);
            }
        }

        /// <summary>
        /// Tries the load configuration.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        private bool TryLoadConfiguration(out uint error, out Exception exception)
        {
            // Try to load.
            var m = new ApplicationDataFoldersManager();
            IList<string> folders;
            var result = m.TryCreateFolders(out folders, out exception);
            if (!result)
            {
                DiagnosticsCollection.Instance.AddMessage("Error creating application data folders.");
                DiagnosticsCollection.Instance.AddMessage(exception);
                error = ResultCodes.CreateAppDataFolderError;
                return false;
            }

            Configuration localConfiguration;
            if (
                (result =
                 this.InternalTryLoadConfiguration(
                     folders[1] + ConfigurationFileName, out localConfiguration, out error, out exception)) == true)
            {
                // Configuration loaded successfully.
                this.Configuration = localConfiguration;
            }
            else
            {
                DiagnosticsCollection.Instance.AddMessage("Error loading current configuration.");
                DiagnosticsCollection.Instance.AddMessage(exception);
            }

            return result;
        }

        /// <summary>
        /// Handles the configuration changed <see cref="ConfigurationChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OnConfigurationChanged(EventArgs e)
        {
            var changed = this.ConfigurationChanged;
            if (changed != null)
            {
                changed(this, e);
            }
        }

        #endregion
    }
}