// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ToolbarElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.MenuArea.Toolbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class ToolbarElements.
    /// </summary>
    public class ToolbarElements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ToolbarElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolbarElements"/> class.
        /// </summary>
        public ToolbarElements()
        {
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
            this.repository = ToolbarElementsRepository.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets tool bar home button
        /// </summary>
        public Button HomeButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonHomeInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets tool bar button About Box
        /// </summary>
        public Button OpenAboutBox
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonOpenAboutInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets tool bar button Compare Datasets
        /// </summary>
        public Button OpenCompare
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonOpenCompareInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets tool bar button Create Documentation
        /// </summary>
        public Button OpenCreateDocumentation
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonOpenCreateDocumentationInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the open envelope curve button.
        /// </summary>
        /// <value>The open envelope curve.</value>
        public Button OpenEnvelopeCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonOpenEnvelopeCurveInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets tool bar button open HISTOROM.
        /// </summary>
        public Button OpenHistorom
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonOpenHistoromInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets tool bar button open Linearization table.
        /// </summary>
        public Button OpenLinearization
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonOpenLinearizationTableInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets tool bar button open SAve/Restore.
        /// </summary>
        public Button SaveRestore
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonOpenSaveRestoreInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
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