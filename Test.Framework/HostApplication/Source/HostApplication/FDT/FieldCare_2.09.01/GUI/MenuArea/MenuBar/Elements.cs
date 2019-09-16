// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Elements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 04.11.2010
 * Time: 8:13 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.GUI.MenuArea.MenuBar
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of MenuElements.
    /// </summary>
    public class Elements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Paths repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Elements"/> class and determines the path of the mdi client
        /// </summary>
        public Elements()
        {
            this.repository = Paths.Instance;
        }

        /// <summary>
        /// Gets Menu bar -> File
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuFile
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuFileInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> New
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryNew
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileNewInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar  -> File -> Open
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryOpen
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileOpenInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Close
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryClose
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileCloseInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Save
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntrySave
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileSaveInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Save As
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntrySaveAs
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileSaveAsInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Print
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryPrint
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FilePrintInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Print Setup
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryPrintSetup
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FilePrintSetupInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Project
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryProject
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.FileProjectInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Project -> Inventory
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryInventory
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileProjectInventoryInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Import/Export
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryImportExport
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.FileImportExportInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Import/Export -> Import Project
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryImportProject
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileImportProjectInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Import/Export -> Export Project
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryExportProject
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileExportProjectInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Import/Export -> Import CSV
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryImportCsv
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileImportCSVFileInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Import/Export -> Export CSV
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryExportCsv
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.FileExportCSVFileInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> LogOff
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryLogOff
        {
            get
            {
                try
                {
                    IList<Button> btnList = Host.Local.Find<Button>(this.repository.MenuAllButtonsInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                    IList<MenuItem> menuItemList = Host.Local.Find<MenuItem>(this.repository.MenuAllMenuItemsInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                    int count = btnList.Count - 2 + menuItemList.Count;
                    string strBuffer = this.repository.FileLogOffInfo.AbsolutePath.ToString().Replace("''", "'" + count + "'");

                    Button btnEntry;
                    if (Host.Local.TryFindSingle(strBuffer, DefaultValues.iTimeoutShort, out btnEntry))
                    {
                        return btnEntry;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> File -> Exit
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryExit
        {
            get
            {
                try
                {
                    IList<Button> btnList = Host.Local.Find<Button>(this.repository.MenuAllButtonsInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                    IList<MenuItem> menuItemList = Host.Local.Find<MenuItem>(this.repository.MenuAllMenuItemsInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                    int count = btnList.Count - 1 + menuItemList.Count;
                    string strBuffer = this.repository.FileExitInfo.AbsolutePath.ToString().Replace("''", "'" + count + "'");

                    Button btnEntry;
                    if (Host.Local.TryFindSingle(strBuffer, DefaultValues.iTimeoutShort, out btnEntry))
                    {
                        return btnEntry;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // Edit structure

        /// <summary>
        /// Gets Menu bar -> Edit
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuEdit
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuEditInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Edit -> Clipboard
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryClipboard
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.EditClipboardInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Edit -> Advanced Select
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryAdvancedSelect
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.EditAdvancedInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Edit -> Find
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryFind
        {
            get
            {
                try
                {
                   Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.EditFindInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Edit -> Find Next
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryFindNext
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.EditFindNextInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // View structure

        /// <summary>
        /// Gets Menu bar -> View
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuView
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuViewInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> View -> Status bar
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryStatusbar
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ViewStatusbarInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> View -> Toolbar
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryToolbar
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ViewToolbarInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> View -> Toolbox
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryToolbox
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ViewToolboxInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> View -> Plant Toolbar
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryPlantToolbar
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ViewToolbarInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> View -> Network
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryNetwork
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ViewNetworkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> View -> Entry Logging
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryLogging
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ViewLoggingInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> View -> DTM Messages
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryDtmMessages
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ViewDtmMessagesInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> View -> Plant
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryPlant
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ViewPlantInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // Device operation structure

        /// <summary>
        /// Gets Menu bar -> Device Operation
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuDeviceOperation
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuDeviceInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Add Device
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryAddDevice
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceAddDeviceInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Delete Device
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryDeleteDevice
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceDeleteDeviceInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Launch Wizard
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryLaunchWizard
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceLaunchWizardInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Connect
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryConnect
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceConnectInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Read From Device
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryReadFromDevice
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceReadFromDeviceInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Write To Device
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryWriteToDevice
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceWriteToDeviceInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Device Function
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryDeviceFunction
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.DeviceDeviceFunctionInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Device Function -> Offline Parameterize
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryOfflineParameterize
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceOfflineParameterInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Device Function -> Online Parameterize
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryOnlineParameterize
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceOnlineParameterInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Device Function -> Observe
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryObserve
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceObserveInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Device Function -> Configuration
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryConfiguration
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceConfigurationInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Device Function -> Diagnosis
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryDiagnosis
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceDiagnosisInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Device Function -> Additions Functions
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryAdditionalFunctions
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.DeviceAdditionalFunctionsInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Device Function -> Channel Functions
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryChannelFunctions
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceChannelFunctionsInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Documentation
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryDocumentation
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.DeviceDocumentationInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Documentation -> Add Link
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryAddLink
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceAddLinkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Documentation -> Remove Link
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryRemoveLink
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceRemoveLinkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Device Operation -> Append To Description
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryAppendToDescription
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.DeviceDescriptionInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // DTMCatalog structure

        /// <summary>
        /// Gets Menu bar -> DTM Catalog
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuDtmCatalog
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuCatalogInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> DTM Catalog -> Display DTM Catalog
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryDisplayDtmCatalog
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.CatalogDisplayInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> DTM Catalog -> Update
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryUpdate
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.CatalogUpdateInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // Tools structure

        /// <summary>
        /// Gets Menu bar -> Tools
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuTools
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuToolsInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Scanning
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryScanning
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.ToolsScanningInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Scanning -> Create Network
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryCreateNetwork
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsCreateNetworkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Scanning -> Verify Network
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryVerifyNetwork
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsVerifyNetworkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Scanning -> Generate Device List
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryGenerateDeviceList
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsGeneralDeviceListInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Scanning -> Device Type Info
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryDeviceTypeInfo
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsDeviceTypeInfoInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Event Logging
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryEventLogging
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.ToolsEventLoggingInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Event Logging -> Buffer Settings
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryBufferSettings
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsBufferSettingsInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Event Logging -> Enable Logging
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryEnableLogging
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsEnableLoggingInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Activity Logging
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryActivityLogging
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.ToolsActivityLoggingInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Activity Logging -> Enable Log
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryEnableLog
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsEnableLogInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

// /// <summary>
//        /// Gets Menu bar -> Tools -> Activity Logging -> Display
//        /// </summary>
//        /// <returns>
//        ///     <br>Button: If call worked fine</br>
//        ///     <br>NULL: If an error occurred</br>
//        /// </returns>
//        public Button EntryDisplayActivityLogging
//        {
//            get
//            {
//                try
//                {
//                    Button btnEntry;
//                    RepoItemInfo elementInfo = _repository.toolsdisInfo;
//                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
//                    return btnEntry;
//                }
//                catch (Exception exception)
//                {
//                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
//                    return null;
//                }
//            }
//        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Plant View
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryPlantView
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.ToolsPlantViewInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Plant View -> Assign Device
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryAssignDevice
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsAssignDeviceInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Tools -> Plant View -> Automated Topology
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryAutomatedTopology
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ToolsAutomatedTopologyInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // Window structure

        /// <summary>
        /// Gets Menu bar -> Window
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuWindow
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuWindowInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Window -> Close All
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryCloseAll
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.WindowCloseAllInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // Extras structure

        /// <summary>
        /// Gets Menu bar -> Extras
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuExtras
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuExtrasInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Extras -> Option
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryOptions
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.ExtrasOptionInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
        
        // Help structure

        /// <summary>
        /// Gets Menu bar -> Help
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem MenuHelp
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.MenuHelpInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> Start Up Screen
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryStartUpScreen
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.HelpStartUpScreenInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> Contents
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryContents
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.HelpContentsInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> Vendor In Web
        /// </summary>
        /// <returns>
        ///     <br>MenuItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public MenuItem EntryVendorInWeb
        {
            get
            {
                try
                {
                    MenuItem menu;
                    RepoItemInfo elementInfo = this.repository.HelpVendorInWebInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out menu);
                    return menu;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> Vendor In Web -> Endress+Hauser
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryEndressHauser
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.HelpEndressHauserInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> Vendor In Web -> Download Area
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryDownloadArea
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.HelpDownloadAreaInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> Vendor In Web -> DTM Download
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryDtmDownload
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.HelpDtmDownloadInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> Vendor In Web -> FieldCareUpdate
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryFieldCareUpdate
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.HelpFieldCareUpdateInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> About
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryAbout
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.HelpAboutInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Help -> License
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryLicense
        {
            get
            {
                try
                {
                    Button btnEntry;
                    RepoItemInfo elementInfo = this.repository.HelpLicenseInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnEntry);
                    return btnEntry;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets Menu bar -> Additional Functions -> available Module
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public IList<Button> ListOfModules
        {
            get
            {
                try
                {
                    RepoItemInfo repoItemInfo = this.repository.MenuAllButtonsInfo;
                    IList<Button> modules = Host.Local.Find<Button>(repoItemInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                    if (modules.Count > 0)
                    {
                        return modules;
                    }

                    return null;
                }
                catch (Exception exception)
                {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Get a (sub)menu-container, containing menu entries
        /// </summary>
        /// <param name="previousHandle">Handle for comparison, to get a different container from previously selected</param>
        /// <returns>
        ///     <br>Container: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element MenuElement(IntPtr previousHandle)
        {
            try
            {
                bool isSearching = true;
                Element element = null;
                int retries = 0;

                while (isSearching && retries < DefaultValues.SearchRetries)
                {
                    Mouse.Click();
                    RepoItemInfo repoItemInfo = this.repository.MenuElementInfo;
                    Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, DefaultValues.GeneralTimeout, out element);
                    IntPtr nextHandle = (new NativeWindow(element)).Handle;

                    

                    if (element != null && nextHandle != previousHandle)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MenuElement found");
                        isSearching = false;
                    }
                    else
                    {
                        element = null;
                    }

                    retries = retries + 1;
                }

                if (element == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "MenuElement not found");
                }

                return element;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
        
        /// <summary>
        /// Gets Menu bar -&gt; Menu Container
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// <br>Container: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Container MenuContainer(int number)
        {
            try
            {
                bool searching = true;
                Container container = null;
                while (searching)
                {
                    RepoItemInfo repoItemInfo = this.repository.MenuContainerInfo;
                    Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, DefaultValues.iTimeoutShort, out container);
                    if (container != null && (container.Children.Count == number || number == 0))
                    {
                        searching = false;
                    }
                }

                return container;
            }
            catch (Exception exception)
            {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets Menu bar -&gt; Window -&gt; Module
        /// </summary>
        /// <param name="moduleName">The Module Name.</param>
        /// <returns>
        /// <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button EntryModule(string moduleName)
        {
            try
            {
                RepoItemInfo repoItemInfo = this.repository.WindowModuleInfo;
                IList<Button> btnList =
                    Host.Local.Find<Button>(repoItemInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                Button btnEntry = null;
                foreach (Button button in btnList)
                {
                    if (button.Text.Contains(moduleName))
                    {
                        btnEntry = button;
                        break;
                    }
                }

                if (btnEntry != null)
                {
                    return btnEntry;
                }

                return null;
            }
            catch (Exception exception)
            {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}