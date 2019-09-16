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

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.GUI
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the CDICommDTMRepo element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("f5a87b78-57c1-4fe5-86b0-b7cf9c1b47b2")]
    public partial class CDICommDTMRepo : RepoGenBaseFolder
    {
        static CDICommDTMRepo instance = new CDICommDTMRepo();
        CDICommDTMRepoFolders.ApplicationAreaAppFolder _applicationarea;
        CDICommDTMRepoFolders.ComboboxListAppFolder _comboboxlist;

        /// <summary>
        /// Gets the singleton class instance representing the CDICommDTMRepo element repository.
        /// </summary>
        [RepositoryFolder("f5a87b78-57c1-4fe5-86b0-b7cf9c1b47b2")]
        public static CDICommDTMRepo Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public CDICommDTMRepo() 
            : base("CDICommDTMRepo", "/", null, 0, false, "f5a87b78-57c1-4fe5-86b0-b7cf9c1b47b2", ".\\RepositoryImages\\CDICommDTMRepof5a87b78.rximgres")
        {
            _applicationarea = new CDICommDTMRepoFolders.ApplicationAreaAppFolder(this);
            _comboboxlist = new CDICommDTMRepoFolders.ComboboxListAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("f5a87b78-57c1-4fe5-86b0-b7cf9c1b47b2")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The ApplicationArea folder.
        /// </summary>
        [RepositoryFolder("7c5d13be-24ec-4095-b3e5-0b13bfc2aee2")]
        public virtual CDICommDTMRepoFolders.ApplicationAreaAppFolder ApplicationArea
        {
            get { return _applicationarea; }
        }

        /// <summary>
        /// The ComboboxList folder.
        /// </summary>
        [RepositoryFolder("a826f725-b5fc-4cb3-a1f0-29bb9e3d066b")]
        public virtual CDICommDTMRepoFolders.ComboboxListAppFolder ComboboxList
        {
            get { return _comboboxlist; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class CDICommDTMRepoFolders
    {
        /// <summary>
        /// The ApplicationAreaAppFolder folder.
        /// </summary>
        [RepositoryFolder("7c5d13be-24ec-4095-b3e5-0b13bfc2aee2")]
        public partial class ApplicationAreaAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _ipaddressInfo;
            RepoItemInfo _comboboxfounddevicesInfo;
            RepoItemInfo _buttonfounddevicesInfo;
            RepoItemInfo _portInfo;
            RepoItemInfo _comboboxtimeoutInfo;
            RepoItemInfo _buttontimeoutInfo;
            RepoItemInfo _textInfo;
            RepoItemInfo _comboboxInfo;
            RepoItemInfo _buttonInfo;

            /// <summary>
            /// Creates a new ApplicationArea  folder.
            /// </summary>
            public ApplicationAreaAppFolder(RepoGenBaseFolder parentFolder) :
                    base("ApplicationArea", "/element[@childindex='1']/container[@childindex='1']", parentFolder, 30000, null, true, "7c5d13be-24ec-4095-b3e5-0b13bfc2aee2", "")
            {
                _ipaddressInfo = new RepoItemInfo(this, "IpAddress", "element[@childindex='2']/text", 30000, null, "06a6909c-773a-4444-bb23-9534aac06bb0");
                _comboboxfounddevicesInfo = new RepoItemInfo(this, "ComboboxFoundDevices", "element[@childindex='6']/combobox", 30000, null, "4a6711f8-a764-4038-9269-2e29d8ce6ed6");
                _buttonfounddevicesInfo = new RepoItemInfo(this, "ButtonFoundDevices", "element[@childindex='7']/combobox/button", 30000, null, "8c51eef7-64c4-47e1-aacb-671c0a54696c");
                _portInfo = new RepoItemInfo(this, "Port", "element[@childindex='11']/text", 30000, null, "46699cbb-8a3a-4144-96dc-80036dd761e3");
                _comboboxtimeoutInfo = new RepoItemInfo(this, "ComboboxTimeout", "element[@childindex='15']/combobox", 30000, null, "48d6f770-70f4-47a5-9ba2-1c4e1c7c3786");
                _buttontimeoutInfo = new RepoItemInfo(this, "ButtonTimeout", "element[@childindex='15']/combobox/button", 30000, null, "a80e1769-21e2-41cd-b923-e5dccae8894f");
                _textInfo = new RepoItemInfo(this, "Text", "element/text", 30000, null, "97625c91-4a7e-484e-8513-5b026ce4d0cf");
                _comboboxInfo = new RepoItemInfo(this, "ComboBox", "element/combobox", 30000, null, "90432b66-5196-40db-88e3-5f53f67496a6");
                _buttonInfo = new RepoItemInfo(this, "Button", "element/combobox/button", 30000, null, "dc96a550-229d-4c98-aaa8-0d2920fe5acb");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("7c5d13be-24ec-4095-b3e5-0b13bfc2aee2")]
            public virtual Ranorex.Container Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("7c5d13be-24ec-4095-b3e5-0b13bfc2aee2")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The IpAddress item.
            /// </summary>
            [RepositoryItem("06a6909c-773a-4444-bb23-9534aac06bb0")]
            public virtual Ranorex.Text IpAddress
            {
                get
                {
                    return _ipaddressInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The IpAddress item info.
            /// </summary>
            [RepositoryItemInfo("06a6909c-773a-4444-bb23-9534aac06bb0")]
            public virtual RepoItemInfo IpAddressInfo
            {
                get
                {
                    return _ipaddressInfo;
                }
            }

            /// <summary>
            /// The ComboboxFoundDevices item.
            /// </summary>
            [RepositoryItem("4a6711f8-a764-4038-9269-2e29d8ce6ed6")]
            public virtual Ranorex.ComboBox ComboboxFoundDevices
            {
                get
                {
                    return _comboboxfounddevicesInfo.CreateAdapter<Ranorex.ComboBox>(true);
                }
            }

            /// <summary>
            /// The ComboboxFoundDevices item info.
            /// </summary>
            [RepositoryItemInfo("4a6711f8-a764-4038-9269-2e29d8ce6ed6")]
            public virtual RepoItemInfo ComboboxFoundDevicesInfo
            {
                get
                {
                    return _comboboxfounddevicesInfo;
                }
            }

            /// <summary>
            /// The ButtonFoundDevices item.
            /// </summary>
            [RepositoryItem("8c51eef7-64c4-47e1-aacb-671c0a54696c")]
            public virtual Ranorex.Button ButtonFoundDevices
            {
                get
                {
                    return _buttonfounddevicesInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonFoundDevices item info.
            /// </summary>
            [RepositoryItemInfo("8c51eef7-64c4-47e1-aacb-671c0a54696c")]
            public virtual RepoItemInfo ButtonFoundDevicesInfo
            {
                get
                {
                    return _buttonfounddevicesInfo;
                }
            }

            /// <summary>
            /// The Port item.
            /// </summary>
            [RepositoryItem("46699cbb-8a3a-4144-96dc-80036dd761e3")]
            public virtual Ranorex.Text Port
            {
                get
                {
                    return _portInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Port item info.
            /// </summary>
            [RepositoryItemInfo("46699cbb-8a3a-4144-96dc-80036dd761e3")]
            public virtual RepoItemInfo PortInfo
            {
                get
                {
                    return _portInfo;
                }
            }

            /// <summary>
            /// The ComboboxTimeout item.
            /// </summary>
            [RepositoryItem("48d6f770-70f4-47a5-9ba2-1c4e1c7c3786")]
            public virtual Ranorex.ComboBox ComboboxTimeout
            {
                get
                {
                    return _comboboxtimeoutInfo.CreateAdapter<Ranorex.ComboBox>(true);
                }
            }

            /// <summary>
            /// The ComboboxTimeout item info.
            /// </summary>
            [RepositoryItemInfo("48d6f770-70f4-47a5-9ba2-1c4e1c7c3786")]
            public virtual RepoItemInfo ComboboxTimeoutInfo
            {
                get
                {
                    return _comboboxtimeoutInfo;
                }
            }

            /// <summary>
            /// The ButtonTimeout item.
            /// </summary>
            [RepositoryItem("a80e1769-21e2-41cd-b923-e5dccae8894f")]
            public virtual Ranorex.Button ButtonTimeout
            {
                get
                {
                    return _buttontimeoutInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonTimeout item info.
            /// </summary>
            [RepositoryItemInfo("a80e1769-21e2-41cd-b923-e5dccae8894f")]
            public virtual RepoItemInfo ButtonTimeoutInfo
            {
                get
                {
                    return _buttontimeoutInfo;
                }
            }

            /// <summary>
            /// The Text item.
            /// </summary>
            [RepositoryItem("97625c91-4a7e-484e-8513-5b026ce4d0cf")]
            public virtual Ranorex.Text Text
            {
                get
                {
                    return _textInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Text item info.
            /// </summary>
            [RepositoryItemInfo("97625c91-4a7e-484e-8513-5b026ce4d0cf")]
            public virtual RepoItemInfo TextInfo
            {
                get
                {
                    return _textInfo;
                }
            }

            /// <summary>
            /// The ComboBox item.
            /// </summary>
            [RepositoryItem("90432b66-5196-40db-88e3-5f53f67496a6")]
            public virtual Ranorex.ComboBox ComboBox
            {
                get
                {
                    return _comboboxInfo.CreateAdapter<Ranorex.ComboBox>(true);
                }
            }

            /// <summary>
            /// The ComboBox item info.
            /// </summary>
            [RepositoryItemInfo("90432b66-5196-40db-88e3-5f53f67496a6")]
            public virtual RepoItemInfo ComboBoxInfo
            {
                get
                {
                    return _comboboxInfo;
                }
            }

            /// <summary>
            /// The Button item.
            /// </summary>
            [RepositoryItem("dc96a550-229d-4c98-aaa8-0d2920fe5acb")]
            public virtual Ranorex.Button Button
            {
                get
                {
                    return _buttonInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The Button item info.
            /// </summary>
            [RepositoryItemInfo("dc96a550-229d-4c98-aaa8-0d2920fe5acb")]
            public virtual RepoItemInfo ButtonInfo
            {
                get
                {
                    return _buttonInfo;
                }
            }
        }

        /// <summary>
        /// The ComboboxListAppFolder folder.
        /// </summary>
        [RepositoryFolder("a826f725-b5fc-4cb3-a1f0-29bb9e3d066b")]
        public partial class ComboboxListAppFolder : RepoGenBaseFolder
        {

            /// <summary>
            /// Creates a new ComboboxList  folder.
            /// </summary>
            public ComboboxListAppFolder(RepoGenBaseFolder parentFolder) :
                    base("ComboboxList", "/list[@processname='FMPFrame']", parentFolder, 30000, null, true, "a826f725-b5fc-4cb3-a1f0-29bb9e3d066b", "")
            {
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("a826f725-b5fc-4cb3-a1f0-29bb9e3d066b")]
            public virtual Ranorex.List Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.List>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("a826f725-b5fc-4cb3-a1f0-29bb9e3d066b")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}