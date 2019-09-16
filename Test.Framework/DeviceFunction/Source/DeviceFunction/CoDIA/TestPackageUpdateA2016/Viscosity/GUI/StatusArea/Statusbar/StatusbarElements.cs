//------------------------------------------------------------------------------
// <copyright file="StatusbarElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.GUI.StatusArea.Statusbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Handles progress elements of device function Event List
    /// </summary>
    public class StatusbarElements
    {
        #region members

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The _repository.
        /// </summary>
        private readonly StatusbarElementsRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarElements"/> class.
        /// </summary>
        public StatusbarElements()
        {
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
            this.repository = StatusbarElementsRepository.Instance;
        }

        #endregion

        /// <summary>
        /// Gets connection state
        /// </summary>
        public string ConnectionState
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.TxtConnectionStateInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection state is null");
                        return null;
                    }

                    string result = element.GetAttributeValueText("AccessibleDescription");
                    return result;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
        
        /// <summary>
        ///  Gets Button OperationInProgress
        /// </summary>
        public Element OperationInProgress
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.ButtonOperationInProgressInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutShort,
                        out element);
                    return element;
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