// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 07.02.2012
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.PrototypeHMI20.EventList.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Handles result elements of device function Event List
    /// </summary>
    public class ResultElements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly Controls repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultElements"/> class.
        /// </summary>
        public ResultElements()
        {
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
            this.repository = Controls.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets Line Down button
        /// </summary>
        public Element ButtonLineDown
        {
            get
            {
                Element element;
                RepoItemInfo exportInfo = this.repository.LineDownInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + exportInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets Line Up button
        /// </summary>
        public Element ButtonLineUp
        {
            get
            {
                Element element;
                RepoItemInfo exportInfo = this.repository.LineUpInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + exportInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets PageDown button
        /// </summary>
        public Element ButtonPageDown
        {
            get
            {
                Element element;
                RepoItemInfo exportInfo = this.repository.PageDownInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + exportInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets PageUp button
        /// </summary>
        public Element ButtonPageUp
        {
            get
            {
                Element element;
                RepoItemInfo exportInfo = this.repository.PageUpInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + exportInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The entries.
        /// </summary>
        /// <returns>
        /// The list 
        /// </returns>
        public IList<TreeItem> Entries()
        {
            try
            {
                var itemInfo = this.repository.treeItemEntriesInfo;
                var list = Host.Local.Find<TreeItem>(this.mdiClientPath + itemInfo.AbsolutePath, DefaultValues.GeneralTimeout);
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