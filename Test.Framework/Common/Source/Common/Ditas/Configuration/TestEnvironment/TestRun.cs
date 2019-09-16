// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestRun.cs" company="Endress+Hauser Process Solutions AG">
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
    using System.IO;
    using System.Xml;

    using EH.PCPS.TestAutomation.Common.Ditas.Persistance.DBHandler;

    /// <summary>
    /// Description of TestRun.
    /// Contains all information about the Test environment.
    /// </summary>
    public class TestRun
    {
        #region Fields

        /// <summary>
        /// The database Connector.
        /// </summary>
        private readonly DBConnector databaseConnector;

        /// <summary>
        /// The is initialized.
        /// </summary>
        private readonly bool isInitialized;

        /// <summary>
        /// The target database.
        /// </summary>
        private readonly string targetDatabase = "dev";

        /// <summary>
        /// The test sequence.
        /// </summary>
        private readonly Queue<KeyValuePair<string, int>> testSequence;

        /// <summary>
        /// The device.
        /// </summary>
        private Device device = null;

        /// <summary>
        /// The iterations.
        /// </summary>
        private int iterations = 1;

        /// <summary>
        /// The pamtool.
        /// </summary>
        private PAMTool pamtool;

        /// <summary>
        /// The report path.
        /// </summary>
        private string reportPath = string.Empty;

        /// <summary>
        /// The sys env param value.
        /// </summary>
        private string sysEnvParamValue = string.Empty;

        /// <summary>
        /// The test case id.
        /// </summary>
        private string testCaseID = "1";

        /// <summary>
        /// The test function name.
        /// </summary>
        private string testFunctionName;

        /// <summary>
        /// The test run id.
        /// </summary>
        private int testRunID;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TestRun"/> class.
        /// </summary>
        public TestRun()
        {
            this.SysEnvParamID = 0;
            this.JobID = 0;
            this.WiringID = 0;
            this.SystemID = 0;
            this.VMWare = null;
            XmlDocument xml = new XmlDocument();
            xml.Load(Directory.GetCurrentDirectory() + "\\TestConfig.xml");
            XmlNodeList testNode = xml.SelectNodes("/test");

            if (testNode != null)
            {
                foreach (XmlNode node in testNode)
                {
                    var xmlElement = node["tester"];
                    if (xmlElement != null)
                    {
                        this.Tester = xmlElement.InnerText;
                    }

                    XmlNode deviceNode = xml.SelectSingleNode("/test/device");

                    this.device = new Device();
                    if (deviceNode != null)
                    {
                        var element = deviceNode["iid"];
                        if (element != null)
                        {
                            this.device.IID = Convert.ToInt32(element.InnerText);
                        }

                        var xmlElementCommunication = deviceNode["communication"];
                        if (xmlElementCommunication != null)
                        {
                            this.device.Communication = xmlElementCommunication.InnerText;
                        }

                        var xmlElementFirmware = deviceNode["firmware"];
                        if (xmlElementFirmware != null)
                        {
                            this.device.Firmware = xmlElementFirmware.InnerText;
                        }

                        var xmlElementFamily = deviceNode["family"];
                        if (xmlElementFamily != null)
                        {
                            this.device.Family = xmlElementFamily.InnerText;
                        }

                        var xmlElementMeasTech = deviceNode["meastech"];
                        if (xmlElementMeasTech != null)
                        {
                            this.device.MeasTech = xmlElementMeasTech.InnerText;
                        }

                        var xmlElementRevision = deviceNode["revision"];
                        if (xmlElementRevision != null)
                        {
                            this.device.Revision = xmlElementRevision.InnerText;
                        }

                        this.device.Type = deviceNode["type"].InnerText;
                    }
                }
            }

            XmlNodeList testFunctions = xml.SelectNodes("/test/testsequence/testfunction");

            this.testSequence = new Queue<KeyValuePair<string, int>>();

            if (testFunctions != null)
            {
                foreach (XmlNode testFunctionNode in testFunctions)
                {
                    var xmlElement = testFunctionNode["name"];
                    if (xmlElement != null)
                    {
                        this.testFunctionName = xmlElement.InnerText;
                    }
                    var element = testFunctionNode["iterations"];
                    if (element != null)
                    {
                        this.iterations = Convert.ToInt32(element.InnerText);
                    }

                    KeyValuePair<string, int> testFunction = new KeyValuePair<string, int>(this.testFunctionName, this.iterations);
                    this.testSequence.Enqueue(testFunction);
                }
            }

            XmlNodeList testEnv = xml.SelectNodes("/test/testenvironment");

            if (testEnv != null)
            {
                foreach (XmlNode node in testEnv)
                {
                    XmlNodeList pamTools = xml.SelectNodes("/test/testenvironment/pamtool");

                    this.pamtool = new PAMTool();

                    if (pamTools != null)
                    {
                        foreach (XmlNode pamToolNode in pamTools)
                        {
                            var xmlElement = pamToolNode["id"];
                            if (xmlElement != null)
                            {
                                this.pamtool.ID = Convert.ToInt32(xmlElement.InnerText);
                            }
                        }
                    }

                    XmlNodeList system = xml.SelectNodes("/test/testenvironment/system");

                    if (system != null)
                    {
                        foreach (XmlNode systemNode in system)
                        {
                            var xmlElement = systemNode["id"];
                            if (xmlElement != null)
                            {
                                this.SystemID = Convert.ToInt32(xmlElement.InnerText);
                            }
                        }
                    }

                    XmlNodeList wiring = xml.SelectNodes("/test/testenvironment/wiring");

                    if (wiring != null)
                    {
                        foreach (XmlNode wiringNode in wiring)
                        {
                            this.WiringID = Convert.ToInt32(wiringNode["id"].InnerText);
                        }
                    }

                    XmlNodeList database = xml.SelectNodes("/test/testenvironment/db");

                    foreach (XmlNode databaseNode in database)
                    {
                        this.targetDatabase = databaseNode.InnerText;
                    }

                    XmlNodeList job = xml.SelectNodes("/test/job");

                    foreach (XmlNode jobNode in job)
                    {
                        this.JobID = Convert.ToInt32(jobNode["id"].InnerText);
                    }

                    XmlNodeList sysEvParameters = xml.SelectNodes("/test/testenvironment/system/systemparameter");

                    foreach (XmlNode sysEvParamNode in sysEvParameters)
                    {
                        this.SysEnvParamID = Convert.ToInt32(sysEvParamNode["id"].InnerText);
                        this.sysEnvParamValue = sysEvParamNode["param"].InnerText;
                    }
                }
            }

            XmlNodeList report = xml.SelectNodes("/test/reports");

            foreach (XmlNode reportNode in report)
            {
                this.reportPath = reportNode["path"].InnerText;
            }

            this.databaseConnector = new DBConnector(this.targetDatabase);

            this.TestSystem = this.databaseConnector.GetTestSystem(this.SystemID);

            if (this.device != null && this.pamtool != null)
            {
                this.isInitialized = true;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the device.
        /// </summary>
        public Device Device
        {
            get
            {
                return this.device;
            }

            set
            {
                this.device = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether is initialized.
        /// </summary>
        public bool IsInitialized
        {
            get
            {
                return this.isInitialized;
            }
        }

        /// <summary>
        /// Gets or sets the job id.
        /// </summary>
        public int JobID { get; set; }

        /// <summary>
        /// Gets or sets the pam tool.
        /// </summary>
        public PAMTool PAMTool
        {
            get
            {
                return this.pamtool;
            }

            set
            {
                this.pamtool = value;
            }
        }

        /// <summary>
        /// Gets or sets the report path.
        /// </summary>
        public string ReportPath
        {
            get
            {
                return this.reportPath;
            }

            set
            {
                this.reportPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the sys env param id.
        /// </summary>
        public int SysEnvParamID { get; set; }

        /// <summary>
        /// Gets or sets the sys env param value.
        /// </summary>
        public string SysEnvParamValue
        {
            get
            {
                return this.sysEnvParamValue;
            }

            set
            {
                this.sysEnvParamValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the system id.
        /// </summary>
        public int SystemID { get; set; }

        /// <summary>
        /// Gets the target db.
        /// </summary>
        public string TargetDB
        {
            get
            {
                return this.targetDatabase;
            }
        }

        /// <summary>
        /// Gets or sets the test case id.
        /// </summary>
        public string TestCaseID
        {
            get
            {
                return this.testCaseID;
            }

            set
            {
                this.testCaseID = value;
            }
        }

        /// <summary>
        /// Gets or sets the test result item.
        /// </summary>
        public ITestResultItem TestResultItem { get; set; }

        /// <summary>
        /// Gets the test sequence.
        /// </summary>
        public Queue<KeyValuePair<string, int>> TestSequence
        {
            get
            {
                return this.testSequence;
            }
        }

        /// <summary>
        /// Gets or sets the test system.
        /// </summary>
        public TestSystem TestSystem { get; set; }

        /// <summary>
        /// Gets or sets the tester.
        /// </summary>
        public string Tester { get; set; }

        /// <summary>
        /// Gets the testrun id.
        /// </summary>
        public int TestrunID
        {
            get
            {
                return this.testRunID;
            }
        }

        /// <summary>
        /// Gets or sets the vm ware.
        /// </summary>
        public VMWare VMWare { get; set; }

        /// <summary>
        /// Gets or sets the wiring id.
        /// </summary>
        public int WiringID { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The save.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool save()
        {
            bool success = false;

            if (this.isInitialized)
            {
                success = this.databaseConnector.Persist(this);
                
                if (success)
                {
                    this.testRunID = this.databaseConnector.GetPersistedTestrunID;
                }
                else
                {
                    this.testRunID = 0;
                }
            }

            return success;
        }

        #endregion
    }
}