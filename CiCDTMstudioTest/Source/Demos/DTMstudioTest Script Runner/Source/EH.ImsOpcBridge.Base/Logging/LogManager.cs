// ***********************************************************************
// Assembly         : EH.ImsOpcBridge.Base
// Author           : I02423401
// Created          : 06-18-2012
//
// Last Modified By : I02423401
// Last Modified On : 10-03-2012
// ***********************************************************************
// <copyright file="LogManager.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Logging
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using EH.ImsOpcBridge.Configuration;
    using EH.ImsOpcBridge.Exceptions;
    using EH.ImsOpcBridge.FileHandling;
    using EH.ImsOpcBridge.Properties;

    using log4net.Config;

    /// <summary>
    /// Static functionality of the FDT module.
    /// </summary>
    public class LogManager
    {
        #region Constants and Fields

        /// <summary>
        /// Turns log4Net log events into FdtRoot events
        /// </summary>
        private static Log4NetAppender log4NetAppender;

        /// <summary>
        /// The singleton instance.
        /// </summary>
        private static LogManager singleton;

        #endregion

        #region Public Events

        /// <summary>
        /// Occurs for each log entry of the type debug.
        /// </summary>
        public static event EventHandler<LogEventArgs> LogDebug;

        /// <summary>
        /// Occurs for each log entry of the type error.
        /// </summary>
        public static event EventHandler<LogEventArgs> LogError;

        /// <summary>
        /// Occurs for each log entry of the type fatal.
        /// </summary>
        public static event EventHandler<LogEventArgs> LogFatal;

        /// <summary>
        /// Occurs for each log entry of the type info.
        /// </summary>
        public static event EventHandler<LogEventArgs> LogInfo;

        /// <summary>
        /// Occurs for each log entry of the type warn.
        /// </summary>
        public static event EventHandler<LogEventArgs> LogWarn;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this instance is logging configured.
        /// </summary>
        /// <value><c>true</c> if this instance is logging configured; otherwise, <c>false</c>.</value>
        public static bool IsLoggingConfigured { get; private set; }

        /// <summary>
        /// Gets the log4Net configuration file.
        /// </summary>
        /// <value>The log4 net configuration file.</value>
        public static FileInfo Log4NetConfigurationFile { get; private set; }

        /// <summary>
        /// Gets the Singleton instance.
        /// </summary>
        /// <value>The singleton.</value>
        public static LogManager Singleton
        {
            get
            {
                return singleton ?? (singleton = new LogManager());
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the log4Net configuration file.
        /// </summary>
        /// <value>The name of the log4 net configuration file.</value>
        private static string Log4NetConfigurationFileName
        {
            get
            {
                // ReSharper disable LocalizableElement
                return @"log4net.config";

                // ReSharper restore LocalizableElement
            }
        }

        /// <summary>
        /// Gets the relative path of the log4Net configuration file.
        /// </summary>
        /// <value>The relative logging path.</value>
        private static string RelativeLoggingPath
        {
            get
            {
                // ReSharper disable LocalizableElement
                return @"Logging";

                // ReSharper restore LocalizableElement
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Configures the log4Net logging.
        /// </summary>
        /// <param name="host">the reference to the interface for callbacks from FDT container to the hosting application.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "OK.")]
        public static void ConfigureLogging(IBaseHost host)
        {
            if (host == null)
            {
                throw new ArgumentNullException(@"host");
            }

            var isService = host.IsService;

            var myOtherProcesses = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            var baseRelativePathItems = new[] { RelativeLoggingPath };
            var basePath = ConfigurationFileSupport.GetConfigurationPath(host.Manufacturer, host.ApplicationName, @"ImsOpcBridge", isService, false, baseRelativePathItems, true);

            try
            {
                foreach (var subDirectory in basePath.EnumerateDirectories())
                {
                    int subDirectoryNameAsInt;

                    if (int.TryParse(subDirectory.Name, NumberStyles.Integer, CultureInfo.InvariantCulture, out subDirectoryNameAsInt))
                    {
                        if (myOtherProcesses.All(p => p.Id != subDirectoryNameAsInt))
                        {
                            try
                            {
                                subDirectory.Delete(true);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }

            string[] relativePathItems;

            if (isService)
            {
                // relative path { "Logging" } leads to ...\Users\UserX\AppData\Local\<manufacturer>\<application>\ImsOpcBridge\Shared\Logging
                relativePathItems = new[] { RelativeLoggingPath };
            }
            else
            {
                // relative path { "Logging" } leads to ...\Users\UserX\AppData\Local\<manufacturer>\<application>\ImsOpcBridge\Shared\Logging\<ProcessId>
                relativePathItems = new[] { RelativeLoggingPath, Process.GetCurrentProcess().Id.ToString(CultureInfo.InvariantCulture) };
            }

            // ReSharper disable LocalizableElement
            Log4NetConfigurationFile = ConfigurationFileSupport.GetConfigurationFileInfo(host.Manufacturer, host.ApplicationName, @"ImsOpcBridge", isService, false, relativePathItems, Log4NetConfigurationFileName, false);

            // ReSharper restore LocalizableElement
            if (!Log4NetConfigurationFile.Exists)
            {
                InstallDefaultLog4NetConfiguration(Log4NetConfigurationFile);
                Log4NetConfigurationFile.Refresh();
            }

            if (Log4NetConfigurationFile.Exists)
            {
                ConfigureLogging(Log4NetConfigurationFile, true);
            }
        }

        /// <summary>
        /// Configures the log4Net logging.
        /// </summary>
        /// <param name="log4NetXmlConfiguration">The log4Net XML configuration file location.</param>
        public static void ConfigureLogging(FileInfo log4NetXmlConfiguration)
        {
            ConfigureLogging(log4NetXmlConfiguration, false);
        }

        /// <summary>
        /// Configures the log4Net logging.
        /// </summary>
        /// <param name="log4NetXmlConfiguration">The log4Net XML configuration file location.</param>
        /// <param name="watch">If set to true, log4NET is watching for configuration changes.</param>
        public static void ConfigureLogging(FileInfo log4NetXmlConfiguration, bool watch)
        {
            if (log4NetXmlConfiguration == null)
            {
                throw new ArgumentNullException(@"log4NetXmlConfiguration");
            }

            if (log4NetAppender != null)
            {
                throw new BaseException(Resources.EnableLoggingEventsAfterConfiguringLogging);
            }

            if (!IsLoggingConfigured)
            {
                Log4NetConfigurationFile = log4NetXmlConfiguration;

                if (watch)
                {
                    XmlConfigurator.ConfigureAndWatch(log4NetXmlConfiguration);
                }
                else
                {
                    XmlConfigurator.Configure(log4NetXmlConfiguration);
                }

                var logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                if (logger.IsDebugEnabled)
                {
                    var message = string.Format(CultureInfo.CurrentUICulture, Resources.LoadingLog4NetConfigurationFrom_WatchIsSetTo_, log4NetXmlConfiguration.FullName, watch);
                    logger.Debug(message);
                }

                IsLoggingConfigured = true;
            }
        }

        /// <summary>
        /// Enables the logging events. This starts firing the according events for each log entry.
        /// </summary>
        public static void EnableLoggingEvents()
        {
            if (log4NetAppender == null)
            {
                // Always add this converter because it is used to turn log4Net log events into FdtRoot events
                log4NetAppender = new Log4NetAppender();
                BasicConfigurator.Configure(log4NetAppender);
            }
        }

        /// <summary>
        /// Called when LogDebug should be fired.
        /// </summary>
        /// <param name="eventArgs">The arguments.</param>
        public void OnLogDebug(LogEventArgs eventArgs)
        {
            var handler = LogDebug;

            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        /// <summary>
        /// Called when LogError should be fired.
        /// </summary>
        /// <param name="eventArgs">The arguments.</param>
        public void OnLogError(LogEventArgs eventArgs)
        {
            var handler = LogError;

            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        /// <summary>
        /// Called when LogFatal should be fired.
        /// </summary>
        /// <param name="eventArgs">The arguments.</param>
        public void OnLogFatal(LogEventArgs eventArgs)
        {
            var handler = LogFatal;

            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        /// <summary>
        /// Called when LogInfo should be fired.
        /// </summary>
        /// <param name="eventArgs">The arguments.</param>
        public void OnLogInfo(LogEventArgs eventArgs)
        {
            var handler = LogInfo;

            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        /// <summary>
        /// Called when LogWarn should be fired.
        /// </summary>
        /// <param name="eventArgs">The arguments.</param>
        public void OnLogWarn(LogEventArgs eventArgs)
        {
            var handler = LogWarn;

            if (handler != null)
            {
                handler(this, eventArgs);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Installs the default log4Net configuration file.
        /// </summary>
        /// <param name="log4NetConfigurationFile">The location to install the file to.</param>
        private static void InstallDefaultLog4NetConfiguration(FileInfo log4NetConfigurationFile)
        {
            if ((log4NetConfigurationFile == null) || (log4NetConfigurationFile.Directory == null))
            {
                return;
            }

            if (!log4NetConfigurationFile.Directory.Exists)
            {
                log4NetConfigurationFile.Directory.Create();
            }

            using (var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EH.ImsOpcBridge.Resources.log4net.config"))
            {
                if (resourceStream != null)
                {
                    using (var fileStream = FileHandler.OpenFile(log4NetConfigurationFile.FullName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        int cnt;
                        const int Len = 4096;
                        var buffer = new byte[Len];

                        while ((cnt = resourceStream.Read(buffer, 0, Len)) != 0)
                        {
                            fileStream.Write(buffer, 0, cnt);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
