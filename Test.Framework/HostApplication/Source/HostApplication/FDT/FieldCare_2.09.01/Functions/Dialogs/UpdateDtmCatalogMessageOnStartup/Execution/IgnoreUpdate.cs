// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IgnoreUpdate.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class IgnoreUpdate.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Execution
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Execution;

    using Ranorex;

    /// <summary>
    /// Class IgnoreUpdate.
    /// </summary>
    public class IgnoreUpdate : IIgnoreUpdate
    {
        #region Public Methods and Operators

        /// <summary>
        /// Clicks the ignore button of the Update Dtm Catalog Dialog when FieldCare is starting
        /// </summary>
        /// <returns>
        /// True if button was found and clicked, false otherwise <see cref="bool"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run()
        {
            bool result = true;
            Button ignore = new UpdateDtmCatalogMessageElements().Ignore;
            if (ignore == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update button is null.");
            }
            else
            {
                ignore.Click();
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking update button.");
            }

            return result;
        }

        #endregion
    }
}