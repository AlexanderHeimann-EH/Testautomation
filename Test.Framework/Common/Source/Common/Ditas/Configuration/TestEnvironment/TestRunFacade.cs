// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestRunFacade.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Reflection;
    using System.Xml;

    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.Common;
    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.Helper;

    using Ranorex;

    using DateTime = System.DateTime;

    /// <summary>
    /// Description of TestResultItemFactory.
    /// </summary>
    public static class TestRunFacade
    {
        #region Static Fields

        /// <summary>
        /// The log file.
        /// </summary>
        private static readonly string LogFile = Directory.GetCurrentDirectory() + "\\testrunlog.txt";

        /// <summary>
        /// The test run.
        /// </summary>
        private static TestRun testRun = null;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add result.
        /// </summary>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <param name="description">
        /// The description.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        public static void AddResult(string function, string description, object result)
        {
            if (testRun.TestResultItem != null)
            {
                testRun.TestResultItem.AddResult(function, description, result);
            }
        }

        /// <summary>
        /// The get device.
        /// </summary>
        /// <returns>
        /// The <see cref="Device"/>.
        /// </returns>
        public static Device GetDevice()
        {
            if (testRun.Device == null)
            {
                return null;
            }
            else
            {
                return testRun.Device;
            }
        }

        /// <summary>
        /// The get job id.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetJobID()
        {
            return testRun.JobID;
        }

        /// <summary>
        /// The get modem ip address.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetModemIPAddress()
        {
            return testRun.SysEnvParamValue;
        }

        /// <summary>
        /// The get report path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetReportPath()
        {
            return testRun.ReportPath;
        }

        /// <summary>
        /// The get target db.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetTargetDB()
        {
            return testRun.TargetDB;
        }

        /// <summary>
        /// The get test run id.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetTestRunID()
        {
            return testRun.TestrunID;
        }

        /// <summary>
        /// The get test sequence.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>Queue</cref>
        ///     </see>
        ///     .
        /// </returns>
        public static Queue<KeyValuePair<string, int>> GetTestSequence()
        {
            return testRun.TestSequence;
        }

        /// <summary>
        /// The get test system.
        /// </summary>
        /// <returns>
        /// The <see cref="TestSystem"/>.
        /// </returns>
        public static TestSystem GetTestSystem()
        {
            if (testRun.TestSystem == null)
            {
                return null;
            }

            return testRun.TestSystem;
        }

        /// <summary>
        /// The get test system id.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetTestSystemID()
        {
            return testRun.SystemID;
        }

        /// <summary>
        /// The initialize test run.
        /// </summary>
        /// <param name="testSuiteType">
        /// The test suite type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool InitializeTestRun(TestSuiteTypes.Types testSuiteType)
        {
            bool success = false;

            XmlDocument settings = new XmlDocument();

            settings.Load(Directory.GetCurrentDirectory() + "\\settings.xml");
            XmlNodeList nodeList = settings.SelectNodes("/settings/reports");

            DISEHHelper disHelper;
            TestlabHelper testlabHelper;

            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    string disehServerName = node["share"].InnerText;
                    string disehUser = node["user"].InnerText;
                    string disehPwd = node["password"].InnerText;

                    disHelper = new DISEHHelper(disehServerName, disehUser, disehPwd);
                }
            }

            nodeList = settings.SelectNodes("/settings/testconfig");

            string testlabShare = string.Empty;
            string testlabJobLocation = string.Empty;
            string testlabUser = string.Empty;
            string testlabPwd = string.Empty;
            string pathtoExe = string.Empty;
            string vmName = string.Empty;

            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    testlabShare = node["share"].InnerText;
                    testlabJobLocation = node["path"].InnerText;
                    testlabUser = node["user"].InnerText;
                    testlabPwd = node["password"].InnerText;
                    pathtoExe = node["pathtoexe"].InnerText;
                }
            }

            nodeList = settings.SelectNodes("/settings/vm");

            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    var xmlElement = node["name"];
                    if (xmlElement != null)
                    {
                        vmName = xmlElement.InnerText;
                    }
                }
            }

            testlabHelper = new TestlabHelper(testlabShare, testlabUser, testlabUser, testlabJobLocation, vmName, pathtoExe);

            if (testlabHelper.MoveJobXMLToExeDir())
            {
                testRun = new TestRun();

                Type[] types = Assembly.GetAssembly(typeof(ITestResultItem)).GetTypes();
                ITestResultItem instance = null;
                foreach (Type t in types)
                {
                    if (typeof(ITestResultItem).IsAssignableFrom(t))
                    {
                        if (t.Name.Equals(testSuiteType + "TestResultItem"))
                        {
                            instance = Activator.CreateInstance(t) as ITestResultItem;
                            break;
                        }
                    }
                }

                testRun.TestResultItem = instance;

                testlabHelper.WriteStatusFileToTestlab(TestStatus.Status.Running);
                success = true;
            }
            else
            {
                testlabHelper.WriteStatusFileToTestlab(TestStatus.Status.ConfigNotCopied);
            }

            return success;
        }

        /// <summary>
        /// The is test run initialized.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsTestRunInitialized()
        {
            return testRun.IsInitialized;
        }

        /// <summary>
        /// The print test results.
        /// </summary>
        public static void PrintTestResults()
        {
            if (testRun.TestResultItem != null)
            {
                Report.Info("TEST RESULTS  ------------------------- ");

                List<NameValueCollection> results = testRun.TestResultItem.GetResults();

                if (results != null && results.Count > 0)
                {
                    foreach (NameValueCollection col in testRun.TestResultItem.GetResults())
                    {
                        string function = col.Get("function");
                        string description = col.Get("description");
                        string duration = col.Get("duration");

                        Report.Info("Function " + function);
                        Report.Info("Description " + description);
                        Report.Info("Duration " + duration);
                    }
                }
            }
        }

        /// <summary>
        /// The print test run configuration.
        /// </summary>
        public static void PrintTestRunConfiguration()
        {
            if (testRun.IsInitialized)
            {
                Report.Info("TEST CONFIGURATION DETAILS ------------------------- ");
                Report.Info("Tester " + testRun.Tester);
                Report.Info("Device IID " + testRun.Device.IID);

                Report.Info("TEST ENVIRONMENT ------------------------- ");
                Report.Info("PAM tool ID " + testRun.PAMTool.ID);
                Report.Info("VMWare ID" + testRun.VMWare.Id);
                Report.Info("Wiring ID" + testRun.WiringID);
                Report.Info("System ID" + testRun.SystemID);
            }
        }

        /// <summary>
        /// The save results.
        /// </summary>
        public static void SaveResults()
        {
            StreamWriter w = File.AppendText(LogFile);
            try
            {
                if (testRun != null)
                {
                    if (testRun.save())
                    {
                        Report.Success("Test results successfully saved");

                        // Clear results after save
                        if (testRun.TestResultItem != null)
                        {
                            testRun.TestResultItem.ClearResults();
                        }
                    }
                    else
                    {
                        Report.Failure("Saving test results failed");
                    }
                }
            }
            catch (Exception ex)
            {
                Report.Failure(ex.Message);
                Log(ex.StackTrace, w);
                Log(ex.Message, w);
            }
        }

        /// <summary>
        /// The write status file.
        /// </summary>
        /// <param name="status">
        /// The status.
        /// </param>
        public static void WriteStatusFile(TestStatus.Status status)
        {
            (new TestlabHelper()).WriteStatusFileToTestlab(status);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The log.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="w">
        /// The w.
        /// </param>
        private static void Log(string message, TextWriter w)
        {
            w.Write("\r\n Log ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine(" : ");
            w.WriteLine(" : {0}", message);
            w.WriteLine("-----------------------------------------------");
        }

        #endregion
    }
}