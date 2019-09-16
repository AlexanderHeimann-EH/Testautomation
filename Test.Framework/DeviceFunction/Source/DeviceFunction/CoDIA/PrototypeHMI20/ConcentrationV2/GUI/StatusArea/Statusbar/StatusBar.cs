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

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.StatusArea.Statusbar
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the StatusBar element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("3a13262f-f09a-4aed-aab1-0ca7e454ffcc")]
    public partial class StatusBar : RepoGenBaseFolder
    {
        static StatusBar instance = new StatusBar();
        StatusBarFolders.StatusbarFolder _statusbar;

        /// <summary>
        /// Gets the singleton class instance representing the StatusBar element repository.
        /// </summary>
        [RepositoryFolder("3a13262f-f09a-4aed-aab1-0ca7e454ffcc")]
        public static StatusBar Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public StatusBar() 
            : base("StatusBar", "/", null, 0, false, "3a13262f-f09a-4aed-aab1-0ca7e454ffcc", ".\\RepositoryImages\\StatusBar3a13262f.rximgres")
        {
            _statusbar = new StatusBarFolders.StatusbarFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("3a13262f-f09a-4aed-aab1-0ca7e454ffcc")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The Statusbar folder.
        /// </summary>
        [RepositoryFolder("dfe6eec6-b84d-4d38-8eda-990de2538fce")]
        public virtual StatusBarFolders.StatusbarFolder Statusbar
        {
            get { return _statusbar; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class StatusBarFolders
    {
        /// <summary>
        /// The StatusbarFolder folder.
        /// </summary>
        [RepositoryFolder("dfe6eec6-b84d-4d38-8eda-990de2538fce")]
        public partial class StatusbarFolder : RepoGenBaseFolder
        {
            RepoItemInfo _connectionstateInfo;

            /// <summary>
            /// Creates a new Statusbar  folder.
            /// </summary>
            public StatusbarFolder(RepoGenBaseFolder parentFolder) :
                    base("Statusbar", "", parentFolder, 0, null, false, "dfe6eec6-b84d-4d38-8eda-990de2538fce", "")
            {
                _connectionstateInfo = new RepoItemInfo(this, "ConnectionState", "/container[@automationid='ConcentrationModule.Form.Concentration']/element[@automationid='ConcentrationModule.StatusBarControl.StatusBar']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/text[@accessiblename='Statusbar.Item.ConnectionState']", 30000, null, "358affff-ac90-4c3a-92bc-1affee281583");
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("dfe6eec6-b84d-4d38-8eda-990de2538fce")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The ConnectionState item.
            /// </summary>
            [RepositoryItem("358affff-ac90-4c3a-92bc-1affee281583")]
            public virtual Ranorex.Text ConnectionState
            {
                get
                {
                    return _connectionstateInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The ConnectionState item info.
            /// </summary>
            [RepositoryItemInfo("358affff-ac90-4c3a-92bc-1affee281583")]
            public virtual RepoItemInfo ConnectionStateInfo
            {
                get
                {
                    return _connectionstateInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}