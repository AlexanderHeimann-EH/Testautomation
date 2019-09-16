﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Compare.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the SelectionElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("06eab64c-c6cd-4251-b5bd-63e260ef229d")]
    public partial class SelectionElementsRepository : RepoGenBaseFolder
    {
        static SelectionElementsRepository instance = new SelectionElementsRepository();
        RepoItemInfo _buttondataset2Info;
        RepoItemInfo _buttonmodeInfo;
        RepoItemInfo _buttondataset1Info;
        RepoItemInfo _listitemmodeselectionInfo;
        RepoItemInfo _listmodeselectionInfo;
        RepoItemInfo _elementmodeselectionInfo;

        /// <summary>
        /// Gets the singleton class instance representing the SelectionElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("06eab64c-c6cd-4251-b5bd-63e260ef229d")]
        public static SelectionElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public SelectionElementsRepository() 
            : base("SelectionElementsRepository", "/", null, 0, false, "06eab64c-c6cd-4251-b5bd-63e260ef229d", ".\\RepositoryImages\\SelectionElementsRepository06eab64c.rximgres")
        {
            _buttondataset2Info = new RepoItemInfo(this, "buttonDataset2", "/container[@controltypename='DtmUserInterface']/container[@controlname='DatasetComparisonPresentation']/?/?/container[@controlname='_DatasetSelectionGroupControl']/element[@controlname='DatasetComparisonGUI.CompareMainPanelDx.Dataset2ButtonEdit']/button", 30000, null, "781e5cf3-1910-4e84-8cb2-00c77624ff0f");
            _buttonmodeInfo = new RepoItemInfo(this, "buttonMode", "/container[@controltypename='DtmUserInterface']/container[@controlname='DatasetComparisonPresentation']/?/?/container[@controlname='_DatasetSelectionGroupControl']/element[@controlname='DatasetComparisonGUI.CompareMainPanelDx.ModeSelection']/button[@accessiblename='Open']", 30000, null, "d8b0de43-5451-40f3-88b5-4059b72ac666");
            _buttondataset1Info = new RepoItemInfo(this, "buttonDataset1", "/container[@controltypename='DtmUserInterface']/container[@controlname='DatasetComparisonPresentation']/?/?/container[@controlname='_DatasetSelectionGroupControl']/element[@controlname='DatasetComparisonGUI.CompareMainPanelDx.Dataset1ButtonEdit']/button", 30000, null, "9317dbfd-e7e8-43b1-8397-86561f91a49d");
            _listitemmodeselectionInfo = new RepoItemInfo(this, "listItemModeSelection", "/form/element/list/listitem", 30000, null, "bac1f050-6a0b-434d-9e98-f5366665fc07");
            _listmodeselectionInfo = new RepoItemInfo(this, "listModeSelection", "/form/element/list", 30000, null, "2b3a5570-6681-4a80-9682-f7e19cd7149d");
            _elementmodeselectionInfo = new RepoItemInfo(this, "elementModeSelection", "/container[@controltypename='DtmUserInterface']/container[@controlname='DatasetComparisonPresentation']/?/?/container[@controlname='_DatasetSelectionGroupControl']/element[@controlname='DatasetComparisonGUI.CompareMainPanelDx.ModeSelection']", 30000, null, "505f47d5-30bf-49c5-a3de-67b6e47c9f27");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("06eab64c-c6cd-4251-b5bd-63e260ef229d")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The buttonDataset2 item.
        /// </summary>
        [RepositoryItem("781e5cf3-1910-4e84-8cb2-00c77624ff0f")]
        public virtual Ranorex.Button buttonDataset2
        {
            get
            {
                 return _buttondataset2Info.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonDataset2 item info.
        /// </summary>
        [RepositoryItemInfo("781e5cf3-1910-4e84-8cb2-00c77624ff0f")]
        public virtual RepoItemInfo buttonDataset2Info
        {
            get
            {
                return _buttondataset2Info;
            }
        }

        /// <summary>
        /// The buttonMode item.
        /// </summary>
        [RepositoryItem("d8b0de43-5451-40f3-88b5-4059b72ac666")]
        public virtual Ranorex.Button buttonMode
        {
            get
            {
                 return _buttonmodeInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonMode item info.
        /// </summary>
        [RepositoryItemInfo("d8b0de43-5451-40f3-88b5-4059b72ac666")]
        public virtual RepoItemInfo buttonModeInfo
        {
            get
            {
                return _buttonmodeInfo;
            }
        }

        /// <summary>
        /// The buttonDataset1 item.
        /// </summary>
        [RepositoryItem("9317dbfd-e7e8-43b1-8397-86561f91a49d")]
        public virtual Ranorex.Button buttonDataset1
        {
            get
            {
                 return _buttondataset1Info.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonDataset1 item info.
        /// </summary>
        [RepositoryItemInfo("9317dbfd-e7e8-43b1-8397-86561f91a49d")]
        public virtual RepoItemInfo buttonDataset1Info
        {
            get
            {
                return _buttondataset1Info;
            }
        }

        /// <summary>
        /// The listItemModeSelection item.
        /// </summary>
        [RepositoryItem("bac1f050-6a0b-434d-9e98-f5366665fc07")]
        public virtual Ranorex.ListItem listItemModeSelection
        {
            get
            {
                 return _listitemmodeselectionInfo.CreateAdapter<Ranorex.ListItem>(true);
            }
        }

        /// <summary>
        /// The listItemModeSelection item info.
        /// </summary>
        [RepositoryItemInfo("bac1f050-6a0b-434d-9e98-f5366665fc07")]
        public virtual RepoItemInfo listItemModeSelectionInfo
        {
            get
            {
                return _listitemmodeselectionInfo;
            }
        }

        /// <summary>
        /// The listModeSelection item.
        /// </summary>
        [RepositoryItem("2b3a5570-6681-4a80-9682-f7e19cd7149d")]
        public virtual Ranorex.List listModeSelection
        {
            get
            {
                 return _listmodeselectionInfo.CreateAdapter<Ranorex.List>(true);
            }
        }

        /// <summary>
        /// The listModeSelection item info.
        /// </summary>
        [RepositoryItemInfo("2b3a5570-6681-4a80-9682-f7e19cd7149d")]
        public virtual RepoItemInfo listModeSelectionInfo
        {
            get
            {
                return _listmodeselectionInfo;
            }
        }

        /// <summary>
        /// The elementModeSelection item.
        /// </summary>
        [RepositoryItem("505f47d5-30bf-49c5-a3de-67b6e47c9f27")]
        public virtual Ranorex.Unknown elementModeSelection
        {
            get
            {
                 return _elementmodeselectionInfo.CreateAdapter<Ranorex.Unknown>(true);
            }
        }

        /// <summary>
        /// The elementModeSelection item info.
        /// </summary>
        [RepositoryItemInfo("505f47d5-30bf-49c5-a3de-67b6e47c9f27")]
        public virtual RepoItemInfo elementModeSelectionInfo
        {
            get
            {
                return _elementmodeselectionInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class SelectionElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}