// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.GUI.MenuArea.Toolbar
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
    ///     Provides access to toolbar controls within module concentration
    /// </summary>
    public class ToolbarElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Toolbar concentration;

        /// <summary>
        /// The mdi client path. 
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolbarElements"/> class.
        /// </summary>
        public ToolbarElements()
        {
            this.concentration = Toolbar.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///  Gets toolbar -> button About
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonAbout
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonAbout = this.concentration.toolbar.buttonAboutInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonAbout.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///   Gets toolbar -> button Calculate
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonCalculate
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonCalculate = this.concentration.toolbar.buttonCalculateInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonCalculate.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button Compare Datasets
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonCompareDatasets
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonCompareDatasets = this.concentration.toolbar.buttonCompareDatasetsInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonCompareDatasets.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button Create Documentation
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonCreateDocumentation
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonCreateDocumentation = this.concentration.toolbar.buttonCreateDocumentationInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonCreateDocumentation.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///   Gets toolbar -> button Event list
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonEventlist
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonEventlist = this.concentration.toolbar.buttonEventListInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonEventlist.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button Export
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonExport
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonExport = this.concentration.toolbar.buttonExportInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonExport.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button Help
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonHelp
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonHelp = this.concentration.toolbar.buttonHelpInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonHelp.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///   Gets toolbar -> button Import
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonImport
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonImport = this.concentration.toolbar.buttonImportInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonImport.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button new
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonNew
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonNew = this.concentration.toolbar.buttonNewInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonNew.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button load
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonOpen
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonOpen = this.concentration.toolbar.buttonOpenInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonOpen.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button Read
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonRead
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonRead = this.concentration.toolbar.buttonReadInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonRead.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button Save
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonSave
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonSave = this.concentration.toolbar.buttonSaveInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonSave.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///   Gets toolbar -> button SaveAs
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonSaveAs
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonSaveAs = this.concentration.toolbar.buttonSaveAsInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonSaveAs.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///   Gets toolbar -> button Save/Restore
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonSaveRestore
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonSaveRestore = this.concentration.toolbar.buttonSaveRestoreInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonSaveRestore.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        ///  Gets toolbar -> button Write
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonWrite
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoButtonWrite = this.concentration.toolbar.buttonWriteInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoButtonWrite.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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