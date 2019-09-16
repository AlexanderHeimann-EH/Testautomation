// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The main view elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.AboutBox.GUI.ApplicationArea.MainView
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// The main view elements.
    /// </summary>
    public class MainViewElements
    {
        #region Fields

        /// <summary>
        /// The host application path.
        /// </summary>
        private readonly string hostApplicationPath;

        /// <summary>
        /// The repository which will be used
        /// </summary>
        private readonly MainViewElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewElements"/> class.
        /// </summary>
        public MainViewElements()
        {
            this.hostApplicationPath = CommonFlows.GetDtmContainerPath.Run();
            this.repository = MainViewElementsRepository.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the copy to clipboard button.
        /// </summary>
        public Button CopyToClipboardButton
        {
            get
            {
                Button button;
                RepoItemInfo repoItem = this.repository.ButtonCopyToClipboardInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out button);
                return button;
            }
        }

        /// <summary>
        /// Gets the device type information date.
        /// </summary>
        public Element DeviceTypeInformationDate
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.DeviceTypeInformation.ElementDeviceTypeInformationDateInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the device type information name.
        /// </summary>
        public Element DeviceTypeInformationName
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.DeviceTypeInformation.ElementDeviceTypeInformationNameInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the device type information version.
        /// </summary>
        public Element DeviceTypeInformationVersion
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.DeviceTypeInformation.ElementDeviceTypeInformationVersionInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the DTM information date.
        /// </summary>
        public Element DtmInformationDate
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.DtmInformation.ElementDtmInformationDateInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the DTM information name.
        /// </summary>
        public Element DtmInformationName
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.DtmInformation.ElementDtmInformationNameInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the DTM information version.
        /// </summary>
        public Element DtmInformationVersion
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.DtmInformation.ElementDtmInformationVersionInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the setup information manufacturer.
        /// </summary>
        public Element SetupInformationManufacturer
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.SetupInformation.ElementSetupInformationManufacturerInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the setup information name.
        /// </summary>
        public Element SetupInformationName
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.SetupInformation.ElementSetupInformationNameInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the setup information version.
        /// </summary>
        public Element SetupInformationVersion
        {
            get
            {
                Element element;
                RepoItemInfo repoItem = this.repository.SetupInformation.ElementSetupInformationVersionInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + repoItem.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}