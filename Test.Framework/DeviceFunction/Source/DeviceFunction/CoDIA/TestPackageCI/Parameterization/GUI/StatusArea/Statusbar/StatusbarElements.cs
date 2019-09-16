// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectionElements.cs" company="Endress+Hauser Process Solutions AG">
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
 * Time: 11:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageCI.Parameterization.GUI.StatusArea.Statusbar
{
    using System.Reflection;

    //using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;

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

        /// <summary>
        /// The _mdi client path.
        /// </summary>
        private readonly string _mdiClientPath;

        /// <summary>
        /// The _statusbar.
        /// </summary>
        private readonly StatusBar _statusbar;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarElements"/> class.
        /// </summary>
        public StatusbarElements()
        {
            this._statusbar = StatusBar.Instance;
            this._mdiClientPath = EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run(); //Execution.GetDtmContainerPath.GetMDIClientPath();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the connection state.
        /// </summary>
        public string ConnectionState
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this._statusbar.txtConnectionStateInfo;
                Host.Local.TryFindSingle(this._mdiClientPath + "/" + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                if (element == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text ConnectionState is null");
                    return string.Empty;
                }

                Mouse.MoveTo(element);
                return element.GetAttributeValueText("AccessibleDescription");
            }
        }

        #endregion
    }
}