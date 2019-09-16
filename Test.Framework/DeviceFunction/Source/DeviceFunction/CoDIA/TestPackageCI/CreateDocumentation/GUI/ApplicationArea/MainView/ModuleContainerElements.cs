// -----------------------------------------------------------------------
// <copyright file="ModuleContainerElements.cs" company="Endress+Hauser Process Solutions AG">
// Endress+Hauser Process Solutions AG
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.CreateDocumentation.GUI.ApplicationArea.MainView
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
        public Element ModuleContainer
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.CreateDocumentationModuleContainerInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }
        #endregion
    }
}
