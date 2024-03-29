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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.CreateDocumentation.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ModuleContainerRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("3a79cfb7-757b-46ee-91b3-e1241f2aef88")]
    public partial class ModuleContainerRepository : RepoGenBaseFolder
    {
        static ModuleContainerRepository instance = new ModuleContainerRepository();
        RepoItemInfo _createdocumentationmodulecontainerInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ModuleContainerRepository element repository.
        /// </summary>
        [RepositoryFolder("3a79cfb7-757b-46ee-91b3-e1241f2aef88")]
        public static ModuleContainerRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ModuleContainerRepository() 
            : base("ModuleContainerRepository", "/", null, 0, false, "3a79cfb7-757b-46ee-91b3-e1241f2aef88", ".\\RepositoryImages\\ModuleContainerRepository3a79cfb7.rximgres")
        {
            _createdocumentationmodulecontainerInfo = new RepoItemInfo(this, "CreateDocumentationModuleContainer", "/container[@controltypename='DtmUserInterface']/container[@controlname='ModulePresentationArea']", 2000, null, "ed2a9c0d-99c3-4729-b652-14554fb61ea8");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("3a79cfb7-757b-46ee-91b3-e1241f2aef88")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The CreateDocumentationModuleContainer item.
        /// </summary>
        [RepositoryItem("ed2a9c0d-99c3-4729-b652-14554fb61ea8")]
        public virtual Ranorex.Container CreateDocumentationModuleContainer
        {
            get
            {
                 return _createdocumentationmodulecontainerInfo.CreateAdapter<Ranorex.Container>(true);
            }
        }

        /// <summary>
        /// The CreateDocumentationModuleContainer item info.
        /// </summary>
        [RepositoryItemInfo("ed2a9c0d-99c3-4729-b652-14554fb61ea8")]
        public virtual RepoItemInfo CreateDocumentationModuleContainerInfo
        {
            get
            {
                return _createdocumentationmodulecontainerInfo;
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