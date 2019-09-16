// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FF912Elements.cs" company="Endress+Hauser Process Solutions AG">
//   Endress + Hauser
// </copyright>
// <summary>
//   Provides access to the FF912 Elements
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
    using System.Collections.Generic;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the FF912 Elements
    /// </summary>
    public class FF912Elements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly FF912ElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FF912Elements"/> class.
        /// </summary>
        public FF912Elements()
        {
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
            this.repository = FF912ElementsRepository.Instance;
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
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
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
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr1
        /// </summary>
        public Element ComboBoxBitNr1
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr1Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr10
        /// </summary>
        public Element ComboBoxBitNr10
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr10Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr11
        /// </summary>
        public Element ComboBoxBitNr11
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr11Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr12
        /// </summary>
        public Element ComboBoxBitNr12
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr12Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr13
        /// </summary>
        public Element ComboBoxBitNr13
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr13Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr14
        /// </summary>
        public Element ComboBoxBitNr14
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr14Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr15
        /// </summary>
        public Element ComboBoxBitNr15
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr15Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr2
        /// </summary>
        public Element ComboBoxBitNr2
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr2Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr3
        /// </summary>
        public Element ComboBoxBitNr3
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr3Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr4
        /// </summary>
        public Element ComboBoxBitNr4
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr4Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr5
        /// </summary>
        public Element ComboBoxBitNr5
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr5Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr6
        /// </summary>
        public Element ComboBoxBitNr6
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr6Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr7
        /// </summary>
        public Element ComboBoxBitNr7
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr7Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr8
        /// </summary>
        public Element ComboBoxBitNr8
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr8Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the ComboBoxBitNr9
        /// </summary>
        public Element ComboBoxBitNr9
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.ComboBoxBitNr9Info;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the combo box simulate.
        /// </summary>
        public Element ComboboxSimulate
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.Simulation.ComboBoxSimulationInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the edit field failure priority
        /// </summary>
        public Element ConfigurableAreaFailurePriority
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.EditFieldFailurePriorityInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the edit field function check priority
        /// </summary>
        public Element ConfigurableAreaFunctionCheckPriority
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.EditFieldFunctionCheckPriorityInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the edit field maintenance required priority
        /// </summary>
        public Element ConfigurableAreaMaintenanceRequiredPriority
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.EditFieldMaintenanceRequiredPriorityInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the edit field out of spec priority
        /// </summary>
        public Element ConfigurableAreaOutOfSpecPriority
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.ConfigurableArea.EditFieldOutOfSpecPriorityInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
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
                List list = this.repository.ListComboboxItems;
                return list.Items;
            }
        }

        /// <summary>
        /// Gets the edit field failure priority
        /// </summary>
        public Element StandardAreaFailurePriority
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.StandardArea.EditFieldFailurePriorityInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the edit field function check priority
        /// </summary>
        public Element StandardAreaFunctionCheckPriority
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.StandardArea.EditFieldFunctionCheckPriorityInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the edit field maintenance required priority
        /// </summary>
        public Element StandardAreaMaintenanceRequiredPriority
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.StandardArea.EditFieldMaintenanceRequiredPriorityInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the edit field out of spec priority
        /// </summary>
        public Element StandardAreaOutOfSpecPriority
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.StandardArea.EditFieldOutOfSpecPriorityInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the tab control.
        /// </summary>
        public Element TabControl
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.TabControlInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + elementInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}