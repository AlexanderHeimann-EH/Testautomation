// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultListTreeElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ResultListTreeElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Compare.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class ResultListTreeElements.
    /// </summary>
    public class ResultListTreeElements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ResultListTreeElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultListTreeElements"/> class. 
        /// Initializes a new instance of the <see cref="ActionElements"/> class.
        /// </summary>
        public ResultListTreeElements()
        {
            this.repository = ResultListTreeElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets a list with all tree items from the result tree
        /// </summary>
        public IList<TreeItem> ResultLisTreeItems
        {
            get
            {
                try
                {
                    RepoItemInfo itemInfo = this.repository.ResultListTreeItemInfo;
                    IList<TreeItem> result = Host.Local.Find<TreeItem>(this.mdiClientPath + itemInfo.AbsolutePath);
                    return result;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets the line up button of the scrollbar
        /// </summary>
        public Button LineUp
        {
            get
            {
                try
                {
                    Button result;
                    RepoItemInfo itemInfo = this.repository.ScrollBarLineUpInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out result);
                    return result;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets the line down button of the scrollbar
        /// </summary>
        public Button LineDown
        {
            get
            {
                try
                {
                    Button result;
                    RepoItemInfo itemInfo = this.repository.ScrollBarLineDownInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out result);
                    return result;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}