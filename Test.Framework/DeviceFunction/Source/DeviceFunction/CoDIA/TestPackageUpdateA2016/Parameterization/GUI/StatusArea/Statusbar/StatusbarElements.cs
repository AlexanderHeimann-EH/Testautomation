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
 * Time: 11:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.StatusArea.Statusbar
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Description of StatusBarElements.
    /// </summary>
    public class StatusbarElements
    {
        #region members

        private readonly string _mdiClientPath;
        private readonly StatusBar _statusbar;

        #endregion

        #region constructor

        /// <summary>
        ///     Creates an instance of the repository which will be used and determines the path of the mdi client
        /// </summary>
        public StatusbarElements()
        {
            this._statusbar = StatusBar.Instance;
            this._mdiClientPath =
                Execution.GetDtmContainerPath
                         .GetMDIClientPath();
        }

        #endregion

        #region properties

        /// <summary>
        ///     Return StatusArea -> Conncetion state
        /// </summary>
        /// <returns>
        ///     <br>string: if call worked</br>
        ///     <br>empty string: if an error occurred</br>
        /// </returns>
        public string ConnectionState
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this._statusbar.txtConnectionStateInfo;
                Host.Local.TryFindSingle(this._mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong,
                                         out element);
                if (element == null)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                 "Text ConnectionState is null");
                    return string.Empty;
                }
                Mouse.MoveTo(element);
                return element.GetAttributeValueText("AccessibleDescription");
            }
        }

        #endregion
    }
}