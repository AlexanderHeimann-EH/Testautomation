// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCaseLoader.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 01/12/2014
 * Time: 10:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestCases
{
    using System.Data.SqlClient;

    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.BO;
    using EH.PCPS.TestAutomation.Common.Ditas.Persistance.DBHandler;

    /// <summary>
    /// Description of TestCaseLoader.
    /// </summary>
    public class TestCaseLoader
    {
        /// <summary>
        /// The database connector
        /// </summary>
        private DBConnector databaseConnector;

        /// <summary>
        /// The reader.
        /// </summary>
        private SqlDataReader reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseLoader"/> class.
        /// </summary>
        /// <param name="targetDataBase">
        /// The target database.
        /// </param>
        public TestCaseLoader(string targetDataBase)
        {
            this.databaseConnector = new DBConnector(targetDataBase);
        }

        /// <summary>
        /// The get test case by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ITestCase"/>.
        /// </returns>
        public ITestCase GetTestCaseByID(int id)
        {
            string query = "Select id, name, precondition, postcondition from Testcases where id = @testcaseID";

            SqlCommand command = new SqlCommand(query, this.databaseConnector.GetConnection());
            command.Parameters.AddWithValue("@testcaseID", id);        
            command.ExecuteNonQuery();
            
            this.reader = command.ExecuteReader();
            
            ITestCase testCase = new TestCase();
            
            while (this.reader.Read())
            {
                testCase.ID = this.reader.GetInt32(this.reader.GetOrdinal("id"));
                testCase.Name = this.reader.GetString(this.reader.GetOrdinal("name"));
                testCase.PreCondition = this.reader.GetString(this.reader.GetOrdinal("precondition"));
                testCase.PostCondition = this.reader.GetString(this.reader.GetOrdinal("postcondition"));
            }
            
            this.reader.Close();
            return testCase;
        }
    }
}

