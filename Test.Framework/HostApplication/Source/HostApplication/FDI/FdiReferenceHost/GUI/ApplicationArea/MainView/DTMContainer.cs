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

namespace EH.PCPS.TestAutomation.FdiReferenceHost.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the DtmContainer element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("8ef118e6-8b88-42b7-8080-2f46179bb0cb")]
    public partial class DtmContainer : RepoGenBaseFolder
    {
        static DtmContainer instance = new DtmContainer();
        RepoItemInfo _dtmcontainerInfo;

        /// <summary>
        /// Gets the singleton class instance representing the DtmContainer element repository.
        /// </summary>
        [RepositoryFolder("8ef118e6-8b88-42b7-8080-2f46179bb0cb")]
        public static DtmContainer Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public DtmContainer() 
            : base("DtmContainer", "/", null, 0, false, "8ef118e6-8b88-42b7-8080-2f46179bb0cb", ".\\RepositoryImages\\DTMContainer8ef118e6.rximgres")
        {
            _dtmcontainerInfo = new RepoItemInfo(this, "DTMContainer", "/form[@processname='Fdi.Reference.Client' and @windowtext='']/?/container[@automationid='TransparentProxyHost']/?", 30000, null, "5d2797fb-6f66-4173-91b1-6d12f7fe12a6");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("8ef118e6-8b88-42b7-8080-2f46179bb0cb")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The DTMContainer item.
        /// </summary>
        [RepositoryItem("5d2797fb-6f66-4173-91b1-6d12f7fe12a6")]
        public virtual Ranorex.Unknown DTMContainer
        {
            get
            {
                 return _dtmcontainerInfo.CreateAdapter<Ranorex.Unknown>(true);
            }
        }

        /// <summary>
        /// The DTMContainer item info.
        /// </summary>
        [RepositoryItemInfo("5d2797fb-6f66-4173-91b1-6d12f7fe12a6")]
        public virtual RepoItemInfo DTMContainerInfo
        {
            get
            {
                return _dtmcontainerInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class DtmContainerFolders
    {
    }
#pragma warning restore 0436
}