// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsTabElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class SettingsTabElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.GUI.ApplicationArea.MainView
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class SettingsTabElements.
    /// </summary>
    public class SettingsTabElements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly MainViewElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsTabElements"/> class. 
        /// Initializes a new instance of the <see cref="MainViewElements"/> class.
        /// </summary>
        public SettingsTabElements()
        {
            this.repository = MainViewElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region GeneralSettings

        /// <summary>
        /// Gets the general settings ComboBox distance unit.
        /// </summary>
        /// <value>The general settings ComboBox distance unit.</value>
        public Element GeneralSettingsComboBoxDistanceUnit
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.GeneralSettings.ComboBoxDistanceUnitInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the general settings ComboBox level unit.
        /// </summary>
        /// <value>The general settings ComboBox level unit.</value>
        public Element GeneralSettingsComboBoxLevelUnit
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.GeneralSettings.ComboBoxLevelUnitInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the type of the general settings ComboBox linearization.
        /// </summary>
        /// <value>The type of the general settings ComboBox linearization.</value>
        public Element GeneralSettingsComboBoxLinearizationType
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.GeneralSettings.ComboBoxLinearizationTypeInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the general settings ComboBox output mode.
        /// </summary>
        /// <value>The general settings ComboBox output mode.</value>
        public Element GeneralSettingsComboBoxOutputMode
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.GeneralSettings.ComboBoxOutputModeInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the general settings edit field empty calibration.
        /// </summary>
        /// <value>The general settings edit field empty calibration.</value>
        public Element GeneralSettingsEditFieldEmptyCalibration
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.GeneralSettings.EditFieldEmptyCalibrationInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the general settings edit field full calibration.
        /// </summary>
        /// <value>The general settings edit field full calibration.</value>
        public Element GeneralSettingsEditFieldFullCalibration
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.GeneralSettings.EditFieldFullCalibrationInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion

        #region UserSettings

        /// <summary>
        /// Gets the user settings ComboBox unit after linearization.
        /// </summary>
        /// <value>The user settings ComboBox unit after linearization.</value>
        public Element UserSettingsComboBoxUnitAfterLinearization
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.UserSettings.ComboBoxUnitAfterLinearizationInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the user settings ComboBox unit after linearization.
        /// </summary>
        /// <value>The user settings ComboBox unit after linearization.</value>
        public Element UserSettingsEditFieldDeviceNameInfo
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.UserSettings.EditFieldDeviceNameInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the user settings edit field device tag information.
        /// </summary>
        /// <value>The user settings edit field device tag information.</value>
        public Element UserSettingsEditFieldDeviceTagInfo
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.UserSettings.EditFieldDeviceTagInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}