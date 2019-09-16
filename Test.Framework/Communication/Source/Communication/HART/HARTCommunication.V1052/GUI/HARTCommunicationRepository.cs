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

namespace EH.PCPS.TestAutomation.HARTCommunication.V1052.GUI
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the HARTCommunicationRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("1cc51f52-1ef4-49f1-8c9f-346fe05fdbe0")]
    public partial class HARTCommunicationRepository : RepoGenBaseFolder
    {
        static HARTCommunicationRepository instance = new HARTCommunicationRepository();
        HARTCommunicationRepositoryFolders.HART_MenuAreaFolder _hart_menuarea;
        HARTCommunicationRepositoryFolders.HART_ApplicationAreaFolder _hart_applicationarea;
        HARTCommunicationRepositoryFolders.ListitemsAppFolder _listitems;
        HARTCommunicationRepositoryFolders.DialogBoxAppFolder _dialogbox;

        /// <summary>
        /// Gets the singleton class instance representing the HARTCommunicationRepository element repository.
        /// </summary>
        [RepositoryFolder("1cc51f52-1ef4-49f1-8c9f-346fe05fdbe0")]
        public static HARTCommunicationRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public HARTCommunicationRepository() 
            : base("HARTCommunicationRepository", "/", null, 0, false, "1cc51f52-1ef4-49f1-8c9f-346fe05fdbe0", ".\\RepositoryImages\\HARTCommunicationRepository1cc51f52.rximgres")
        {
            _hart_menuarea = new HARTCommunicationRepositoryFolders.HART_MenuAreaFolder(this);
            _hart_applicationarea = new HARTCommunicationRepositoryFolders.HART_ApplicationAreaFolder(this);
            _listitems = new HARTCommunicationRepositoryFolders.ListitemsAppFolder(this);
            _dialogbox = new HARTCommunicationRepositoryFolders.DialogBoxAppFolder(this);
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("1cc51f52-1ef4-49f1-8c9f-346fe05fdbe0")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The HART_MenuArea folder.
        /// </summary>
        [RepositoryFolder("1b7935d8-e09b-42ce-8c13-feb727350d5e")]
        public virtual HARTCommunicationRepositoryFolders.HART_MenuAreaFolder HART_MenuArea
        {
            get { return _hart_menuarea; }
        }

        /// <summary>
        /// The HART_ApplicationArea folder.
        /// </summary>
        [RepositoryFolder("a6151bbe-79fe-497f-90cf-3d43e4075fe5")]
        public virtual HARTCommunicationRepositoryFolders.HART_ApplicationAreaFolder HART_ApplicationArea
        {
            get { return _hart_applicationarea; }
        }

        /// <summary>
        /// The Listitems folder.
        /// </summary>
        [RepositoryFolder("d2e50fad-8e50-4c26-95ac-cba4d72aadf7")]
        public virtual HARTCommunicationRepositoryFolders.ListitemsAppFolder Listitems
        {
            get { return _listitems; }
        }

        /// <summary>
        /// The DialogBox folder.
        /// </summary>
        [RepositoryFolder("9b25d99a-7819-4968-9f2e-35009e377e4d")]
        public virtual HARTCommunicationRepositoryFolders.DialogBoxAppFolder DialogBox
        {
            get { return _dialogbox; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class HARTCommunicationRepositoryFolders
    {
        /// <summary>
        /// The HART_MenuAreaFolder folder.
        /// </summary>
        [RepositoryFolder("1b7935d8-e09b-42ce-8c13-feb727350d5e")]
        public partial class HART_MenuAreaFolder : RepoGenBaseFolder
        {
            RepoItemInfo _buttonapplyInfo;
            RepoItemInfo _buttoncancelInfo;
            RepoItemInfo _buttonokInfo;

            /// <summary>
            /// Creates a new HART_MenuArea  folder.
            /// </summary>
            public HART_MenuAreaFolder(RepoGenBaseFolder parentFolder) :
                    base("HART_MenuArea", "/element[@childindex='0' and @class='ThunderRT6PictureBoxDC']", parentFolder, 30000, null, false, "1b7935d8-e09b-42ce-8c13-feb727350d5e", "")
            {
                _buttonapplyInfo = new RepoItemInfo(this, "ButtonApply", "button[@text='&Apply' and @class='ThunderRT6CommandButton']", 30000, null, "c8d912dd-b786-452a-8d4b-5df67816ca0b");
                _buttoncancelInfo = new RepoItemInfo(this, "ButtonCancel", "button[@text='&Cancel' and @class='ThunderRT6CommandButton']", 30000, null, "c25e6ac5-04d1-4029-8d83-a0c2650ceeca");
                _buttonokInfo = new RepoItemInfo(this, "ButtonOK", "button[@text='&OK' and @class='ThunderRT6CommandButton']", 30000, null, "df157cd2-0ec7-4dac-8925-cab021aabb4c");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("1b7935d8-e09b-42ce-8c13-feb727350d5e")]
            public virtual Ranorex.Unknown Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("1b7935d8-e09b-42ce-8c13-feb727350d5e")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The ButtonApply item.
            /// </summary>
            [RepositoryItem("c8d912dd-b786-452a-8d4b-5df67816ca0b")]
            public virtual Ranorex.Button ButtonApply
            {
                get
                {
                    return _buttonapplyInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonApply item info.
            /// </summary>
            [RepositoryItemInfo("c8d912dd-b786-452a-8d4b-5df67816ca0b")]
            public virtual RepoItemInfo ButtonApplyInfo
            {
                get
                {
                    return _buttonapplyInfo;
                }
            }

            /// <summary>
            /// The ButtonCancel item.
            /// </summary>
            [RepositoryItem("c25e6ac5-04d1-4029-8d83-a0c2650ceeca")]
            public virtual Ranorex.Button ButtonCancel
            {
                get
                {
                    return _buttoncancelInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonCancel item info.
            /// </summary>
            [RepositoryItemInfo("c25e6ac5-04d1-4029-8d83-a0c2650ceeca")]
            public virtual RepoItemInfo ButtonCancelInfo
            {
                get
                {
                    return _buttoncancelInfo;
                }
            }

            /// <summary>
            /// The ButtonOK item.
            /// </summary>
            [RepositoryItem("df157cd2-0ec7-4dac-8925-cab021aabb4c")]
            public virtual Ranorex.Button ButtonOK
            {
                get
                {
                    return _buttonokInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonOK item info.
            /// </summary>
            [RepositoryItemInfo("df157cd2-0ec7-4dac-8925-cab021aabb4c")]
            public virtual RepoItemInfo ButtonOKInfo
            {
                get
                {
                    return _buttonokInfo;
                }
            }
        }

        /// <summary>
        /// The HART_ApplicationAreaFolder folder.
        /// </summary>
        [RepositoryFolder("a6151bbe-79fe-497f-90cf-3d43e4075fe5")]
        public partial class HART_ApplicationAreaFolder : RepoGenBaseFolder
        {
            HARTCommunicationRepositoryFolders.DTMFrameboxFolder _dtmframebox;

            /// <summary>
            /// Creates a new HART_ApplicationArea  folder.
            /// </summary>
            public HART_ApplicationAreaFolder(RepoGenBaseFolder parentFolder) :
                    base("HART_ApplicationArea", "/element[@childindex='1' and @class='ThunderRT6PictureBoxDC']", parentFolder, 30000, null, false, "a6151bbe-79fe-497f-90cf-3d43e4075fe5", "")
            {
                _dtmframebox = new HARTCommunicationRepositoryFolders.DTMFrameboxFolder(this);
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("a6151bbe-79fe-497f-90cf-3d43e4075fe5")]
            public virtual Ranorex.Unknown Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("a6151bbe-79fe-497f-90cf-3d43e4075fe5")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The DTMFramebox folder.
            /// </summary>
            [RepositoryFolder("afd45281-a708-4a57-9e68-68d96178ce42")]
            public virtual HARTCommunicationRepositoryFolders.DTMFrameboxFolder DTMFramebox
            {
                get { return _dtmframebox; }
            }
        }

        /// <summary>
        /// The DTMFrameboxFolder folder.
        /// </summary>
        [RepositoryFolder("afd45281-a708-4a57-9e68-68d96178ce42")]
        public partial class DTMFrameboxFolder : RepoGenBaseFolder
        {
            HARTCommunicationRepositoryFolders.AddressContainerFolder _addresscontainer;
            HARTCommunicationRepositoryFolders.InterfaceContainerFolder _interfacecontainer;

            /// <summary>
            /// Creates a new DTMFramebox  folder.
            /// </summary>
            public DTMFrameboxFolder(RepoGenBaseFolder parentFolder) :
                    base("DTMFramebox", "element[@childindex='0' and @class='ThunderRT6Frame']", parentFolder, 30000, null, false, "afd45281-a708-4a57-9e68-68d96178ce42", "")
            {
                _addresscontainer = new HARTCommunicationRepositoryFolders.AddressContainerFolder(this);
                _interfacecontainer = new HARTCommunicationRepositoryFolders.InterfaceContainerFolder(this);
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("afd45281-a708-4a57-9e68-68d96178ce42")]
            public virtual Ranorex.Unknown Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("afd45281-a708-4a57-9e68-68d96178ce42")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The AddressContainer folder.
            /// </summary>
            [RepositoryFolder("fceb1bc6-6f77-4046-b5e3-ecb347d3c262")]
            public virtual HARTCommunicationRepositoryFolders.AddressContainerFolder AddressContainer
            {
                get { return _addresscontainer; }
            }

            /// <summary>
            /// The InterfaceContainer folder.
            /// </summary>
            [RepositoryFolder("bdccb5e4-7314-4ed9-a677-38e0456fdb54")]
            public virtual HARTCommunicationRepositoryFolders.InterfaceContainerFolder InterfaceContainer
            {
                get { return _interfacecontainer; }
            }
        }

        /// <summary>
        /// The AddressContainerFolder folder.
        /// </summary>
        [RepositoryFolder("fceb1bc6-6f77-4046-b5e3-ecb347d3c262")]
        public partial class AddressContainerFolder : RepoGenBaseFolder
        {
            RepoItemInfo _endaddressInfo;
            RepoItemInfo _startaddressInfo;

            /// <summary>
            /// Creates a new AddressContainer  folder.
            /// </summary>
            public AddressContainerFolder(RepoGenBaseFolder parentFolder) :
                    base("AddressContainer", "element[@childindex='0' and @class='ThunderRT6PictureBoxDC']", parentFolder, 30000, null, false, "fceb1bc6-6f77-4046-b5e3-ecb347d3c262", "")
            {
                _endaddressInfo = new RepoItemInfo(this, "EndAddress", "element[@childindex='1' and @class='ThunderRT6ComboBox']/combobox[@accessiblerole='ComboBox']", 30000, null, "65302177-4c4f-40cb-a794-49e1b9527651");
                _startaddressInfo = new RepoItemInfo(this, "StartAddress", "element[@childindex='2' and @class='ThunderRT6ComboBox']/combobox[@accessiblerole='ComboBox']", 30000, null, "900f809c-4007-48e4-bfc1-8ab8ed1155a0");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("fceb1bc6-6f77-4046-b5e3-ecb347d3c262")]
            public virtual Ranorex.Unknown Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("fceb1bc6-6f77-4046-b5e3-ecb347d3c262")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The EndAddress item.
            /// </summary>
            [RepositoryItem("65302177-4c4f-40cb-a794-49e1b9527651")]
            public virtual Ranorex.ComboBox EndAddress
            {
                get
                {
                    return _endaddressInfo.CreateAdapter<Ranorex.ComboBox>(true);
                }
            }

            /// <summary>
            /// The EndAddress item info.
            /// </summary>
            [RepositoryItemInfo("65302177-4c4f-40cb-a794-49e1b9527651")]
            public virtual RepoItemInfo EndAddressInfo
            {
                get
                {
                    return _endaddressInfo;
                }
            }

            /// <summary>
            /// The StartAddress item.
            /// </summary>
            [RepositoryItem("900f809c-4007-48e4-bfc1-8ab8ed1155a0")]
            public virtual Ranorex.ComboBox StartAddress
            {
                get
                {
                    return _startaddressInfo.CreateAdapter<Ranorex.ComboBox>(true);
                }
            }

            /// <summary>
            /// The StartAddress item info.
            /// </summary>
            [RepositoryItemInfo("900f809c-4007-48e4-bfc1-8ab8ed1155a0")]
            public virtual RepoItemInfo StartAddressInfo
            {
                get
                {
                    return _startaddressInfo;
                }
            }
        }

        /// <summary>
        /// The InterfaceContainerFolder folder.
        /// </summary>
        [RepositoryFolder("bdccb5e4-7314-4ed9-a677-38e0456fdb54")]
        public partial class InterfaceContainerFolder : RepoGenBaseFolder
        {
            RepoItemInfo _communicationinterfaceInfo;
            RepoItemInfo _serialinterfaceInfo;

            /// <summary>
            /// Creates a new InterfaceContainer  folder.
            /// </summary>
            public InterfaceContainerFolder(RepoGenBaseFolder parentFolder) :
                    base("InterfaceContainer", "element[@childindex='2' and @class='ThunderRT6PictureBoxDC']", parentFolder, 30000, null, false, "bdccb5e4-7314-4ed9-a677-38e0456fdb54", "")
            {
                _communicationinterfaceInfo = new RepoItemInfo(this, "CommunicationInterface", "element[@childindex='3' and @class='ThunderRT6ComboBox']/combobox[@accessiblerole='ComboBox']", 30000, null, "74d5df22-9933-4895-878f-b49377a5a825");
                _serialinterfaceInfo = new RepoItemInfo(this, "SerialInterface", "element[@childindex='5' and @class='ThunderRT6ComboBox']/combobox[@accessiblerole='ComboBox']", 30000, null, "c3cd6acc-8608-4d29-87fb-6b72ca9de86e");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("bdccb5e4-7314-4ed9-a677-38e0456fdb54")]
            public virtual Ranorex.Unknown Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("bdccb5e4-7314-4ed9-a677-38e0456fdb54")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The CommunicationInterface item.
            /// </summary>
            [RepositoryItem("74d5df22-9933-4895-878f-b49377a5a825")]
            public virtual Ranorex.ComboBox CommunicationInterface
            {
                get
                {
                    return _communicationinterfaceInfo.CreateAdapter<Ranorex.ComboBox>(true);
                }
            }

            /// <summary>
            /// The CommunicationInterface item info.
            /// </summary>
            [RepositoryItemInfo("74d5df22-9933-4895-878f-b49377a5a825")]
            public virtual RepoItemInfo CommunicationInterfaceInfo
            {
                get
                {
                    return _communicationinterfaceInfo;
                }
            }

            /// <summary>
            /// The SerialInterface item.
            /// </summary>
            [RepositoryItem("c3cd6acc-8608-4d29-87fb-6b72ca9de86e")]
            public virtual Ranorex.ComboBox SerialInterface
            {
                get
                {
                    return _serialinterfaceInfo.CreateAdapter<Ranorex.ComboBox>(true);
                }
            }

            /// <summary>
            /// The SerialInterface item info.
            /// </summary>
            [RepositoryItemInfo("c3cd6acc-8608-4d29-87fb-6b72ca9de86e")]
            public virtual RepoItemInfo SerialInterfaceInfo
            {
                get
                {
                    return _serialinterfaceInfo;
                }
            }
        }

        /// <summary>
        /// The ListitemsAppFolder folder.
        /// </summary>
        [RepositoryFolder("d2e50fad-8e50-4c26-95ac-cba4d72aadf7")]
        public partial class ListitemsAppFolder : RepoGenBaseFolder
        {

            /// <summary>
            /// Creates a new Listitems  folder.
            /// </summary>
            public ListitemsAppFolder(RepoGenBaseFolder parentFolder) :
                    base("Listitems", "/list[@controlid='1000' and @processname='FMPFrame' and @class='ComboLBox']", parentFolder, 30000, null, true, "d2e50fad-8e50-4c26-95ac-cba4d72aadf7", "")
            {
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("d2e50fad-8e50-4c26-95ac-cba4d72aadf7")]
            public virtual Ranorex.List Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.List>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("d2e50fad-8e50-4c26-95ac-cba4d72aadf7")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }
        }

        /// <summary>
        /// The DialogBoxAppFolder folder.
        /// </summary>
        [RepositoryFolder("9b25d99a-7819-4968-9f2e-35009e377e4d")]
        public partial class DialogBoxAppFolder : RepoGenBaseFolder
        {
            RepoItemInfo _buttonyesInfo;
            RepoItemInfo _buttonnoInfo;
            RepoItemInfo _buttoncancelInfo;
            RepoItemInfo _buttoncloseInfo;

            /// <summary>
            /// Creates a new DialogBox  folder.
            /// </summary>
            public DialogBoxAppFolder(RepoGenBaseFolder parentFolder) :
                    base("DialogBox", "/form[@title='CWHartFdt' and @processname='FMPFrame' and @class='#32770']", parentFolder, 30000, null, true, "9b25d99a-7819-4968-9f2e-35009e377e4d", "")
            {
                _buttonyesInfo = new RepoItemInfo(this, "ButtonYes", "button[@text='&Yes' and @class='Button']", 30000, null, "ccf04380-8ce8-4441-807d-29a7bdce843b");
                _buttonnoInfo = new RepoItemInfo(this, "ButtonNo", "button[@text='&No' and @class='Button']", 30000, null, "f043796e-3eb2-4287-b580-6f38100a55d2");
                _buttoncancelInfo = new RepoItemInfo(this, "ButtonCancel", "button[@text='Cancel' and @class='Button']", 30000, null, "3c9f0b29-72a9-4205-b7f9-7a33563763b4");
                _buttoncloseInfo = new RepoItemInfo(this, "ButtonClose", "titlebar[@accessiblerole='TitleBar' and @text='CWHartFdt']/button[@accessiblename='Close' and @text='Close']", 30000, null, "5f687f10-529f-41c1-baf5-9b6dc4027dc0");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("9b25d99a-7819-4968-9f2e-35009e377e4d")]
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
            [RepositoryItemInfo("9b25d99a-7819-4968-9f2e-35009e377e4d")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The ButtonYes item.
            /// </summary>
            [RepositoryItem("ccf04380-8ce8-4441-807d-29a7bdce843b")]
            public virtual Ranorex.Button ButtonYes
            {
                get
                {
                    return _buttonyesInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonYes item info.
            /// </summary>
            [RepositoryItemInfo("ccf04380-8ce8-4441-807d-29a7bdce843b")]
            public virtual RepoItemInfo ButtonYesInfo
            {
                get
                {
                    return _buttonyesInfo;
                }
            }

            /// <summary>
            /// The ButtonNo item.
            /// </summary>
            [RepositoryItem("f043796e-3eb2-4287-b580-6f38100a55d2")]
            public virtual Ranorex.Button ButtonNo
            {
                get
                {
                    return _buttonnoInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonNo item info.
            /// </summary>
            [RepositoryItemInfo("f043796e-3eb2-4287-b580-6f38100a55d2")]
            public virtual RepoItemInfo ButtonNoInfo
            {
                get
                {
                    return _buttonnoInfo;
                }
            }

            /// <summary>
            /// The ButtonCancel item.
            /// </summary>
            [RepositoryItem("3c9f0b29-72a9-4205-b7f9-7a33563763b4")]
            public virtual Ranorex.Button ButtonCancel
            {
                get
                {
                    return _buttoncancelInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonCancel item info.
            /// </summary>
            [RepositoryItemInfo("3c9f0b29-72a9-4205-b7f9-7a33563763b4")]
            public virtual RepoItemInfo ButtonCancelInfo
            {
                get
                {
                    return _buttoncancelInfo;
                }
            }

            /// <summary>
            /// The ButtonClose item.
            /// </summary>
            [RepositoryItem("5f687f10-529f-41c1-baf5-9b6dc4027dc0")]
            public virtual Ranorex.Button ButtonClose
            {
                get
                {
                    return _buttoncloseInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The ButtonClose item info.
            /// </summary>
            [RepositoryItemInfo("5f687f10-529f-41c1-baf5-9b6dc4027dc0")]
            public virtual RepoItemInfo ButtonCloseInfo
            {
                get
                {
                    return _buttoncloseInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}