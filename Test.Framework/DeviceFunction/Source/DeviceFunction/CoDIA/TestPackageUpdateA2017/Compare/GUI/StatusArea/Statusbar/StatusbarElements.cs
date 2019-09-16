// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusbarElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Compare.GUI.StatusArea.Statusbar
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Description of status bar elements 
    /// </summary>
    public class StatusbarElements
    {
        #region Fields

        /// <summary>
        /// MDI client path
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        ///  Repository which will be used
        /// </summary>
        private readonly StatusbarElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusbarElements"/> class. 
        /// </summary>
        public StatusbarElements()
        {
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
            this.repository = StatusbarElementsRepository.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///  Gets StatusArea -> Connection state
        /// </summary>
        /// <returns>
        ///     <br>string: if call worked</br>
        ///     <br>empty string: if an error occurred</br>
        /// </returns>
        public string ConnectionState
        {
            get
            {
                Element element;
                RepoItemInfo elementInfo = this.repository.txtConnectionStateInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                if (element == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text ConnectionState is null");
                    return string.Empty;
                }

                return element.GetAttributeValueText("AccessibleDescription");
            }
        }

        /// <summary>
        ///  Gets StatusArea -> Connection state
        /// </summary>
        /// <returns>
        ///     <br>string: if call worked</br>
        ///     <br>empty string: if an error occurred</br>
        /// </returns>
        public Button ComparisonProgress
        {
            get
            {
                Button button;
                RepoItemInfo buttonInfo = this.repository.ComparisonOfDataSetsInfo;
                Host.Local.TryFindSingle(this.mdiClientPath + buttonInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                return button;
            }
        }

        #endregion
    }
}