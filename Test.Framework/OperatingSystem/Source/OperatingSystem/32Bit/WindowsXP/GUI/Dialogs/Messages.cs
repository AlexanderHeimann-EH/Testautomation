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

namespace EH.PCPS.TestAutomation.WindowsXP.GUI.Dialogs
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the Messages element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("dab644b0-0297-4856-ac4f-3a65318a3e51")]
    public partial class Messages : RepoGenBaseFolder
    {
        static Messages instance = new Messages();
        MessagesFolders.OpenMessagesFolder _openmessages;
        MessagesFolders.SaveAsMessagesFolder _saveasmessages;

        /// <summary>
        /// Gets the singleton class instance representing the Messages element repository.
        /// </summary>
        [RepositoryFolder("dab644b0-0297-4856-ac4f-3a65318a3e51")]
        public static Messages Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public Messages() 
            : base("Messages", "/", null, 0, false, "dab644b0-0297-4856-ac4f-3a65318a3e51", ".\\RepositoryImages\\Messagesdab644b0.rximgres")
        {
            _openmessages = new MessagesFolders.OpenMessagesFolder(this);
            _saveasmessages = new MessagesFolders.SaveAsMessagesFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("dab644b0-0297-4856-ac4f-3a65318a3e51")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The OpenMessages folder.
        /// </summary>
        [RepositoryFolder("809cf477-f0c6-42a2-a1f6-b78b0aeee18f")]
        public virtual MessagesFolders.OpenMessagesFolder OpenMessages
        {
            get { return _openmessages; }
        }

        /// <summary>
        /// The SaveAsMessages folder.
        /// </summary>
        [RepositoryFolder("d8a7c1ac-842c-4bf3-bc43-a50b3c96098b")]
        public virtual MessagesFolders.SaveAsMessagesFolder SaveAsMessages
        {
            get { return _saveasmessages; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class MessagesFolders
    {
        /// <summary>
        /// The OpenMessagesFolder folder.
        /// </summary>
        [RepositoryFolder("809cf477-f0c6-42a2-a1f6-b78b0aeee18f")]
        public partial class OpenMessagesFolder : RepoGenBaseFolder
        {
            MessagesFolders.OpenAppFolder _open;

            /// <summary>
            /// Creates a new OpenMessages  folder.
            /// </summary>
            public OpenMessagesFolder(RepoGenBaseFolder parentFolder) :
                    base("OpenMessages", "", parentFolder, 0, null, false, "809cf477-f0c6-42a2-a1f6-b78b0aeee18f", "")
            {
                _open = new MessagesFolders.OpenAppFolder(this);
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("809cf477-f0c6-42a2-a1f6-b78b0aeee18f")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The Open folder.
            /// </summary>
            [RepositoryFolder("1cbef4bc-da73-45f4-bb45-4841e5d53bf3")]
            public virtual MessagesFolders.OpenAppFolder Open
            {
                get { return _open; }
            }
        }

        /// <summary>
        /// The OpenAppFolder folder.
        /// </summary>
        [RepositoryFolder("1cbef4bc-da73-45f4-bb45-4841e5d53bf3")]
        public partial class OpenAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _buttonokInfo;

            /// <summary>
            /// Creates a new Open  folder.
            /// </summary>
            public OpenAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Open", "/form", parentFolder, 5000, null, true, "1cbef4bc-da73-45f4-bb45-4841e5d53bf3", "")
            {
                _buttonokInfo = new RepoItemInfo(this, "buttonOK", "button[@controlid='2']", 5000, null, "1a5ff758-5f68-4f54-a336-ef012e892e62");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("1cbef4bc-da73-45f4-bb45-4841e5d53bf3")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("1cbef4bc-da73-45f4-bb45-4841e5d53bf3")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The buttonOK item.
            /// </summary>
            [RepositoryItem("1a5ff758-5f68-4f54-a336-ef012e892e62")]
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
            [RepositoryItemInfo("1a5ff758-5f68-4f54-a336-ef012e892e62")]
            public virtual RepoItemInfo buttonOKInfo
            {
                get
                {
                    return _buttonokInfo;
                }
            }
        }

        /// <summary>
        /// The SaveAsMessagesFolder folder.
        /// </summary>
        [RepositoryFolder("d8a7c1ac-842c-4bf3-bc43-a50b3c96098b")]
        public partial class SaveAsMessagesFolder : RepoGenBaseFolder
        {
            MessagesFolders.ConfirmSaveAsAppFolder _confirmsaveas;

            /// <summary>
            /// Creates a new SaveAsMessages  folder.
            /// </summary>
            public SaveAsMessagesFolder(RepoGenBaseFolder parentFolder) :
                    base("SaveAsMessages", "", parentFolder, 0, null, false, "d8a7c1ac-842c-4bf3-bc43-a50b3c96098b", "")
            {
                _confirmsaveas = new MessagesFolders.ConfirmSaveAsAppFolder(this);
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("d8a7c1ac-842c-4bf3-bc43-a50b3c96098b")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The ConfirmSaveAs folder.
            /// </summary>
            [RepositoryFolder("c4f55adf-780a-4862-accb-588f3f338387")]
            public virtual MessagesFolders.ConfirmSaveAsAppFolder ConfirmSaveAs
            {
                get { return _confirmsaveas; }
            }
        }

        /// <summary>
        /// The ConfirmSaveAsAppFolder folder.
        /// </summary>
        [RepositoryFolder("c4f55adf-780a-4862-accb-588f3f338387")]
        public partial class ConfirmSaveAsAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _buttonyesInfo;
            RepoItemInfo _buttonnoInfo;

            /// <summary>
            /// Creates a new ConfirmSaveAs  folder.
            /// </summary>
            public ConfirmSaveAsAppFolder(RepoGenBaseFolder parentFolder) :
                    base("ConfirmSaveAs", "/form", parentFolder, 5000, null, true, "c4f55adf-780a-4862-accb-588f3f338387", "")
            {
                _buttonyesInfo = new RepoItemInfo(this, "buttonYes", "button[@controlid='6']", 5000, null, "a9d895a0-db2e-414c-91c8-18c79abfe18a");
                _buttonnoInfo = new RepoItemInfo(this, "buttonNo", "button[@controlid='7']", 5000, null, "b99ecf2d-0ff0-4081-8399-3e2fa6914dc4");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("c4f55adf-780a-4862-accb-588f3f338387")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("c4f55adf-780a-4862-accb-588f3f338387")]
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
            [RepositoryItem("a9d895a0-db2e-414c-91c8-18c79abfe18a")]
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
            [RepositoryItemInfo("a9d895a0-db2e-414c-91c8-18c79abfe18a")]
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
            [RepositoryItem("b99ecf2d-0ff0-4081-8399-3e2fa6914dc4")]
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
            [RepositoryItemInfo("b99ecf2d-0ff0-4081-8399-3e2fa6914dc4")]
            public virtual RepoItemInfo buttonNoInfo
            {
                get
                {
                    return _buttonnoInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}