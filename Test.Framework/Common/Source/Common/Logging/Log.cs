// -----------------------------------------------------------------------
// <copyright file="Log.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright © Endress+Hauser Process Solutions AG 2013
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Security;
using EH.OpcDa.Common.Logging.Log4Net;
using EH.OpcDa.Common.Logging.WinEventView;

[assembly: AllowPartiallyTrustedCallers]

namespace EH.OpcDa.Common.Logging
{
    /// <summary>
    /// The log.
    /// </summary>
    public class Log
    {
        #region Initialization

        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="loggerConfigurationPath">
        /// The logger configuration path.
        /// </param>
        public static void Initialize(string loggerConfigurationPath)
        {
            Log4NetLog.XmlInitialize(loggerConfigurationPath);
            WindowsEventLog.Initialize(loggerConfigurationPath);
        }

        #endregion

        #region Log Operations

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Debug(string message)
        {
            Log4NetLog.Debug(null, message);
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
            Log4NetLog.Debug(sender, message);
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Error(string message)
        {
            Log4NetLog.Error(null, message);
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
            Log4NetLog.Error(sender, message);
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
            Log4NetLog.ErrorEx(sender, ex, message);
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
            Log4NetLog.Fatal(sender, message);
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
            Log4NetLog.FatalEx(sender, ex, message);
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Info(string message)
        {
            Log4NetLog.Info(null, message);
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
            Log4NetLog.Info(sender, message);
        }

        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Warn(string message)
        {
            Log4NetLog.Warn(null, message);
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
            Log4NetLog.Warn(sender, message);
        }

        /// <summary>
        /// The time stamp.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void TimeStamp(object sender, string message)
        {
            Log4NetLog.TimeStamp(sender, message);
        }

        /// <summary>
        /// The enter.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Enter(string method)
        {
            Log4NetLog.Enter(null, method);
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
            Log4NetLog.Enter(sender, method);
        }

        /// <summary>
        /// The success.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void Success(string method)
        {
            Log4NetLog.Success(null, method);
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
            Log4NetLog.Success(sender, method);
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
        /// <param name="error">
        /// The error.
        /// </param>
        public static void Failure(object sender, string method, Exception error)
        {
            Log4NetLog.Failure(sender, method, error);
        }

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void WinEventDebug(string message)
        {
            WindowsEventLog.Debug(null, message);
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
        public static void WinEventDebug(object sender, string message)
        {
            WindowsEventLog.Debug(sender, message);
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void WinEventError(string message)
        {
            WindowsEventLog.Error(null, message);
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
        public static void WinEventError(object sender, string message)
        {
            WindowsEventLog.Error(sender, message);
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
        public static void WinEventErrorEx(object sender, Exception ex, string message)
        {
            WindowsEventLog.ErrorEx(sender, ex, message);
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
        public static void WinEventFatal(object sender, string message)
        {
            WindowsEventLog.Fatal(sender, message);
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
        public static void WinEventFatalEx(object sender, Exception ex, string message)
        {
            WindowsEventLog.FatalEx(sender, ex, message);
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void WinEventInfo(string message)
        {
            WindowsEventLog.Info(message);
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
        public static void WinEventInfo(object sender, string message)
        {
            WindowsEventLog.Info(sender, message);
        }

        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void WinEventWarn(string message)
        {
            WindowsEventLog.Warn(message);
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
        public static void WinEventWarn(object sender, string message)
        {
            WindowsEventLog.Warn(sender, message);
        }

        /// <summary>
        /// The enter.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void WinEventEnter(string method)
        {
            WindowsEventLog.Enter(method);
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
        public static void WinEventEnter(object sender, string method)
        {
            WindowsEventLog.Enter(sender, method);
        }

        /// <summary>
        /// The success.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        public static void WinEventSuccess(string method)
        {
            WindowsEventLog.Success(method);
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
        public static void WinEventSuccess(object sender, string method)
        {
            WindowsEventLog.Success(sender, method);
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
        /// <param name="error">
        /// The error.
        /// </param>
        public static void WinEventFailure(object sender, string method, Exception error)
        {
            WindowsEventLog.Failure(sender, method, error);
        }

        #endregion
    }
}
