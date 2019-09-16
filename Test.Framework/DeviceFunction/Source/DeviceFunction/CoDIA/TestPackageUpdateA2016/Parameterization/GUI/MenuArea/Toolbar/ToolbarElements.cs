
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.GUI.MenuArea.Toolbar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class ToolbarElements.
    /// </summary>
    public class ToolbarElements
    {
                /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ToolbarElementsRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolbarElements"/> class.
        /// </summary>
        public ToolbarElements()
        {
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
            this.repository = ToolbarElementsRepository.Instance;
        }

        /// <summary>
        ///   Gets tool bar home button
        /// </summary>
        public Button HomeButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.repository.ButtonHomeInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
    }
}
