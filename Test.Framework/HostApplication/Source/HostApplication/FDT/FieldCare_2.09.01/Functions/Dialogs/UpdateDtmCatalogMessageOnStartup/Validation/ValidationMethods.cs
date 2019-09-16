// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationMethods.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ValidationMethods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.UpdateDtmCatalogMessageOnStartup.Validation;

    /// <summary>
    /// Class ValidationMethods.
    /// </summary>
    public class ValidationMethods : IValidationMethods
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether [is catalog update dialog shown].
        /// </summary>
        /// <returns><c>true</c> if [is catalog update dialog shown]; otherwise, <c>false</c>.</returns>
        public bool IsCatalogUpdateDialogShown()
        {
            var updateCatalog = new UpdateDtmCatalogMessageElements().Update;
            bool result = updateCatalog != null;

            return result;
        }

        /// <summary>
        /// Waits for catalog update dialog.
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds.
        /// </param>
        /// <returns>
        /// <c>true</c> if dialog shows up, <c>false</c> otherwise.
        /// </returns>
        public bool WaitForCatalogUpdateDialog(int timeoutInMilliseconds)
        {
            bool result = true;
            var watch = new Stopwatch();
            watch.Start();
            while (this.IsCatalogUpdateDialogShown() == false)
            {
                if (watch.ElapsedMilliseconds >= timeoutInMilliseconds)
                {
                    result = false;
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Update Catalog dialog did not show up after: " + timeoutInMilliseconds + " milliseconds.");
                    break;
                }
            }

            watch.Stop();

            return result;
        }

        #endregion
    }
}