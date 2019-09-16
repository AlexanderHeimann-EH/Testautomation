// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIgnoreUpdate.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The IgnoreUpdate interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Execution
{
    /// <summary>
    /// The IgnoreUpdate interface.
    /// </summary>
    public interface IIgnoreUpdate
    {
        #region Public Methods and Operators

        /// <summary>
        /// Clicks the ignore button of the Update Dtm Catalog Dialog when FieldCare is starting
        /// </summary>
        /// <returns>
        /// True if button was found and clicked, false otherwise <see cref="bool"/>.
        /// </returns>
        bool Run();

        #endregion
    }
}