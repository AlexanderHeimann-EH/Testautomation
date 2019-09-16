// -----------------------------------------------------------------------
// <copyright file="StatusbarElements.cs" company="Endress+Hauser Process Solutions AG">
// Endress + Hauser
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Linearization.GUI.StatusArea.Statusbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// The status bar elements.
    /// </summary>
    public class StatusbarElements
    {
        #region members

        /// <summary>
        /// Repository which will be used
        /// </summary>
        private readonly StatusbarElementsRepository repository;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarElements"/> class.
        /// </summary>
        public StatusbarElements()
        {
            this.repository = StatusbarElementsRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
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
                RepoItemInfo infoConnectionState = this.repository.StatusbarItemConnectionStateInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + infoConnectionState.AbsolutePath, out element);
                if (element == null)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Conncetion State is null");
                    return string.Empty;
                }

                return element.GetAttributeValueText("AccessibleDescription");
            }
        }

        /// <summary>
        /// Gets the button operation in progress (progress bar).
        /// </summary>
        public Button OperationInProgress
        {
            get
            {
                Button button;
                RepoItemInfo itemInfo = this.repository.ButtonOperationInProgressInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out button);
                return button;
            }
        }
        #endregion
    }
} 
