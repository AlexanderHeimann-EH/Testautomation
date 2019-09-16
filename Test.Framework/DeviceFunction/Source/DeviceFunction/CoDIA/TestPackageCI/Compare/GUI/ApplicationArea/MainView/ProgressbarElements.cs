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

namespace EH.PCPS.TestAutomation.TestPackageCI.Compare.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ProgressbarElements element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("0895062f-065b-4db5-974c-7553a8d59b41")]
    public partial class ProgressbarElements : RepoGenBaseFolder
    {
        static ProgressbarElements instance = new ProgressbarElements();
        RepoItemInfo _progressbarInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ProgressbarElements element repository.
        /// </summary>
        [RepositoryFolder("0895062f-065b-4db5-974c-7553a8d59b41")]
        public static ProgressbarElements Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ProgressbarElements() 
            : base("ProgressbarElements", "/", null, 0, false, "0895062f-065b-4db5-974c-7553a8d59b41", ".\\RepositoryImages\\ProgressbarElements0895062f.rximgres")
        {
            _progressbarInfo = new RepoItemInfo(this, "ProgressBar", "/container[@controltypename='DtmUserInterface']/container[@controlname='DatasetComparisonPresentation']/container[@controlname='CompareGuiPanel']/container[@controlname='_BottomButtonsGroupControl']/element[@controlname='_ProgressBarControl']/progressbar", 30000, null, "ba064636-f9dd-4958-a41f-60683d59b8ec");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("0895062f-065b-4db5-974c-7553a8d59b41")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The ProgressBar item.
        /// </summary>
        [RepositoryItem("ba064636-f9dd-4958-a41f-60683d59b8ec")]
        public virtual Ranorex.ProgressBar ProgressBar
        {
            get
            {
                 return _progressbarInfo.CreateAdapter<Ranorex.ProgressBar>(true);
            }
        }

        /// <summary>
        /// The ProgressBar item info.
        /// </summary>
        [RepositoryItemInfo("ba064636-f9dd-4958-a41f-60683d59b8ec")]
        public virtual RepoItemInfo ProgressBarInfo
        {
            get
            {
                return _progressbarInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ProgressbarElementsFolders
    {
    }
#pragma warning restore 0436
}