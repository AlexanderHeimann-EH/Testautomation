// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusbarElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.Concentration.GUI.StatusArea.Statusbar
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
    ///     Description of Status bar Elements.
    /// </summary>
    public class StatusbarElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly StatusBar concentration;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarElements"/> class.
        /// </summary>
        public StatusbarElements()
        {
            this.concentration = StatusBar.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the connection state. 
        /// </summary>
        public string ConnectionState
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoConnectionState = this.concentration.Statusbar.ConnectionStateInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoConnectionState.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection State is null");
                        return string.Empty;
                    }

                    return element.GetAttributeValueText("AccessibleDescription");
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