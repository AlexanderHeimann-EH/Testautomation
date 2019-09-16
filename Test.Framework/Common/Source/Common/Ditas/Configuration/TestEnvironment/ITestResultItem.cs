// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITestResultItem.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Ditas.Configuration.TestEnvironment
{
    using System.Collections.Generic;
    using System.Collections.Specialized;

    /// <summary>
    /// Description of TestResultItem.
    /// </summary>
    public interface ITestResultItem
    {
        #region Public Methods and Operators

        /// <summary>
        /// The result type.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int ResultType();

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string ToString();

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
        void AddResult(string function, string description, object result);

        /// <summary>
        /// The clear results.
        /// </summary>
        void ClearResults();

        /// <summary>
        /// The get results.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        List<NameValueCollection> GetResults();

        #endregion
    }
}