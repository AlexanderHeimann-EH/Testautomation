//------------------------------------------------------------------------------
// <copyright file="PrinterAndProgressElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.CreateDocumentation.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Handles Printer and Progress Elements within device function Create Documentation
    /// </summary>
    public class PrinterAndProgressElements
    {
        #region members

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly PrinterAndProgressElementsRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PrinterAndProgressElements"/> class.
        /// </summary>
        public PrinterAndProgressElements()
        {
            this.repository = PrinterAndProgressElementsRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        /// <summary>
        ///     Gets button PrinterProperties
        /// </summary>
        public Button PrinterProperties
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnPrinterPropertiesInfo = this.repository.buttonPrinterPropertiesInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + btnPrinterPropertiesInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets progress bar MainProgress
        /// </summary>
        public ProgressBar MainProgress
        {
            get
            {
                try
                {
                    ProgressBar progressbar;
                    RepoItemInfo progressbarInfo = this.repository.progressbarMainProgressInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + progressbarInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out progressbar);
                    return progressbar;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets progress bar MainProgress state in percent
        /// </summary>
        public string MainProgressText
        {
            get
            {
                try
                {
                    string state;
                    Element progressbar = this.MainProgress;
                    state = progressbar.GetAttributeValueText("AccessibleValue");
                    return state;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return string.Empty;
                }
            }
        }

        /// <summary>
        ///     Gets progress bar SubProgress
        /// </summary>
        public ProgressBar SubProgress
        {
            get
            {
                try
                {
                    ProgressBar progressbar;
                    RepoItemInfo progressbarInfo = this.repository.progressbarSubProgressInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + progressbarInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out progressbar);
                    return progressbar;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets progress bar SubProgress State
        /// </summary>
        public Text SubProgressText
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo subProgressTextInfo = this.repository.textSubProgressInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + subProgressTextInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out text);
                    return text;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
    }
}