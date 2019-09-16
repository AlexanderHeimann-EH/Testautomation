// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExportRestultToTestManagement.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Interfaces
{
    /// <summary>
    /// The ExportResultToTestManagement interface.
    /// </summary>
    public interface IExportResultToTestManagement
    {
        /// <summary>
        /// Gets or sets the path to report.
        /// </summary>
        string PathToReport { get;set; }

        /// <summary>
        /// Gets or sets the test name.
        /// </summary>
        string TestName { get; set; }

        /// <summary>
        /// Gets or sets the version information.
        /// </summary>
        //VersionInformation VersionInformation { get; set; } 
    }
}
