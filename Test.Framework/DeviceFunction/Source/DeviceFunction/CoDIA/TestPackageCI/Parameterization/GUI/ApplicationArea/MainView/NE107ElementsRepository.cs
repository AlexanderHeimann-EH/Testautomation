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

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.ApplicationArea.MainView
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the NE107ElementsRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    [RepositoryFolder("c0e1ba20-8203-4f56-86c1-65b0cbc75c70")]
    public partial class NE107ElementsRepository : RepoGenBaseFolder
    {
        static NE107ElementsRepository instance = new NE107ElementsRepository();
        NE107ElementsRepositoryFolders.SimulationFolder _simulation;
        NE107ElementsRepositoryFolders.ElectronicsFolder _electronics;
        NE107ElementsRepositoryFolders.ProcessFolder _process;
        NE107ElementsRepositoryFolders.ConfigurationFolder _configuration;
        NE107ElementsRepositoryFolders.SensorFolder _sensor;
        RepoItemInfo _tabcontrolInfo;
        RepoItemInfo _buttonapplyInfo;
        RepoItemInfo _buttoncancelInfo;
        RepoItemInfo _eventelementInfo;
        RepoItemInfo _eventradiobuttonInfo;
        RepoItemInfo _eventelementsInfo;
        RepoItemInfo _activeeventradiobuttonInfo;

        /// <summary>
        /// Gets the singleton class instance representing the NE107ElementsRepository element repository.
        /// </summary>
        [RepositoryFolder("c0e1ba20-8203-4f56-86c1-65b0cbc75c70")]
        public static NE107ElementsRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public NE107ElementsRepository() 
            : base("NE107ElementsRepository", "/", null, 0, false, "c0e1ba20-8203-4f56-86c1-65b0cbc75c70", ".\\RepositoryImages\\NE107ElementsRepositoryc0e1ba20.rximgres")
        {
            _simulation = new NE107ElementsRepositoryFolders.SimulationFolder(this);
            _electronics = new NE107ElementsRepositoryFolders.ElectronicsFolder(this);
            _process = new NE107ElementsRepositoryFolders.ProcessFolder(this);
            _configuration = new NE107ElementsRepositoryFolders.ConfigurationFolder(this);
            _sensor = new NE107ElementsRepositoryFolders.SensorFolder(this);
            _tabcontrolInfo = new RepoItemInfo(this, "TabControl", "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/container[@controlname='EddMenuPanel_ScrollContainer']/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//container/?/?/container[@controlname='_PluginControl']/?/?/element[@controlname='mainTabControl']", 30000, null, "7729e468-edc4-48d3-9367-f0f9f8e85a9d");
            _buttonapplyInfo = new RepoItemInfo(this, "ButtonApply", "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/container[@controlname='EddMenuPanel_ScrollContainer']/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//container/?/?/container[@controlname='_PluginControl']/?/?/container[@controlname='panelActionArea']/?/?/button[@accessiblename='Apply']", 30000, null, "cc4ecb5c-784e-4612-b1c4-6073c6f2f9f2");
            _buttoncancelInfo = new RepoItemInfo(this, "ButtonCancel", "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/container[@controlname='EddMenuPanel_ScrollContainer']/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//container/?/?/container[@controlname='_PluginControl']/?/?/container[@controlname='panelActionArea']/?/?/button[@accessiblename='Cancel']", 30000, null, "f3e93af9-ec58-4da1-ab2b-f6208ff4ac30");
            _eventelementInfo = new RepoItemInfo(this, "EventElement", "/container[@controltypename='DtmUserInterface']/container/container/container/container/container/container/container/container/container/container/element/container/container/container/element/text[@accessiblename='REPLACEACCESSIBLENAME']/..", 30000, null, "2ee1f7e5-442d-4e7b-b7de-996920c9e730");
            _eventradiobuttonInfo = new RepoItemInfo(this, "EventRadioButton", "/container[@controltypename='DtmUserInterface']/container/container/container/container/container/container/container/container/container/container/element/container/container/container/element[@controlname='REPLACECONTROLNAME']/radiobutton", 30000, null, "3aa0d56a-909b-4ea4-afc3-a96af2710265");
            _eventelementsInfo = new RepoItemInfo(this, "EventElements", "/container[@controltypename='DtmUserInterface']/container/container/container/container/container/container/container/container/container/container/element/container/container/container/element[@controlname~'REPLACECONTROLNAME']/radiobutton/..", 30000, null, "1a09df98-907d-4ed0-bc1f-2c614aa63a73");
            _activeeventradiobuttonInfo = new RepoItemInfo(this, "ActiveEventRadioButton", "/container[@controltypename='DtmUserInterface']/container/container/container/container/container/container/container/container/container/container/element/container/container/container/element[@controlname~'REPLACECONTROLNAME']/radiobutton[@accessiblestate~'Checked']/..", 30000, null, "c1ae1dc2-2929-418b-83ab-8a140af08a0a");
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("c0e1ba20-8203-4f56-86c1-65b0cbc75c70")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The TabControl item.
        /// </summary>
        [RepositoryItem("7729e468-edc4-48d3-9367-f0f9f8e85a9d")]
        public virtual Ranorex.Unknown TabControl
        {
            get
            {
                 return _tabcontrolInfo.CreateAdapter<Ranorex.Unknown>(true);
            }
        }

        /// <summary>
        /// The TabControl item info.
        /// </summary>
        [RepositoryItemInfo("7729e468-edc4-48d3-9367-f0f9f8e85a9d")]
        public virtual RepoItemInfo TabControlInfo
        {
            get
            {
                return _tabcontrolInfo;
            }
        }

        /// <summary>
        /// The ButtonApply item.
        /// </summary>
        [RepositoryItem("cc4ecb5c-784e-4612-b1c4-6073c6f2f9f2")]
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
        [RepositoryItemInfo("cc4ecb5c-784e-4612-b1c4-6073c6f2f9f2")]
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
        [RepositoryItem("f3e93af9-ec58-4da1-ab2b-f6208ff4ac30")]
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
        [RepositoryItemInfo("f3e93af9-ec58-4da1-ab2b-f6208ff4ac30")]
        public virtual RepoItemInfo ButtonCancelInfo
        {
            get
            {
                return _buttoncancelInfo;
            }
        }

        /// <summary>
        /// The EventElement item.
        /// </summary>
        [RepositoryItem("2ee1f7e5-442d-4e7b-b7de-996920c9e730")]
        public virtual Ranorex.Unknown EventElement
        {
            get
            {
                 return _eventelementInfo.CreateAdapter<Ranorex.Unknown>(true);
            }
        }

        /// <summary>
        /// The EventElement item info.
        /// </summary>
        [RepositoryItemInfo("2ee1f7e5-442d-4e7b-b7de-996920c9e730")]
        public virtual RepoItemInfo EventElementInfo
        {
            get
            {
                return _eventelementInfo;
            }
        }

        /// <summary>
        /// The EventRadioButton item.
        /// </summary>
        [RepositoryItem("3aa0d56a-909b-4ea4-afc3-a96af2710265")]
        public virtual Ranorex.RadioButton EventRadioButton
        {
            get
            {
                 return _eventradiobuttonInfo.CreateAdapter<Ranorex.RadioButton>(true);
            }
        }

        /// <summary>
        /// The EventRadioButton item info.
        /// </summary>
        [RepositoryItemInfo("3aa0d56a-909b-4ea4-afc3-a96af2710265")]
        public virtual RepoItemInfo EventRadioButtonInfo
        {
            get
            {
                return _eventradiobuttonInfo;
            }
        }

        /// <summary>
        /// The EventElements item.
        /// </summary>
        [RepositoryItem("1a09df98-907d-4ed0-bc1f-2c614aa63a73")]
        public virtual Ranorex.Unknown EventElements
        {
            get
            {
                 return _eventelementsInfo.CreateAdapter<Ranorex.Unknown>(true);
            }
        }

        /// <summary>
        /// The EventElements item info.
        /// </summary>
        [RepositoryItemInfo("1a09df98-907d-4ed0-bc1f-2c614aa63a73")]
        public virtual RepoItemInfo EventElementsInfo
        {
            get
            {
                return _eventelementsInfo;
            }
        }

        /// <summary>
        /// The ActiveEventRadioButton item.
        /// </summary>
        [RepositoryItem("c1ae1dc2-2929-418b-83ab-8a140af08a0a")]
        public virtual Ranorex.Unknown ActiveEventRadioButton
        {
            get
            {
                 return _activeeventradiobuttonInfo.CreateAdapter<Ranorex.Unknown>(true);
            }
        }

        /// <summary>
        /// The ActiveEventRadioButton item info.
        /// </summary>
        [RepositoryItemInfo("c1ae1dc2-2929-418b-83ab-8a140af08a0a")]
        public virtual RepoItemInfo ActiveEventRadioButtonInfo
        {
            get
            {
                return _activeeventradiobuttonInfo;
            }
        }

        /// <summary>
        /// The Simulation folder.
        /// </summary>
        [RepositoryFolder("8b42aade-17e6-4521-9b94-9a9df00d13e1")]
        public virtual NE107ElementsRepositoryFolders.SimulationFolder Simulation
        {
            get { return _simulation; }
        }

        /// <summary>
        /// The Electronics folder.
        /// </summary>
        [RepositoryFolder("e9a360a2-fe2e-41b2-aba7-21498e016178")]
        public virtual NE107ElementsRepositoryFolders.ElectronicsFolder Electronics
        {
            get { return _electronics; }
        }

        /// <summary>
        /// The Process folder.
        /// </summary>
        [RepositoryFolder("fed5fd2c-381f-46ad-a01d-be5acf585a0c")]
        public virtual NE107ElementsRepositoryFolders.ProcessFolder Process
        {
            get { return _process; }
        }

        /// <summary>
        /// The Configuration folder.
        /// </summary>
        [RepositoryFolder("ece24f6c-9b9b-4c0c-a1b0-5ba7d1b1dcc2")]
        public virtual NE107ElementsRepositoryFolders.ConfigurationFolder Configuration
        {
            get { return _configuration; }
        }

        /// <summary>
        /// The Sensor folder.
        /// </summary>
        [RepositoryFolder("f3d0d816-aacf-42fb-bd36-4293e68e33f7")]
        public virtual NE107ElementsRepositoryFolders.SensorFolder Sensor
        {
            get { return _sensor; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", "6.1")]
    public partial class NE107ElementsRepositoryFolders
    {
        /// <summary>
        /// The SimulationFolder folder.
        /// </summary>
        [RepositoryFolder("8b42aade-17e6-4521-9b94-9a9df00d13e1")]
        public partial class SimulationFolder : RepoGenBaseFolder
        {
            RepoItemInfo _arraylistsimulationeventInfo;
            RepoItemInfo _listitemsimulationeventInfo;
            RepoItemInfo _listsimulationeventInfo;
            RepoItemInfo _simulationcomboboxInfo;

            /// <summary>
            /// Creates a new Simulation  folder.
            /// </summary>
            public SimulationFolder(RepoGenBaseFolder parentFolder) :
                    base("Simulation", "", parentFolder, 0, null, false, "8b42aade-17e6-4521-9b94-9a9df00d13e1", "")
            {
                _arraylistsimulationeventInfo = new RepoItemInfo(this, "ArrayListSimulationEvent", "/container[@controltypename='DtmUserInterface']/container[@controlname='DtmDisplayArea']/container/container[@controlname='EddMenuPanel_ScrollContainer']/container[@controlname='EddMenuPanel_ScrollContainer_ZeroLayoutContainer']//container//container[@controlname='SimulationTab']/container[@controlname='SimulationPanel']/element[@controlname='System.Collections.ArrayList']", 30000, null, "93d1ce95-00a9-4114-ae7f-289990a3d288");
                _listitemsimulationeventInfo = new RepoItemInfo(this, "ListItemSimulationEvent", "/form/?/?/list/listitem", 30000, null, "ad956e5b-f7f3-4246-9b23-689a13d39ca2");
                _listsimulationeventInfo = new RepoItemInfo(this, "ListSimulationEvent", "/form/?/?/list", 30000, null, "ab903831-a1f7-4f2b-9cff-fd295d9f2ed3");
                _simulationcomboboxInfo = new RepoItemInfo(this, "SimulationComboBox", "/container[@controltypename='DtmUserInterface']/container/container/container/container/container/container/container/container/container/container/element/container/container/element[@controlname='Value_Variable.Simulation.Parameters.SPV_SimulateDiagCode_1']/text", 30000, null, "75393774-9d37-4020-ad80-a7ccfc9c5574");
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("8b42aade-17e6-4521-9b94-9a9df00d13e1")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The ArrayListSimulationEvent item.
            /// </summary>
            [RepositoryItem("93d1ce95-00a9-4114-ae7f-289990a3d288")]
            public virtual Ranorex.Unknown ArrayListSimulationEvent
            {
                get
                {
                    return _arraylistsimulationeventInfo.CreateAdapter<Ranorex.Unknown>(true);
                }
            }

            /// <summary>
            /// The ArrayListSimulationEvent item info.
            /// </summary>
            [RepositoryItemInfo("93d1ce95-00a9-4114-ae7f-289990a3d288")]
            public virtual RepoItemInfo ArrayListSimulationEventInfo
            {
                get
                {
                    return _arraylistsimulationeventInfo;
                }
            }

            /// <summary>
            /// The ListItemSimulationEvent item.
            /// </summary>
            [RepositoryItem("ad956e5b-f7f3-4246-9b23-689a13d39ca2")]
            public virtual Ranorex.ListItem ListItemSimulationEvent
            {
                get
                {
                    return _listitemsimulationeventInfo.CreateAdapter<Ranorex.ListItem>(true);
                }
            }

            /// <summary>
            /// The ListItemSimulationEvent item info.
            /// </summary>
            [RepositoryItemInfo("ad956e5b-f7f3-4246-9b23-689a13d39ca2")]
            public virtual RepoItemInfo ListItemSimulationEventInfo
            {
                get
                {
                    return _listitemsimulationeventInfo;
                }
            }

            /// <summary>
            /// The ListSimulationEvent item.
            /// </summary>
            [RepositoryItem("ab903831-a1f7-4f2b-9cff-fd295d9f2ed3")]
            public virtual Ranorex.List ListSimulationEvent
            {
                get
                {
                    return _listsimulationeventInfo.CreateAdapter<Ranorex.List>(true);
                }
            }

            /// <summary>
            /// The ListSimulationEvent item info.
            /// </summary>
            [RepositoryItemInfo("ab903831-a1f7-4f2b-9cff-fd295d9f2ed3")]
            public virtual RepoItemInfo ListSimulationEventInfo
            {
                get
                {
                    return _listsimulationeventInfo;
                }
            }

            /// <summary>
            /// The SimulationComboBox item.
            /// </summary>
            [RepositoryItem("75393774-9d37-4020-ad80-a7ccfc9c5574")]
            public virtual Ranorex.Text SimulationComboBox
            {
                get
                {
                    return _simulationcomboboxInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The SimulationComboBox item info.
            /// </summary>
            [RepositoryItemInfo("75393774-9d37-4020-ad80-a7ccfc9c5574")]
            public virtual RepoItemInfo SimulationComboBoxInfo
            {
                get
                {
                    return _simulationcomboboxInfo;
                }
            }
        }

        /// <summary>
        /// The ElectronicsFolder folder.
        /// </summary>
        [RepositoryFolder("e9a360a2-fe2e-41b2-aba7-21498e016178")]
        public partial class ElectronicsFolder : RepoGenBaseFolder
        {

            /// <summary>
            /// Creates a new Electronics  folder.
            /// </summary>
            public ElectronicsFolder(RepoGenBaseFolder parentFolder) :
                    base("Electronics", "", parentFolder, 0, null, false, "e9a360a2-fe2e-41b2-aba7-21498e016178", "")
            {
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("e9a360a2-fe2e-41b2-aba7-21498e016178")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }
        }

        /// <summary>
        /// The ProcessFolder folder.
        /// </summary>
        [RepositoryFolder("fed5fd2c-381f-46ad-a01d-be5acf585a0c")]
        public partial class ProcessFolder : RepoGenBaseFolder
        {

            /// <summary>
            /// Creates a new Process  folder.
            /// </summary>
            public ProcessFolder(RepoGenBaseFolder parentFolder) :
                    base("Process", "", parentFolder, 0, null, false, "fed5fd2c-381f-46ad-a01d-be5acf585a0c", "")
            {
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("fed5fd2c-381f-46ad-a01d-be5acf585a0c")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }
        }

        /// <summary>
        /// The ConfigurationFolder folder.
        /// </summary>
        [RepositoryFolder("ece24f6c-9b9b-4c0c-a1b0-5ba7d1b1dcc2")]
        public partial class ConfigurationFolder : RepoGenBaseFolder
        {

            /// <summary>
            /// Creates a new Configuration  folder.
            /// </summary>
            public ConfigurationFolder(RepoGenBaseFolder parentFolder) :
                    base("Configuration", "", parentFolder, 0, null, false, "ece24f6c-9b9b-4c0c-a1b0-5ba7d1b1dcc2", "")
            {
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("ece24f6c-9b9b-4c0c-a1b0-5ba7d1b1dcc2")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }
        }

        /// <summary>
        /// The SensorFolder folder.
        /// </summary>
        [RepositoryFolder("f3d0d816-aacf-42fb-bd36-4293e68e33f7")]
        public partial class SensorFolder : RepoGenBaseFolder
        {

            /// <summary>
            /// Creates a new Sensor  folder.
            /// </summary>
            public SensorFolder(RepoGenBaseFolder parentFolder) :
                    base("Sensor", "", parentFolder, 0, null, false, "f3d0d816-aacf-42fb-bd36-4293e68e33f7", "")
            {
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("f3d0d816-aacf-42fb-bd36-4293e68e33f7")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}