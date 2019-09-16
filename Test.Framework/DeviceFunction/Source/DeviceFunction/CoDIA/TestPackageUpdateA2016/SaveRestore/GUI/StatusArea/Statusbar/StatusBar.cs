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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.GUI.StatusArea.Statusbar
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
        StatusBarFolders.StatusbarAppFolder _statusbar;
        RepoItemInfo _txtconnectionstateInfo;

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
            _statusbar = new StatusBarFolders.StatusbarAppFolder(this);
            _txtconnectionstateInfo = new RepoItemInfo(this, "txtConnectionState", "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmStatusBar']//text[@childindex='0']", 30000, null, "9305361f-f968-4995-b661-2a19fd074d08");
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
        /// The txtConnectionState item.
        /// </summary>
        [RepositoryItem("9305361f-f968-4995-b661-2a19fd074d08")]
        public virtual Ranorex.Text txtConnectionState
        {
            get
            {
                 return _txtconnectionstateInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtConnectionState item info.
        /// </summary>
        [RepositoryItemInfo("9305361f-f968-4995-b661-2a19fd074d08")]
        public virtual RepoItemInfo txtConnectionStateInfo
        {
            get
            {
                return _txtconnectionstateInfo;
            }
        }

        /// <summary>
        /// The Statusbar folder.
        /// </summary>
        [RepositoryFolder("75acf141-52de-422f-aa94-e3247436d94e")]
        public virtual StatusBarFolders.StatusbarAppFolder Statusbar
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
        /// The StatusbarAppFolder folder.
        /// </summary>
        [RepositoryFolder("75acf141-52de-422f-aa94-e3247436d94e")]
        public partial class StatusbarAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _buttoninprogressInfo;

            /// <summary>
            /// Creates a new Statusbar  folder.
            /// </summary>
            public StatusbarAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Statusbar", "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmStatusBar']/element/element/statusbar[@accessiblename='Bar']", parentFolder, 30000, null, true, "75acf141-52de-422f-aa94-e3247436d94e", "")
            {
                _buttoninprogressInfo = new RepoItemInfo(this, "buttonInProgress", "button", 30000, null, "6be4ac45-ee16-4705-83af-f435924af466");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("75acf141-52de-422f-aa94-e3247436d94e")]
            public virtual Ranorex.StatusBar Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.StatusBar>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("75acf141-52de-422f-aa94-e3247436d94e")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The buttonInProgress item.
            /// </summary>
            [RepositoryItem("6be4ac45-ee16-4705-83af-f435924af466")]
            public virtual Ranorex.Button buttonInProgress
            {
                get
                {
                    return _buttoninprogressInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonInProgress item info.
            /// </summary>
            [RepositoryItemInfo("6be4ac45-ee16-4705-83af-f435924af466")]
            public virtual RepoItemInfo buttonInProgressInfo
            {
                get
                {
                    return _buttoninprogressInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}