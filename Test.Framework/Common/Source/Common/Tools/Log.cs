// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Encapsulates the Ranorex report functionality
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Tools
{
    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Reporting;

    /// <summary>
    /// Encapsulates the RANOREX report functionality
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Report functionality for case "Failure"
        /// </summary>
        /// <param name="source">
        /// Current method/source method
        /// </param>
        /// <param name="message">
        /// Message containing information regarding current action and it's result
        /// </param>
        public static void Failure(string source, string message)
        {
            Report.Failure(source, message);
        }

        /// <summary>
        /// The failure.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Failure(string message)
        {
            Report.Failure(message);
        }

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Debug(string source, string message)
        {
            Report.Debug(source, message);
        }

        /// <summary>
        /// The debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Debug(string message)
        {
            Report.Debug(message);
        }

        /// <summary>
        /// Report functionality for case "Error"
        /// </summary>
        /// <param name="source">
        /// Current method/source method
        /// </param>
        /// <param name="message">
        /// Message containing information regarding current action and it's result
        /// </param>
        public static void Error(string source, string message)
        {
            Report.Error(source, message);
        }

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Error(string message)
        {
            Report.Error(message);
        }

        /// <summary>
        /// Report functionality for case "Info"
        /// </summary>
        /// <param name="source">
        /// Current method/source method
        /// </param>
        /// <param name="message">
        /// Message containing information regarding current action and it's result
        /// </param>
        public static void Info(string source, string message)
        {
            Report.Info(source, message);
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Info(string message)
        {
            Report.Info(message);
        }

        /// <summary>
        /// Report functionality for case "Success" 
        /// </summary>
        /// <param name="source">
        /// Current method/source method
        /// </param>
        /// <param name="message">
        /// Message containing information regarding current action and it's result
        /// </param>
        public static void Success(string source, string message)
        {
            Report.Success(source, message);
        }

        /// <summary>
        /// The success.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Success(string message)
        {
            Report.Success(message);
        }

        /// <summary>
        /// Report functionality for case "Warn" 
        /// </summary>
        /// <param name="source">
        /// Current method/source method
        /// </param>
        /// <param name="message">
        /// Message containing information regarding current action and it's result
        /// </param>
        public static void Warn(string source, string message)
        {
            Report.Warn(source, message);
        }

        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Warn(string message)
        {
            Report.Warn(message);
        }

        /// <summary>
        /// Report functionality for case "Screenshot" 
        /// </summary>        
        public static void Screenshot()
        {
            Report.Screenshot();
        }

        /// <summary>
        /// Report functionality for case "Screenshot for specified Element" 
        /// </summary>
        /// <param name="element">The element.</param>
        public static void Screenshot(Element element)
        {
            Report.Screenshot(element);
        }

        /// <summary>
        /// Begins the test suite.
        /// </summary>
        /// <param name="testSuiteName">Name of the test suite.</param>
        public static void BeginTestSuite(string testSuiteName)
        {
            TestReport.BeginTestSuite(testSuiteName);
        }

        /// <summary>
        /// Begins the test case.
        /// </summary>
        /// <param name="testCaseName">Name of the test case.</param>
        public static void BeginTestCase(string testCaseName)
        {
            TestReport.BeginTestCase(testCaseName);
        }
        
        /// <summary>
        /// Begins the test module.
        /// </summary>
        /// <param name="testCaseModule">The test case module.</param>
        public static void BeginTestModule(string testCaseModule)
        {
            TestReport.BeginTestModule(testCaseModule);
        }

        /// <summary>
        /// Ends the test case.
        /// </summary>
        public static void EndTestCase()
        {
            TestReport.EndTestCase();
        }
        
        /// <summary>
        /// Ends the test module.
        /// </summary>
        public static void EndTestModule()
        {
            TestReport.EndTestModule();
        }

        /// <summary>
        /// Begins the test suite.
        /// </summary>
        public static void SaveReport()
        {
            TestReport.SaveReport();
        }
    }
}
