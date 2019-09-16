// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The main view elements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.GUI.ApplicationArea.MainView
{
    using System.Collections.Generic;

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
        /// Initializes a new instance of the <see cref="MainViewElements"/> class.
        /// </summary>
        public MainViewElements()
        {
            this.repository = MainViewElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets combo box list items
        /// </summary>
        public IList<ListItem> ListItemsComboBox
        {
            get
            {
                List list = this.repository.comboBoxList;
                if (list != null && list.Items.Count > 0)
                {
                    return list.Items;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the read button
        /// </summary>
        public Element ReadButton
        {
            get
            {
                Element element;
                RepoItemInfo readButtonInfo = this.repository.Table.ButtonReadInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + readButtonInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the tab control for diagram and tank
        /// </summary>
        public Element TabControl
        {
            get
            {
                Element element;
                RepoItemInfo tabControlInfo = this.repository.TabControl.TabControlForDiagramAndTankInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + tabControlInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the write button
        /// </summary>
        public Element WriteButton
        {
            get
            {
                Element element;
                RepoItemInfo writeButtonInfo = this.repository.Table.ButtonWriteInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + writeButtonInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}