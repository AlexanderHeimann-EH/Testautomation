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

namespace EH.PCPS.TestAutomation.TestPackageCI.Linearization.GUI.StatusArea.Statusbar
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the StatusbarElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("b3965ad5-3b8b-4787-9762-a5fd045d0247")]
    public partial class StatusbarElementsRepository : RepoGenBaseFolder
    {
        static StatusbarElementsRepository instance = new StatusbarElementsRepository();
        RepoItemInfo _statusbaritemconnectionstateInfo;
        RepoItemInfo _buttonoperationinprogressInfo;

        /// <summary>
        /// Gets the singleton class instance representing the StatusbarElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("b3965ad5-3b8b-4787-9762-a5fd045d0247")]
        public static StatusbarElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public StatusbarElementsRepository() 
            : base("StatusbarElementsRepository", "/", null, 0, false, "b3965ad5-3b8b-4787-9762-a5fd045d0247", ".\\RepositoryImages\\StatusbarElementsRepositoryb3965ad5.rximgres")
        {
            _statusbaritemconnectionstateInfo = new RepoItemInfo(this, "StatusbarItemConnectionState", "/container[@automationid='LinearizationModule.LinearizationForm.DtmFormBase']/element[@automationid='LinearizationModule.StatusBarControl.StatusBar']/element[@controlname='barDockControlTop']/element[@controltypename='DockedBarControl']/toolbar[@accessiblename='Bar']/text[@accessiblename='Statusbar.Item.ConnectionState']", 30000, null, "e6e63e6e-04e4-48b0-b77b-64e3e6185ec9");
            _buttonoperationinprogressInfo = new RepoItemInfo(this, "ButtonOperationInProgress", "/container[@automationid='LinearizationModule.LinearizationForm.DtmFormBase']/element[@automationid='LinearizationModule.StatusBarControl.StatusBar']/element[@controlname='barDockControlTop']/element[@controltypename='DockedBarControl']/toolbar[@accessiblename='Bar']/button[@accessiblename='Statusbar.Item.OperationProgress']", 30000, null, "bbb629c5-ef3e-4de6-8095-4a21d937b347");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("b3965ad5-3b8b-4787-9762-a5fd045d0247")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The StatusbarItemConnectionState item.
        /// </summary>
        [RepositoryItem("e6e63e6e-04e4-48b0-b77b-64e3e6185ec9")]
        public virtual Ranorex.Text StatusbarItemConnectionState
        {
            get
            {
                 return _statusbaritemconnectionstateInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The StatusbarItemConnectionState item info.
        /// </summary>
        [RepositoryItemInfo("e6e63e6e-04e4-48b0-b77b-64e3e6185ec9")]
        public virtual RepoItemInfo StatusbarItemConnectionStateInfo
        {
            get
            {
                return _statusbaritemconnectionstateInfo;
            }
        }

        /// <summary>
        /// The ButtonOperationInProgress item.
        /// </summary>
        [RepositoryItem("bbb629c5-ef3e-4de6-8095-4a21d937b347")]
        public virtual Ranorex.Button ButtonOperationInProgress
        {
            get
            {
                 return _buttonoperationinprogressInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ButtonOperationInProgress item info.
        /// </summary>
        [RepositoryItemInfo("bbb629c5-ef3e-4de6-8095-4a21d937b347")]
        public virtual RepoItemInfo ButtonOperationInProgressInfo
        {
            get
            {
                return _buttonoperationinprogressInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class StatusbarElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}