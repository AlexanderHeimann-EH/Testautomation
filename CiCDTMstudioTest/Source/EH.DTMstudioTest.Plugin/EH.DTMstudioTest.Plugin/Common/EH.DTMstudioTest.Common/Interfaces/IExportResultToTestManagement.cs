// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExportResultToTestManagement.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The TestOutput interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.DTMstudioTest.Common.Interfaces
{
    using EH.DTMstudioTest.Common.TransportObjects.DTMstudioTestData;

    /// <summary>
    /// The TestOutput interface.
    /// </summary>
    public interface IExportResultToTestManagement
    {
        /// <summary>
        /// The export result.
        /// </summary>
        /// <param name="pathToReport">
        /// The path to report.
        /// </param>
        /// <param name="testName">
        /// The test name.
        /// </param>
        /// <param name="dtmStudioTestData">
        /// The test data.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool ExportTestResult(string pathToReport, string testName, DTMstudioTestData dtmStudioTestData);
    }
}