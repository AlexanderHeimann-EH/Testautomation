using System;
using log4net;
using log4net.Config;
using System.IO;

/*
Konfiguration Log4Net.logger.conf.xml

 * C:\ProgramData\Endress+Hauser Process Solutions AG\EHCorporateOpcDa\1.0.0.0\Logs
 
<log4net >
  <appender name="RollingFileInTemp" type="log4net.Appender.RollingFileAppender" >
    <file type="log4net.Util.PatternString" value="C:\\ProgramData\\Endress+Hauser Process Solutions AG\\EHCorporateOpcDa\\1.0.0.0\Logs\\log4net.log" /> <!-- 

_%processid -->
    <appendToFile value="false" />
    <rollingStyle value="Size" />
    <maxSizeRollBackups value="2" />
    <maximumFileSize value="100MB" />
    <staticLogFileName value="false" />
	<layout type="log4net.Layout.XmlLayout" />     
  </appender>

  <appender name="XMLFileAppender" type="log4net.Appender.FileAppender"> 
     <file type="log4net.Util.PatternString" value="C:\\ProgramData\\Endress+Hauser Process Solutions AG\\EHCorporateOpcDa\\1.0.0.0\Logs\\log4net.log" /> <!-- 

_%processid -->
     <appendToFile value="false" /> 
     <layout type="log4net.Layout.XmlLayout" /> 
  </appender>
   
	<!-- Levels: ALL Verbose Trace Debug Info Notice Warn Error Severe Critical Alert Fatal Emergency OFF -->
	<root> <level value="ERROR" />
      <appender-ref ref="RollingFileInTemp" /> 
   </root>		
   <logger name="NSPlugin">                  						<level value="ALL" /> </logger>
   <logger name="Endress.WirelessHART_Ethernet">                  	<level value="ALL" /> </logger>	
   
</log4net>
 * 

*/

namespace EH.OpcDa.Common.Logging.Log4Net
{
    namespace SpecialLogs
    {
        internal class TimeStamp { }
    }


    public class Log4NetLog
    {
        #region Fields

        private const string LoggerConfigurationFile = "Log4Net.logger.conf.xml";

        #endregion

        #region Initialization

        /// <summary>
        /// Initialize logging from the application config file.
        /// </summary>
        public static void XmlInitialize()
        {
            XmlInitialize("");
        }

        /// <summary>
        /// Initialize logging from the application config file.
        /// </summary>
        public static void XmlInitialize(string loggerConfigurationPath)
        {
            try
            {
                var info = new FileInfo(System.IO.Path.Combine(loggerConfigurationPath, LoggerConfigurationFile));
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
        /// Logs a Dispose method execution.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="disposing"></param>
        public static void Dispose(object sender, bool disposing)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.InfoFormat("Dispose({0})", disposing);
        }

        #endregion

        #region Log Operations

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public static void Debug(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsDebugEnabled)
                return;

            Debug(sender, message, null);

        }


        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Debug(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsDebugEnabled)
                return;
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
        /// Logs an error message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public static void Error(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsErrorEnabled)
                return;

            Error(sender, message, null);
        }


        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Error(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsErrorEnabled)
                return;

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
        /// Logs an error message together with an exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void ErrorEx(object sender, Exception ex, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsErrorEnabled)
                return;

            Error(sender, message, ex, null);
        }


        /// <summary>
        /// Logs an error message together with an exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void ErrorEx(object sender, Exception ex, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsErrorEnabled)
                return;

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
        /// Logs a fatal error message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public static void Fatal(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsFatalEnabled)
                return;

            Fatal(sender, message, null);

        }


        /// <summary>
        /// Logs a fatal error message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Fatal(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsFatalEnabled)
                return;

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
        /// Logs a fatal error message together with an exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        public static void FatalEx(object sender, Exception ex, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsFatalEnabled)
                return;

            logger.Fatal(message, ex);
        }


        /// <summary>
        /// Logs a fatal error message together with an exception.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void FatalEx(object sender, Exception ex, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsFatalEnabled)
                return;

            logger.Fatal(string.Format(message, args), ex);
        }


        /// <summary>
        /// Logs an info message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public static void Info(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.Info(message);
        }


        /// <summary>
        /// Logs an info message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Info(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.InfoFormat(message, args);
        }


        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public static void Warn(object sender, string message)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsWarnEnabled)
                return;

            logger.Warn(message);
        }


        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Warn(object sender, string message, params object[] args)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsWarnEnabled)
                return;

            logger.WarnFormat(message, args);
        }


        /// <summary>
        /// Logs a timestamp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        public static void TimeStamp(object sender, string message)
        {
            var logger = FindLogger(typeof(SpecialLogs.TimeStamp));
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.Info(message);
        }


        /// <summary>
        /// Logs a timestamp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void TimeStamp(object sender, string message, params object[] args)
        {
            var logger = FindLogger(typeof(SpecialLogs.TimeStamp));
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.InfoFormat(message, args);
        }


        /// <summary>
        /// Logs a method entry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="method"></param>
        public static void Enter(object sender, string method)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

            Enter(sender, method, null);
        }


        /// <summary>
        /// Logs a method entry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="method"></param>
        /// <param name="arguments"></param>
        public static void Enter(object sender, string method, params object[] arguments)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

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
        /// Logs a successful method exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="method"></param>
        public static void Success(object sender, string method)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.InfoFormat("Success: {0}", method);
        }


        /// <summary>
        /// Logs a successful method exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="method"></param>
        /// <param name="results"></param>
        public static void Success(object sender, string method, params object[] results)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.InfoFormat("Success: {0}", string.Format(method, results));
        }


        /// <summary>
        /// Logs a failure method exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="method"></param>
        /// <param name="error"></param>
        public static void Failure(object sender, string method, Exception error)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.InfoFormat("{0}: {1}", method, error);
        }


        /// <summary>
        /// Logs a failure method exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="method"></param>
        /// <param name="error"></param>
        /// <param name="results"></param>
        public static void Failure(object sender, string method, Exception error, params object[] results)
        {
            var logger = FindLogger(sender);
            if (logger == null || !logger.IsInfoEnabled)
                return;

            logger.InfoFormat("Failure: {0}: {1}", string.Format(method, results), error);
        }

        #endregion

        #region Logger Operations

        private static ILog FindLogger(object sender)
        {
            if (sender == null)
                return (null);

            if (sender is Type)
                return (LogManager.GetLogger(sender as Type));

            if (sender is string)
                return (LogManager.GetLogger(sender as string));

            return (LogManager.GetLogger(sender.GetType()));
        }

        #endregion
    };
};
