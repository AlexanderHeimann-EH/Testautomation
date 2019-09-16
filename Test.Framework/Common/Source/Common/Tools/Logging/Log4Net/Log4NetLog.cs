// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log4NetLog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class Log4NetLog.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Tools.Logging.Log4Net
{
    #region

    using System;
    using System.IO;

    using EH.PCPS.TestAutomation.Common.Tools.Logging.Log4Net.SpecialLogs;

    using log4net;
    using log4net.Config;

    #endregion

    namespace SpecialLogs
    {
        /// <summary>
        /// Class TimeStamp.
        /// </summary>
        internal class TimeStamp
        {
        }
    }

    /// <summary>
    /// Class Log4NetLog.
    /// </summary>
    public class Log4NetLog
    {
        #region Constants

        /// <summary>
        /// The logger configuration file
        /// </summary>
        private const string LoggerConfigurationFile = "testpackage.logger.conf.xml";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Basics the initialize.
        /// </summary>
        public static void BasicInitialize()
        {
            try
            {
                BasicConfigurator.Configure();
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
        /// Debugs the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Debug(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsDebugEnabled)
            {
                return;
            }

            Debug(sender, message, null);
        }

        /// <summary>
        /// Debugs the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void Debug(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsDebugEnabled)
            {
                return;
            }

            if (args == null)
            {
                logger.Debug(message);
            }
            else
            {
                logger.DebugFormat("Debug: " + message, args);
            }
        }

        /// <summary>
        /// Disposes the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="disposing">
        /// if set to <c>true</c> [disposing].
        /// </param>
        public static void Dispose(object sender, bool disposing)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.InfoFormat("Dispose({0})", disposing);
        }

        /// <summary>
        /// Enters the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Enter(object sender, string method)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            Enter(sender, method, null);
        }

        /// <summary>
        /// Enters the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        public static void Enter(object sender, string method, params object[] arguments)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            if (arguments == null)
            {
                logger.DebugFormat("MethodEnter: {0}", method);
            }
            else
            {
                logger.DebugFormat("MethodEnter: {0}", string.Format(method, arguments));
            }
        }

        /// <summary>
        /// Errors the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Error(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsErrorEnabled)
            {
                return;
            }

            Error(sender, message, null);
        }

        /// <summary>
        /// Errors the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void Error(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsErrorEnabled)
            {
                return;
            }

            if (args == null)
            {
                logger.Error("Error: " + message);
            }
            else
            {
                logger.ErrorFormat("Error: " + message, args);
            }
        }

        /// <summary>
        /// Errors the ex.
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
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsErrorEnabled)
            {
                return;
            }

            Error(sender, message, ex, null);
        }

        /// <summary>
        /// Errors the ex.
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
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void ErrorEx(object sender, Exception ex, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsErrorEnabled)
            {
                return;
            }

            if (args == null)
            {
                logger.Error("ErrorEx: " + message, ex);
            }
            else
            {
                logger.Error("ErrorEx: " + string.Format(message, args), ex);
            }
        }

        /// <summary>
        /// Failures the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="error">
        /// The error.
        /// </param>
        public static void Failure(object sender, string method, Exception error)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.InfoFormat("{0}: {1}", method, error);
        }

        /// <summary>
        /// Failures the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="error">
        /// The error.
        /// </param>
        /// <param name="results">
        /// The results.
        /// </param>
        public static void Failure(object sender, string method, Exception error, params object[] results)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.InfoFormat("Failure: {0}: {1}", string.Format(method, results), error);
        }

        /// <summary>
        /// Fatals the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Fatal(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsFatalEnabled)
            {
                return;
            }

            Fatal(sender, message, null);
        }

        /// <summary>
        /// Fatals the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void Fatal(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsFatalEnabled)
            {
                return;
            }

            if (args == null)
            {
                logger.Fatal("Fatal: " + message);
            }
            else
            {
                logger.FatalFormat("Fatal: " + message, args);
            }
        }

        /// <summary>
        /// Fatals the ex.
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
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsFatalEnabled)
            {
                return;
            }

            logger.Fatal(message, ex);
        }

        /// <summary>
        /// Fatals the ex.
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
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void FatalEx(object sender, Exception ex, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsFatalEnabled)
            {
                return;
            }

            logger.Fatal(string.Format(message, args), ex);
        }

        /// <summary>
        /// Informations the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Info(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.Info(message);
        }

        /// <summary>
        /// Informations the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void Info(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.InfoFormat(message, args);
        }

        /// <summary>
        /// Successes the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Success(object sender, string method)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.InfoFormat("Success: {0}", method);
        }

        /// <summary>
        /// Successes the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="results">
        /// The results.
        /// </param>
        public static void Success(object sender, string method, params object[] results)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.InfoFormat("Success: {0}", string.Format(method, results));
        }

        /// <summary>
        /// Times the stamp.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void TimeStamp(object sender, string message)
        {
            var logger = FindLogger(typeof(TimeStamp));
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.Info(message);
        }

        /// <summary>
        /// Times the stamp.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void TimeStamp(object sender, string message, params object[] args)
        {
            var logger = FindLogger(typeof(TimeStamp));
            if (logger == null || !logger.IsInfoEnabled)
            {
                return;
            }

            logger.InfoFormat(message, args);
        }

        /// <summary>
        /// Warns the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Warn(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsWarnEnabled)
            {
                return;
            }

            logger.Warn(message);
        }

        /// <summary>
        /// Warns the specified sender.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The arguments.
        /// </param>
        public static void Warn(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsWarnEnabled)
            {
                return;
            }

            logger.WarnFormat(message, args);
        }

        /// <summary>
        /// XMLs the initialize.
        /// </summary>
        public static void XmlInitialize()
        {
            XmlInitialize(@"C:\tmp\");
        }

        /// <summary>
        /// XMLs the initialize.
        /// </summary>
        /// <param name="loggerConfigurationPath">
        /// The logger configuration path.
        /// </param>
        public static void XmlInitialize(string loggerConfigurationPath)
        {
            try
            {
                var info = new FileInfo(Path.Combine(loggerConfigurationPath, LoggerConfigurationFile));
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

        #endregion

        #region Methods

        /// <summary>
        /// The find logger.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <returns>
        /// The <see cref="ILog"/>.
        /// </returns>
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

        #endregion
    }
}