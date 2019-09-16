// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FF912DiagnosticCategories.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The diagnostic categories.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.Enumerations
{
    /// <summary>
    /// The ff 912 error categoriescs.
    /// </summary>
// ReSharper disable InconsistentNaming
    public enum FF912DiagnosticCategories
// ReSharper restore InconsistentNaming
    {
        /// <summary>
        /// The failure.
        /// </summary>
        Failure = 1,

        /// <summary>
        /// The function check.
        /// </summary>
        FunctionCheck = 2,

        /// <summary>
        /// The out of specification.
        /// </summary>
        OutOfSpecification = 3,

        /// <summary>
        /// The maintenance required.
        /// </summary>
        MaintenanceRequired = 4
    }
}