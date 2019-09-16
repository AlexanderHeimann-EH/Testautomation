// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Compare.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to controls at progress area at Compare module
    /// </summary>
    public class ProgressElements
    {
        #region Fields

        /// <summary>
        ///  MDI client path
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// Repository which will be used
        /// </summary>
        private readonly ProgressbarElements progressbarRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressElements"/> class.
        /// </summary>
        public ProgressElements()
        {
            this.progressbarRepository = ProgressbarElements.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///  Gets progress bar
        /// </summary>
        public ProgressBar Progressbar
        {
            get
            {
                try
                {
                    ProgressBar progressbar;
                    RepoItemInfo progressbarInfo = this.progressbarRepository.ProgressBarInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + progressbarInfo.AbsolutePath, DefaultValues.iTimeoutLong, out progressbar);
                    return progressbar;
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