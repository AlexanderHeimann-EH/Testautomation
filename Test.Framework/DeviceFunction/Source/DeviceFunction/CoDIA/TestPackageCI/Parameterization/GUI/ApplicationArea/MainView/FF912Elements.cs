// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FF912Elements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides access to the FF912 Elements
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the FF912 Elements
    /// </summary>
// ReSharper disable InconsistentNaming
    public class FF912Elements
// ReSharper restore InconsistentNaming
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
        public Button ApplyButton
        {
            get
            {
                Button button;
                RepoItemInfo buttonInfo = this.repository.ButtonApplyInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + buttonInfo.AbsolutePath, DefaultValues.GeneralTimeout, out button);
                return button;
            }
        }

        /// <summary>
        /// Gets the cancel button
        /// </summary>
        public Button CancelButton
        {
            get
            {
                Button button;
                RepoItemInfo buttonInfo = this.repository.ButtonCancelInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + "/" + buttonInfo.AbsolutePath, DefaultValues.GeneralTimeout, out button);
                return button;
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

        /// <summary>
        /// The standard area check box.
        /// </summary>
        /// <param name="pathToEventCheckBox">
        /// The path To Event Check Box.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public CheckBox StandardAreaCheckBox(string pathToEventCheckBox)
        {
            CheckBox checkBox;
            RepoItemInfo checkBoxInfo = this.repository.StandardArea.CheckBoxInfo;
            string modifiedPathToEventCheckBox = pathToEventCheckBox.Replace("//", ".");
            RxPath modifiedPath = new RxPath(checkBoxInfo.AbsolutePath.ToString().Replace("REPLACETHIS", modifiedPathToEventCheckBox));
            Host.Local.TryFindSingle(this.mdiClientPath + "/" + modifiedPath, out checkBox);
            return checkBox;
        }

        /// <summary>
        /// The simulation area check box event name.
        /// </summary>
        /// <param name="pathToEventCheckBox">
        /// The path to event check box.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public CheckBox SimulationAreaCheckBoxEventName(string pathToEventCheckBox)
        {
            CheckBox checkBox;
            RepoItemInfo checkBoxInfo = this.repository.Simulation.CheckBoxEventNameInfo;
            string modifiedPathToEventCheckBox = pathToEventCheckBox.Replace("//", ".");
            RxPath modifiedPath = new RxPath(checkBoxInfo.AbsolutePath.ToString().Replace("REPLACETHIS", modifiedPathToEventCheckBox));
            Host.Local.TryFindSingle(this.mdiClientPath + "/" + modifiedPath, out checkBox);
            return checkBox;
        }

        /// <summary>
        /// The simulation area check box bit number.
        /// </summary>
        /// <param name="pathToEventCheckBox">
        /// The path to event check box.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public CheckBox SimulationAreaCheckBoxBitNumber(string pathToEventCheckBox)
        {
            CheckBox checkBox;
            RepoItemInfo checkBoxInfo = this.repository.Simulation.CheckBoxBitNumberInfo;
            string[] seperator = { "//" };
            string[] pathParts = pathToEventCheckBox.Split(seperator, StringSplitOptions.None);
            string bitNumber = pathParts[0];
            string modifiedPathToEventCheckBox = pathParts[1];
            string buffer = checkBoxInfo.AbsolutePath.ToString().Replace("BIT#", bitNumber);
            buffer = buffer.Replace("REPLACETHIS", modifiedPathToEventCheckBox);
            RxPath modifiedPath = new RxPath(buffer);
            Host.Local.TryFindSingle(this.mdiClientPath + "/" + modifiedPath, out checkBox);
            return checkBox;
        }

        /// <summary>
        /// The configurable area check box.
        /// </summary>
        /// <param name="pathToEventCheckBox">
        /// The path To Event Check Box.
        /// </param>
        /// <returns>
        /// The <see cref="CheckBox"/>.
        /// </returns>
        public CheckBox ConfigurableAreaCheckBox(string pathToEventCheckBox)
        {
            CheckBox checkBox;
            RepoItemInfo checkBoxInfo = this.repository.ConfigurableArea.CheckBoxInfo;
            string[] seperator = { "//" };
            string[] pathParts = pathToEventCheckBox.Split(seperator, StringSplitOptions.None);
            string bitNumber = pathParts[0];
            string modifiedPathToEventCheckBox = pathParts[1] + "." + pathParts[2];
            string buffer = checkBoxInfo.AbsolutePath.ToString().Replace("BIT#", bitNumber);
            buffer = buffer.Replace("REPLACETHIS", modifiedPathToEventCheckBox);
            RxPath modifiedPath = new RxPath(buffer);
            Host.Local.TryFindSingle(this.mdiClientPath + "/" + modifiedPath, out checkBox);
            return checkBox;
        }

        /// <summary>
        /// The configurable area combo box.
        /// </summary>
        /// <param name="bitNumber">
        /// The bit number.
        /// </param>
        /// <returns>
        /// The <see cref="Element"/>.
        /// </returns>
        public Element ConfigurableAreaComboBox(string bitNumber)
        {
            Element element;
            RepoItemInfo comboBoxInfo = this.repository.ConfigurableArea.ComboBoxInfo;
            string buffer = comboBoxInfo.AbsolutePath.ToString().Replace("BIT#", bitNumber);
            RxPath modifiedPath = new RxPath(buffer);
            Host.Local.TryFindSingle(this.mdiClientPath + "/" + modifiedPath, out element);
            return element;
        }

        /// <summary>
        /// The status 1 area check box.
        /// </summary>
        /// <param name="pathToEventCheckBox">
        /// The path To Event Check Box.
        /// </param>
        /// <returns>
        /// The <see cref="Element"/>.
        /// </returns>
        public CheckBox Status1AreaCheckBox(string pathToEventCheckBox)
        {
            CheckBox checkBox;
            RepoItemInfo checkBoxInfo = this.repository.Status1Area.CheckBoxInfo;
            string modifiedPathToEventCheckBox = pathToEventCheckBox.Replace("//", ".");
            RxPath modifiedPath = new RxPath(checkBoxInfo.AbsolutePath.ToString().Replace("REPLACETHIS", modifiedPathToEventCheckBox));
            Host.Local.TryFindSingle(this.mdiClientPath + "/" + modifiedPath, out checkBox);
            return checkBox;
        }

        /// <summary>
        /// The status 2 area check box.
        /// </summary>
        /// <param name="pathToEventCheckBox">
        /// The path To Event Check Box.
        /// </param>
        /// <returns>
        /// The <see cref="Element"/>.
        /// </returns>
        public CheckBox Status2AreaCheckBox(string pathToEventCheckBox)
        {
            CheckBox checkBox;
            RepoItemInfo checkBoxInfo = this.repository.Status2Area.CheckBoxInfo;
            string[] seperator = { "//" };
            string[] pathParts = pathToEventCheckBox.Split(seperator, StringSplitOptions.None);
            string bitNumber = pathParts[0];
            string modifiedPathToEventCheckBox = pathParts[1];
            string buffer = checkBoxInfo.AbsolutePath.ToString().Replace("BIT#", bitNumber);
            buffer = buffer.Replace("REPLACETHIS", modifiedPathToEventCheckBox);
            RxPath modifiedPath = new RxPath(buffer);
            Host.Local.TryFindSingle(this.mdiClientPath + "/" + modifiedPath, out checkBox);
            return checkBox;
        }

        #endregion
    }
}