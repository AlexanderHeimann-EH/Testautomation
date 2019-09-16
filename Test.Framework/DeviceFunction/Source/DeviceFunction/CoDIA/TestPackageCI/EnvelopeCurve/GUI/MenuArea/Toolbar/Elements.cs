//------------------------------------------------------------------------------
// <copyright file="Elements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurve.GUI.MenuArea.Toolbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     EnvCurIconElements contains methods to get access to [Envelope Curve] toolbar-icons.
    /// </summary>
    public class Elements
    {
        #region members

        /// <summary>
        /// The _mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The _repository.
        /// </summary>
        private readonly IconsRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Elements"/> class.
        /// </summary>
        public Elements()
        {
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
            this.repository = IconsRepository.Instance;
        }

        #endregion

        #region Icons

        /// <summary>
        /// Gets the button new curve.
        /// </summary>
        public Button BtnNewCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo newCurveInfo = this.repository.buttonNewCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + newCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button load curve.
        /// </summary>
        public Button BtnLoadCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo loadCurveInfo = this.repository.buttonOpenCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + loadCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button save curve.
        /// </summary>
        public Button BtnSaveCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo saveCurveInfo = this.repository.buttonSaveCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + saveCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button first curve.
        /// </summary>
        public Button BtnFirstCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo firstCurveInfo = this.repository.buttonFirstEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + firstCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button previous curve.
        /// </summary>
        public Button BtnPreviousCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo previousCurveInfo = this.repository.buttonPreviousEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + previousCurveInfo.AbsolutePath,
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
        /// Gets the button next curve.
        /// </summary>
        public Button BtnNextCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo nextCurveInfo = this.repository.buttonNextEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + nextCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button last curve.
        /// </summary>
        public Button BtnLastCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo lastCurveInfo = this.repository.buttonLastEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + lastCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button read curve.
        /// </summary>
        public Button BtnReadCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo readCurveInfo = this.repository.buttonReadCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + readCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button end read.
        /// </summary>
        public Button BtnEndRead
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo endReadInfo = this.repository.buttonNextEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + endReadInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button read settings.
        /// </summary>
        public Button BtnReadSettings
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo readSettingsInfo = this.repository.buttonReadSettingsInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + readSettingsInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button cyclic read.
        /// </summary>
        public Button BtnCyclicRead
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo cyclicReadInfo = this.repository.buttonCyclicReadInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + cyclicReadInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button cyclic read settings.
        /// </summary>
        public Button BtnCyclicReadSettings
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo cyclicReadSettingsInfo = this.repository.buttonCyclicReadSettingsInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + cyclicReadSettingsInfo.AbsolutePath,
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
        /// Gets the button reset reading range.
        /// </summary>
        public Button BtnResetReadingRange
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo resetReadingRangeInfo = this.repository.buttonResetReadingRangeInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + resetReadingRangeInfo.AbsolutePath,
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
        /// Gets the button reset zoom area.
        /// </summary>
        public Button BtnResetZoomArea
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo resetZoomAreaInfo = this.repository.buttonResetZoomAreaInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + resetZoomAreaInfo.AbsolutePath,
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
        /// Gets the button undo zoom.
        /// </summary>
        public Button BtnUndoZoom
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo undoZoomInfo = this.repository.buttonUndoZoomInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + undoZoomInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button selected curves.
        /// </summary>
        public Button BtnSelectedCurves
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo selectedCurvesInfo = this.repository.buttonSelectedCurvesInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + selectedCurvesInfo.AbsolutePath,
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
        /// Gets the button fast reverse.
        /// </summary>
        public Button BtnFastReverse
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo fastReverseInfo = this.repository.buttonFastReverseInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + fastReverseInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button reverse.
        /// </summary>
        public Button BtnReverse
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo reverseInfo = this.repository.buttonReverseInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + reverseInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button playback stop.
        /// </summary>
        public Button BtnPlaybackStop
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo playbackStopInfo = this.repository.buttonStopInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + playbackStopInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button playback pause.
        /// </summary>
        public Button BtnPlaybackPause
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo playbackPauseInfo = this.repository.buttonPauseInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + playbackPauseInfo.AbsolutePath,
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
        /// Gets the button forward.
        /// </summary>
        public Button BtnForward
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo playbackForwardInfo = this.repository.buttonForwardInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + playbackForwardInfo.AbsolutePath,
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
        /// Gets the button fast forward.
        /// </summary>
        public Button BtnFastForward
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo fastForwardInfo = this.repository.buttonFastForwardInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + fastForwardInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets the button open save restore.
        /// </summary>
        public Button BtnOpenSaveRestore
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo openSaveRestoreInfo = this.repository.buttonSaveRestoreInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + openSaveRestoreInfo.AbsolutePath,
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
        /// Gets the button open linearization online.
        /// </summary>
        public Button BtnOpenLinearizationOnline
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo openLinTableOnlineInfo = this.repository.buttonLinearizationTableOnlineInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + openLinTableOnlineInfo.AbsolutePath,
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
        /// Gets the button open event list.
        /// </summary>
        public Button BtnOpenEventList
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo openEventListInfo = this.repository.buttonEventlistExtendedHistoROMInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + openEventListInfo.AbsolutePath,
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
        /// Gets the button open create documentation.
        /// </summary>
        public Button BtnOpenCreateDocumentation
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo openCreateDocInfo = this.repository.buttonCreateDocumentationInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + openCreateDocInfo.AbsolutePath,
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
        /// Gets the button open envelope curve help.
        /// </summary>
        public Button BtnOpenEnvelopeCurveHelp
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo openEnvelopeCurveInfo = this.repository.buttonEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + openEnvelopeCurveInfo.AbsolutePath,
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

        #endregion
    }
}