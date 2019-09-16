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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.GUI.MenuArea.Toolbar
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ToolbarElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("c7d55f01-cf90-4d50-88f2-55da3174f987")]
    public partial class ToolbarElementsRepository : RepoGenBaseFolder
    {
        static ToolbarElementsRepository instance = new ToolbarElementsRepository();
        RepoItemInfo _toolbariconloadInfo;
        RepoItemInfo _toolbariconnewInfo;
        RepoItemInfo _toolbariconsaveInfo;
        RepoItemInfo _toolbariconsaveasInfo;
        RepoItemInfo _toolbariconimportInfo;
        RepoItemInfo _toolbariconexportInfo;
        RepoItemInfo _toolbariconcalculateInfo;
        RepoItemInfo _toolbariconwriteInfo;
        RepoItemInfo _toolbariconhelpInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ToolbarElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("c7d55f01-cf90-4d50-88f2-55da3174f987")]
        public static ToolbarElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ToolbarElementsRepository() 
            : base("ToolbarElementsRepository", "/", null, 0, false, "c7d55f01-cf90-4d50-88f2-55da3174f987", ".\\RepositoryImages\\ToolbarElementsRepositoryc7d55f01.rximgres")
        {
            _toolbariconloadInfo = new RepoItemInfo(this, "ToolbarIconLoad", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Load']", 30000, null, "61045900-6b8f-473e-b44e-89c0b44f739f");
            _toolbariconnewInfo = new RepoItemInfo(this, "ToolbarIconNew", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.New']", 30000, null, "f4841452-e6c8-4fbf-be42-dba5aa408867");
            _toolbariconsaveInfo = new RepoItemInfo(this, "ToolbarIconSave", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Save']", 30000, null, "0e07e975-8c06-4861-85d0-c388ddad6e66");
            _toolbariconsaveasInfo = new RepoItemInfo(this, "ToolbarIconSaveAs", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.SaveAs']", 30000, null, "20268547-fce0-4b15-980d-c6a0f6f331e8");
            _toolbariconimportInfo = new RepoItemInfo(this, "ToolbarIconImport", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Import']", 30000, null, "d84a071d-d965-4c3e-ad25-6d2bf19a1a2f");
            _toolbariconexportInfo = new RepoItemInfo(this, "ToolbarIconExport", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Export']", 30000, null, "902e61c9-9889-4049-935a-d00ecf0b16df");
            _toolbariconcalculateInfo = new RepoItemInfo(this, "ToolbarIconCalculate", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Calculate']", 30000, null, "cb13835a-8f5e-43bf-ac9c-f06cf08837f6");
            _toolbariconwriteInfo = new RepoItemInfo(this, "ToolbarIconWrite", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Write']", 30000, null, "e04861df-0de5-4ec8-bc23-01f8fe63da37");
            _toolbariconhelpInfo = new RepoItemInfo(this, "ToolbarIconHelp", "/container[@automationid='ViscosityModule.ViscosityForm.Form']/element[@automationid='Toolbar.Viscosity']/element[@controlname='barDockControlTop']/?/?/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Help']", 30000, null, "c0f1c614-dcbd-4c76-828b-947057db499d");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("c7d55f01-cf90-4d50-88f2-55da3174f987")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconLoad item.
        /// </summary>
        [RepositoryItem("61045900-6b8f-473e-b44e-89c0b44f739f")]
        public virtual Ranorex.Button ToolbarIconLoad
        {
            get
            {
                 return _toolbariconloadInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconLoad item info.
        /// </summary>
        [RepositoryItemInfo("61045900-6b8f-473e-b44e-89c0b44f739f")]
        public virtual RepoItemInfo ToolbarIconLoadInfo
        {
            get
            {
                return _toolbariconloadInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconNew item.
        /// </summary>
        [RepositoryItem("f4841452-e6c8-4fbf-be42-dba5aa408867")]
        public virtual Ranorex.Button ToolbarIconNew
        {
            get
            {
                 return _toolbariconnewInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconNew item info.
        /// </summary>
        [RepositoryItemInfo("f4841452-e6c8-4fbf-be42-dba5aa408867")]
        public virtual RepoItemInfo ToolbarIconNewInfo
        {
            get
            {
                return _toolbariconnewInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconSave item.
        /// </summary>
        [RepositoryItem("0e07e975-8c06-4861-85d0-c388ddad6e66")]
        public virtual Ranorex.Button ToolbarIconSave
        {
            get
            {
                 return _toolbariconsaveInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconSave item info.
        /// </summary>
        [RepositoryItemInfo("0e07e975-8c06-4861-85d0-c388ddad6e66")]
        public virtual RepoItemInfo ToolbarIconSaveInfo
        {
            get
            {
                return _toolbariconsaveInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconSaveAs item.
        /// </summary>
        [RepositoryItem("20268547-fce0-4b15-980d-c6a0f6f331e8")]
        public virtual Ranorex.Button ToolbarIconSaveAs
        {
            get
            {
                 return _toolbariconsaveasInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconSaveAs item info.
        /// </summary>
        [RepositoryItemInfo("20268547-fce0-4b15-980d-c6a0f6f331e8")]
        public virtual RepoItemInfo ToolbarIconSaveAsInfo
        {
            get
            {
                return _toolbariconsaveasInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconImport item.
        /// </summary>
        [RepositoryItem("d84a071d-d965-4c3e-ad25-6d2bf19a1a2f")]
        public virtual Ranorex.Button ToolbarIconImport
        {
            get
            {
                 return _toolbariconimportInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconImport item info.
        /// </summary>
        [RepositoryItemInfo("d84a071d-d965-4c3e-ad25-6d2bf19a1a2f")]
        public virtual RepoItemInfo ToolbarIconImportInfo
        {
            get
            {
                return _toolbariconimportInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconExport item.
        /// </summary>
        [RepositoryItem("902e61c9-9889-4049-935a-d00ecf0b16df")]
        public virtual Ranorex.Button ToolbarIconExport
        {
            get
            {
                 return _toolbariconexportInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconExport item info.
        /// </summary>
        [RepositoryItemInfo("902e61c9-9889-4049-935a-d00ecf0b16df")]
        public virtual RepoItemInfo ToolbarIconExportInfo
        {
            get
            {
                return _toolbariconexportInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconCalculate item.
        /// </summary>
        [RepositoryItem("cb13835a-8f5e-43bf-ac9c-f06cf08837f6")]
        public virtual Ranorex.Button ToolbarIconCalculate
        {
            get
            {
                 return _toolbariconcalculateInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconCalculate item info.
        /// </summary>
        [RepositoryItemInfo("cb13835a-8f5e-43bf-ac9c-f06cf08837f6")]
        public virtual RepoItemInfo ToolbarIconCalculateInfo
        {
            get
            {
                return _toolbariconcalculateInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconWrite item.
        /// </summary>
        [RepositoryItem("e04861df-0de5-4ec8-bc23-01f8fe63da37")]
        public virtual Ranorex.Button ToolbarIconWrite
        {
            get
            {
                 return _toolbariconwriteInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconWrite item info.
        /// </summary>
        [RepositoryItemInfo("e04861df-0de5-4ec8-bc23-01f8fe63da37")]
        public virtual RepoItemInfo ToolbarIconWriteInfo
        {
            get
            {
                return _toolbariconwriteInfo;
            }
        }

        /// <summary>
        /// The ToolbarIconHelp item.
        /// </summary>
        [RepositoryItem("c0f1c614-dcbd-4c76-828b-947057db499d")]
        public virtual Ranorex.Button ToolbarIconHelp
        {
            get
            {
                 return _toolbariconhelpInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The ToolbarIconHelp item info.
        /// </summary>
        [RepositoryItemInfo("c0f1c614-dcbd-4c76-828b-947057db499d")]
        public virtual RepoItemInfo ToolbarIconHelpInfo
        {
            get
            {
                return _toolbariconhelpInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ToolbarElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}