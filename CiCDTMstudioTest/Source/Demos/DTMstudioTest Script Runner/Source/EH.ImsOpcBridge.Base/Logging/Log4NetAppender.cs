// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log4NetAppender.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.ImsOpcBridge.Logging
{
    using System;
    using System.Globalization;
    using System.Threading;

    using EH.ImsOpcBridge.Properties;

    using log4net.Appender;
    using log4net.Core;

    /// <summary>
    /// The log4Net appender, which supports, that log4Net messages are forwarded to FdtRoot events.
    /// </summary>
    public class Log4NetAppender : AppenderSkeleton
    {
        #region Methods

        /// <summary>
        /// Subclasses of <see cref="T:log4net.Appender.AppenderSkeleton"/> should implement this method
        /// to perform actual logging.
        /// </summary>
        /// <param name="loggingEvent">The event to append.</param>
        protected override void Append(LoggingEvent loggingEvent)
        {
            if (loggingEvent == null)
            {
                throw new ArgumentNullException(@"loggingEvent");
            }

            var text = string.Format(CultureInfo.CurrentUICulture, Resources.Log4NetAppender_Append_LogFormat, loggingEvent.TimeStamp, loggingEvent.RenderedMessage, loggingEvent.LoggerName, Thread.CurrentThread.ManagedThreadId);
            var exception = loggingEvent.ExceptionObject;

            var logEventArgs = new LogEventArgs(text, exception);

            if (loggingEvent.Level == Level.Debug)
            {
                LogManager.Singleton.OnLogDebug(logEventArgs);
            }
            else if (loggingEvent.Level == Level.Info)
            {
                LogManager.Singleton.OnLogInfo(logEventArgs);
            }
            else if (loggingEvent.Level == Level.Warn)
            {
                LogManager.Singleton.OnLogWarn(logEventArgs);
            }
            else if (loggingEvent.Level == Level.Error)
            {
                LogManager.Singleton.OnLogError(logEventArgs);
            }
            else if (loggingEvent.Level == Level.Fatal)
            {
                LogManager.Singleton.OnLogFatal(logEventArgs);
            }
            else
            {
                LogManager.Singleton.OnLogError(new LogEventArgs(string.Format(CultureInfo.CurrentUICulture, Resources.LoggingLevel_IsNotSupported, loggingEvent.Level.DisplayName)));
                LogManager.Singleton.OnLogDebug(logEventArgs);
            }
        }

        #endregion
    }
}
