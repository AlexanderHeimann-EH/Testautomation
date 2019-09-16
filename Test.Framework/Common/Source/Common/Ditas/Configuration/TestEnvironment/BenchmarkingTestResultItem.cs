// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BenchmarkingTestResultItem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: i02401198
 * Date: 29.10.2013
 * Time: 15:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment
{
    using System.Collections.Generic;
    using System.Collections.Specialized;

    /// <summary>
    /// Description of ResultItem.
    /// </summary>
    public class BenchmarkingTestResultItem : ITestResultItem
    {
        #region Fields

        /// <summary>
        /// The results.
        /// </summary>
        private readonly List<NameValueCollection> results = new List<NameValueCollection>();

        /// <summary>
        /// The result type.
        /// </summary>
        private int resultType = 1; // "Duration (ms)"

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The result type.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int ResultType()
        {
            return this.resultType;
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return "BenchmarkTestResultItem";
        }

        /// <summary>
        /// The add result.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <param name="functionDescription">
        /// The function description.
        /// </param>
        /// <param name="durationMilliseconds">
        /// The duration milliseconds.
        /// </param>
        public void AddResult(string functionName, string functionDescription, object durationMilliseconds)
        {
            NameValueCollection resultPairs = new NameValueCollection();
            resultPairs.Add("function", functionName);
            resultPairs.Add("description", functionDescription);
            resultPairs.Add("duration", durationMilliseconds.ToString());
            this.results.Add(resultPairs);
        }

        /// <summary>
        /// The clear results.
        /// </summary>
        public void ClearResults()
        {
            this.results.Clear();
        }

        /// <summary>
        /// The get results.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<NameValueCollection> GetResults()
        {
            return this.results;
        }

        #endregion
    }
}