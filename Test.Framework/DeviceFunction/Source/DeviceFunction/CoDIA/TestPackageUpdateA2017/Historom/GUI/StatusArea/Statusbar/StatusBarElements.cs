//------------------------------------------------------------------------------
// <copyright file="StatusBarElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.GUI.StatusArea.Statusbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to to the status toolbar elements within module HISTOROM
    /// </summary>
    public class StatusBarElements
    {
        #region members

        /// <summary>
        /// The HISTOROM.
        /// </summary>
        private readonly StatusbarElementsRepository historom;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBarElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public StatusBarElements()
        {
            this.historom = StatusbarElementsRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        /// <summary>
        /// Gets the status bar.
        /// </summary>
        public Element StatusBar
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.StatusBarInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Statusbar is null");
                        return null;
                    }

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
        /// Gets the connection state.
        /// </summary>
        public string ConnectionState
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.historom.ConnectionStateInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                if (element == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text ConnectionState is null");
                    return string.Empty;
                }

                return element.GetAttributeValueText("AccessibleDescription");
            }
        }

        /// <summary>
        /// Gets the button operation in progress.
        /// </summary>
        public Button ButtonOperationInProgress
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonOperationInProgressInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Progressbar is null");
                        return null;
                    }

                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
    }
}