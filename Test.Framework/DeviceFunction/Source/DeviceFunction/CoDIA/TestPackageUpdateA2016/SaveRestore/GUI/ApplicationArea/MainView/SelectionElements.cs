// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectionElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 27.01.2012
 * Time: 13:33 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of SelectionElements
    /// </summary>
    /// <returns>
    ///     <br>Button: If call worked fine</br>
    ///     <br>NULL: If an error occurred</br>
    /// </returns>
    public class SelectionElements
    {
        #region Fields

        /// <summary>
        /// The _mdi client path.
        /// </summary>
        private readonly string _mdiClientPath;

        /// <summary>
        /// The _selection.
        /// </summary>
        private readonly Selection _selection;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionElements"/> class. 
        ///     Creates an instance of the repository which will be used and determines the path of the mdi client
        /// </summary>
        public SelectionElements()
        {
            this._selection = Selection.Instance;
            this._mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets Button RestoreFrom;
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element BtnRestoreFrom
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo btnRestoreFromInfo = this._selection.buttonRestoreFromInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + btnRestoreFromInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets Button
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element BtnSaveAs
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo btnSaveAsInfo = this._selection.buttonSaveAsInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + btnSaveAsInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets Checkbox Download
        /// </summary>
        /// <returns>
        ///     <br>Checkbox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public CheckBox CbDownload
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo cbDownloadInfo = this._selection.checkboxDownloadInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + cbDownloadInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets Checkbox Upload
        /// </summary>
        /// <returns>
        ///     <br>Checkbox: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public CheckBox CbUpload
        {
            get
            {
                try
                {
                    CheckBox element;
                    RepoItemInfo cbUploadInfo = this._selection.checkboxUploadInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + cbUploadInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the download mode all parameter.
        /// </summary>
        /// <value>The download mode duplicate.</value>
        public RadioButton DownloadModeAllParameter
        {
            get
            {
                try
                {
                    RadioButton element;
                    RepoItemInfo itemInfo = this._selection.radioButtonDownloadModeAllParameterInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + itemInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the download mode duplicate.
        /// </summary>
        /// <value>The download mode duplicate.</value>
        public RadioButton DownloadModeDuplicate
        {
            get
            {
                try
                {
                    RadioButton element;
                    RepoItemInfo itemInfo = this._selection.radioButtonDownloadModeDuplicateInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + itemInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text "Status of device"
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element TxtStatusOfDevice
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo txtStateInfo = this._selection.txtStatusOfDeviceInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + txtStateInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text "Status of Save/Restore Assistant"
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element TxtStatusOfSaveRestoreModule
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo txtInformationInfo = this._selection.txtStatusOfSaveRestoreAssistentInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + txtInformationInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}