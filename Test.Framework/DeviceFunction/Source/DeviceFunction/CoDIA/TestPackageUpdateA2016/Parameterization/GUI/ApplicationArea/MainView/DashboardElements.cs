// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DashboardElements.cs" company="Endress+Hauser Process Solutions AG">
//   Endress + Hauser Process Solutions AG
// </copyright>
// <summary>
//   The dashboard elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// The dashboard elements.
    /// </summary>
    public class DashboardElements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly DashboardElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardElements"/> class.
        /// </summary>
        public DashboardElements()
        {
            this.repository = DashboardElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the container alternate measured value label 1.
        /// </summary>
        public Element ContainerAlternateMeasuredValueLabel1
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Dashboard.ContainerAlternateMeasuredValueLabel1Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container alternate measured value label 2.
        /// </summary>
        public Element ContainerAlternateMeasuredValueLabel2
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Dashboard.ContainerAlternateMeasuredValueLabel2Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container alternate measured value label 3.
        /// </summary>
        public Element ContainerAlternateMeasuredValueLabel3
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Dashboard.ContainerAlternateMeasuredValueLabel3Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container alternate measured value label 4.
        /// </summary>
        public Element ContainerAlternateMeasuredValueLabel4
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Dashboard.ContainerAlternateMeasuredValueLabel4Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container extended measured value label 1.
        /// </summary>
        public Element ContainerExtendedMeasuredValueLabel1
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ContainerExtendedMeasuredValueLabel1Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container extended measured value label 2.
        /// </summary>
        public Element ContainerExtendedMeasuredValueLabel2
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ContainerExtendedMeasuredValueLabel2Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container extended measured value label 3.
        /// </summary>
        public Element ContainerExtendedMeasuredValueLabel3
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ContainerExtendedMeasuredValueLabel3Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container extended measured value label 4.
        /// </summary>
        public Element ContainerExtendedMeasuredValueLabel4
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ContainerExtendedMeasuredValueLabel4Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container extended measured value label 5.
        /// </summary>
        public Element ContainerExtendedMeasuredValueLabel5
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ContainerExtendedMeasuredValueLabel5Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container extended measured value label 6.
        /// </summary>
        public Element ContainerExtendedMeasuredValueLabel6
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ContainerExtendedMeasuredValueLabel6Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container extended measured value label 7.
        /// </summary>
        public Element ContainerExtendedMeasuredValueLabel7
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ContainerExtendedMeasuredValueLabel7Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the container extended measured value label 8.
        /// </summary>
        public Element ContainerExtendedMeasuredValueLabel8
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ContainerExtendedMeasuredValueLabel8Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the main container of the dashboard.
        /// </summary>
        public Element MainDashboardContainer
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ContainerProcessVariablesPanelControlInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the tab control of the dashboard.
        /// </summary>
        public Element TabControlDashboard
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ElementTabControlInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        #endregion
    }
}