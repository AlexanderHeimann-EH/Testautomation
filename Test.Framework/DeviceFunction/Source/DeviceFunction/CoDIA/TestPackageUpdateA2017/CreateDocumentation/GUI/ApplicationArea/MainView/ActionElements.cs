// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.CreateDocumentation.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides methods to get access to controls of action area within module create documentation
    /// </summary>
    public class ActionElements
    {
        #region members

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ActionElementsRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionElements"/> class.
        /// </summary>
        public ActionElements()
        {
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
            this.repository = ActionElementsRepository.Instance;
        }

        #endregion

        /// <summary>
        ///     Gets button Print
        /// </summary>
        public Button Print
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonPrintInfo = this.repository.buttonPrintInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + buttonPrintInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets button Cancel
        /// </summary>
        public Button Cancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonCancelInfo = this.repository.buttonCancelInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + buttonCancelInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets button SaveAs
        /// </summary>
        public Button SaveAs
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonSaveAsInfo = this.repository.buttonSaveAsInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + buttonSaveAsInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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