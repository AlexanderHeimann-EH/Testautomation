// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Selection.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of Selection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Description of Selection.
    /// </summary>
    public class Selection : ISelection
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Get progress Information
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public string GetProgressInformation()
        {
            Element progressInformation = new SelectionElements().TxtStatusOfSaveRestoreModule;
            if (progressInformation == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element progress information is null");
                return string.Empty;
            }

            string result = progressInformation.GetAttributeValueText("Text");
            return result;
        }

        /// <summary>
        ///     Get State Information
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public string GetStateInformation()
        {
            Element stateInformation = new SelectionElements().TxtStatusOfDevice;
            if (stateInformation == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element state information is null");
                return string.Empty;
            }

            string result = stateInformation.GetAttributeValueText("Text");
            return result;
        }

        /// <summary>
        /// Get summary Information
        /// </summary>
        /// <returns><br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br></returns>
        public string GetSummaryInformation()
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not implemented. Only usable with TestPackageUpdateB2014");
            return string.Empty;
        }

        /// <summary>
        ///     Save file with default name
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Load()
        {
            Element button = new SelectionElements().BtnRestoreFrom;
            if (button != null && button.Enabled)
            {
                Mouse.MoveTo(button, 500);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        /// <summary>
        ///     Save file with default name
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Save()
        {
            Element button = new SelectionElements().BtnSaveAs;
            if (button != null && button.Enabled)
            {
                Mouse.MoveTo(button, 500);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        /// <summary>
        /// Select option for Different Device
        /// </summary>
        /// <returns><br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br></returns>
        public bool SelectDifferent()
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not implemented. Only usable with TestPackageUpdateB2014");
            return false;
        }

        /// <summary>
        ///     Clicks checkbox Download
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SelectDownload()
        {
            CheckBox checkBox = new SelectionElements().CbDownload;
            if (checkBox != null && checkBox.Enabled)
            {
                checkBox.MoveTo(2000);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        /// <summary>
        /// Selects the download mode all parameters.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SelectDownloadModeAllParameters()
        {
            RadioButton allParameters = new SelectionElements().DownloadModeAllParameter;
            if (allParameters != null)
            {
                allParameters.MoveTo(2000);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        /// <summary>
        /// Selects the download mode duplicate.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SelectDownloadModeDuplicate()
        {
            RadioButton duplicate = new SelectionElements().DownloadModeDuplicate;
            if (duplicate != null)
            {
                duplicate.MoveTo(2000);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        /// <summary>
        /// Select option for Identical Device
        /// </summary>
        /// <returns><br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br></returns>
        public bool SelectIdentical()
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not implemented. Only usable with TestPackageUpdateB2014");
            return false;
        }

        /// <summary>
        /// Clicks checkbox Restore
        /// </summary>
        /// <returns><br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br></returns>
        public bool SelectRestore()
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not implemented. Only usable with TestPackageUpdateB2014");
            return false;
        }

        /// <summary>
        /// Clicks checkbox Save
        /// </summary>
        /// <returns><br>True: If call worked fine</br>
        /// <br>False: If an error occurred</br></returns>
        public bool SelectSave()
        {
            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Not implemented. Only usable with TestPackageUpdateB2014");
            return false;
        }

        /// <summary>
        ///     Clicks checkbox Upload
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SelectUpload()
        {
            CheckBox checkBox = new SelectionElements().CbUpload;
            if (checkBox != null && checkBox.Enabled)
            {
                checkBox.MoveTo(2000);
                Mouse.Click();
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }

        #endregion
    }
}