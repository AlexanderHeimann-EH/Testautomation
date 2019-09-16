// -----------------------------------------------------------------------
// <copyright file="UserMessagesElements.cs" company="Endress+Hauser Process Solutions AG">
// E+H PCPS
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Linearization.GUI.StatusArea.UserMessages
{
    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the Linearization user messages
    /// </summary>
    public class UserMessagesElements
    {
        #region members

        /// <summary>
        /// Repository which will be used
        /// </summary>
        private readonly UserMessagesRepository repository;

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
            this.repository = UserMessagesRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the user message.
        /// </summary>
        public Element UserMessage
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.ElementUserMessageInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}
