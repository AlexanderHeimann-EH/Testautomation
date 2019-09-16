// ***********************************************************************
// <copyright file="Logger.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.ImsOpcBridge.Service.Implementation.Logging
{
    using System;
    using System.IO;

    using log4net;
    using log4net.Config;

    /// <summary>
    /// Implements the logger, based on the standard log4net component.
    /// </summary>
    public sealed class Logger
    {
        #region Const

        /// <summary>
        /// The configuration file name.
        /// </summary>
        private const string ConfigurationFileName = @"C:\tmp\ImsOpcBridge.logger.conf.xml";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="Logger"/> class.
        /// </summary>
        static Logger()
        {
            InitializeLog4Net();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Writes a message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        public static void Debug(object sender, object message)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsDebugEnabled)
            {
                logger.Debug(message);
                DiagnosticsDebug(sender, message);
            }
        }

        /// <summary>
        /// Writes a message with an exception to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        /// <param name="exception">The exception to write.</param>
        public static void DebugException(object sender, object message, Exception exception)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsDebugEnabled)
            {
                logger.Debug(message, exception);
                DiagnosticsDebug(sender, message, exception);
            }
        }

        /// <summary>
        /// Writes a formatted message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="format">The format of the message.</param>
        /// <param name="args">The dynamic arguments.</param>
        public static void DebugFormat(object sender, string format, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsDebugEnabled)
            {
                logger.DebugFormat(format, args);
                DiagnosticsDebug(sender, format, args);
            }
        }

        /// <summary>
        /// Writes a message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        public static void Error(object sender, object message)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsErrorEnabled)
            {
                logger.Error(message);
                DiagnosticsDebug(sender, message);
            }
        }

        /// <summary>
        /// Writes a message with an exception to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        /// <param name="exception">The exception to write.</param>
        public static void ErrorException(object sender, object message, Exception exception)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsErrorEnabled)
            {
                logger.Error(message, exception);
                DiagnosticsDebug(sender, message, exception);
            }
        }

        /// <summary>
        /// Writes a formatted message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="format">The format of the message.</param>
        /// <param name="args">The dynamic arguments.</param>
        public static void ErrorFormat(object sender, string format, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsErrorEnabled)
            {
                logger.ErrorFormat(format, args);
                DiagnosticsDebug(sender, format, args);
            }
        }

        /// <summary>
        /// Writes a message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        public static void Fatal(object sender, object message)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsFatalEnabled)
            {
                logger.Fatal(message);
                DiagnosticsDebug(sender, message);
            }
        }

        /// <summary>
        /// Writes a message with an exception to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        /// <param name="exception">The exception to write.</param>
        public static void FatalException(object sender, object message, Exception exception)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsFatalEnabled)
            {
                logger.Fatal(message, exception);
                DiagnosticsDebug(sender, message, exception);
            }
        }

        /// <summary>
        /// Writes a formatted message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="format">The format of the message.</param>
        /// <param name="args">The dynamic arguments.</param>
        public static void FatalFormat(object sender, string format, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsFatalEnabled)
            {
                logger.FatalFormat(format, args);
                DiagnosticsDebug(sender, format, args);
            }
        }

        /// <summary>
        /// Writes a message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        public static void Info(object sender, object message)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsInfoEnabled)
            {
                logger.Info(message);
                DiagnosticsDebug(sender, message);
            }
        }

        /// <summary>
        /// Writes a message with an exception to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        /// <param name="exception">The exception to write.</param>
        public static void InfoException(object sender, object message, Exception exception)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsInfoEnabled)
            {
                logger.Info(message, exception);
                DiagnosticsDebug(sender, message, exception);
            }
        }

        /// <summary>
        /// Writes a formatted message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="format">The format of the message.</param>
        /// <param name="args">The dynamic arguments.</param>
        public static void InfoFormat(object sender, string format, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsInfoEnabled)
            {
                logger.InfoFormat(format, args);
                DiagnosticsDebug(sender, format, args);
            }
        }

        /// <summary>
        /// Writes a message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        public static void Warn(object sender, object message)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsWarnEnabled)
            {
                logger.Warn(message);
                DiagnosticsDebug(sender, message);
            }
        }

        /// <summary>
        /// Writes a message with an exception to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        /// <param name="exception">The exception to write.</param>
        public static void WarnException(object sender, object message, Exception exception)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsWarnEnabled)
            {
                logger.Warn(message, exception);
                DiagnosticsDebug(sender, message, exception);
            }
        }

        /// <summary>
        /// Writes a formatted message to the current logging component.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="format">The format of the message.</param>
        /// <param name="args">The dynamic arguments.</param>
        public static void WarnFormat(object sender, string format, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger != null && logger.IsWarnEnabled)
            {
                logger.WarnFormat(format, args);
                DiagnosticsDebug(sender, format, args);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialize logging from the application config file.
        /// </summary>
        /// <remarks>
        /// The configuration file CANNOT be somewhere else. There is no way to configure it,
        /// therefore it is hardcoded directly in the initialization method.
        /// </remarks>
        private static void InitializeLog4Net()
        {
            try
            {
                var info = new FileInfo(ConfigurationFileName);
                if (info.Exists)
                {
                    XmlConfigurator.Configure(info);
                }
            }
            catch (Exception exception)
            {
                // Something went wrong configuring the logger, therefore we cannot log this exception!
                // The following code is to prevent having StyleCop warning about empty catch.
                // Do not want to use warning suppression.
                var message = exception.Message;
            }
        }

        /// <summary>
        /// Finds a logger.
        /// </summary>
        /// <param name="sender">The name of the requested logger.</param>
        /// <returns>A reference to the logger if found, null in case of errors.</returns>
        private static ILog FindLogger(object sender)
        {
            if (sender == null)
            {
                return null;
            }

            if (sender is Type)
            {
                return LogManager.GetLogger(sender as Type);
            }

            if (sender is string)
            {
                return LogManager.GetLogger(sender as string);
            }

            return LogManager.GetLogger(sender.GetType());
        }

        /// <summary>
        /// Writes a message to the diagnostics debug.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        private static void DiagnosticsDebug(object sender, object message)
        {
            var text = string.Format(
                "{0}, {1}",
                sender == null ? "(null)" : sender.ToString(),
                message == null ? "(null)" : message.ToString());

            System.Diagnostics.Debug.WriteLine(text);
        }

        /// <summary>
        /// Writes a message with an exception to the diagnostics debug.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="message">The message to write.</param>
        /// <param name="exception">The exception to write.</param>
        private static void DiagnosticsDebug(object sender, object message, Exception exception)
        {
            DiagnosticsDebug(sender, message);
            if (exception != null)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
                System.Diagnostics.Debug.WriteLine(exception.StackTrace);
            }
        }

        /// <summary>
        /// Writes a formatted message to the diagnostics debug.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="format">The format of the message.</param>
        /// <param name="args">The dynamic arguments.</param>
        private static void DiagnosticsDebug(object sender, string format, params object[] args)
        {
            System.Diagnostics.Debug.Write(sender == null ? "(null), " : sender.ToString() + ", ");
            var text = string.Format(format, args);
            System.Diagnostics.Debug.WriteLine(text);
        }

        #endregion
    }
}
