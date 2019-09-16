// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to tabulator containers control within module concentration
    /// </summary>
    public class ContainerElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client path
        /// </summary>
        private readonly Controls concentration;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerElements"/> class.
        /// </summary>
        public ContainerElements()
        {
            this.concentration = Controls.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the tab base settings.
        /// </summary>
        public Element TabBaseSettings
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTabulatorBaseSettings = this.concentration.Tabulator.BaseSettingsInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTabulatorBaseSettings.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the tab coefficients overview.
        /// </summary>
        public Element TabCoefficientsOverview
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTabulatorCoefficientsOverview = this.concentration.Tabulator.CoefficientsOverviewInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTabulatorCoefficientsOverview.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the tab expert results.
        /// </summary>
        public Element TabExpertResults
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTabulatorExpertResults = this.concentration.Tabulator.ExpertResultsInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTabulatorExpertResults.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the tab liquid properties.
        /// </summary>
        public Element TabLiquidProperties
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTabulatorLiquidProperties = this.concentration.Tabulator.LiquidPropertiesInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTabulatorLiquidProperties.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the tab page Base Settings.
        /// </summary>
        public Element TabPageBaseSettings
        {
            get
            {               
                    Element element;
                    RepoItemInfo elementInfo = this.concentration.Tabulator.TabPageBaseSettingsInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    return element;
            }
        }

        /// <summary>
        /// Gets the tab page Liquid Properties.
        /// </summary>
        public Element TabPageLiquidProperties
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.concentration.Tabulator.TabPageLiquidPropertiesInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the tab page Coefficients Overview
        /// </summary>
        public Element TabPageCoefficientsOverview
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.concentration.Tabulator.TabPageCoefficientsOverviewInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the tab page Expert Results
        /// </summary>
        public Element TabPageExpertResults
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.concentration.Tabulator.TabPageExpertResultsInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the tabulator container. 
        /// </summary>
        public Element TabulatorContainer
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTabulatorContainer = this.concentration.Tabulator.ContainerInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTabulatorContainer.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
    }
}