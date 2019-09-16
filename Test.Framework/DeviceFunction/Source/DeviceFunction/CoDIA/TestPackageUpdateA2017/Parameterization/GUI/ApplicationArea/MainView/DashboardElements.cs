// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DashboardElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The dashboard elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.GUI.ApplicationArea.MainView
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
        /// Gets the HomeButton
        /// </summary>
        public Button HomeButton
        {
            get
            {
                Button element;
                RepoItemInfo elementInfo = this.repository.HomeButtonInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the Dashboard container alternate measured value label 1.
        /// </summary>
        public Element DashboardAlternateMeasuredValueLabel1
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
        /// Gets the Dashboard container alternate measured value label 2.
        /// </summary>
        public Element DashboardAlternateMeasuredValueLabel2
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
        /// Gets the Dashboard container alternate measured value label 3.
        /// </summary>
        public Element DashboardAlternateMeasuredValueLabel3
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
        /// Gets the Dashboard container alternate measured value label 4.
        /// </summary>
        public Element DashboardAlternateMeasuredValueLabel4
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
        /// Gets the Dashboard container alternate measured value main label.
        /// </summary>
        public Element DashboardAlternateMeasuredValueMainLabel
        {
            get
            {
                // TODO: BESSERE NAMEN für die Elemente
                Element element;
                RepoItemInfo elementInfo = this.repository.Dashboard.ContainerMainLabelInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container alternate measured value label 1.
        /// </summary>
        public Element ExtendedDashboardAlternateMeasuredValueLabel1
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.MainValues.ContainerAlternateMeasuredValueLabel1Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container alternate measured value label 2.
        /// </summary>
        public Element ExtendedDashboardAlternateMeasuredValueLabel2
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.MainValues.ContainerAlternateMeasuredValueLabel2Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container alternate measured value label 3.
        /// </summary>
        public Element ExtendedDashboardAlternateMeasuredValueLabel3
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.MainValues.ContainerAlternateMeasuredValueLabel3Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container alternate measured value label 4.
        /// </summary>
        public Element ExtendedDashboardAlternateMeasuredValueLabel4
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.MainValues.ContainerAlternateMeasuredValueLabel4Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container alternate measured value main label.
        /// </summary>
        public Element ExtendedDashboardAlternateMeasuredValueMainLabel
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.MainValues.ContainerMainLabelInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container extended measured value label 1 from the tab extended values.
        /// </summary>
        public Element ExtendedDashboardExtendedMeasuredValueLabel1
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ExtendedValues.ContainerExtendedMeasuredValueLabel1Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container extended measured value label 2 from the tab extended values.
        /// </summary>
        public Element ExtendedDashboardExtendedMeasuredValueLabel2
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ExtendedValues.ContainerExtendedMeasuredValueLabel2Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container extended measured value label 3 from the tab extended values.
        /// </summary>
        public Element ExtendedDashboardExtendedMeasuredValueLabel3
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ExtendedValues.ContainerExtendedMeasuredValueLabel3Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container extended measured value label 4 from the tab extended values.
        /// </summary>
        public Element ExtendedDashboardExtendedMeasuredValueLabel4
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ExtendedValues.ContainerExtendedMeasuredValueLabel4Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container extended measured value label 5 from the tab extended values.
        /// </summary>
        public Element ExtendedDashboardExtendedMeasuredValueLabel5
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ExtendedValues.ContainerExtendedMeasuredValueLabel5Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container extended measured value label 6 from the tab extended values.
        /// </summary>
        public Element ExtendedDashboardExtendedMeasuredValueLabel6
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ExtendedValues.ContainerExtendedMeasuredValueLabel6Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container extended measured value label 7 from the tab extended values.
        /// </summary>
        public Element ExtendedDashboardExtendedMeasuredValueLabel7
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ExtendedValues.ContainerExtendedMeasuredValueLabel7Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the extended Dashboard container extended measured value label 8 from the tab extended values.
        /// </summary>
        public Element ExtendedDashboardExtendedMeasuredValueLabel8
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Extended.ExtendedValues.ContainerExtendedMeasuredValueLabel8Info;
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