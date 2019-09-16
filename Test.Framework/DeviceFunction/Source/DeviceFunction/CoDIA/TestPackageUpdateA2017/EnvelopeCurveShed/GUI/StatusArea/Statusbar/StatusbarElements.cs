//------------------------------------------------------------------------------
// <copyright file="StatusbarElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.EnvelopeCurveShed.GUI.StatusArea.Statusbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of status bar elements.
    /// </summary>
    public class StatusbarElements
    {
        #region members

        /// <summary>
        /// The _mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The _repository.
        /// </summary>
        private readonly StatusbarElementsRepository repository;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarElements"/> class.
        /// </summary>
        public StatusbarElements()
        {
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
            this.repository = StatusbarElementsRepository.Instance;
        }

        #region properties

        /// <summary>
        /// Gets the connection state.
        /// </summary>
        public string ConnectionState
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.txtConnectionStateInfo;
                Host.Local.TryFindSingle(
                    this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                if (element == null)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text ConnectionState is null");
                    return string.Empty;
                }

                Mouse.MoveTo(element);
                return element.GetAttributeValueText("AccessibleDescription");
            }
        }

        /// <summary>
        /// Gets the operation in progress.
        /// </summary>
        public Button OperationInProgress
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.buttonOperationInProgressInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + buttonInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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