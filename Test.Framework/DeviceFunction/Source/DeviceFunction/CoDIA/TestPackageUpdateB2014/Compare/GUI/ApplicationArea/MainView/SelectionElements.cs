// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectionElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Compare.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to controls at action area at module Compare
    /// </summary>
    public class SelectionElements
    {
        #region Fields

        /// <summary>
        ///  MDI client path
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// Repository which will be used
        /// </summary>
        private readonly SelectionElementsRepository selectionRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionElements"/> class.
        /// </summary>
        public SelectionElements()
        {
            this.selectionRepository = SelectionElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets button for Dataset1 selection
        /// </summary>
        public Button ButtonDataset1
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnDataset1Info = this.selectionRepository.buttonDataset1Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + btnDataset1Info.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets button for Dataset2 selection
        /// </summary>
        public Button ButtonDataset2
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnDataset2Info = this.selectionRepository.buttonDataset2Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + btnDataset2Info.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets button for mode selection
        /// </summary>
        public Button ButtonMode
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnModeInfo = this.selectionRepository.buttonModeInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + btnModeInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets mode selection field
        /// </summary>
        public Element ElementModeSelection
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.selectionRepository.elementModeSelectionInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets list items for mode selection
        /// </summary>
        public IList<ListItem> ListItemsMode
        {
            get
            {
                try
                {
                    IList<ListItem> listItems = this.selectionRepository.listModeSelection.Items;
                    return listItems;
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