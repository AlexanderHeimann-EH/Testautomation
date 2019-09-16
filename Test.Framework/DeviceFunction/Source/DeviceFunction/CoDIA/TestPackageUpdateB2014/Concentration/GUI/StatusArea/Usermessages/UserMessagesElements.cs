// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserMessagesElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Concentration.GUI.StatusArea.Usermessages
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
    ///     Description of UserMessagesElements.
    /// </summary>
    public class UserMessagesElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly UserMessages concentration;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMessagesElements"/> class.
        /// </summary>
        public UserMessagesElements()
        {
            this.concentration = UserMessages.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the user notification. 
        /// </summary>
        public string UserNotification
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoUserNotification = this.concentration.elementUserNotificationInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoUserNotification.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        return string.Empty;
                    }

                    return element.GetAttributeValueText("Text");
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