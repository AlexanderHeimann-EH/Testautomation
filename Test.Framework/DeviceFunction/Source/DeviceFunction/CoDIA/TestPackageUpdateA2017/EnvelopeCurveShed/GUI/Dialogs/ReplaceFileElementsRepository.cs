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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurveShed.GUI.Dialogs
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ReplaceFileElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("526fdbe6-f20b-4ea2-a8e6-cdabac22cebc")]
    public partial class ReplaceFileElementsRepository : RepoGenBaseFolder
    {
        static ReplaceFileElementsRepository instance = new ReplaceFileElementsRepository();
        RepoItemInfo _buttonyesInfo;
        RepoItemInfo _buttonnoInfo;
        RepoItemInfo _buttoncancelInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ReplaceFileElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("526fdbe6-f20b-4ea2-a8e6-cdabac22cebc")]
        public static ReplaceFileElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ReplaceFileElementsRepository() 
            : base("ReplaceFileElementsRepository", "/", null, 0, false, "526fdbe6-f20b-4ea2-a8e6-cdabac22cebc", ".\\RepositoryImages\\ReplaceFileElementsRepository526fdbe6.rximgres")
        {
            _buttonyesInfo = new RepoItemInfo(this, "buttonYes", "/form/button[@accessiblename='Yes' or @automationid='ButtonYes']", 30000, null, "743fc5aa-66eb-4cff-bc3b-74be42ee385c");
            _buttonnoInfo = new RepoItemInfo(this, "buttonNo", "/form/button[@accessiblename='No' or @automationid='ButtonNo']", 30000, null, "a784d4ef-7f7c-4160-ac6c-95a09fd41664");
            _buttoncancelInfo = new RepoItemInfo(this, "buttonCancel", "/form/button[@accessiblename='Cancel']", 30000, null, "9ede16c1-9b48-4a5b-b3c2-44a8bfbe9932");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("526fdbe6-f20b-4ea2-a8e6-cdabac22cebc")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The buttonYes item.
        /// </summary>
        [RepositoryItem("743fc5aa-66eb-4cff-bc3b-74be42ee385c")]
        public virtual Ranorex.Button buttonYes
        {
            get
            {
                 return _buttonyesInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonYes item info.
        /// </summary>
        [RepositoryItemInfo("743fc5aa-66eb-4cff-bc3b-74be42ee385c")]
        public virtual RepoItemInfo buttonYesInfo
        {
            get
            {
                return _buttonyesInfo;
            }
        }

        /// <summary>
        /// The buttonNo item.
        /// </summary>
        [RepositoryItem("a784d4ef-7f7c-4160-ac6c-95a09fd41664")]
        public virtual Ranorex.Button buttonNo
        {
            get
            {
                 return _buttonnoInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonNo item info.
        /// </summary>
        [RepositoryItemInfo("a784d4ef-7f7c-4160-ac6c-95a09fd41664")]
        public virtual RepoItemInfo buttonNoInfo
        {
            get
            {
                return _buttonnoInfo;
            }
        }

        /// <summary>
        /// The buttonCancel item.
        /// </summary>
        [RepositoryItem("9ede16c1-9b48-4a5b-b3c2-44a8bfbe9932")]
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
        [RepositoryItemInfo("9ede16c1-9b48-4a5b-b3c2-44a8bfbe9932")]
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
    public partial class ReplaceFileElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}