// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleContainerElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Provides access to the module container
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.AboutBox.GUI.ApplicationArea.MainView
{
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Provides access to the module container
    /// </summary>
    public class ModuleContainerElements
    {
        #region Fields

        /// <summary>
        /// The host application path.
        /// </summary>
        private readonly string hostApplicationPath;

        /// <summary>
        /// The repository which will be used
        /// </summary>
        private readonly MainViewElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleContainerElements"/> class.
        /// </summary>
        public ModuleContainerElements()
        {
            this.hostApplicationPath = CommonFlows.GetDtmContainerPath.Run();
            this.repository = MainViewElementsRepository.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the module container
        /// </summary>
        public Element ModuleContainer
        {
            get
            {
                Element element;
                RepoItemInfo itemInfo = this.repository.AboutBoxModuleContainerInfo;
                Host.Local.TryFindSingle(this.hostApplicationPath + itemInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}