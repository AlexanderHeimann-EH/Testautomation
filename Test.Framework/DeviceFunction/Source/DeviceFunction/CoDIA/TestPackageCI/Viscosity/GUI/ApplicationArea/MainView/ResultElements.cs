// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 7/22/2013
 * Time: 9:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageCI.Viscosity.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of ResultElements.
    /// </summary>
    public class ResultElements
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
        /// Initializes a new instance of the <see cref="ResultElements"/> class. 
        /// Creates an instance of the repository which will be used and determines the path of the mdi client
        /// </summary>
        public ResultElements()
        {
            this.repository = MainViewElementsRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #region properties
        /// <summary>
        /// Gets edit control -> CalculationModel
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element EditControlCalculationModel
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.Results.EditControlCalculationModelInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + "/" + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        ///  Gets edit control -> CoefficientX1
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element EditControlCoefficientX1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.Results.EditControlCoefficientX1Info;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + "/" + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        ///  Gets  edit control -> CoefficientX2
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element EditControlCoefficientX2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.Results.EditControlCoefficientX2Info;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + "/" + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        ///  Gets  edit control -> ReferenceTemperature
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element EditControlReferenceTemperature
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.Results.EditControlReferenceTemperatureInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + "/" + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        ///  Gets  edit control -> TemperatureUnit
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element EditControlTemperatureUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.Results.EditControlTemperatureUnitInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + "/" + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        ///  Gets  edit control -> ViscosityUnit
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Element EditControlViscosityUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.Results.EditControlViscosityUnitInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + "/" + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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