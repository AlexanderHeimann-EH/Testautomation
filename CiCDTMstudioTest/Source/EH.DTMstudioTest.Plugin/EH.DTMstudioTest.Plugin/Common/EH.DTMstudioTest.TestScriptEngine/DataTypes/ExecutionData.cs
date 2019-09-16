// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExecutionData.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The execution data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.DataTypes
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;

    /// <summary>
    /// The execution data.
    /// </summary>
    public class ExecutionData
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionData"/> class.
        /// </summary>
        public ExecutionData()
        {
            this.TestMethods = new TestObjectCollection();
            this.Parameters = new List<TestParameter>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExecutionData"/> class.
        /// </summary>
        /// <param name="executionData">
        /// The execution data.
        /// </param>
        public ExecutionData(ExecutionData executionData)
        {
            // reporting
            this.SearchedGuid = executionData.SearchedGuid;
            this.TestMethods = executionData.TestMethods;
            this.TestSuiteBaseFolder = executionData.TestSuiteBaseFolder;

            // execution
            this.Assembly = executionData.Assembly;
            this.AssemblyName = executionData.AssemblyName;
            this.AttributeData = executionData.AttributeData;
            this.Method = executionData.Method;
            this.Parameter = executionData.Parameter;
            this.Parameters = executionData.Parameters;
            this.ParentGuid = executionData.ParentGuid;
            this.Type = executionData.Type;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the assembly.
        /// </summary>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// Gets or sets the assembly name.
        /// </summary>
        public string AssemblyName { get; set; }

        /// <summary>
        /// Gets or sets the attribute data.
        /// </summary>
        public CustomAttributeData AttributeData { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        public MethodInfo Method { get; set; }

        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        public ParameterInfo[] Parameter { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public IList<TestParameter> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the parent guid.
        /// </summary>
        public string ParentGuid { get; set; }

        /// <summary>
        /// Gets or sets the searched guid.
        /// </summary>
        public string SearchedGuid { get; set; }

        /// <summary>
        /// Gets or sets the test methods.
        /// </summary>
        public TestObjectCollection TestMethods { get; set; }

        /// <summary>
        /// Gets or sets the test suite folder.
        /// </summary>
        public string TestSuiteBaseFolder { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public Type Type { get; set; }

        #endregion
    }
}