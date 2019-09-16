// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserMessagesElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.GUI.StatusArea.Usermessages
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// The user messages elements.
    /// </summary>
    public class UserMessagesElements
    {
        #region members

        /// <summary>
        /// The user messages.
        /// </summary>
        private readonly UserMessages userMessages;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessagesElements"/> class.
        /// </summary>
        public UserMessagesElements()
        {
            this.userMessages = UserMessages.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the user notification message.
        /// </summary>
        public string UserNotificationMessage
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.userMessages.ViscosityModuleMessageControlPopupEditInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Viscosity Module Message Control Popup is not found ");
                        return string.Empty;  
                    }

                    return element.GetAttributeValueText("Text");
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
