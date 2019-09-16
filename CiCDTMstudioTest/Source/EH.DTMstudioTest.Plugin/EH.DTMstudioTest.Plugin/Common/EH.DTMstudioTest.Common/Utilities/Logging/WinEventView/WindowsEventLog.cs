// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowsEventLog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The windows event log.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Utilities.Logging.WinEventView  
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// The windows event log.
    /// </summary>
    public class WindowsEventLog
    {
        #region Constants

        /// <summary>
        /// The logger configuration file.
        /// </summary>
        private const string LoggerConfigurationFile = "WinEventLog.logger.conf.xml";

        #endregion

        #region Static Fields

        /// <summary>
        /// The event log entry type.
        /// </summary>
        private static EHEventLogEntryType eventLogEntryType = EHEventLogEntryType.Error | EHEventLogEntryType.FailureAudit | EHEventLogEntryType.Information | EHEventLogEntryType.SuccessAudit | EHEventLogEntryType.Warning | EHEventLogEntryType.Debug;

        /// <summary>
        /// The logger configuration path.
        /// </summary>
        private static string loggerConfigurationPath = string.Empty;

        /// <summary>
        /// The source.
        /// </summary>
        private static string productName = "NSPluginNet4"; // "Application.ProductName";

        #endregion

        // private static string Computername = "STCHPS720"; //System.Windows.Forms.SystemInformation.ComputerName.ToString();
        // private static string ProjectName = "NSPluginNet4"; //Application.ProductName;
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether is Win Event Logging Activate.
        /// </summary>
        public static bool IsWinEventLoggingActive { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Debug(string message)
        {
            Debug(null, message);
        }

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Debug(object sender, string message)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Debug) == EHEventLogEntryType.Debug)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("Debug: {0}", message), EventLogEntryType.Information);
                }
                else
                {
                    WriteEntry(productName, string.Format("Debug: {0} - {1}", sender.GetType(), message), EventLogEntryType.Information);
                }
            }
        }

        /// <summary>
        /// The enter.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Enter(string method)
        {
            Enter(null, method);
        }

        /// <summary>
        /// The enter.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Enter(object sender, string method)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Debug) == EHEventLogEntryType.Debug)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("MethodEnter: {0}", method), EventLogEntryType.Information);
                }
                else
                {
                    WriteEntry(productName, string.Format("MethodEnter: {0} - {1}", sender.GetType(), method), EventLogEntryType.Information);
                }
            }
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Error(string message)
        {
            Error(null, message);
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Error(object sender, string message)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Error) == EHEventLogEntryType.Error)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("Error: {0}", message), EventLogEntryType.Error);
                }
                else
                {
                    WriteEntry(productName, string.Format("Error: {0} - {1}", sender.GetType(), message), EventLogEntryType.Error);
                }
            }
        }

        /// <summary>
        /// The error ex.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="ex">
        /// The ex.
        /// </param>
        public static void ErrorEx(string message, Exception ex)
        {
            ErrorEx(null, ex, message);
        }

        /// <summary>
        /// The error ex.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="ex">
        /// The ex.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void ErrorEx(object sender, Exception ex, string message)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Error) == EHEventLogEntryType.Error)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("ErrorEx: {0} - {1}", message, ex), EventLogEntryType.Error);
                }
                else
                {
                    WriteEntry(productName, string.Format("ErrorEx: {0} - {1} - {2}", sender.GetType(), message, ex), EventLogEntryType.Error);
                }
            }
        }

        /// <summary>
        /// The failure.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="ex">
        /// The ex.
        /// </param>
        public static void Failure(string method, Exception ex)
        {
            Failure(null, method, ex);
        }

        /// <summary>
        /// The failure.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="ex">
        /// The ex.
        /// </param>
        public static void Failure(object sender, string method, Exception ex)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Error) == EHEventLogEntryType.Error)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("Failure: {0} - {1}", method, ex), EventLogEntryType.Error);
                }
                else
                {
                    WriteEntry(productName, string.Format("Failure: {0} - {1} - {2}", sender.GetType(), method, ex), EventLogEntryType.Error);
                }
            }
        }

        /// <summary>
        /// The failure audit.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        public static void FailureAudit(string text)
        {
            FailureAudit(null, text);
        }

        /// <summary>
        /// The failure audit.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        public static void FailureAudit(object sender, string text)
        {
            if ((eventLogEntryType & EHEventLogEntryType.FailureAudit) == EHEventLogEntryType.FailureAudit)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("FailureAudit: {0}", text), EventLogEntryType.FailureAudit);
                }
                else
                {
                    WriteEntry(productName, string.Format("FailureAudit: {0} - {1}", sender.GetType(), text), EventLogEntryType.FailureAudit);
                }
            }
        }

        /// <summary>
        /// The fatal.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Fatal(string message)
        {
            Fatal(null, message);
        }

        /// <summary>
        /// The fatal.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Fatal(object sender, string message)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Error) == EHEventLogEntryType.Error)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("Fatal: {0}", message), EventLogEntryType.Error);
                }
                else
                {
                    WriteEntry(productName, string.Format("Fatal: {0} - {1}", sender.GetType(), message), EventLogEntryType.Error);
                }
            }
        }

        /// <summary>
        /// The fatal ex.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void FatalEx(Exception ex, string message)
        {
            FatalEx(null, ex, message);
        }

        /// <summary>
        /// The fatal ex.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="ex">
        /// The ex.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void FatalEx(object sender, Exception ex, string message)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Error) == EHEventLogEntryType.Error)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("FatalEx: {0} - {1}", message, ex), EventLogEntryType.Error);
                }
                else
                {
                    WriteEntry(productName, string.Format("FatalEx: {0} - {1} - {2}", sender.GetType(), message, ex), EventLogEntryType.Error);
                }
            }
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Info(string message)
        {
            Info(null, message);
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Info(object sender, string message)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Information) == EHEventLogEntryType.Information)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("Information: {0}", message), EventLogEntryType.Information);
                }
                else
                {
                    WriteEntry(productName, string.Format("Information: {0} - {1}", sender.GetType(), message), EventLogEntryType.Information);
                }
            }
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="loggerConfigurationFolder">
        /// The logger configuration folder.
        /// </param>
        public static void Initialize(string loggerConfigurationFolder)
        {
            loggerConfigurationPath = Path.Combine(loggerConfigurationFolder, LoggerConfigurationFile);

            var winEventLogConfiguration = new WinEventLogConfiguration();
            winEventLogConfiguration.GetConfiguration(loggerConfigurationPath);
            eventLogEntryType = winEventLogConfiguration.EHEventLogEntryType;

            productName = winEventLogConfiguration.Source;
            IsWinEventLoggingActive = winEventLogConfiguration.IsWinEventLoggingActive;
        }

        /// <summary>
        /// The success.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Success(string method)
        {
            Success(null, method);
        }

        /// <summary>
        /// The success.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Success(object sender, string method)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Information) == EHEventLogEntryType.Information)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("Success: {0}", method), EventLogEntryType.Information);
                }
                else
                {
                    WriteEntry(productName, string.Format("Success: {0} - {1}", sender.GetType(), method), EventLogEntryType.Information);
                }
            }
        }

        /// <summary>
        /// The success audit.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        public static void SuccessAudit(string text)
        {
            SuccessAudit(null, text);
        }

        /// <summary>
        /// The success audit.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        public static void SuccessAudit(object sender, string text)
        {
            if ((eventLogEntryType & EHEventLogEntryType.SuccessAudit) == EHEventLogEntryType.SuccessAudit)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("SuccessAudit: {0}", text), EventLogEntryType.SuccessAudit);
                }
                else
                {
                    WriteEntry(productName, string.Format("SuccessAudit: {0} - {1}", sender.GetType(), text), EventLogEntryType.SuccessAudit);
                }
            }
        }

        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Warn(string message)
        {
            Warn(null, message);
        }

        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Warn(object sender, string message)
        {
            if ((eventLogEntryType & EHEventLogEntryType.Warning) == EHEventLogEntryType.Warning)
            {
                if (sender == null)
                {
                    WriteEntry(productName, string.Format("Warning: {0}", message), EventLogEntryType.Warning);
                }
                else
                {
                    WriteEntry(productName, string.Format("Warning: {0} - {1}", sender.GetType(), message), EventLogEntryType.Warning);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The write entry.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="writeEntryEventLogEntryType">
        /// The event log entry type.
        /// </param>
        private static void WriteEntry(string source, string message, EventLogEntryType writeEntryEventLogEntryType)
        {
            if (IsWinEventLoggingActive)
            {
                try
                {
                    EventLog.WriteEntry(source, message, writeEntryEventLogEntryType);
                }
                catch (Exception ex)
                {
                    IsWinEventLoggingActive = false;
                    Log.ErrorEx("EH.OpcDa.Common.Logging.WinEventView.WriteEntry", ex, ex.Message);
                }
            }
        }

        #endregion
    }
}