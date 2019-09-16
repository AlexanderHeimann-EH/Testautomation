// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpdateCatalog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The UpdateCatalog interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Execution
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The UpdateCatalog interface.
    /// </summary>
    public interface IUpdateCatalog
    {
        #region Public Methods and Operators

        /// <summary>
        /// Clicks the update button of the Update Dtm Catalog Dialog when FieldCare is starting
        /// </summary>
        /// <returns>
        /// True if button was found and clicked, false otherwise <see cref="bool"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        bool Run();

        #endregion
    }
}