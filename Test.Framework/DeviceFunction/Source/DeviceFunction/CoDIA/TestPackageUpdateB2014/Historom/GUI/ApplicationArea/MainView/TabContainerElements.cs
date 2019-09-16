//------------------------------------------------------------------------------
// <copyright file="TabContainerElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     ´Provides access to the different tabs within HISTOROM module
    /// </summary>
    public class TabContainerElements
    {
        #region members

        /// <summary>
        /// The HISTOROM repository.
        /// </summary>
        private readonly Controls historom;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TabContainerElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public TabContainerElements()
        {
            this.historom = Controls.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region methods

        /// <summary>
        ///  Gets the tabulator control
        /// </summary>
        public Element TabulatorControl
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Tabulator.TabulatorControlInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tabulator is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets tab -> Table
        /// </summary>
        public Element ContainerTabTable
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Tabulator.TabulatorControlInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Table container is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab -> Graphic
        /// </summary>
        public Element ContainerTabGraphic
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Tabulator.GraphicInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GraphicTab container is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab -> Statistic
        /// </summary>
        public Element ContainerTabStatistic
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Tabulator.StatisticInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "StatisticTab container is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab -> Settings
        /// </summary>
        public Element ContainerTabSettings
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Tabulator.SettingsInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "SettingsTab container is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}