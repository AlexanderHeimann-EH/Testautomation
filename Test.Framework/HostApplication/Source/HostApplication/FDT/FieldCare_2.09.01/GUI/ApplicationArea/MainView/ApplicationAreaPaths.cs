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

namespace EH.PCPS.TestAutomation.FieldCare.V20901.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the ApplicationAreaPaths element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("b87112a2-0a48-486f-9bec-5e6d3574bcc4")]
    public partial class ApplicationAreaPaths : RepoGenBaseFolder
    {
        static ApplicationAreaPaths instance = new ApplicationAreaPaths();
        RepoItemInfo _framemainwindowInfo;

        /// <summary>
        /// Gets the singleton class instance representing the ApplicationAreaPaths element repository.
        /// </summary>
        [RepositoryFolder("b87112a2-0a48-486f-9bec-5e6d3574bcc4")]
        public static ApplicationAreaPaths Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public ApplicationAreaPaths() 
            : base("ApplicationAreaPaths", "/", null, 0, false, "b87112a2-0a48-486f-9bec-5e6d3574bcc4", ".\\RepositoryImages\\ApplicationAreaPathsb87112a2.rximgres")
        {
            _framemainwindowInfo = new RepoItemInfo(this, "FrameMainWindow", "/form[@processname='FMPFrame']", 30000, null, "9e88ec4e-89cd-465a-b487-d1bba5b62f49");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("b87112a2-0a48-486f-9bec-5e6d3574bcc4")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The FrameMainWindow item.
        /// </summary>
        [RepositoryItem("9e88ec4e-89cd-465a-b487-d1bba5b62f49")]
        public virtual Ranorex.Form FrameMainWindow
        {
            get
            {
                 return _framemainwindowInfo.CreateAdapter<Ranorex.Form>(true);
            }
        }

        /// <summary>
        /// The FrameMainWindow item info.
        /// </summary>
        [RepositoryItemInfo("9e88ec4e-89cd-465a-b487-d1bba5b62f49")]
        public virtual RepoItemInfo FrameMainWindowInfo
        {
            get
            {
                return _framemainwindowInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class ApplicationAreaPathsFolders
    {
    }
#pragma warning restore 0436
}