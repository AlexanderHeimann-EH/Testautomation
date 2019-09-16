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

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.CreateDocumentation.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ActionElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("f3ddc732-4bf6-4bb6-ba7d-c7002176ed04")]
    public partial class ActionElementsRepository : RepoGenBaseFolder
    {
        static ActionElementsRepository instance = new ActionElementsRepository();
        RepoItemInfo _buttoncancelInfo;
        RepoItemInfo _buttonprintInfo;
        RepoItemInfo _buttonsaveasInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ActionElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("f3ddc732-4bf6-4bb6-ba7d-c7002176ed04")]
        public static ActionElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ActionElementsRepository() 
            : base("ActionElementsRepository", "/", null, 0, false, "f3ddc732-4bf6-4bb6-ba7d-c7002176ed04", ".\\RepositoryImages\\ActionElementsRepositoryf3ddc732.rximgres")
        {
            _buttoncancelInfo = new RepoItemInfo(this, "buttonCancel", "/container[@controltypename='DtmUserInterface']/container[@controlname='ModulePresentationArea']/container[@controlname='splitContainerControl1']/container[@controlname='panel2']/?/?/container[@controlname='_actionArea']/?/?/button[@accessiblename='Cancel']", 30000, null, "7da13b35-7825-418c-80af-c1d657730c39");
            _buttonprintInfo = new RepoItemInfo(this, "buttonPrint", "/container[@controltypename='DtmUserInterface']/container[@controlname='ModulePresentationArea']/container[@controlname='splitContainerControl1']/container[@controlname='panel2']/?/?/container[@controlname='_actionArea']/?/?/button[@accessiblename='Print']", 30000, null, "c595e8fa-baa5-4676-b9b1-449dfa290a46");
            _buttonsaveasInfo = new RepoItemInfo(this, "buttonSaveAs", "/container[@controltypename='DtmUserInterface']/container[@controlname='ModulePresentationArea']/container[@controlname='splitContainerControl1']/container[@controlname='panel2']/?/?/container[@controlname='_actionArea']/?/?/button[@accessiblename='Save as ...']", 30000, null, "c03f55b5-2e6a-48f6-89d7-09099d711af8");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("f3ddc732-4bf6-4bb6-ba7d-c7002176ed04")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The buttonCancel item.
        /// </summary>
        [RepositoryItem("7da13b35-7825-418c-80af-c1d657730c39")]
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
        [RepositoryItemInfo("7da13b35-7825-418c-80af-c1d657730c39")]
        public virtual RepoItemInfo buttonCancelInfo
        {
            get
            {
                return _buttoncancelInfo;
            }
        }

        /// <summary>
        /// The buttonPrint item.
        /// </summary>
        [RepositoryItem("c595e8fa-baa5-4676-b9b1-449dfa290a46")]
        public virtual Ranorex.Button buttonPrint
        {
            get
            {
                 return _buttonprintInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonPrint item info.
        /// </summary>
        [RepositoryItemInfo("c595e8fa-baa5-4676-b9b1-449dfa290a46")]
        public virtual RepoItemInfo buttonPrintInfo
        {
            get
            {
                return _buttonprintInfo;
            }
        }

        /// <summary>
        /// The buttonSaveAs item.
        /// </summary>
        [RepositoryItem("c03f55b5-2e6a-48f6-89d7-09099d711af8")]
        public virtual Ranorex.Button buttonSaveAs
        {
            get
            {
                 return _buttonsaveasInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonSaveAs item info.
        /// </summary>
        [RepositoryItemInfo("c03f55b5-2e6a-48f6-89d7-09099d711af8")]
        public virtual RepoItemInfo buttonSaveAsInfo
        {
            get
            {
                return _buttonsaveasInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ActionElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}