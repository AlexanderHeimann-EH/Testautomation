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
    /// The class representing the SaveFileElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("00264644-77b8-4b7b-a407-18383efe68fa")]
    public partial class SaveFileElementsRepository : RepoGenBaseFolder
    {
        static SaveFileElementsRepository instance = new SaveFileElementsRepository();
        RepoItemInfo _buttonnoInfo;
        RepoItemInfo _buttonyesInfo;

        /// <summary>
        /// Gets the singleton class instance representing the SaveFileElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("00264644-77b8-4b7b-a407-18383efe68fa")]
        public static SaveFileElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public SaveFileElementsRepository() 
            : base("SaveFileElementsRepository", "/", null, 0, false, "00264644-77b8-4b7b-a407-18383efe68fa", ".\\RepositoryImages\\SaveFileElementsRepository00264644.rximgres")
        {
            _buttonnoInfo = new RepoItemInfo(this, "buttonNo", "/form/button[@accessiblename='No' or @automationid='ButtonNo']", 30000, null, "4b498841-fa62-46e6-9c7a-8e8391653b68");
            _buttonyesInfo = new RepoItemInfo(this, "buttonYes", "/form/button[@accessiblename='Yes' or @automationid='ButtonYes']", 30000, null, "8d271a85-0940-4504-b106-ad29c2e756ee");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("00264644-77b8-4b7b-a407-18383efe68fa")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The buttonNo item.
        /// </summary>
        [RepositoryItem("4b498841-fa62-46e6-9c7a-8e8391653b68")]
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
        [RepositoryItemInfo("4b498841-fa62-46e6-9c7a-8e8391653b68")]
        public virtual RepoItemInfo buttonNoInfo
        {
            get
            {
                return _buttonnoInfo;
            }
        }

        /// <summary>
        /// The buttonYes item.
        /// </summary>
        [RepositoryItem("8d271a85-0940-4504-b106-ad29c2e756ee")]
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
        [RepositoryItemInfo("8d271a85-0940-4504-b106-ad29c2e756ee")]
        public virtual RepoItemInfo buttonYesInfo
        {
            get
            {
                return _buttonyesInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class SaveFileElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}