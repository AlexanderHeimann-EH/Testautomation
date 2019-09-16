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
    /// The class representing the ReadSettingsElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("4b35435c-a5f4-4638-8860-2b3307205ce3")]
    public partial class ReadSettingsElementsRepository : RepoGenBaseFolder
    {
        static ReadSettingsElementsRepository instance = new ReadSettingsElementsRepository();
        RepoItemInfo _buttonreadnowInfo;
        RepoItemInfo _buttonokInfo;
        RepoItemInfo _buttoncancelInfo;
        RepoItemInfo _buttoncloseInfo;
        RepoItemInfo _sliderresolutionInfo;
        RepoItemInfo _textbeginrangeunitInfo;
        RepoItemInfo _textendrangeunitInfo;
        RepoItemInfo _textbeginrangeInfo;
        RepoItemInfo _textendrangeInfo;
        RepoItemInfo _containercurvesInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ReadSettingsElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("4b35435c-a5f4-4638-8860-2b3307205ce3")]
        public static ReadSettingsElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ReadSettingsElementsRepository() 
            : base("ReadSettingsElementsRepository", "/", null, 0, false, "4b35435c-a5f4-4638-8860-2b3307205ce3", ".\\RepositoryImages\\ReadSettingsElementsRepository4b35435c.rximgres")
        {
            _buttonreadnowInfo = new RepoItemInfo(this, "buttonReadNow", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/element[@controlname='ReadButton']/button", 30000, null, "eed76e31-973e-4307-9b56-f8fa22dd5865");
            _buttonokInfo = new RepoItemInfo(this, "buttonOK", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/element[@controlname='OKButton']/button", 30000, null, "d9e0c90a-0cf3-443f-800c-98ee449cef71");
            _buttoncancelInfo = new RepoItemInfo(this, "buttonCancel", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/element[@controlname='cancelButton']/button", 30000, null, "06475a1a-03f0-481d-8232-79a35e8d7841");
            _buttoncloseInfo = new RepoItemInfo(this, "buttonClose", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/titlebar/button", 30000, null, "afd3fc5d-1511-4d9e-ac9e-3aa4ace4242c");
            _sliderresolutionInfo = new RepoItemInfo(this, "sliderResolution", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/container[@controlname='groupControlResolution']/element[@controlname='trackBarControl1']/slider[@accessiblename='5']", 30000, null, "cc89e9c9-d15c-43ed-a352-bcc4d4b7397f");
            _textbeginrangeunitInfo = new RepoItemInfo(this, "textBeginRangeUnit", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/container[@controlname='groupControlRange']/element[@controlname='labelControlBeginUnit']/text", 30000, null, "a455b021-b3a0-4c67-9b5d-2ca94b8bdfd7");
            _textendrangeunitInfo = new RepoItemInfo(this, "textEndRangeUnit", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/container[@controlname='groupControlRange']/element[@controlname='labelControlEndUnit']/text", 30000, null, "cb5d4a31-d8c9-4667-be67-cbf354040d71");
            _textbeginrangeInfo = new RepoItemInfo(this, "textBeginRange", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/container[@controlname='groupControlRange']/element[@controlname='textEdit1']/text", 30000, null, "36f27b20-3ea6-48fc-aaa2-50d0359fc7ae");
            _textendrangeInfo = new RepoItemInfo(this, "textEndRange", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/container[@controlname='groupControlRange']/element[@controlname='textEdit2']/text", 30000, null, "14b3f1b2-c30c-45c6-a040-390e58632919");
            _containercurvesInfo = new RepoItemInfo(this, "ContainerCurves", "/form[@controlname='EnvelopeCurveReadSettingsDialog']/element[@controlname='checkedCurveListControl']/tree/container[@accessiblename='Data Panel']", 30000, null, "85ee5bf8-7b66-4027-9391-200580ebb7ad");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("4b35435c-a5f4-4638-8860-2b3307205ce3")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The buttonReadNow item.
        /// </summary>
        [RepositoryItem("eed76e31-973e-4307-9b56-f8fa22dd5865")]
        public virtual Ranorex.Button buttonReadNow
        {
            get
            {
                 return _buttonreadnowInfo.CreateAdapter<Ranorex.Button>(true);
            }
        }

        /// <summary>
        /// The buttonReadNow item info.
        /// </summary>
        [RepositoryItemInfo("eed76e31-973e-4307-9b56-f8fa22dd5865")]
        public virtual RepoItemInfo buttonReadNowInfo
        {
            get
            {
                return _buttonreadnowInfo;
            }
        }

        /// <summary>
        /// The buttonOK item.
        /// </summary>
        [RepositoryItem("d9e0c90a-0cf3-443f-800c-98ee449cef71")]
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
        [RepositoryItemInfo("d9e0c90a-0cf3-443f-800c-98ee449cef71")]
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
        [RepositoryItem("06475a1a-03f0-481d-8232-79a35e8d7841")]
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
        [RepositoryItemInfo("06475a1a-03f0-481d-8232-79a35e8d7841")]
        public virtual RepoItemInfo buttonCancelInfo
        {
            get
            {
                return _buttoncancelInfo;
            }
        }

        /// <summary>
        /// The buttonClose item.
        /// </summary>
        [RepositoryItem("afd3fc5d-1511-4d9e-ac9e-3aa4ace4242c")]
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
        [RepositoryItemInfo("afd3fc5d-1511-4d9e-ac9e-3aa4ace4242c")]
        public virtual RepoItemInfo buttonCloseInfo
        {
            get
            {
                return _buttoncloseInfo;
            }
        }

        /// <summary>
        /// The sliderResolution item.
        /// </summary>
        [RepositoryItem("cc89e9c9-d15c-43ed-a352-bcc4d4b7397f")]
        public virtual Ranorex.Slider sliderResolution
        {
            get
            {
                 return _sliderresolutionInfo.CreateAdapter<Ranorex.Slider>(true);
            }
        }

        /// <summary>
        /// The sliderResolution item info.
        /// </summary>
        [RepositoryItemInfo("cc89e9c9-d15c-43ed-a352-bcc4d4b7397f")]
        public virtual RepoItemInfo sliderResolutionInfo
        {
            get
            {
                return _sliderresolutionInfo;
            }
        }

        /// <summary>
        /// The textBeginRangeUnit item.
        /// </summary>
        [RepositoryItem("a455b021-b3a0-4c67-9b5d-2ca94b8bdfd7")]
        public virtual Ranorex.Text textBeginRangeUnit
        {
            get
            {
                 return _textbeginrangeunitInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The textBeginRangeUnit item info.
        /// </summary>
        [RepositoryItemInfo("a455b021-b3a0-4c67-9b5d-2ca94b8bdfd7")]
        public virtual RepoItemInfo textBeginRangeUnitInfo
        {
            get
            {
                return _textbeginrangeunitInfo;
            }
        }

        /// <summary>
        /// The textEndRangeUnit item.
        /// </summary>
        [RepositoryItem("cb5d4a31-d8c9-4667-be67-cbf354040d71")]
        public virtual Ranorex.Text textEndRangeUnit
        {
            get
            {
                 return _textendrangeunitInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The textEndRangeUnit item info.
        /// </summary>
        [RepositoryItemInfo("cb5d4a31-d8c9-4667-be67-cbf354040d71")]
        public virtual RepoItemInfo textEndRangeUnitInfo
        {
            get
            {
                return _textendrangeunitInfo;
            }
        }

        /// <summary>
        /// The textBeginRange item.
        /// </summary>
        [RepositoryItem("36f27b20-3ea6-48fc-aaa2-50d0359fc7ae")]
        public virtual Ranorex.Text textBeginRange
        {
            get
            {
                 return _textbeginrangeInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The textBeginRange item info.
        /// </summary>
        [RepositoryItemInfo("36f27b20-3ea6-48fc-aaa2-50d0359fc7ae")]
        public virtual RepoItemInfo textBeginRangeInfo
        {
            get
            {
                return _textbeginrangeInfo;
            }
        }

        /// <summary>
        /// The textEndRange item.
        /// </summary>
        [RepositoryItem("14b3f1b2-c30c-45c6-a040-390e58632919")]
        public virtual Ranorex.Text textEndRange
        {
            get
            {
                 return _textendrangeInfo.CreateAdapter<Ranorex.Text>(true);
            }
        }

        /// <summary>
        /// The textEndRange item info.
        /// </summary>
        [RepositoryItemInfo("14b3f1b2-c30c-45c6-a040-390e58632919")]
        public virtual RepoItemInfo textEndRangeInfo
        {
            get
            {
                return _textendrangeInfo;
            }
        }

        /// <summary>
        /// The ContainerCurves item.
        /// </summary>
        [RepositoryItem("85ee5bf8-7b66-4027-9391-200580ebb7ad")]
        public virtual Ranorex.Container ContainerCurves
        {
            get
            {
                 return _containercurvesInfo.CreateAdapter<Ranorex.Container>(true);
            }
        }

        /// <summary>
        /// The ContainerCurves item info.
        /// </summary>
        [RepositoryItemInfo("85ee5bf8-7b66-4027-9391-200580ebb7ad")]
        public virtual RepoItemInfo ContainerCurvesInfo
        {
            get
            {
                return _containercurvesInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ReadSettingsElementsRepositoryFolders
    {
    }
#pragma warning restore 0436
}