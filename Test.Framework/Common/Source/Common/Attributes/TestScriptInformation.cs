// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestScriptInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   Attribute Information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 20.08.2014
 * Time: 6:30 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common.Attributes
{
    using System;

    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// The test script information.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, Inherited = false)]
    [Serializable]
    public class TestScriptInformation : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public TestScriptInformation()
        {
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="TestScriptInformation"/> class.
        ///// </summary>
        ///// <param name="guid">
        ///// The unique identifier.
        ///// </param>
        ///// <param name="testDefinition">
        ///// The test definition.
        ///// </param>
        ///// <param name="testScript">
        ///// The test script.
        ///// </param>
        ///// <param name="testCategory">
        ///// The test category.
        ///// </param>
        ///// <param name="testFocus">
        ///// The test focus.
        ///// </param>
        ////public TestScriptInformation(string guid, TestDefinition testDefinition, TestScript testScript, TestCategory testCategory, TestFocus testFocus)
        //{
        //    this.Guid           = guid;
        //    this.TestDefinition = testDefinition;
        //    this.TestScript     = testScript;
        //    this.TestCategory   = testCategory;
        //    this.TestFocus      = testFocus;
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="TestScriptInformation"/> class.
        /// </summary>
        /// <param name="guid">
        /// The unique identifier.
        /// </param>
        /// <param name="testDefinition">
        /// The test Definition.
        /// </param>
        /// <param name="testScript">
        /// The test script.
        /// </param>
        public TestScriptInformation(string guid, TestDefinition testDefinition, TestScript testScript)
        {
            this.Guid           = guid;
            this.TestDefinition = testDefinition;
            this.TestScript     = testScript;
            //this.TestCategory   = TestCategory.NotDefined;
            //this.TestFocus      = TestFocus.NotDefined;
        }

        /// <summary>
        /// Gets or sets the graphical user interface identifier.
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the test script.
        /// </summary>
        public TestScript TestScript { get; set; }

        ///// <summary>
        ///// Gets or sets the test category.
        ///// </summary>
        //public TestCategory TestCategory { get; set; }

        ///// <summary>
        ///// Gets or sets the test focus.
        ///// </summary>
        //public TestFocus TestFocus { get; set; }

        /// <summary>
        /// Gets or sets the test definition.
        /// </summary>
        /// <value>The test definition.</value>
        public TestDefinition TestDefinition { get; set; }
    }
}
