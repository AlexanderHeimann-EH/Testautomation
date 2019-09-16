// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsTabElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class SettingsTabElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.DipTable.GUI.ApplicationArea.MainView
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

        #region Public Properties

        /// <summary>
        /// Gets the DateTime from settings tab
        /// </summary>
        /// <value>The DateTime from settings tab.</value>
        public Element DateTime
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.DateTimeInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the device name from settings tab
        /// </summary>
        /// <value>The device name from settings tab.</value>
        public Element DeviceName
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.DeviceNameInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the firmware version from settings tab
        /// </summary>
        /// <value>The firmware version from settings tab.</value>
        public Element FirmwareVersion
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.FirmwareVersionInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the OperatingTime from settings tab
        /// </summary>
        /// <value>The OperatingTime from settings tab.</value>
        public Element OperatingTime
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.OperatingTimeInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the order code from settings tab
        /// </summary>
        /// <value>The order code from settings tab.</value>
        public Element OrderCode
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.OrderCodeInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the SerialNumber from settings tab
        /// </summary>
        /// <value>The SerialNumber from settings tab.</value>
        public Element SerialNumber
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.Settings.SerialNumberInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}