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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ModuleContainerRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("028bc93a-f3bd-4692-9311-5829bbdee554")]
    public partial class ModuleContainerRepository : RepoGenBaseFolder
    {
        static ModuleContainerRepository instance = new ModuleContainerRepository();
        RepoItemInfo _onlineparameterizationmodulecontainerInfo;
        RepoItemInfo _offlineparameterizationmodulecontainerInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ModuleContainerRepository element repository.
        /// </summary>
        [RepositoryFolder("028bc93a-f3bd-4692-9311-5829bbdee554")]
        public static ModuleContainerRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ModuleContainerRepository() 
            : base("ModuleContainerRepository", "/", null, 0, false, "028bc93a-f3bd-4692-9311-5829bbdee554", ".\\RepositoryImages\\ModuleContainerRepository028bc93a.rximgres")
        {
            _onlineparameterizationmodulecontainerInfo = new RepoItemInfo(this, "OnlineParameterizationModuleContainer", "/container[@controltypename='DtmUserInterface']", 2000, null, "ddae3bee-5ab0-453b-a8c7-123552164469");
            _offlineparameterizationmodulecontainerInfo = new RepoItemInfo(this, "OfflineParameterizationModuleContainer", "/container[@controltypename='DtmUserInterface']", 2000, null, "4c717084-dbc0-4ac3-ae71-624566375c89");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("028bc93a-f3bd-4692-9311-5829bbdee554")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The OnlineParameterizationModuleContainer item.
        /// </summary>
        [RepositoryItem("ddae3bee-5ab0-453b-a8c7-123552164469")]
        public virtual Ranorex.Container OnlineParameterizationModuleContainer
        {
            get
            {
                 return _onlineparameterizationmodulecontainerInfo.CreateAdapter<Ranorex.Container>(true);
            }
        }

        /// <summary>
        /// The OnlineParameterizationModuleContainer item info.
        /// </summary>
        [RepositoryItemInfo("ddae3bee-5ab0-453b-a8c7-123552164469")]
        public virtual RepoItemInfo OnlineParameterizationModuleContainerInfo
        {
            get
            {
                return _onlineparameterizationmodulecontainerInfo;
            }
        }

        /// <summary>
        /// The OfflineParameterizationModuleContainer item.
        /// </summary>
        [RepositoryItem("4c717084-dbc0-4ac3-ae71-624566375c89")]
        public virtual Ranorex.Container OfflineParameterizationModuleContainer
        {
            get
            {
                 return _offlineparameterizationmodulecontainerInfo.CreateAdapter<Ranorex.Container>(true);
            }
        }

        /// <summary>
        /// The OfflineParameterizationModuleContainer item info.
        /// </summary>
        [RepositoryItemInfo("4c717084-dbc0-4ac3-ae71-624566375c89")]
        public virtual RepoItemInfo OfflineParameterizationModuleContainerInfo
        {
            get
            {
                return _offlineparameterizationmodulecontainerInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ModuleContainerRepositoryFolders
    {
    }
#pragma warning restore 0436
}