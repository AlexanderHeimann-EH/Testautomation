// -----------------------------------------------------------------------
// <copyright file="ToolbarElements.cs" company="Endress+Hauser Process Solutions AG">
// Endress + Hauser
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Linearization.GUI.MenuArea.Toolbar
{
    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// The toolbar elements.
    /// </summary>
    public class ToolbarElements
    {
        #region members

        /// <summary>
        /// Repository which will be used
        /// </summary>
        private readonly ToolbarElementsRepository repository;

        /// <summary>
        /// MDI client path
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolbarElements"/> class.
        /// </summary>
        public ToolbarElements()
        {
            this.repository = ToolbarElementsRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets export button
        /// </summary>
        public Element ExportButton
        {
            get
            {
                Element element;
                RepoItemInfo exportInfo = this.repository.ButtonExportInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + exportInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the import button
        /// </summary>
        public Element ImportButton
        {
            get
            {
                Element element;
                RepoItemInfo importInfo = this.repository.ButtonImportInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + importInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the help button
        /// </summary>
        public Element HelpButton
        {
            get
            {
                Element element;
                RepoItemInfo helpInfo = this.repository.ButtonHelpInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + helpInfo, out element);
                return element;
            }
        }

        /// <summary>
        ///  Gets the reset zoom area button
        /// </summary>
        public Element ResetZoomAreaButton
        {
            get
            {
                Element element;
                RepoItemInfo resetInfo = this.repository.ButtonResetZoomAreaInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + resetInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the show table button
        /// </summary>
        public Element ShowTable
        {
            get
            {
                Element element;
                RepoItemInfo showTableInfo = this.repository.ButtonShowTableInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + showTableInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the start CA button
        /// </summary>
        public Element StartCaButton
        {
            get
            {
                Element element;
                RepoItemInfo startCaInfo = this.repository.ButtonStartCAInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + startCaInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the start DT button
        /// </summary>
        public Element StartDtButton
        {
            get
            {
                Element element;
                RepoItemInfo startDtInfo = this.repository.ButtonStartDTInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + startDtInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the start QH button
        /// </summary>
        public Element StartQhButton
        {
            get
            {
                Element element;
                RepoItemInfo startQhInfo = this.repository.ButtonStartQHInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + startQhInfo.AbsolutePath, out element);
                return element;
            }
        }

        /// <summary>
        /// Gets the undo zoom button
        /// </summary>
        public Element UndoZoomButton
        {
            get
            {
                Element element;
                RepoItemInfo undoZoomInfo = this.repository.ButtonUndoZoomInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + undoZoomInfo.AbsolutePath, out element);
                return element;
            }
        }

        #endregion
    }
}
