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

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.GUI.Dialogs
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the DiscardCurvesElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("eca6e05f-32a6-49a2-a377-392d00ad7aa3")]
    public partial class DiscardCurvesElementsRepository : RepoGenBaseFolder
    {
        static DiscardCurvesElementsRepository instance = new DiscardCurvesElementsRepository();
        RepoItemInfo _buttonokInfo;
        RepoItemInfo _buttoncancelInfo;

        /// <summary>
        /// Gets the singleton class instance representing the DiscardCurvesElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("eca6e05f-32a6-49a2-a377-392d00ad7aa3")]
        public static DiscardCurvesElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public DiscardCurvesElementsRepository() 
            : base("DiscardCurvesElementsRepository", "/", null, 0, false, "eca6e05f-32a6-49a2-a377-392d00ad7aa3", ".\\RepositoryImages\\DiscardCurvesElementsRepositoryeca6e05f.rximgres")
        {
            _buttonokInfo = new RepoItemInfo(this, "buttonOK", "/form/button[@controlid='202']", 30000, null, "621ca815-a332-4c55-a6c4-974b232255aa");
            _buttoncancelInfo = new RepoItemInfo(this, "buttonCancel", "/form/button[@controlid='203']", 30000, null, "22e207e8-75a4-4672-9da9-75d414dccd99");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("eca6e05f-32a6-49a2-a377-392d00ad7aa3")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The buttonOK item.
        /// </summary>
        [RepositoryItem("621ca815-a332-4c55-a6c4-974b232255aa")]
        public virtual Ranorex.Button buttonOK
        {
            get
            {
                 return _buttonokInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonOK item info.
        /// </summary>
        [RepositoryItemInfo("621ca815-a332-4c55-a6c4-974b232255aa")]
        public virtual RepoItemInfo buttonOKInfo
        {
            get
            {
                return _buttonokInfo;
            }
        }

        /// <summary>
        /// The buttonCancel item.
        /// </summary>
        [RepositoryItem("22e207e8-75a4-4672-9da9-75d414dccd99")]
        public virtual Ranorex.Button buttonCancel
        {
            get
            {
                 return _buttoncancelInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonCancel item info.
        /// </summary>
        [RepositoryItemInfo("22e207e8-75a4-4672-9da9-75d414dccd99")]
        public virtual RepoItemInfo buttonCancelInfo
        {
            get
            {
                return _buttoncancelInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class DiscardCurvesElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}