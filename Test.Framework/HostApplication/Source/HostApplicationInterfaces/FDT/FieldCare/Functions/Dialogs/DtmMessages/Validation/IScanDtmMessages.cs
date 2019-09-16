// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScanDtmMessages.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The ScanDtmMessages interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.DtmMessages.Validation
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The ScanDtmMessages interface.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public interface IScanDtmMessages
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether the latest DTM message contains the specified text.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// <c>true</c> if the latest DTM message contains the specified text; otherwise, <c>false</c>.
        /// </returns>
        bool Contains(string text);

        /// <summary>
        /// Determines whether the latest DTM message contains a critical error message.
        /// </summary>
        /// <returns><c>true</c> if the latest DTM message contains a critical error message; otherwise, <c>false</c>.</returns>
        bool ContainsCriticalError();

        #endregion
    }
}