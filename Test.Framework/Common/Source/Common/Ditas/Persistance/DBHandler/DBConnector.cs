// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBConnector.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 11/6/2013
 * Time: 8:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Ditas.Persistance.DBHandler
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Xml;

    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment;

    using Ranorex;

    /// <summary>
    /// Description of DBConnector.
    /// </summary>
    public class DBConnector
    {
        /// <summary>
        /// The con.
        /// </summary>
        private SqlConnection con;

        /// <summary>
        /// The log file.
        /// </summary>
        private string logFile = Directory.GetCurrentDirectory() + "\\dblog.txt";

        /// <summary>
        /// The test run id.
        /// </summary>
        private int testRunId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBConnector"/> class.
        /// </summary>
        /// <param name="targetDb">
        /// The target database.
        /// </param>
        public DBConnector(string targetDb)
        {
            if (this.con == null || this.con.State != ConnectionState.Open)
            {
                this.Connect(targetDb);
            }
        }

        /// <summary>
        /// Gets the get persisted test run id.
        /// </summary>
        public int GetPersistedTestrunID
        {
            get
            {
                return this.testRunId;
            }
        }

        /// <summary>
        /// The get connection.
        /// </summary>
        /// <returns>
        /// The <see cref="SqlConnection"/>.
        /// </returns>
        public SqlConnection GetConnection()
        {
            if (this.con.State != ConnectionState.Open)
            {
                this.con.Open();
            }

            return this.con;
        }

        /// <summary>
        /// The get test system.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TestSystem"/>.
        /// </returns>
        public TestSystem GetTestSystem(int id)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            
            string query = "Select id, name from TestSystems where component_id = @id";
            SqlCommand command = new SqlCommand(query, this.con);            
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            
            TestSystem system = new TestSystem();
            
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                system.ID = reader.GetInt32(reader.GetOrdinal("id"));
                system.Name = reader.GetString(reader.GetOrdinal("name"));
            }

            reader.Close();

            command = new SqlCommand("select tep.parametername, tsp.defaultvalue from TestEnvironmentParameters tep, TestSystemParameters tsp where tep.id in (select parameter_id from TestSystemParameters where system_id = @id) and tep.id = tsp.parameter_id", this.con);
            command.Parameters.AddWithValue("@id", system.ID);
            command.ExecuteNonQuery();
            
            reader = command.ExecuteReader();
            while (reader.Read())
            {                
                string paramName = reader.GetString(reader.GetOrdinal("parametername"));                
                string paramDefaultValue = reader.GetString(reader.GetOrdinal("defaultvalue"));

                if (paramName != null)
                {
                    parameters.Add(paramName, paramDefaultValue);
                }
            }
            
            system.Parameters = parameters;
            reader.Close();
            
            return system;
        }

        /// <summary>
        /// Persists the specified test run.
        /// </summary>
        /// <param name="testRun">The test run.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Persist(TestRun testRun)
        {                        
            bool success = true;
            StreamWriter w = File.AppendText(this.logFile);

            try
            {
                string jobInfo = "Select runs_on_vm from Jobs where id = @jobID";
                SqlCommand command = new SqlCommand(jobInfo, this.con);
                command.Parameters.AddWithValue("@jobID", testRun.JobID);        
                command.ExecuteNonQuery();
            
                Report.Info("QUERY: Select runs_on_vm from Jobs where id = " + testRun.JobID);
                Log("Select runs_on_vm from Jobs where id = " + testRun.JobID, w);
                
                SqlDataReader reader = command.ExecuteReader();
                int virtualMachineId = 0;
            
                while (reader.Read())
                {
                    virtualMachineId = reader.GetInt32(reader.GetOrdinal("runs_on_vm"));
                    Log("VM ID " + virtualMachineId, w);
                    Report.Info("VM ID " + virtualMachineId);
                }

                reader.Close();
            
                string insertTestEnv = "Insert into TestEnvironment (pamtool_id, wirings_id, vmware_id, testsystem_id) values (@pamtoolID, @wiringID, @vmwareID, @testsystemID)";
            
                command = new SqlCommand(insertTestEnv, this.con);
                command.Parameters.AddWithValue("@pamtoolID", testRun.PAMTool.ID);            
                command.Parameters.AddWithValue("@wiringID", testRun.WiringID);
                command.Parameters.AddWithValue("@vmwareID", virtualMachineId);
                command.Parameters.AddWithValue("@testsystemID", testRun.SystemID);

                Report.Info("QUERY: Insert into TestEnvironment (pamtool_id, wirings_id, vmware_id, testsystem_id) values (" + testRun.PAMTool.ID + ", " + testRun.WiringID + ", " + virtualMachineId + "," + testRun.SystemID + ")");
                Log("Insert into TestEnvironment (pamtool_id, wirings_id, vmware_id) values (" + testRun.PAMTool.ID + ", " + testRun.WiringID + ", " + virtualMachineId + ", " + testRun.SystemID + ")", w);
                int insertedRows = command.ExecuteNonQuery();
                Log(command.CommandText, w);
                if (insertedRows == 1)
                {                
                    command.CommandText = "SELECT IDENT_CURRENT('TestEnvironment')";            
                    command.ExecuteNonQuery();                        
                    int testEnvId = Convert.ToInt32(command.ExecuteScalar());
                
                    Log("NEW TEST ENV ID " + testEnvId, w);

                    int employeeId = Convert.ToInt32(testRun.Tester);
                    
                    int testRunInsert = 0;
                    
                    if (employeeId != 0)
                    {
                        string insertTestRun = "Insert into TestRuns (device_iid, testcase_id, date_execution, tester, testenv_id, job_id) values (@deviceIID, @testcaseID, GETDATE(), @tester, @testenvID, @jobID)";
                        command = new SqlCommand(insertTestRun, this.con);
                        command.Parameters.AddWithValue("@deviceIID", testRun.Device.IID);
                        command.Parameters.AddWithValue("@testcaseID", testRun.TestCaseID);                        
                        command.Parameters.AddWithValue("@tester", employeeId);
                        command.Parameters.AddWithValue("@testenvID", testEnvId);
                        command.Parameters.AddWithValue("@jobID", testRun.JobID);

                        testRunInsert += command.ExecuteNonQuery();
                        Report.Info("Insert into TestRuns (device_iid, testcase_id, date_execution, tester, testenv_id, job_id) values (" + testRun.Device.IID + ", " + testRun.TestCaseID + ", " + employeeId + ", " + testEnvId + ", " + testRun.JobID + ")");                                                                                            
                        Log("Insert into TestRuns (device_iid, testcase_id, date_execution, tester, testenv_id, job_id) values (" + testRun.Device.IID + ", " + testRun.TestCaseID + ", " + employeeId + ", " + testEnvId + ", " + testRun.JobID + ")", w);                                                                                            
                        
                        if (testRunInsert == 1)
                        {
                            command.CommandText = "SELECT IDENT_CURRENT('TestRuns')";            
                            command.ExecuteNonQuery();                        
                            this.testRunId = Convert.ToInt32(command.ExecuteScalar());                                                         
                        }
                        else
                        {
                            success = false;    
                        }

                        if (this.testRunId != 0)
                        {
                            ITestResultItem testResult = testRun.TestResultItem;    
                                                        
                            int resultCount = testRun.TestResultItem.GetResults().Count;
                            int insertedResults = 0;
                            
                            foreach (NameValueCollection col in testRun.TestResultItem.GetResults())
                            {                            
                                string insertTestRunFunc = "Insert into TestRunFunctions (testrun_id, function_name, description) values (@testrunID, @functionName, @description)";
                                command = new SqlCommand(insertTestRunFunc, this.con);
                                command.Parameters.AddWithValue("@testrunID", this.testRunId);
                                command.Parameters.AddWithValue("@functionName", col.Get("function"));
                                command.Parameters.AddWithValue("@description", col.Get("description"));
                            
                                insertedResults += command.ExecuteNonQuery();
                                Report.Info("Insert into TestRunFunctions (testrun_id, function_name, description) values (" + this.testRunId + ", " + col.Get("function") + ", " + col.Get("description") + ")");
                                Log("Insert into TestRunFunctions (testrun_id, function_name, description) values (" + this.testRunId + ", " + col.Get("function") + ", " + col.Get("description") + ")", w);
                                
                                command.CommandText = "SELECT IDENT_CURRENT('TestRunFunctions')";            
                                command.ExecuteNonQuery();                        
                                int testRunFunctionId = Convert.ToInt32(command.ExecuteScalar());
                                string insertTesRunResult = "Insert into TestRunResults (resulttype_id, result_value, testrunfunction_id) values (@resulttypeID, @resultValue, @testrunfunctionID)";
                                command = new SqlCommand(insertTesRunResult, this.con);
                                command.Parameters.AddWithValue("@resulttypeID", testResult.ResultType());
                                command.Parameters.AddWithValue("@resultValue",  col.Get("duration"));
                                command.Parameters.AddWithValue("@testrunfunctionID", testRunFunctionId);
                                command.ExecuteNonQuery();
                                Report.Info("Insert into TestRunResults (resulttype_id, result_value, testrunfunction_id) values (" + testResult.ResultType() + ", " + col.Get("duration") + ", " + testRunFunctionId + ")");
                                Log("Insert into TestRunResults (resulttype_id, result_value, testrunfunction_id) values (" + testResult.ResultType() + ", " + col.Get("duration") + ", " + testRunFunctionId + ")", w);
                            }                            

                            if (insertedResults != resultCount)
                            {
                                success = false;    
                            }
                        }
                        else
                        {
                            success = false;    
                        }
                    }                                
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message, w);
            }

            return success;            
        }

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
            w.WriteLine("{0} {1}", System.DateTime.Now.ToLongTimeString(), System.DateTime.Now.ToLongDateString());
            w.WriteLine(" : ");
            w.WriteLine(" : {0}", message);
            w.WriteLine("-----------------------------------------------");
        }

        /// <summary>
        /// The get employee id.
        /// </summary>
        /// <param name="employeeNumber">
        /// The i number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private int GetEmployeeId(string employeeNumber)
        {
            SqlCommand command = new SqlCommand("Select id from Employees where employee_id = '" + employeeNumber + "'", this.con);
            command.ExecuteNonQuery();
            int id = 0;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(reader.GetOrdinal("id"));
            }

            reader.Close();
            return id;
        }

        /// <summary>
        /// The connect.
        /// </summary>
        /// <param name="targetDatabase">
        /// The target database.
        /// </param>
        private void Connect(string targetDatabase)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Directory.GetCurrentDirectory() + "\\settings.xml");

            XmlNodeList nodeList = null;

            if (targetDatabase.Equals("dev"))
            {
                nodeList = xml.SelectNodes("/settings/database/dev");
            }
            else if (targetDatabase.Equals("prod"))
            {
                nodeList = xml.SelectNodes("/settings/database/prod");
            }

            if (nodeList != null)
            {
                string connectionString = string.Empty;

                foreach (XmlNode node in nodeList)
                {
                    var xmlElementServer = node["server"];
                    var xmlElementDatabaseName = node["name"];
                    var xmlElementUser = node["user"];
                    var xmlElementPassword = node["password"];
                    if (xmlElementServer != null && xmlElementDatabaseName != null && xmlElementUser != null && xmlElementPassword != null)
                    {
                        string server = "server=" + xmlElementServer.InnerText;
                        string database = "database=" + xmlElementDatabaseName.InnerText;
                        string user = "user id=" + xmlElementUser.InnerText;
                        string password = "password=" + xmlElementPassword.InnerText;
                        connectionString = user + ";" + password + ";" + server + ";" + database + ";";
                    }
                }

                this.con = new SqlConnection(connectionString);
                this.con.Open();
            }
        }
    }
}
