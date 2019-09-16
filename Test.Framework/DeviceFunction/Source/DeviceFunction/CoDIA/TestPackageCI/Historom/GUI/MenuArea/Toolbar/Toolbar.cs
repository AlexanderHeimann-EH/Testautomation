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

namespace EH.PCPS.TestAutomation.TestPackageCI.Historom.GUI.MenuArea.Toolbar
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the Toolbar element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("3a13262f-f09a-4aed-aab1-0ca7e454ffcc")]
    public partial class Toolbar : RepoGenBaseFolder
    {
        static Toolbar instance = new Toolbar();
        RepoItemInfo _buttonnewInfo;
        RepoItemInfo _buttonnavigateforwardsInfo;
        RepoItemInfo _buttonloadInfo;
        RepoItemInfo _buttonsaveInfo;
        RepoItemInfo _buttonsaveasInfo;
        RepoItemInfo _buttonexportInfo;
        RepoItemInfo _buttonzoominInfo;
        RepoItemInfo _buttonzoomoutInfo;
        RepoItemInfo _buttonnavigatebackwardsInfo;
        RepoItemInfo _buttonreadInfo;
        RepoItemInfo _buttoncancelInfo;
        RepoItemInfo _buttonhelpInfo;
        RepoItemInfo _buttonresetzoomrangeInfo;

        /// <summary>
        /// Gets the singleton class instance representing the Toolbar element repository.
        /// </summary>
        [RepositoryFolder("3a13262f-f09a-4aed-aab1-0ca7e454ffcc")]
        public static Toolbar Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public Toolbar() 
            : base("Toolbar", "/", null, 0, false, "3a13262f-f09a-4aed-aab1-0ca7e454ffcc", ".\\RepositoryImages\\Toolbar3a13262f.rximgres")
        {
            _buttonnewInfo = new RepoItemInfo(this, "buttonNew", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.New']", 30000, null, "a8ec6a33-0b66-424b-aa94-15103ce57af9");
            _buttonnavigateforwardsInfo = new RepoItemInfo(this, "buttonNavigateForwards", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.ScrollUp']", 30000, null, "c54730c6-f487-4ef3-ab37-0ffd240bf53d");
            _buttonloadInfo = new RepoItemInfo(this, "buttonLoad", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Load']", 30000, null, "ddab3941-1bb3-48ff-8dc7-987ba055e55e");
            _buttonsaveInfo = new RepoItemInfo(this, "buttonSave", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Save']", 30000, null, "b717ade8-0ffa-4a87-bf5c-5823e7fa564f");
            _buttonsaveasInfo = new RepoItemInfo(this, "buttonSaveAs", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.SaveAs']", 30000, null, "59cd87fa-9c1f-4bf5-9f81-ea40cb6f2d5d");
            _buttonexportInfo = new RepoItemInfo(this, "buttonExport", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Export']", 30000, null, "23310a1d-ef41-4ce0-a33b-a335aa269142");
            _buttonzoominInfo = new RepoItemInfo(this, "buttonZoomIn", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.ZoomIn']", 30000, null, "6d20b5d0-c771-40a8-a4e1-c980ff4a5849");
            _buttonzoomoutInfo = new RepoItemInfo(this, "buttonZoomOut", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.ZoomOut']", 30000, null, "821ac081-d421-40de-ba6b-ef1ac49b7ebc");
            _buttonnavigatebackwardsInfo = new RepoItemInfo(this, "buttonNavigateBackwards", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.ScrollDown']", 30000, null, "07b8f0fd-93c4-4218-bf0e-b52ce505350c");
            _buttonreadInfo = new RepoItemInfo(this, "buttonRead", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Read']", 30000, null, "ff36a32f-ff20-40a2-8972-f21a66226d88");
            _buttoncancelInfo = new RepoItemInfo(this, "buttonCancel", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Cancel']", 30000, null, "161f6903-6882-4828-a08f-d580d0371bc8");
            _buttonhelpInfo = new RepoItemInfo(this, "buttonHelp", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.Help']", 30000, null, "89ccf158-fea2-469e-9f82-2aff1c06cf16");
            _buttonresetzoomrangeInfo = new RepoItemInfo(this, "buttonResetZoomRange", "/container[@automationid='HistoROMModule.HistoROMForm.Form']/element[@automationid='Toolbar.HistoROM']/element[@controlname='barDockControlTop']/element/toolbar[@accessiblename='Bar']/button[@accessiblename='Toolbar.Icon.ZoomReset']", 30000, null, "784caf07-7767-4349-b990-b0f85d7a7d52");
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
        /// The buttonNew item.
        /// </summary>
        [RepositoryItem("a8ec6a33-0b66-424b-aa94-15103ce57af9")]
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
        [RepositoryItemInfo("a8ec6a33-0b66-424b-aa94-15103ce57af9")]
        public virtual RepoItemInfo buttonNewInfo
        {
            get
            {
                return _buttonnewInfo;
            }
        }

        /// <summary>
        /// The buttonNavigateForwards item.
        /// </summary>
        [RepositoryItem("c54730c6-f487-4ef3-ab37-0ffd240bf53d")]
        public virtual Ranorex.Button buttonNavigateForwards
        {
            get
            {
                 return _buttonnavigateforwardsInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonNavigateForwards item info.
        /// </summary>
        [RepositoryItemInfo("c54730c6-f487-4ef3-ab37-0ffd240bf53d")]
        public virtual RepoItemInfo buttonNavigateForwardsInfo
        {
            get
            {
                return _buttonnavigateforwardsInfo;
            }
        }

        /// <summary>
        /// The buttonLoad item.
        /// </summary>
        [RepositoryItem("ddab3941-1bb3-48ff-8dc7-987ba055e55e")]
        public virtual Ranorex.Button buttonLoad
        {
            get
            {
                 return _buttonloadInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonLoad item info.
        /// </summary>
        [RepositoryItemInfo("ddab3941-1bb3-48ff-8dc7-987ba055e55e")]
        public virtual RepoItemInfo buttonLoadInfo
        {
            get
            {
                return _buttonloadInfo;
            }
        }

        /// <summary>
        /// The buttonSave item.
        /// </summary>
        [RepositoryItem("b717ade8-0ffa-4a87-bf5c-5823e7fa564f")]
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
        [RepositoryItemInfo("b717ade8-0ffa-4a87-bf5c-5823e7fa564f")]
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
        [RepositoryItem("59cd87fa-9c1f-4bf5-9f81-ea40cb6f2d5d")]
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
        [RepositoryItemInfo("59cd87fa-9c1f-4bf5-9f81-ea40cb6f2d5d")]
        public virtual RepoItemInfo buttonSaveAsInfo
        {
            get
            {
                return _buttonsaveasInfo;
            }
        }

        /// <summary>
        /// The buttonExport item.
        /// </summary>
        [RepositoryItem("23310a1d-ef41-4ce0-a33b-a335aa269142")]
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
        [RepositoryItemInfo("23310a1d-ef41-4ce0-a33b-a335aa269142")]
        public virtual RepoItemInfo buttonExportInfo
        {
            get
            {
                return _buttonexportInfo;
            }
        }

        /// <summary>
        /// The buttonZoomIn item.
        /// </summary>
        [RepositoryItem("6d20b5d0-c771-40a8-a4e1-c980ff4a5849")]
        public virtual Ranorex.Button buttonZoomIn
        {
            get
            {
                 return _buttonzoominInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonZoomIn item info.
        /// </summary>
        [RepositoryItemInfo("6d20b5d0-c771-40a8-a4e1-c980ff4a5849")]
        public virtual RepoItemInfo buttonZoomInInfo
        {
            get
            {
                return _buttonzoominInfo;
            }
        }

        /// <summary>
        /// The buttonZoomOut item.
        /// </summary>
        [RepositoryItem("821ac081-d421-40de-ba6b-ef1ac49b7ebc")]
        public virtual Ranorex.Button buttonZoomOut
        {
            get
            {
                 return _buttonzoomoutInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonZoomOut item info.
        /// </summary>
        [RepositoryItemInfo("821ac081-d421-40de-ba6b-ef1ac49b7ebc")]
        public virtual RepoItemInfo buttonZoomOutInfo
        {
            get
            {
                return _buttonzoomoutInfo;
            }
        }

        /// <summary>
        /// The buttonNavigateBackwards item.
        /// </summary>
        [RepositoryItem("07b8f0fd-93c4-4218-bf0e-b52ce505350c")]
        public virtual Ranorex.Button buttonNavigateBackwards
        {
            get
            {
                 return _buttonnavigatebackwardsInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonNavigateBackwards item info.
        /// </summary>
        [RepositoryItemInfo("07b8f0fd-93c4-4218-bf0e-b52ce505350c")]
        public virtual RepoItemInfo buttonNavigateBackwardsInfo
        {
            get
            {
                return _buttonnavigatebackwardsInfo;
            }
        }

        /// <summary>
        /// The buttonRead item.
        /// </summary>
        [RepositoryItem("ff36a32f-ff20-40a2-8972-f21a66226d88")]
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
        [RepositoryItemInfo("ff36a32f-ff20-40a2-8972-f21a66226d88")]
        public virtual RepoItemInfo buttonReadInfo
        {
            get
            {
                return _buttonreadInfo;
            }
        }

        /// <summary>
        /// The buttonCancel item.
        /// </summary>
        [RepositoryItem("161f6903-6882-4828-a08f-d580d0371bc8")]
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
        [RepositoryItemInfo("161f6903-6882-4828-a08f-d580d0371bc8")]
        public virtual RepoItemInfo buttonCancelInfo
        {
            get
            {
                return _buttoncancelInfo;
            }
        }

        /// <summary>
        /// The buttonHelp item.
        /// </summary>
        [RepositoryItem("89ccf158-fea2-469e-9f82-2aff1c06cf16")]
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
        [RepositoryItemInfo("89ccf158-fea2-469e-9f82-2aff1c06cf16")]
        public virtual RepoItemInfo buttonHelpInfo
        {
            get
            {
                return _buttonhelpInfo;
            }
        }

        /// <summary>
        /// The buttonResetZoomRange item.
        /// </summary>
        [RepositoryItem("784caf07-7767-4349-b990-b0f85d7a7d52")]
        public virtual Ranorex.Button buttonResetZoomRange
        {
            get
            {
                 return _buttonresetzoomrangeInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonResetZoomRange item info.
        /// </summary>
        [RepositoryItemInfo("784caf07-7767-4349-b990-b0f85d7a7d52")]
        public virtual RepoItemInfo buttonResetZoomRangeInfo
        {
            get
            {
                return _buttonresetzoomrangeInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ToolbarFolders
    {
    }
#pragma warning restore 0436
}