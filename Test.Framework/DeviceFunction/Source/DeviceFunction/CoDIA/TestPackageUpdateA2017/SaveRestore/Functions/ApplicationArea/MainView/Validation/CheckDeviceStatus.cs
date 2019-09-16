// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckDeviceStatus.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Provides methods to access information about the current device status during a Save/Restore action
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides methods to access information about the current device status during a Save/Restore action
    /// </summary>
    public class CheckDeviceStatus : ICheckDeviceStatus
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the current device status as shown in the Save/Restore module
        /// </summary>
        /// <returns>
        /// The current status
        /// </returns>
        public string GetCurrentStatus()
        {
            string result = string.Empty;
            Element status = new SelectionElements().TxtStatusOfDevice;
            if (status == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'StatusOfDevice' is null");
            }
            else
            {
                result = status.GetAttributeValueText("Text");
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The current status of the device is: '" + result + "'.");
            }

            return result;
        }

        /// <summary>
        /// Evaluates whether uploading was successful
        /// </summary>
        /// <returns><c>true</c> if 'Download succeeded' message is shown in the 'Status of Save/Restore Assistant' box, <c>false</c> otherwise.</returns>
        public bool WasUploadSuccessful()
        {
            bool result = true;

            Element status = new SelectionElements().TxtStatusOfDevice;
            if (status == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'StatusOfDevice' is null");
                result = false;
            }
            else
            {
                if (status.GetAttributeValueText("Text") != @"Up-/download inactive" && status.GetAttributeValueText("Text") != "Download succeeded")
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The current status of the device is: '" + status.GetAttributeValueText("Text") + "'.");
                    result = false;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Upload succeeded");
                }
            }

            return result;
        }

        /// <summary>
        /// Evaluates whether downloading was successful
        /// </summary>
        /// <returns><c>true</c> if 'Download succeeded' message is shown in the 'Status of Save/Restore Assistant' box, <c>false</c> otherwise.</returns>
        public bool WasDownloadSuccessful()
        {
            bool result = true;

            Element status = new SelectionElements().TxtStatusOfDevice;
            if (status == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'StatusOfDevice' is null");
                result = false;
            }
            else
            {
                if (status.GetAttributeValueText("Text") != @"Up-/download inactive" && status.GetAttributeValueText("Text") != "Download succeeded")
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The current status of the device is: '" + status.GetAttributeValueText("Text") + "'.");
                    result = false;
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Download succeeded");
                }
            }

            return result;
        }
        #endregion
    }
}