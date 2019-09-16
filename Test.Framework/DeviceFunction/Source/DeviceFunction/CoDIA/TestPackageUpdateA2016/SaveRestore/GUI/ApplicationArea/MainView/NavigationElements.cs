// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 28.11.2011
 * Time: 13:33 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.GUI.ApplicationArea.MainView
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
    ///     Description of NavigationElements.
    /// </summary>
    public class NavigationElements
    {
        #region Fields

        /// <summary>
        /// The _mdi client path.
        /// </summary>
        private readonly string _mdiClientPath;

        /// <summary>
        /// The _navigation.
        /// </summary>
        private readonly Navigation _navigation;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationElements"/> class. 
        ///     Creates an instance of the repository which will be used and determines the path of the mdi client
        /// </summary>
        public NavigationElements()
        {
            this._navigation = Navigation.Instance;
            this._mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Get button Back
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element BtnBack
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo btnBackInfo = this._navigation.buttonBackInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + btnBackInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///     Get button Restore
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element BtnRestore
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo btnRestoreInfo = this._navigation.buttonRestoreInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + btnRestoreInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///     Get button Save
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element BtnSave
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo btnSaveInfo = this._navigation.buttonSaveInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + btnSaveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///     Get button Next
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element BtnStart
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo btnNextInfo = this._navigation.buttonStartInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + btnNextInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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