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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.MenuArea.Toolbar
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ToolbarElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("3dd203e9-79b8-4426-a6ea-3c825669a0a6")]
    public partial class ToolbarElementsRepository : RepoGenBaseFolder
    {
        static ToolbarElementsRepository instance = new ToolbarElementsRepository();
        RepoItemInfo _buttonhomeInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ToolbarElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("3dd203e9-79b8-4426-a6ea-3c825669a0a6")]
        public static ToolbarElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ToolbarElementsRepository() 
            : base("ToolbarElementsRepository", "/", null, 0, false, "3dd203e9-79b8-4426-a6ea-3c825669a0a6", ".\\RepositoryImages\\ToolbarElementsRepository3dd203e9.rximgres")
        {
            _buttonhomeInfo = new RepoItemInfo(this, "ButtonHome", "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmToolBar']//toolbar[@accessiblename='Bar']/button[@accessiblename='Go to home location.']", 30000, null, "04f4d013-53b0-4539-9647-86292fc9c2d7");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("3dd203e9-79b8-4426-a6ea-3c825669a0a6")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The ButtonHome item.
        /// </summary>
        [RepositoryItem("04f4d013-53b0-4539-9647-86292fc9c2d7")]
        public virtual Ranorex.Button ButtonHome
        {
            get
            {
                 return _buttonhomeInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ButtonHome item info.
        /// </summary>
        [RepositoryItemInfo("04f4d013-53b0-4539-9647-86292fc9c2d7")]
        public virtual RepoItemInfo ButtonHomeInfo
        {
            get
            {
                return _buttonhomeInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ToolbarElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}