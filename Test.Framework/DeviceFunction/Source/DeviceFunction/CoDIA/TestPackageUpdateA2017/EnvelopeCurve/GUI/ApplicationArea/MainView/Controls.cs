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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurve.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the Controls element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("0a838cfd-8f7b-4906-83b8-7612e8d28287")]
    public partial class Controls : RepoGenBaseFolder
    {
        static Controls instance = new Controls();
        RepoItemInfo _curvedatanumberInfo;
        RepoItemInfo _progressbarcontainerInfo;
        RepoItemInfo _curvecontainerInfo;
        RepoItemInfo _diagramcontrolInfo;
        RepoItemInfo _envelopecurvemodulecontainerInfo;

        /// <summary>
        /// Gets the singleton class instance representing the Controls element repository.
        /// </summary>
        [RepositoryFolder("0a838cfd-8f7b-4906-83b8-7612e8d28287")]
        public static Controls Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public Controls() 
            : base("Controls", "/", null, 0, false, "0a838cfd-8f7b-4906-83b8-7612e8d28287", ".\\RepositoryImages\\Controls0a838cfd.rximgres")
        {
            _curvedatanumberInfo = new RepoItemInfo(this, "CurveDataNumber", "/container[@automationid='EnvelopeCurveModule.EnvelopeCurveForm.Form']/container[@controlname='EnvelopeCurveModule.CurveDisplayExtension.EnvelopeCurveComposite']/container[@controlname='EnvelopeCurveModule.GroupControlBase.CurveData']/element[@controlname='EnvelopeCurveModule.LabelControlBase.CurveDataValue1']", 30000, null, "5dc7d9cb-4d39-46d5-91cc-2365f7e16fb6");
            _progressbarcontainerInfo = new RepoItemInfo(this, "ProgressbarContainer", "/container[@automationid='EnvelopeCurveModule.EnvelopeCurveForm.Form']/container[@controlname='EnvelopeCurveModule.CurveDisplayExtension.EnvelopeCurveComposite']/container[@controlname='EnvelopeCurveModule.SplitContainerControlBase.VerticalSplitter']/?/?/container[@controlname='diagramControl']", 30000, null, "4dd33315-3300-46a0-ba33-7f7df423066a");
            _curvecontainerInfo = new RepoItemInfo(this, "CurveContainer", "/container[@automationid='EnvelopeCurveModule.EnvelopeCurveForm.Form']/container[@controlname='EnvelopeCurveModule.CurveDisplayExtension.EnvelopeCurveComposite']/container[@controlname='EnvelopeCurveModule.SplitContainerControlBase.VerticalSplitter']/?/?/container[@controlname='diagramControl']", 30000, null, "01dd8961-53f1-4e43-a98d-c4134a1967b5");
            _diagramcontrolInfo = new RepoItemInfo(this, "DiagramControl", "/container[@automationid='EnvelopeCurveModule.EnvelopeCurveForm.Form']/container[@controlname='EnvelopeCurveModule.CurveDisplayExtension.EnvelopeCurveComposite']/container[@controlname='EnvelopeCurveModule.SplitContainerControlBase.VerticalSplitter']/?/?/container[@controlname='diagramControl']", 30000, null, "953195e2-3c7f-4214-9d7e-c8a868955423");
            _envelopecurvemodulecontainerInfo = new RepoItemInfo(this, "EnvelopeCurveModuleContainer", "/container[@automationid='EnvelopeCurveModule.EnvelopeCurveForm.Form']", 2000, null, "7cdbe01a-6ae6-4adf-8159-8d702d58d995");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("0a838cfd-8f7b-4906-83b8-7612e8d28287")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The CurveDataNumber item.
        /// </summary>
        [RepositoryItem("5dc7d9cb-4d39-46d5-91cc-2365f7e16fb6")]
        public virtual Ranorex.Unknown CurveDataNumber
        {
            get
            {
                 return _curvedatanumberInfo.CreateAdapter<Ranorex.Unknown>(true);
            }
        }

        /// <summary>
        /// The CurveDataNumber item info.
        /// </summary>
        [RepositoryItemInfo("5dc7d9cb-4d39-46d5-91cc-2365f7e16fb6")]
        public virtual RepoItemInfo CurveDataNumberInfo
        {
            get
            {
                return _curvedatanumberInfo;
            }
        }

        /// <summary>
        /// The ProgressbarContainer item.
        /// </summary>
        [RepositoryItem("4dd33315-3300-46a0-ba33-7f7df423066a")]
        public virtual Ranorex.Container ProgressbarContainer
        {
            get
            {
                 return _progressbarcontainerInfo.CreateAdapter<Ranorex.Container>(true);
            }
        }

        /// <summary>
        /// The ProgressbarContainer item info.
        /// </summary>
        [RepositoryItemInfo("4dd33315-3300-46a0-ba33-7f7df423066a")]
        public virtual RepoItemInfo ProgressbarContainerInfo
        {
            get
            {
                return _progressbarcontainerInfo;
            }
        }

        /// <summary>
        /// The CurveContainer item.
        /// </summary>
        [RepositoryItem("01dd8961-53f1-4e43-a98d-c4134a1967b5")]
        public virtual Ranorex.Container CurveContainer
        {
            get
            {
                 return _curvecontainerInfo.CreateAdapter<Ranorex.Container>(true);
            }
        }

        /// <summary>
        /// The CurveContainer item info.
        /// </summary>
        [RepositoryItemInfo("01dd8961-53f1-4e43-a98d-c4134a1967b5")]
        public virtual RepoItemInfo CurveContainerInfo
        {
            get
            {
                return _curvecontainerInfo;
            }
        }

        /// <summary>
        /// The DiagramControl item.
        /// </summary>
        [RepositoryItem("953195e2-3c7f-4214-9d7e-c8a868955423")]
        public virtual Ranorex.Container DiagramControl
        {
            get
            {
                 return _diagramcontrolInfo.CreateAdapter<Ranorex.Container>(true);
            }
        }

        /// <summary>
        /// The DiagramControl item info.
        /// </summary>
        [RepositoryItemInfo("953195e2-3c7f-4214-9d7e-c8a868955423")]
        public virtual RepoItemInfo DiagramControlInfo
        {
            get
            {
                return _diagramcontrolInfo;
            }
        }

        /// <summary>
        /// The EnvelopeCurveModuleContainer item.
        /// </summary>
        [RepositoryItem("7cdbe01a-6ae6-4adf-8159-8d702d58d995")]
        public virtual Ranorex.Container EnvelopeCurveModuleContainer
        {
            get
            {
                 return _envelopecurvemodulecontainerInfo.CreateAdapter<Ranorex.Container>(true);
            }
        }

        /// <summary>
        /// The EnvelopeCurveModuleContainer item info.
        /// </summary>
        [RepositoryItemInfo("7cdbe01a-6ae6-4adf-8159-8d702d58d995")]
        public virtual RepoItemInfo EnvelopeCurveModuleContainerInfo
        {
            get
            {
                return _envelopecurvemodulecontainerInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ControlsFolders
    {
    }
#pragma warning restore 0436
}