// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckSaveRestoreStatus.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Provides methods to access information about the current status of the Save/Restore module
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides methods to access information about the current status of the Save/Restore module
    /// </summary>
    public class CheckSaveRestoreStatus : ICheckSaveRestoreStatus
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the current status of the Save/Restore module
        /// </summary>
        /// <returns>
        /// The current status
        /// </returns>
        public string GetCurrentStatus()
        {
            string result = string.Empty;
            Element status = new SelectionElements().TxtStatusOfSaveRestoreModule;
            if (status == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'StatusOfSaveRestoreModule' is null");
            }
            else
            {
                result = status.GetAttributeValueText("Text");
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The current status of the Save/Restore module is: '" + result + "'.");
            }

            return result;
        }

        /// <summary>
        /// Evaluates whether saving was successful
        /// </summary>
        /// <returns><c>true</c> if 'Saving finished successfully' message is shown in the 'Status of Save/Restore Assistant' box, <c>false</c> otherwise.</returns>
        public bool WasSavingSuccessful()
        {
            bool result = true;

            Element status = new SelectionElements().TxtStatusOfSaveRestoreModule;
            if (status == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'StatusOfSaveRestoreModule' is null");
                result = false;
            }
            else
            {
                if (status.GetAttributeValueText("Text") != "Saving finished successfully")
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The current status of the Save/Restore module is: '" + status.GetAttributeValueText("Text") + "'.");
                    result = false;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving finished successfully");
                }
            }

            return result;
        }

        /// <summary>
        /// Evaluates whether restoring was successful
        /// </summary>
        /// <returns><c>true</c> if 'Restoring finished successfully' message is shown in the 'Status of Save/Restore Assistant' box, <c>false</c> otherwise.</returns>
        public bool WasRestoringSuccessful()
        {
            bool result = true;

            Element status = new SelectionElements().TxtStatusOfSaveRestoreModule;
            if (status == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'StatusOfSaveRestoreModule' is null");
                result = false;
            }
            else
            {
                if (status.GetAttributeValueText("Text") != "Restoring finished successfully")
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The current status of the Save/Restore module is: '" + status.GetAttributeValueText("Text") + "'.");
                    result = false;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Restoring finished successfully");
                }
            }

            return result;
        }  
        #endregion
    }
}