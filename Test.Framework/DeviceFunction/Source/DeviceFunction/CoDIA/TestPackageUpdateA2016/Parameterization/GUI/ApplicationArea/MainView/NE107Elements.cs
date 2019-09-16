// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NE107Elements.cs" company="Endress+Hauser Process Solutions AG">
//   Endress + Hauser Process Solutions AG
// </copyright>
// <summary>
//   The dashboard elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
    using System.Collections.Generic;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// The dashboard elements.
    /// </summary>
    public class NE107Elements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly NE107ElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NE107Elements"/> class.
        /// </summary>
        public NE107Elements()
        {
            this.repository = NE107ElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the apply button
        /// </summary>
        public Element ApplyButton
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ButtonApplyInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the Simulation diagnostic events array list(combo box).
        /// </summary>
        public Element ArrayListSimulationDiagnosticEvents
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Simulation.ArrayListSimulationEventInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the cancel button
        /// </summary>
        public Element CancelButton
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ButtonCancelInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets combo box list items
        /// </summary>
        public IList<ListItem> ListItemsComboBox
        {
            get
            {
                List list = this.repository.Simulation.ListSimulationEvent;
                return list.Items;
            }
        }

        /// <summary>
        /// Gets the tab control of the NE107 embedded module.
        /// </summary>
        public Element TabControlNE107
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.TabControlInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        #endregion
    }
}