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

namespace EH.PCPS.TestAutomation.FieldCare.V21000.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the DtmViewPaths element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("b87112a2-0a48-486f-9bec-5e6d3574bcc4")]
    public partial class DtmViewPaths : RepoGenBaseFolder
    {
        static DtmViewPaths instance = new DtmViewPaths();
        DtmViewPathsFolders.DTMViewPathsFolder _dtmviewpaths;

        /// <summary>
        /// Gets the singleton class instance representing the DtmViewPaths element repository.
        /// </summary>
        [RepositoryFolder("b87112a2-0a48-486f-9bec-5e6d3574bcc4")]
        public static DtmViewPaths Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public DtmViewPaths() 
            : base("DtmViewPaths", "/", null, 0, false, "b87112a2-0a48-486f-9bec-5e6d3574bcc4", ".\\RepositoryImages\\DtmViewPathsb87112a2.rximgres")
        {
            _dtmviewpaths = new DtmViewPathsFolders.DTMViewPathsFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("b87112a2-0a48-486f-9bec-5e6d3574bcc4")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The DTMViewPaths folder.
        /// </summary>
        [RepositoryFolder("7ea2f6be-e0f2-4e89-8413-ca33e28902e9")]
        public virtual DtmViewPathsFolders.DTMViewPathsFolder DTMViewPaths
        {
            get { return _dtmviewpaths; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class DtmViewPathsFolders
    {
        /// <summary>
        /// The DTMViewPathsFolder folder.
        /// </summary>
        [RepositoryFolder("7ea2f6be-e0f2-4e89-8413-ca33e28902e9")]
        public partial class DTMViewPathsFolder : RepoGenBaseFolder
        {
            RepoItemInfo _mdiclientInfo;
            RepoItemInfo _mdiclientchildformsInfo;

            /// <summary>
            /// Creates a new DTMViewPaths  folder.
            /// </summary>
            public DTMViewPathsFolder(RepoGenBaseFolder parentFolder) :
                    base("DTMViewPaths", "", parentFolder, 0, null, false, "7ea2f6be-e0f2-4e89-8413-ca33e28902e9", "")
            {
                _mdiclientInfo = new RepoItemInfo(this, "MDIClient", "/form[@processname='FMPFrame']/element[@controltypename='MdiClient']", 30000, null, "b939a2e7-7d0d-4c18-b59c-86c1f240f126");
                _mdiclientchildformsInfo = new RepoItemInfo(this, "MDIClientChildForms", "/form[@processname='FMPFrame']/element[@controltypename='MdiClient']/form", 30000, null, "698a586c-5de1-43bf-8621-2e0fbe0c08e7");
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("7ea2f6be-e0f2-4e89-8413-ca33e28902e9")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The MDIClient item.
            /// </summary>
            [RepositoryItem("b939a2e7-7d0d-4c18-b59c-86c1f240f126")]
            public virtual Ranorex.Unknown MDIClient
            {
                get
                {
                    return _mdiclientInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The MDIClient item info.
            /// </summary>
            [RepositoryItemInfo("b939a2e7-7d0d-4c18-b59c-86c1f240f126")]
            public virtual RepoItemInfo MDIClientInfo
            {
                get
                {
                    return _mdiclientInfo;
                }
            }

            /// <summary>
            /// The MDIClientChildForms item.
            /// </summary>
            [RepositoryItem("698a586c-5de1-43bf-8621-2e0fbe0c08e7")]
            public virtual Ranorex.Form MDIClientChildForms
            {
                get
                {
                    return _mdiclientchildformsInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The MDIClientChildForms item info.
            /// </summary>
            [RepositoryItemInfo("698a586c-5de1-43bf-8621-2e0fbe0c08e7")]
            public virtual RepoItemInfo MDIClientChildFormsInfo
            {
                get
                {
                    return _mdiclientchildformsInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}