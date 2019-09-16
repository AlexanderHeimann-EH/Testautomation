// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Compare.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to controls at action area at module Compare
    /// </summary>
    public class ActionElements
    {
        #region Fields

        /// <summary>
        /// The action buttons.
        /// </summary>
        private readonly ActionButtons actionButtons;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionElements"/> class.
        /// </summary>
        public ActionElements()
        {
            this.actionButtons = ActionButtons.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets button Cancel
        /// </summary>
        public Button ButtonCancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnCancelInfo = this.actionButtons.buttonCancelInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + btnCancelInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///    Gets button Compare
        /// </summary>
        public Button ButtonCompare
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnCompareInfo = this.actionButtons.buttonCompareInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + btnCompareInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                    return button;
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