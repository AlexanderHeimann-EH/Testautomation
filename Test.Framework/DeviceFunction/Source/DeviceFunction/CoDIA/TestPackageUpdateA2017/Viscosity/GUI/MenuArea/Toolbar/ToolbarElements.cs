// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarElements.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.GUI.MenuArea.Toolbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of ToolbarElements.
    /// </summary>
    public class ToolbarElements
    {
        #region members

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly ToolbarElementsRepository toolbar;
        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolbarElements"/> class. 
        ///     Creates an instance of the repository which will be used and determines the path of the mdi client
        /// </summary>
        public ToolbarElements()
        {
            this.toolbar = ToolbarElementsRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }
        #region properties
        /// <summary>
        /// Gets toolbar -> button "Load"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button LoadButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo loadButtonInfo = this.toolbar.ToolbarIconLoadInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + loadButtonInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets  toolbar -> button "New"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button NewButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo newButtonInfo = this.toolbar.ToolbarIconNewInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + newButtonInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets toolbar -> button "Save"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button SaveButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo saveButtonInfo = this.toolbar.ToolbarIconSaveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + saveButtonInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out button);
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
        /// Gets toolbar -> button "SaveAs"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button SaveAsButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo saveAsButtonInfo = this.toolbar.ToolbarIconSaveAsInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + saveAsButtonInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out button);
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
        /// Gets toolbar -> button "Import"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ImportButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo importButtonInfo = this.toolbar.ToolbarIconImportInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + importButtonInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out button);
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
        /// Gets toolbar -> button "Export"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ExportButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo exportButtonInfo = this.toolbar.ToolbarIconExportInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + exportButtonInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out button);
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
        /// Gets toolbar -> button "Calculate"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button CalculateButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo calculateButtonInfo = this.toolbar.ToolbarIconCalculateInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + calculateButtonInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out button);
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
        /// Gets toolbar -> button "Write"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button WriteButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo writeButtonInfo = this.toolbar.ToolbarIconWriteInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + writeButtonInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out button);
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
        /// Gets toolbar -> button "Help"
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button HelpButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo helpButtonInfo = this.toolbar.ToolbarIconHelpInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + helpButtonInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out button);
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