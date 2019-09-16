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

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.GUI.StatusArea.Statusbar
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the StatusbarElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("0bfcede5-4dc0-4506-8922-81cb86f7a072")]
    public partial class StatusbarElementsRepository : RepoGenBaseFolder
    {
        static StatusbarElementsRepository instance = new StatusbarElementsRepository();
        RepoItemInfo _txtconnectionstateInfo;
        RepoItemInfo _buttonoperationinprogressInfo;

        /// <summary>
        /// Gets the singleton class instance representing the StatusbarElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("0bfcede5-4dc0-4506-8922-81cb86f7a072")]
        public static StatusbarElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public StatusbarElementsRepository() 
            : base("StatusbarElementsRepository", "/", null, 0, false, "0bfcede5-4dc0-4506-8922-81cb86f7a072", ".\\RepositoryImages\\StatusbarElementsRepository0bfcede5.rximgres")
        {
            _txtconnectionstateInfo = new RepoItemInfo(this, "txtConnectionState", "/container[@automationid='EnvelopeCurveModule.EnvelopeCurveForm.Form']/container[@automationid='EnvelopeCurveModule.StatusBarStub.StatusBar']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/text[@accessiblerole='StaticText' and @childindex='0']", 30000, null, "1cd7cb97-ed5f-4600-a960-536a6801b894");
            _buttonoperationinprogressInfo = new RepoItemInfo(this, "buttonOperationInProgress", "/container[@automationid='EnvelopeCurveModule.EnvelopeCurveForm.Form']/container[@automationid='EnvelopeCurveModule.StatusBarStub.StatusBar']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button", 30000, null, "cd9fc69a-0ca6-4306-812f-d55a4500299d");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("0bfcede5-4dc0-4506-8922-81cb86f7a072")]
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
        [RepositoryItem("1cd7cb97-ed5f-4600-a960-536a6801b894")]
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
        [RepositoryItemInfo("1cd7cb97-ed5f-4600-a960-536a6801b894")]
        public virtual RepoItemInfo txtConnectionStateInfo
        {
            get
            {
                return _txtconnectionstateInfo;
            }
        }

        /// <summary>
        /// The buttonOperationInProgress item.
        /// </summary>
        [RepositoryItem("cd9fc69a-0ca6-4306-812f-d55a4500299d")]
        public virtual Ranorex.Button buttonOperationInProgress
        {
            get
            {
                 return _buttonoperationinprogressInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonOperationInProgress item info.
        /// </summary>
        [RepositoryItemInfo("cd9fc69a-0ca6-4306-812f-d55a4500299d")]
        public virtual RepoItemInfo buttonOperationInProgressInfo
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