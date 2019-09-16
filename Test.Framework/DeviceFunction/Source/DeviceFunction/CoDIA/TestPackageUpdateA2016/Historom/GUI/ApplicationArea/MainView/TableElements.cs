// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TableElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to the "events" tree within tab "Table"
    /// </summary>
    public class TableElements
    {
        #region Fields

        /// <summary>
        /// The HISTOROM.
        /// </summary>
        private readonly Controls historom;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public TableElements()
        {
            this.historom = Controls.Instance;
            this.mdiClientPath = Execution.GetDtmContainerPath.GetMDIClientPath();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets scroll bar button line down
        /// </summary>
        public Element ButtonLineDown
        {
            get
            {
                try
                {
                    throw new NotImplementedException(LogInfo.Namespace(MethodBase.GetCurrentMethod()));
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets scrollbar button line up
        /// </summary>
        public Element ButtonLineUp
        {
            get
            {
                try
                {
                    throw new NotImplementedException(LogInfo.Namespace(MethodBase.GetCurrentMethod()));
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets scroll bar button page down
        /// </summary>
        public Element ButtonPageDown
        {
            get
            {
                try
                {
                    throw new NotImplementedException(LogInfo.Namespace(MethodBase.GetCurrentMethod()));
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets scroll bar button page up
        /// </summary>
        public Element ButtonPageUp
        {
            get
            {
                try
                {
                    throw new NotImplementedException(LogInfo.Namespace(MethodBase.GetCurrentMethod()));
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab "table" -> event list tree
        /// </summary>
        public Tree EventListTree
        {
            get
            {
                try
                {
                    Tree tree;
                    RepoItemInfo treeInfo = this.historom.Table.eventListTreeInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + "/" + treeInfo.AbsolutePath, DefaultValues.iTimeoutLong, out tree);
                    if (tree == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Event list Tree is null");
                        return null;
                    }

                    return tree;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets a list of HISTOROM event containers
        /// </summary>
        public IList<Container> HistoRomEventContainer
        {
            get
            {
                try
                {
                    RepoItemInfo containerInfo = this.historom.Table.eventListContainerInfo;
                    string pathToItem = this.mdiClientPath + "/" + containerInfo.AbsolutePath;
                    IList<Container> list = Host.Local.Find<Container>(pathToItem, DefaultValues.iTimeoutLong);
                    if (list == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "List HistoROMEventContainer is null");
                        return null;
                    }

                    return list;
                }
                catch (Exception exception)
                {
                    Log.Error("DeviceFunction.Modules.Historom.MainView.Areas.TableElements.GetHistoRomEventContainer", exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets picture sample of progress bar
        /// </summary>
        public Bitmap Progressbar
        {
            get
            {
                try
                {
                    return Diagram.progressbar;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets scrollbar
        /// </summary>
        public Element ScrollbarHistorom
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Table.Scrollbar.ScrollbarInfo;
                    string pathToItem = this.mdiClientPath + "/" + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Scrollbar is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Tries to find the tree item representing the first event in the list
        /// </summary>
        /// <returns>true: if tree item is not null, false: if tree item is null or an error occurred </returns>
        public bool FindFirstEvent()
        {
            try
            {
                TreeItem firstEvent;
                RepoItemInfo firstEventInfo = this.historom.Table.eventListEntriesInfo;
                string pathToItem = this.mdiClientPath + "/" + firstEventInfo.AbsolutePath;
                Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutModules, out firstEvent);
                return firstEvent != null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The get HISTOROM event list.
        /// </summary>
        /// <returns>
        /// The list with events
        /// </returns>
        public IList<TreeItem> GetHistoRomEventList()
        {
            try
            {
                RepoItemInfo listInfo = this.historom.Table.eventListEntriesInfo;
                string pathToItem = this.mdiClientPath + "/" + listInfo.AbsolutePath;
                ListItem test;
                Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutShort, out test);
                IList<TreeItem> list = Host.Local.Find<TreeItem>(pathToItem, DefaultValues.iTimeoutModules);
                if (list == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "List with HistoROM Events is null");
                    return null;
                }

                return list;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        #endregion
    }
}