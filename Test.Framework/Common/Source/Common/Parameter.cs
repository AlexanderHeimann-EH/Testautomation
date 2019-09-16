//------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 23.03.2011
 * Time: 8:54 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Common
{
    using System;
    
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    ///     Parameter represents a DTM parameter. It provides functionality
    ///     to set/get parameter properties.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// The similarity.
        /// </summary>
        private static double similarity = 0.99;

        /// <summary>
        /// The _parameter name.
        /// </summary>
        private string parameterName = string.Empty;

        /// <summary>
        /// The parameter state.
        /// </summary>
        private ParameterState parameterState = ParameterState.NotRecognized;

        /// <summary>
        /// The parameter type.
        /// </summary>
        private ParameterType parameterType = ParameterType.Unknown;

        /// <summary>
        /// The parameter unit.
        /// </summary>
        private string parameterUnit = string.Empty;

        /// <summary>
        /// The parameter value.
        /// </summary>
        private string parameterValue = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class. 
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        public Parameter(string parameterName)
        {
            this.ParameterName = this.GetParameterName(parameterName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class. 
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        /// <param name="parameterState">
        /// State of parameter
        /// </param>
        public Parameter(string parameterName, ParameterState parameterState)
        {
            this.ParameterName = this.GetParameterName(parameterName);
            this.ParameterState = parameterState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class. 
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        /// <param name="parameterState">
        /// State of parameter
        /// </param>
        /// <param name="parameterValue">
        /// Value of parameter
        /// </param>
        public Parameter(string parameterName, ParameterState parameterState, string parameterValue)
        {
            this.ParameterName = this.GetParameterName(parameterName);
            this.ParameterState = parameterState;
            this.ParameterValue = parameterValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class. 
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        /// <param name="parameterState">
        /// State of parameter
        /// </param>
        /// <param name="parameterValue">
        /// Value of parameter
        /// </param>
        /// <param name="parameterUnit">
        /// Unit of parameter
        /// </param>
        public Parameter(string parameterName, ParameterState parameterState, string parameterValue, string parameterUnit)
        {
            this.ParameterName = this.GetParameterName(parameterName);
            this.ParameterState = parameterState;
            this.ParameterValue = parameterValue;
            this.ParameterUnit = parameterUnit;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class. 
        /// Constructor
        /// </summary>
        /// <param name="parameterName">
        /// Name of parameter
        /// </param>
        /// <param name="parameterState">
        /// State of parameter
        /// </param>
        /// <param name="parameterValue">
        /// Value of parameter
        /// </param>
        /// <param name="parameterUnit">
        /// Unit of parameter
        /// </param>
        /// <param name="parameterType">
        /// Type of parameter
        /// </param>
        public Parameter(string parameterName, ParameterState parameterState, string parameterValue, string parameterUnit, ParameterType parameterType)
        {
            this.ParameterName = this.GetParameterName(parameterName);
            this.ParameterState = parameterState;
            this.ParameterValue = parameterValue;
            this.ParameterUnit = parameterUnit;
            this.ParameterType = parameterType;
        }

        /// <summary>
        /// Gets or sets similarity
        /// </summary>
        public static double Similarity
        {
            get { return similarity; }
            set { similarity = value; }
        }

        /// <summary>
        /// Gets or sets parameter name
        /// </summary>
        public string ParameterName
        {
            get { return this.parameterName; }
            set { this.parameterName = value; }
        }

        /// <summary>
        /// Gets or sets parameter unit
        /// </summary>
        public string ParameterValue
        {
            get { return this.parameterValue; }
            set { this.parameterValue = value; }
        }

        /// <summary>
        /// Gets or sets parameter unit
        /// </summary>
        public string ParameterUnit
        {
            get { return this.parameterUnit; }
            set { this.parameterUnit = value; }
        }

        /// <summary>
        /// Gets or sets parameter state
        /// </summary>
        public ParameterState ParameterState
        {
            get { return this.parameterState; }
            set { this.parameterState = value; }
        }

        /// <summary>
        /// Gets or sets parameter type
        /// </summary>
        public ParameterType ParameterType
        {
            get { return this.parameterType; }
            set { this.parameterType = value; }
        }

        /// <summary>
        ///     Extracts the parameter name out of the tree path from [Navigation Area]
        /// </summary>
        /// <param name="path">Tree path that leads to parameter</param>
        /// <returns>Name of parameter</returns>
        private string GetParameterName(string path)
        {
            string[] separator = { "//" };
            string[] pathParts = path.Split(separator, StringSplitOptions.None);
            return pathParts[pathParts.Length - 1];
        }
    }
}