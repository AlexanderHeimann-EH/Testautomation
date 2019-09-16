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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.GUI.Dialogs
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ZoomAndGridSettingsElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("5021e8e1-be13-4f62-9ca7-5e504253bcaa")]
    public partial class ZoomAndGridSettingsElementsRepository : RepoGenBaseFolder
    {
        static ZoomAndGridSettingsElementsRepository instance = new ZoomAndGridSettingsElementsRepository();
        RepoItemInfo _buttoncancelInfo;
        RepoItemInfo _buttonokInfo;
        RepoItemInfo _buttoncloseInfo;
        RepoItemInfo _txtzoomareaxmaxInfo;
        RepoItemInfo _txtzoomareaxmaxunitInfo;
        RepoItemInfo _txtzoomareaxminunitInfo;
        RepoItemInfo _txtzoomareaxminInfo;
        RepoItemInfo _txtzoomareayminunitInfo;
        RepoItemInfo _txtzoomareaymaxInfo;
        RepoItemInfo _txtzoomareayminInfo;
        RepoItemInfo _txtzoomareaymaxunitInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ZoomAndGridSettingsElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("5021e8e1-be13-4f62-9ca7-5e504253bcaa")]
        public static ZoomAndGridSettingsElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ZoomAndGridSettingsElementsRepository() 
            : base("ZoomAndGridSettingsElementsRepository", "/", null, 0, false, "5021e8e1-be13-4f62-9ca7-5e504253bcaa", ".\\RepositoryImages\\ZoomAndGridSettingsElementsRepository5021e8e1.rximgres")
        {
            _buttoncancelInfo = new RepoItemInfo(this, "buttonCancel", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/element[@controlname='cancelButton']/button", 30000, null, "5f40a87c-a83f-4212-b546-9afd5a417fe2");
            _buttonokInfo = new RepoItemInfo(this, "buttonOK", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/element[@controlname='OKButton']/button", 30000, null, "14c50acc-f109-4d64-9412-8b5416b5a567");
            _buttoncloseInfo = new RepoItemInfo(this, "buttonClose", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/titlebar/button", 30000, null, "4a516c70-00ac-4d77-8b16-e69a5e848db8");
            _txtzoomareaxmaxInfo = new RepoItemInfo(this, "txtZoomAreaXMax", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/container[@controlname='groupControlZoom']/element[@controlname='SetZoomXMaxEdit']/text[@controltypename='TextBoxMaskBox']", 30000, null, "a75e78f7-a4e5-4b04-b097-42bfed706ad3");
            _txtzoomareaxmaxunitInfo = new RepoItemInfo(this, "txtZoomAreaXMaxUnit", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/container[@controlname='groupControlZoom']/element[@controlname='labelZoomXMaxUnit']/text", 30000, null, "1b32c36c-bee0-4596-8209-ad26469caa88");
            _txtzoomareaxminunitInfo = new RepoItemInfo(this, "txtZoomAreaXMinUnit", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/container[@controlname='groupControlZoom']/element[@controlname='labelZoomXMinUnit']/text", 30000, null, "e63246a4-5a62-467c-a133-e23dfcc998ab");
            _txtzoomareaxminInfo = new RepoItemInfo(this, "txtZoomAreaXMin", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/container[@controlname='groupControlZoom']/element[@controlname='SetZoomXMinEdit']/text[@controltypename='TextBoxMaskBox']", 30000, null, "b5c16e30-8b1e-404e-ab32-fd12297a18d2");
            _txtzoomareayminunitInfo = new RepoItemInfo(this, "txtZoomAreaYMinUnit", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/container[@controlname='groupControlZoom']/element[@controlname='labelZoomYMinUnit']/text", 30000, null, "69283f47-e795-446d-b668-c91fb27ef524");
            _txtzoomareaymaxInfo = new RepoItemInfo(this, "txtZoomAreaYMax", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/container[@controlname='groupControlZoom']/element[@controlname='SetZoomYMaxEdit']/text[@controltypename='TextBoxMaskBox']", 30000, null, "4cabf0b2-06ad-4f31-a8d5-a2207e725597");
            _txtzoomareayminInfo = new RepoItemInfo(this, "txtZoomAreaYMin", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/container[@controlname='groupControlZoom']/element[@controlname='SetZoomYMinEdit']/text[@controltypename='TextBoxMaskBox']", 30000, null, "c9495fbe-ea99-438a-ac93-78aa529a61a8");
            _txtzoomareaymaxunitInfo = new RepoItemInfo(this, "txtZoomAreaYMaxUnit", "/form[@controlname='EnvelopeCurveZoomAndGridSettingsDialog']/container[@controlname='groupControlZoom']/element[@controlname='labelZoomYMaxUnit']/text", 30000, null, "6b43a74c-5483-400c-8d02-017c0acee090");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("5021e8e1-be13-4f62-9ca7-5e504253bcaa")]
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
        [RepositoryItem("5f40a87c-a83f-4212-b546-9afd5a417fe2")]
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
        [RepositoryItemInfo("5f40a87c-a83f-4212-b546-9afd5a417fe2")]
        public virtual RepoItemInfo buttonCancelInfo
        {
            get
            {
                return _buttoncancelInfo;
            }
        }

        /// <summary>
        /// The buttonOK item.
        /// </summary>
        [RepositoryItem("14c50acc-f109-4d64-9412-8b5416b5a567")]
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
        [RepositoryItemInfo("14c50acc-f109-4d64-9412-8b5416b5a567")]
        public virtual RepoItemInfo buttonOKInfo
        {
            get
            {
                return _buttonokInfo;
            }
        }

        /// <summary>
        /// The buttonClose item.
        /// </summary>
        [RepositoryItem("4a516c70-00ac-4d77-8b16-e69a5e848db8")]
        public virtual Ranorex.Button buttonClose
        {
            get
            {
                 return _buttoncloseInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonClose item info.
        /// </summary>
        [RepositoryItemInfo("4a516c70-00ac-4d77-8b16-e69a5e848db8")]
        public virtual RepoItemInfo buttonCloseInfo
        {
            get
            {
                return _buttoncloseInfo;
            }
        }

        /// <summary>
        /// The txtZoomAreaXMax item.
        /// </summary>
        [RepositoryItem("a75e78f7-a4e5-4b04-b097-42bfed706ad3")]
        public virtual Ranorex.Text txtZoomAreaXMax
        {
            get
            {
                 return _txtzoomareaxmaxInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtZoomAreaXMax item info.
        /// </summary>
        [RepositoryItemInfo("a75e78f7-a4e5-4b04-b097-42bfed706ad3")]
        public virtual RepoItemInfo txtZoomAreaXMaxInfo
        {
            get
            {
                return _txtzoomareaxmaxInfo;
            }
        }

        /// <summary>
        /// The txtZoomAreaXMaxUnit item.
        /// </summary>
        [RepositoryItem("1b32c36c-bee0-4596-8209-ad26469caa88")]
        public virtual Ranorex.Text txtZoomAreaXMaxUnit
        {
            get
            {
                 return _txtzoomareaxmaxunitInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtZoomAreaXMaxUnit item info.
        /// </summary>
        [RepositoryItemInfo("1b32c36c-bee0-4596-8209-ad26469caa88")]
        public virtual RepoItemInfo txtZoomAreaXMaxUnitInfo
        {
            get
            {
                return _txtzoomareaxmaxunitInfo;
            }
        }

        /// <summary>
        /// The txtZoomAreaXMinUnit item.
        /// </summary>
        [RepositoryItem("e63246a4-5a62-467c-a133-e23dfcc998ab")]
        public virtual Ranorex.Text txtZoomAreaXMinUnit
        {
            get
            {
                 return _txtzoomareaxminunitInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtZoomAreaXMinUnit item info.
        /// </summary>
        [RepositoryItemInfo("e63246a4-5a62-467c-a133-e23dfcc998ab")]
        public virtual RepoItemInfo txtZoomAreaXMinUnitInfo
        {
            get
            {
                return _txtzoomareaxminunitInfo;
            }
        }

        /// <summary>
        /// The txtZoomAreaXMin item.
        /// </summary>
        [RepositoryItem("b5c16e30-8b1e-404e-ab32-fd12297a18d2")]
        public virtual Ranorex.Text txtZoomAreaXMin
        {
            get
            {
                 return _txtzoomareaxminInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtZoomAreaXMin item info.
        /// </summary>
        [RepositoryItemInfo("b5c16e30-8b1e-404e-ab32-fd12297a18d2")]
        public virtual RepoItemInfo txtZoomAreaXMinInfo
        {
            get
            {
                return _txtzoomareaxminInfo;
            }
        }

        /// <summary>
        /// The txtZoomAreaYMinUnit item.
        /// </summary>
        [RepositoryItem("69283f47-e795-446d-b668-c91fb27ef524")]
        public virtual Ranorex.Text txtZoomAreaYMinUnit
        {
            get
            {
                 return _txtzoomareayminunitInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtZoomAreaYMinUnit item info.
        /// </summary>
        [RepositoryItemInfo("69283f47-e795-446d-b668-c91fb27ef524")]
        public virtual RepoItemInfo txtZoomAreaYMinUnitInfo
        {
            get
            {
                return _txtzoomareayminunitInfo;
            }
        }

        /// <summary>
        /// The txtZoomAreaYMax item.
        /// </summary>
        [RepositoryItem("4cabf0b2-06ad-4f31-a8d5-a2207e725597")]
        public virtual Ranorex.Text txtZoomAreaYMax
        {
            get
            {
                 return _txtzoomareaymaxInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtZoomAreaYMax item info.
        /// </summary>
        [RepositoryItemInfo("4cabf0b2-06ad-4f31-a8d5-a2207e725597")]
        public virtual RepoItemInfo txtZoomAreaYMaxInfo
        {
            get
            {
                return _txtzoomareaymaxInfo;
            }
        }

        /// <summary>
        /// The txtZoomAreaYMin item.
        /// </summary>
        [RepositoryItem("c9495fbe-ea99-438a-ac93-78aa529a61a8")]
        public virtual Ranorex.Text txtZoomAreaYMin
        {
            get
            {
                 return _txtzoomareayminInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtZoomAreaYMin item info.
        /// </summary>
        [RepositoryItemInfo("c9495fbe-ea99-438a-ac93-78aa529a61a8")]
        public virtual RepoItemInfo txtZoomAreaYMinInfo
        {
            get
            {
                return _txtzoomareayminInfo;
            }
        }

        /// <summary>
        /// The txtZoomAreaYMaxUnit item.
        /// </summary>
        [RepositoryItem("6b43a74c-5483-400c-8d02-017c0acee090")]
        public virtual Ranorex.Text txtZoomAreaYMaxUnit
        {
            get
            {
                 return _txtzoomareaymaxunitInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The txtZoomAreaYMaxUnit item info.
        /// </summary>
        [RepositoryItemInfo("6b43a74c-5483-400c-8d02-017c0acee090")]
        public virtual RepoItemInfo txtZoomAreaYMaxUnitInfo
        {
            get
            {
                return _txtzoomareaymaxunitInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ZoomAndGridSettingsElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}