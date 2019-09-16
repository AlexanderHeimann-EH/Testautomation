//------------------------------------------------------------------------------
// <copyright file="TabControlElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of ResultElements
    /// </summary>
    public class TabControlElements
    {
        #region members

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly MainViewElementsRepository repository;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TabControlElements"/> class. 
        /// Creates an instance of the repository which will be used and determines the path of the mdi client
        /// </summary>
        public TabControlElements()
        {
            this.repository = MainViewElementsRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #region properties
        /// <summary>
        /// Gets tab control viscosity
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element TabControlViscosity
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.TabPages.TabControlViscosityInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        /// Gets tab page control -> Fluid Properties
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element TabPageControlFluidProperties
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.TabPages.TabPageControlFluidPropertiesInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        /// Gets tab page control -> Results
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element TabPageControlResults
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.TabPages.TabPageControlResultsInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        /// Gets tab page control -> Analysis
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element TabPageControlAnalysis
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.TabPages.TabPageControlAnalysisInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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