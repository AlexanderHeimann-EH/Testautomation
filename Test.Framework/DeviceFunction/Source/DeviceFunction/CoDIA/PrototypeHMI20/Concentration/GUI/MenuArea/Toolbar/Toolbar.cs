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

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.GUI.MenuArea.Toolbar
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the Toolbar element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("12146e85-b7b8-4d41-bc0a-46e0516a9bbe")]
    public partial class Toolbar : RepoGenBaseFolder
    {
        static Toolbar instance = new Toolbar();
        ToolbarFolders.ToolbarFolder _toolbar;

        /// <summary>
        /// Gets the singleton class instance representing the Toolbar element repository.
        /// </summary>
        [RepositoryFolder("12146e85-b7b8-4d41-bc0a-46e0516a9bbe")]
        public static Toolbar Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public Toolbar() 
            : base("Toolbar", "/", null, 0, false, "12146e85-b7b8-4d41-bc0a-46e0516a9bbe", ".\\RepositoryImages\\Toolbar12146e85.rximgres")
        {
            _toolbar = new ToolbarFolders.ToolbarFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("12146e85-b7b8-4d41-bc0a-46e0516a9bbe")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The toolbar folder.
        /// </summary>
        [RepositoryFolder("7537d604-5648-4804-948f-b41b9bad441b")]
        public virtual ToolbarFolders.ToolbarFolder toolbar
        {
            get { return _toolbar; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ToolbarFolders
    {
        /// <summary>
        /// The ToolbarFolder folder.
        /// </summary>
        [RepositoryFolder("7537d604-5648-4804-948f-b41b9bad441b")]
        public partial class ToolbarFolder : RepoGenBaseFolder
        {
            RepoItemInfo _buttoneventlistInfo;
            RepoItemInfo _buttoncalculateInfo;
            RepoItemInfo _buttonexportInfo;
            RepoItemInfo _buttonhelpInfo;
            RepoItemInfo _buttonimportInfo;
            RepoItemInfo _buttonopenInfo;
            RepoItemInfo _buttonnewInfo;
            RepoItemInfo _buttoncreatedocumentationInfo;
            RepoItemInfo _buttonreadInfo;
            RepoItemInfo _buttonsaveInfo;
            RepoItemInfo _buttonsaveasInfo;
            RepoItemInfo _buttonsaverestoreInfo;
            RepoItemInfo _buttonwriteInfo;
            RepoItemInfo _buttonaboutInfo;
            RepoItemInfo _buttoncomparedatasetsInfo;

            /// <summary>
            /// Creates a new toolbar  folder.
            /// </summary>
            public ToolbarFolder(RepoGenBaseFolder parentFolder) :
                    base("toolbar", "/container[@automationid='ConcentrationModule.Form.Concentration']/element[@automationid='Toolbar.Concentration']/element/element/toolbar", parentFolder, 30000, null, true, "7537d604-5648-4804-948f-b41b9bad441b", "")
            {
                _buttoneventlistInfo = new RepoItemInfo(this, "buttonEventList", "button[@accessiblename='Toolbar.Icon.EventListModule']", 30000, null, "228ad650-bcda-40f7-bac2-2d5bf2c9790a");
                _buttoncalculateInfo = new RepoItemInfo(this, "buttonCalculate", "button[@accessiblename='Toolbar.Icon.Calculate']", 30000, null, "757ce627-a82f-47a9-b25d-633028d77331");
                _buttonexportInfo = new RepoItemInfo(this, "buttonExport", "button[@accessiblename='Toolbar.Icon.Export']", 30000, null, "5620bb72-000b-4b88-97b7-b8e3a99b42d7");
                _buttonhelpInfo = new RepoItemInfo(this, "buttonHelp", "button[@accessiblename='Toolbar.Icon.Help']", 30000, null, "780f8b67-382e-43d0-b763-7d5f2030ad35");
                _buttonimportInfo = new RepoItemInfo(this, "buttonImport", "button[@accessiblename='Toolbar.Icon.Import']", 30000, null, "8dad1148-8af5-4154-ae55-aae6e395b95a");
                _buttonopenInfo = new RepoItemInfo(this, "buttonOpen", "button[@accessiblename='Toolbar.Icon.Load']", 30000, null, "5ddcfbe2-8fac-425e-9e9e-efb4ab3266d6");
                _buttonnewInfo = new RepoItemInfo(this, "buttonNew", "button[@accessiblename='Toolbar.Icon.New']", 30000, null, "a957779f-60e7-4f36-b8bc-083d03e342cc");
                _buttoncreatedocumentationInfo = new RepoItemInfo(this, "buttonCreateDocumentation", "button[@accessiblename='Toolbar.Icon.OCPModule']", 30000, null, "e1c94afb-733e-44ab-b9df-1761a94fd8f2");
                _buttonreadInfo = new RepoItemInfo(this, "buttonRead", "button[@accessiblename='Toolbar.Icon.Read']", 30000, null, "3bb526de-1210-4584-ae25-83657517e534");
                _buttonsaveInfo = new RepoItemInfo(this, "buttonSave", "button[@accessiblename='Toolbar.Icon.Save']", 30000, null, "cc85a5bd-3bb1-40f3-aea1-e95f1b38edfe");
                _buttonsaveasInfo = new RepoItemInfo(this, "buttonSaveAs", "button[@accessiblename='Toolbar.Icon.SaveAs']", 30000, null, "a091edb3-019c-433f-b830-fa561dcced72");
                _buttonsaverestoreInfo = new RepoItemInfo(this, "buttonSaveRestore", "button[@accessiblename='Toolbar.Icon.UDModule']", 30000, null, "c391f7a8-ef7f-404a-83e6-8352dd48b075");
                _buttonwriteInfo = new RepoItemInfo(this, "buttonWrite", "button[@accessiblename='Toolbar.Icon.Write']", 30000, null, "41743a00-f25f-47bd-a1ab-d3d755a37ecd");
                _buttonaboutInfo = new RepoItemInfo(this, "buttonAbout", "button[@accessiblename='Toolbar.Icon.AboutBoxModule']", 30000, null, "5a7ebfdb-5808-4ea4-8216-2ad5fce7f9e4");
                _buttoncomparedatasetsInfo = new RepoItemInfo(this, "buttonCompareDatasets", "button[@accessiblename='Toolbar.Icon.CompareModule']", 30000, null, "98629c1b-2fba-4c3c-b67a-dc64a8233e25");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("7537d604-5648-4804-948f-b41b9bad441b")]
            public virtual Ranorex.ToolBar Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.ToolBar>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("7537d604-5648-4804-948f-b41b9bad441b")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The buttonEventList item.
            /// </summary>
            [RepositoryItem("228ad650-bcda-40f7-bac2-2d5bf2c9790a")]
            public virtual Ranorex.Button buttonEventList
            {
                get
                {
                    return _buttoneventlistInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonEventList item info.
            /// </summary>
            [RepositoryItemInfo("228ad650-bcda-40f7-bac2-2d5bf2c9790a")]
            public virtual RepoItemInfo buttonEventListInfo
            {
                get
                {
                    return _buttoneventlistInfo;
                }
            }

            /// <summary>
            /// The buttonCalculate item.
            /// </summary>
            [RepositoryItem("757ce627-a82f-47a9-b25d-633028d77331")]
            public virtual Ranorex.Button buttonCalculate
            {
                get
                {
                    return _buttoncalculateInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonCalculate item info.
            /// </summary>
            [RepositoryItemInfo("757ce627-a82f-47a9-b25d-633028d77331")]
            public virtual RepoItemInfo buttonCalculateInfo
            {
                get
                {
                    return _buttoncalculateInfo;
                }
            }

            /// <summary>
            /// The buttonExport item.
            /// </summary>
            [RepositoryItem("5620bb72-000b-4b88-97b7-b8e3a99b42d7")]
            public virtual Ranorex.Button buttonExport
            {
                get
                {
                    return _buttonexportInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonExport item info.
            /// </summary>
            [RepositoryItemInfo("5620bb72-000b-4b88-97b7-b8e3a99b42d7")]
            public virtual RepoItemInfo buttonExportInfo
            {
                get
                {
                    return _buttonexportInfo;
                }
            }

            /// <summary>
            /// The buttonHelp item.
            /// </summary>
            [RepositoryItem("780f8b67-382e-43d0-b763-7d5f2030ad35")]
            public virtual Ranorex.Button buttonHelp
            {
                get
                {
                    return _buttonhelpInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonHelp item info.
            /// </summary>
            [RepositoryItemInfo("780f8b67-382e-43d0-b763-7d5f2030ad35")]
            public virtual RepoItemInfo buttonHelpInfo
            {
                get
                {
                    return _buttonhelpInfo;
                }
            }

            /// <summary>
            /// The buttonImport item.
            /// </summary>
            [RepositoryItem("8dad1148-8af5-4154-ae55-aae6e395b95a")]
            public virtual Ranorex.Button buttonImport
            {
                get
                {
                    return _buttonimportInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonImport item info.
            /// </summary>
            [RepositoryItemInfo("8dad1148-8af5-4154-ae55-aae6e395b95a")]
            public virtual RepoItemInfo buttonImportInfo
            {
                get
                {
                    return _buttonimportInfo;
                }
            }

            /// <summary>
            /// The buttonOpen item.
            /// </summary>
            [RepositoryItem("5ddcfbe2-8fac-425e-9e9e-efb4ab3266d6")]
            public virtual Ranorex.Button buttonOpen
            {
                get
                {
                    return _buttonopenInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonOpen item info.
            /// </summary>
            [RepositoryItemInfo("5ddcfbe2-8fac-425e-9e9e-efb4ab3266d6")]
            public virtual RepoItemInfo buttonOpenInfo
            {
                get
                {
                    return _buttonopenInfo;
                }
            }

            /// <summary>
            /// The buttonNew item.
            /// </summary>
            [RepositoryItem("a957779f-60e7-4f36-b8bc-083d03e342cc")]
            public virtual Ranorex.Button buttonNew
            {
                get
                {
                    return _buttonnewInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonNew item info.
            /// </summary>
            [RepositoryItemInfo("a957779f-60e7-4f36-b8bc-083d03e342cc")]
            public virtual RepoItemInfo buttonNewInfo
            {
                get
                {
                    return _buttonnewInfo;
                }
            }

            /// <summary>
            /// The buttonCreateDocumentation item.
            /// </summary>
            [RepositoryItem("e1c94afb-733e-44ab-b9df-1761a94fd8f2")]
            public virtual Ranorex.Button buttonCreateDocumentation
            {
                get
                {
                    return _buttoncreatedocumentationInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonCreateDocumentation item info.
            /// </summary>
            [RepositoryItemInfo("e1c94afb-733e-44ab-b9df-1761a94fd8f2")]
            public virtual RepoItemInfo buttonCreateDocumentationInfo
            {
                get
                {
                    return _buttoncreatedocumentationInfo;
                }
            }

            /// <summary>
            /// The buttonRead item.
            /// </summary>
            [RepositoryItem("3bb526de-1210-4584-ae25-83657517e534")]
            public virtual Ranorex.Button buttonRead
            {
                get
                {
                    return _buttonreadInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonRead item info.
            /// </summary>
            [RepositoryItemInfo("3bb526de-1210-4584-ae25-83657517e534")]
            public virtual RepoItemInfo buttonReadInfo
            {
                get
                {
                    return _buttonreadInfo;
                }
            }

            /// <summary>
            /// The buttonSave item.
            /// </summary>
            [RepositoryItem("cc85a5bd-3bb1-40f3-aea1-e95f1b38edfe")]
            public virtual Ranorex.Button buttonSave
            {
                get
                {
                    return _buttonsaveInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonSave item info.
            /// </summary>
            [RepositoryItemInfo("cc85a5bd-3bb1-40f3-aea1-e95f1b38edfe")]
            public virtual RepoItemInfo buttonSaveInfo
            {
                get
                {
                    return _buttonsaveInfo;
                }
            }

            /// <summary>
            /// The buttonSaveAs item.
            /// </summary>
            [RepositoryItem("a091edb3-019c-433f-b830-fa561dcced72")]
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
            [RepositoryItemInfo("a091edb3-019c-433f-b830-fa561dcced72")]
            public virtual RepoItemInfo buttonSaveAsInfo
            {
                get
                {
                    return _buttonsaveasInfo;
                }
            }

            /// <summary>
            /// The buttonSaveRestore item.
            /// </summary>
            [RepositoryItem("c391f7a8-ef7f-404a-83e6-8352dd48b075")]
            public virtual Ranorex.Button buttonSaveRestore
            {
                get
                {
                    return _buttonsaverestoreInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonSaveRestore item info.
            /// </summary>
            [RepositoryItemInfo("c391f7a8-ef7f-404a-83e6-8352dd48b075")]
            public virtual RepoItemInfo buttonSaveRestoreInfo
            {
                get
                {
                    return _buttonsaverestoreInfo;
                }
            }

            /// <summary>
            /// The buttonWrite item.
            /// </summary>
            [RepositoryItem("41743a00-f25f-47bd-a1ab-d3d755a37ecd")]
            public virtual Ranorex.Button buttonWrite
            {
                get
                {
                    return _buttonwriteInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonWrite item info.
            /// </summary>
            [RepositoryItemInfo("41743a00-f25f-47bd-a1ab-d3d755a37ecd")]
            public virtual RepoItemInfo buttonWriteInfo
            {
                get
                {
                    return _buttonwriteInfo;
                }
            }

            /// <summary>
            /// The buttonAbout item.
            /// </summary>
            [RepositoryItem("5a7ebfdb-5808-4ea4-8216-2ad5fce7f9e4")]
            public virtual Ranorex.Button buttonAbout
            {
                get
                {
                    return _buttonaboutInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonAbout item info.
            /// </summary>
            [RepositoryItemInfo("5a7ebfdb-5808-4ea4-8216-2ad5fce7f9e4")]
            public virtual RepoItemInfo buttonAboutInfo
            {
                get
                {
                    return _buttonaboutInfo;
                }
            }

            /// <summary>
            /// The buttonCompareDatasets item.
            /// </summary>
            [RepositoryItem("98629c1b-2fba-4c3c-b67a-dc64a8233e25")]
            public virtual Ranorex.Button buttonCompareDatasets
            {
                get
                {
                    return _buttoncomparedatasetsInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The buttonCompareDatasets item info.
            /// </summary>
            [RepositoryItemInfo("98629c1b-2fba-4c3c-b67a-dc64a8233e25")]
            public virtual RepoItemInfo buttonCompareDatasetsInfo
            {
                get
                {
                    return _buttoncomparedatasetsInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}