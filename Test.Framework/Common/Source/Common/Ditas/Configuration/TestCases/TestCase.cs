// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCase.cs" company="Endress+Hauser Process Solutions AG">
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
 * Time: 10:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestCases
{
    using EH.PCPS.TestAutomation.Common.Ditas.Configuration.BO;

    /// <summary>
    /// Description of TestCase.
    /// </summary>
    public class TestCase : ITestCase
    {
        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The precondition.
        /// </summary>
        private string precondition;

        /// <summary>
        /// The postcondition.
        /// </summary>
        private string postcondition;

        /// <summary>
        /// The id.
        /// </summary>
        private int id;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the pre condition.
        /// </summary>
        public string PreCondition
        {
            get { return this.precondition; }
            set { this.precondition = value; }
        }

        /// <summary>
        /// Gets or sets the post condition.
        /// </summary>
        public string PostCondition
        {
            get { return this.postcondition; }
            set { this.postcondition = value; }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }     
    }
}
