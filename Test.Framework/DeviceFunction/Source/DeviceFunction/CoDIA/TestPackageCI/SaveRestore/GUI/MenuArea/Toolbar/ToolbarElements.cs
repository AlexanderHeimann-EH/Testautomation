//------------------------------------------------------------------------------
// <copyright file="SelectionElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 7/22/2013
 * Time: 9:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageCI.SaveRestore.GUI.MenuArea.Toolbar
{
    using System;
    using System.Reflection;

    using Ranorex;
    using Ranorex.Core.Repository;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Description of ToolbarElements.
    /// </summary>
    public class ToolbarElements
    {
        #region members

        private readonly string _mdiClientPath;

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Toolbar _toolbar;

        #endregion

        /// <summary>
        ///     Creates an instance of the repository which will be used and determines the path of the mdi client
        /// </summary>
        public ToolbarElements()
        {
            this._toolbar = Toolbar.Instance;
            this._mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #region properties

        /// <summary>
        ///     Return toolbar -> button select parameter set
        /// </summary>
        /// <returns>
        ///     <br>Button: if button was found</br>
        ///     <br>Null: if button was not found or an error occurred</br>
        /// </returns>
        public Button ButtonParameterSelection
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo selectButtonInfo = this._toolbar.toolbarRepository.buttonParameterSelectionInfo;
                    Host.Local.TryFindSingle(this._mdiClientPath + selectButtonInfo.AbsolutePath,
                                             DefaultValues.iTimeoutLong, out button);
                    return button;
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