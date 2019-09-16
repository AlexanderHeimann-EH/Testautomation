// -----------------------------------------------------------------------
// <copyright file="ModuleContainerElements.cs" company="Endress+Hauser Process Solutions AG">
// Endress+Hauser Process Solutions AG
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.GUI.ApplicationArea.MainView
{
    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the module container
    /// </summary>
    public class ModuleContainerElements
    {
        #region members

        /// <summary>
        /// The host application path.
        /// </summary>
        private readonly string hostApplicationPath;

        /// <summary>
        /// The repository which will be used
        /// </summary>
        private readonly ModuleContainerRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleContainerElements"/> class.
        /// </summary>
        public ModuleContainerElements()
        {
            this.hostApplicationPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
            this.repository = ModuleContainerRepository.Instance;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the module container
        /// </summary>
        public Element ModuleContainerOffline
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.OfflineParameterizationModuleContainerInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the module container
        /// </summary>
        public Element ModuleContainerOnline
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.OnlineParameterizationModuleContainerInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }
        #endregion
    }
}
