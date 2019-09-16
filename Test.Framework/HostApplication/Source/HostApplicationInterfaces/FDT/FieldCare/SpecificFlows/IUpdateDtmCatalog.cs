// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpdateDtmCatalog.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Interface IUpdateDtmCatalog
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Interface IUpdateDtmCatalog
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public interface IUpdateDtmCatalog
    {
        #region Public Methods and Operators

        /// <summary>
        /// Opens the FieldCare Catalog via Menu, starts an update and adds new devices if necessary.
        /// </summary>
        /// <param name="timeToWaitForUpdateMessage">
        /// The time to wait for the update window to appear in milliseconds. Recommended: 5000.
        /// </param>
        /// <param name="timeoutForUpdateProgress">
        /// The timeout For the Update Progress. This depends on how many dtms are found. Recommended: 120000.
        /// </param>
        /// <param name="shouldFindNewDevice">
        /// Set to true only if new devices have been installed. They will be added to the catalog.
        /// </param>
        /// <param name="maxMinutesSinceDtmWasInstalled">
        /// The approximate time in minutes since the dtm has been installed
        /// </param>
        /// <param name="timeToWaitForMoving">
        /// The time To Wait For Moving in milliseconds. This is important if the update is huge.
        /// </param>
        /// <returns>
        /// True if the update was successful, false otherwise.<see cref="bool"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        bool Run(int timeToWaitForUpdateMessage, int timeoutForUpdateProgress, bool shouldFindNewDevice, int maxMinutesSinceDtmWasInstalled, int timeToWaitForMoving);

        #endregion
    }
}