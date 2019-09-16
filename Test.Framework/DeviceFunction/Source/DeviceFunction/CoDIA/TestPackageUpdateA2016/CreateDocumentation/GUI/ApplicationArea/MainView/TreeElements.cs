//------------------------------------------------------------------------------
// <copyright file="TreeElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.CreateDocumentation.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Handles tree area elements within device function Create Documentation
    /// </summary>
    public class TreeElements
    {
        #region members

        /// <summary>
        /// The _mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The _repository.
        /// </summary>
        private readonly TreeElementsRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeElements"/> class. 
        ///     Sets mdi client path and creates an instance of the repository which will be used
        /// </summary>
        public TreeElements()
        {
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
            this.repository = TreeElementsRepository.Instance;
        }

        #endregion

        /// <summary>
        /// Gets the root name.
        /// </summary>
        public Cell RootName
        {
            get
            {
                try
                {
                    Cell cell;
                    RepoItemInfo cellDocumentationInfo = this.repository.cellDocumentationInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + cellDocumentationInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out cell);
                    return cell;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the root state.
        /// </summary>
        public Cell RootState
        {
            get
            {
                try
                {
                    Cell cell;
                    RepoItemInfo cellStatusInfo = this.repository.cellStatusInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + cellStatusInfo.AbsolutePath, DefaultValues.iTimeoutLong, out cell);
                    return cell;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Get all TreeItem from CreateDocumentation
        /// </summary>
        /// <returns>
        ///     List(TreeItem): if everything worked fine
        ///     Null: if an error occurred
        /// </returns>
        public IList<TreeItem> Entries()
        {
            try
            {
                RepoItemInfo treeItemInfo = this.repository.treeItemPrintoutSelectionInfo;
                IList<TreeItem> list = Host.Local.Find<TreeItem>(
                    this.mdiClientPath + treeItemInfo.AbsolutePath, DefaultValues.iTimeoutLong);
                return list;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}