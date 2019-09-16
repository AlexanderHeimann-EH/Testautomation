// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Elements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.GUI.MenuArea.Menubar
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    using Button = Ranorex.Button;
    using MenuItem = Ranorex.MenuItem;

    /// <summary>
    /// EnvCurIconElements contains methods to get access to [Envelope Curve] menu bar entries.
    /// </summary>
    public class Elements
    {
        #region members

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ElementsRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Elements"/> class. 
        /// Creates an instance of the repository which will be used
        /// </summary>
        public Elements()
        {
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
            this.repository = ElementsRepository.Instance;
        }

        #endregion

        #region Menu-specific

        // DO NOT USE A MDI CLIENT PATH FOR THE MENU ELEMENTS

        /// <summary>
        ///  Gets menu bar -> Menu Container
        /// </summary>
        public Container MenuContainer
        {
            get
            {
                try
                {
                    Container container;
                    RepoItemInfo menuContainerInfo = this.repository.containerMenuContainerInfo;
                    Host.Local.TryFindSingle(menuContainerInfo.AbsolutePath, DefaultValues.iTimeoutLong, out container);
                    return container;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve
        /// </summary>
        public MenuItem MenuEnvelopeCurve
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo envelopeCurveMenuInfo = this.repository.menuItemEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + envelopeCurveMenuInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the menu help.
        /// </summary>
        public MenuItem MenuHelp
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo helpMenuInfo = this.repository.menuItemHelpInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + helpMenuInfo.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the entry new curve.
        /// </summary>
        public Button EntryNewCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo newCurveInfo = this.repository.buttonNewCurveInfo;
                    Host.Local.TryFindSingle(newCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Open Curve
        /// </summary>
        public Button EntryLoadCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo loadCurveInfo = this.repository.buttonOpenCurveInfo;
                    Host.Local.TryFindSingle(loadCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Save Curve
        /// </summary>
        public Button EntrySaveCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo saveCurveInfo = this.repository.buttonSaveCurveInfo;
                    Host.Local.TryFindSingle(saveCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Save Curve As
        /// </summary>
        public Button EntrySaveCurveAs
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo saveCurveAsInfo = this.repository.buttonSaveCurveAsInfo;
                    Host.Local.TryFindSingle(saveCurveAsInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Read Curve
        /// </summary>
        public Button EntryReadCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo readCurveInfo = this.repository.buttonReadCurveInfo;
                    Host.Local.TryFindSingle(readCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Cyclic Read
        /// </summary>
        public Button EntryCyclicRead
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo cyclicReadInfo = this.repository.buttonCyclicReadInfo;
                    Host.Local.TryFindSingle(cyclicReadInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Read Diagnostic
        /// </summary>
        public Button EntryReadDiagnostics
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo readDiagInfo = this.repository.buttonReadDiagnosticCurvesInfo;
                    Host.Local.TryFindSingle(readDiagInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Read Reference
        /// </summary>
        public Button EntryReadReference
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo readReferenceInfo = this.repository.buttonReadReferenceCurveInfo;
                    Host.Local.TryFindSingle(readReferenceInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> End Read / Write
        /// </summary>
        public Button EntryEndReadWrite
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo endReadWriteInfo = this.repository.buttonEndReadWriteInfo;
                    Host.Local.TryFindSingle(endReadWriteInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Read Settings
        /// </summary>
        public Button EntryReadSettings
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo readSettingsInfo = this.repository.buttonReadSettingsInfo;
                    Host.Local.TryFindSingle(readSettingsInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Cyclic Read Settings
        /// </summary>
        public Button EntryCyclicReadSettings
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo cyclicReadSettingsInfo = this.repository.buttonCyclicReadSettingsInfo;
                    Host.Local.TryFindSingle(
                        cyclicReadSettingsInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Reset Reading Range
        /// </summary>
        public Button EntryResetReadingRange
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo resetReadingRangeInfo = this.repository.buttonResetReadingRangeInfo;
                    Host.Local.TryFindSingle(resetReadingRangeInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Edit Parameter List
        /// </summary>
        public Button EntryEditParameterList
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo editParameterListInfo = this.repository.buttonEditParameterListInfo;
                    Host.Local.TryFindSingle(editParameterListInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> OverlappedCurves
        /// </summary>
        public Button EntryOverlappedCurves
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo overlappedCurvesInfo = this.repository.buttonOverlappedCurvesInfo;
                    Host.Local.TryFindSingle(overlappedCurvesInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Playback
        /// </summary>
        public MenuItem SubmenuPlayBack
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo playBackMenuInfo = this.repository.menuItemPlayBackInfo;
                    Host.Local.TryFindSingle(playBackMenuInfo.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Playback -> Select Curves
        /// </summary>
        public Button EntrySelectCurves
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo selectCurvesInfo = this.repository.buttonPlaybackSelectedCurvesInfo;
                    Host.Local.TryFindSingle(selectCurvesInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Playback -> Forward
        /// </summary>
        public Button EntryForward
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo forwardInfo = this.repository.buttonPlaybackForwardInfo;
                    Host.Local.TryFindSingle(forwardInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Playback -> Fast Forward
        /// </summary>
        public Button EntryFastForward
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo fastForwardInfo = this.repository.buttonPlaybackFastForwardInfo;
                    Host.Local.TryFindSingle(fastForwardInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Playback -> Reverse
        /// </summary>
        public Button EntryReverse
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo reverseInfo = this.repository.buttonPlaybackReverseInfo;
                    Host.Local.TryFindSingle(reverseInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Playback -> Fast Reverse
        /// </summary>
        public Button EntryFastReverse
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo fastReverseInfo = this.repository.buttonPlaybackFastReverseInfo;
                    Host.Local.TryFindSingle(fastReverseInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Playback -> Stop
        /// </summary>
        public Button EntryPlaybackStop
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo playbackStopInfo = this.repository.buttonPlaybackStopInfo;
                    Host.Local.TryFindSingle(playbackStopInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Playback -> Pause
        /// </summary>
        public Button EntryPlaybackPause
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo playbackPauseInfo = this.repository.buttonPlaybackPauseInfo;
                    Host.Local.TryFindSingle(playbackPauseInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Display
        /// </summary>
        public MenuItem SubmenuDisplay
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo menuDisplayInfo = this.repository.menuItemDisplayInfo;
                    Host.Local.TryFindSingle(menuDisplayInfo.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Display -> Clear Plot Display
        /// </summary>
        public Button EntryClearPlotDisplay
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo clearPlotDisplayInfo = this.repository.buttonDisplayClearPlotDisplayInfo;
                    Host.Local.TryFindSingle(clearPlotDisplayInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Display -> Zoom And Grid Settings
        /// </summary>
        public Button EntryZoomAndGridSettings
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo zoomInfo = this.repository.buttonDisplayZoomAndGridSettingsInfo;
                    Host.Local.TryFindSingle(zoomInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Display -> Reset Zoom Area
        /// </summary>
        public Button EntryResetZoomArea
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo resetZoomInfo = this.repository.buttonDisplayResetZoomAreaInfo;
                    Host.Local.TryFindSingle(resetZoomInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///   Gets menu bar -> Envelope Curve -> Display -> Undo Zoom
        /// </summary>
        public Button EntryUndoZoom
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo undoZoomInfo = this.repository.buttonDisplayUndoZoomInfo;
                    Host.Local.TryFindSingle(undoZoomInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Display -> First Curve
        /// </summary>
        public Button EntryFirstCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo firstCurveInfo = this.repository.buttonDisplayFirstEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(firstCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///   Gets menu bar -> Envelope Curve -> Display -> Last Curve
        /// </summary>
        public Button EntryLastCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo lastCurveInfo = this.repository.buttonDisplayLastEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(lastCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Display -> Next Curve
        /// </summary>
        public Button EntryNextCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo nextCurveInfo = this.repository.buttonDisplayNextEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(nextCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Display -> Previous Curve
        /// </summary>
        public Button EntryPreviousCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo previousCurveInfo = this.repository.buttonDisplayPreviousEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(previousCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Extract
        /// </summary>
        public Button EntryExtract
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo extractInfo = this.repository.buttonExtractInfo;
                    Host.Local.TryFindSingle(extractInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Export To File
        /// </summary>
        public Button EntryExportToFile
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo exportToFileInfo = this.repository.buttonExportToFileInfo;
                    Host.Local.TryFindSingle(exportToFileInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Edit MAP
        /// </summary>
        public Button EntryEditMAP
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo editMapInfo = this.repository.buttonEditMAPInfo;
                    Host.Local.TryFindSingle(editMapInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Stop Edit MAP
        /// </summary>
        public MenuItem SubmenuStopEditMAP
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo stopEditMapInfo = this.repository.menuItemStopEditMAPInfo;
                    Host.Local.TryFindSingle(stopEditMapInfo.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Stop Edit MAP -> Write MAP To Device
        /// </summary>
        public Button EntryWriteMAPToDevice
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo writeMapInfo = this.repository.buttonEditMapWriteMAPToDeviceInfo;
                    Host.Local.TryFindSingle(writeMapInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Stop Edit MAP -> Discard MAP Editing
        /// </summary>
        public Button EntryDiscardMAPEditing
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo discardMapInfo = this.repository.buttonEditMapDiscardMAPEditingInfo;
                    Host.Local.TryFindSingle(discardMapInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Remarks
        /// </summary>
        public Button EntryRemarks
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo remarksInfo = this.repository.buttonRemarksInfo;
                    Host.Local.TryFindSingle(remarksInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Load Ideal Echo Curve
        /// </summary>
        public Button EntryLoadIdealEchoCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo loadIdealEchoCurveInfo = this.repository.buttonLoadIdealEchoCurveInfo;
                    Host.Local.TryFindSingle(
                        loadIdealEchoCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Move Ideal Echo Curve To Peak
        /// </summary>
        public Button EntryMoveIdealEchoCurveToPeak
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo moveIdealEchoInfo = this.repository.buttonMoveIdealEchoCurveToPeakInfo;
                    Host.Local.TryFindSingle(moveIdealEchoInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor
        /// </summary>
        public MenuItem SubmenuSetCursor
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo setCursorInfo = this.repository.menuItemSetCursorInfo;
                    Host.Local.TryFindSingle(setCursorInfo.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///   Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor 1
        /// </summary>
        public MenuItem SubmenuCursor1
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo cursor1Info = this.repository.menuItemSetCursorCursor1Info;
                    Host.Local.TryFindSingle(cursor1Info.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor 2
        /// </summary>
        public MenuItem SubmenuCursor2
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo cursor2Info = this.repository.menuItemSetCursorCursor2Info;
                    Host.Local.TryFindSingle(cursor2Info.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> EditCurveUnderCursor
        /// </summary>
        public Button EntryEditCurveUnderCursor
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo editCurveUnderCursorInfo = this.repository.buttonSetCursorEditCurveUnderCursorInfo;
                    Host.Local.TryFindSingle(
                        editCurveUnderCursorInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Active
        /// </summary>
        public Button EntryActive
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorActiveInfo = this.repository.buttonSetCursorCursorXActiveInfo;
                    Host.Local.TryFindSingle(setCursorActiveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Free
        /// </summary>
        public Button EntryFree
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorFreeInfo = this.repository.buttonSetCursorCursorXFreeInfo;
                    Host.Local.TryFindSingle(setCursorFreeInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // TODO: repository

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Substracted Signal
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        public Button EntrySubstractedSignal
        {
            get
            {
                try
                {
                    // Button button;

                    // RepoItemInfo  = repository.buttonSetCursorCursorX;
                    // Host.Local.TryFindSingle(Paths.MenuentryEnvelopeCurve_SetCursor_CursorX_SubstractedSignal, DefaultValues.iTimeoutLong, out button);
                    return null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> MAP1
        /// </summary>
        public Button EntryMAP
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorMapInfo = this.repository.buttonSetCursorCursorXMapInfo;
                    Host.Local.TryFindSingle(setCursorMapInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> 
        /// </summary>
        public Button EntryEditableMAP
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorEditableMapInfo = this.repository.buttonSetCursorCursorXEditableMapInfo;
                    Host.Local.TryFindSingle(
                        setCursorEditableMapInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Envelope Curve
        /// </summary>
        public Button EntryEnvelopeCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorEnvelopeCurveInfo = this.repository.buttonSetCursorCursorXEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        setCursorEnvelopeCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // TODO: repository

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Threshold Curve
        /// </summary>
        public Button EntryThresholdCurve
        {
            get
            {
                try
                {
                    // Button button;

                    // RepoItemInfo = repository.buttonSetCursorCursorX;
                    // Host.Local.TryFindSingle(Paths.MenuentryEnvelopeCurve_SetCursor_CursorX_ThresholdCurve, DefaultValues.iTimeoutLong, out button);
                    return null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // TODO: repository

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Threshold End Of Probe
        /// </summary>
        public Button EntryThresholdEndOfProbe
        {
            get
            {
                try
                {
                    // Button button;

                    // Host.Local.TryFindSingle(Paths.MenuentryEnvelopeCurve_SetCursor_CursorX_ThresholdEndOfProbe, DefaultValues.iTimeoutLong, out button);
                    return null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // TODO: repository

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Threshold Broken Probe
        /// </summary>
        public Button EntryThresholdBrokenProbe
        {
            get
            {
                try
                {
                    // Button button;

                    // Host.Local.TryFindSingle(Paths.MenuentryEnvelopeCurve_SetCursor_CursorX_ThresholdBrokenProbe, DefaultValues.iTimeoutLong, out button);
                    return null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Ideal Echo
        /// </summary>
        public Button EntryIdealEcho
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorIdealEchoInfo = this.repository.buttonSetCursorCursorXIdealEchoCurveInfo;
                    Host.Local.TryFindSingle(
                        setCursorIdealEchoInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Threshold Gas Phase Compensation
        /// </summary>
        public Button EntryThresholdGasPhaseCompensation
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorThresholdGPCInfo =
                        this.repository.buttonSetCursorCursorXThresholdGasPhaseCompensationGPCInfo;
                    Host.Local.TryFindSingle(
                        setCursorThresholdGPCInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Off
        /// </summary>
        public Button EntryOff
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorOffInfo = this.repository.buttonSetCursorCursorXOffInfo;
                    Host.Local.TryFindSingle(setCursorOffInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Weighting Curve
        /// </summary>
        public Button EntryWeightingCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorWeightingCurveInfo = this.repository.buttonSetCursorCursorXWeightingCurveInfo;
                    Host.Local.TryFindSingle(
                        setCursorWeightingCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Threshold Tank Bottom
        /// </summary>
        public Button EntryThresholdTankBottom
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorThresholdTankButtonInfo =
                        this.repository.buttonSetCursorCursorXThresholdTankBottomInfo;
                    Host.Local.TryFindSingle(
                        setCursorThresholdTankButtonInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> First Echo Curve
        /// </summary>
        public Button EntryFirstEchoCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorFirstEchoCurveInfo = this.repository.buttonSetCursorCursorXFirstEchoCurveInfo;
                    Host.Local.TryFindSingle(
                        setCursorFirstEchoCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Ideal echo from file
        /// </summary>
        public Button EntryIdealEchoFromFile
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorIdealEchoFromFileInfo =
                        this.repository.buttonSetCursorCursorXIdealEchoFromFileInfo;
                    Host.Local.TryFindSingle(
                        setCursorIdealEchoFromFileInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Reference Curve
        /// </summary>
        public Button EntryReferenceCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorReferenceCurveInfo = this.repository.buttonSetCursorCursorXReferenceCurveInfo;
                    Host.Local.TryFindSingle(
                        setCursorReferenceCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Set Cursor -> Cursor x -> Raw Envelope Curve
        /// </summary>
        public Button EntryRawEnvelopeCurve
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo setCursorRawEnvelopeCurveInfo =
                        this.repository.buttonSetCursorCursorXRawEnvelopeCurveInfo;
                    Host.Local.TryFindSingle(
                        setCursorRawEnvelopeCurveInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Layout
        /// </summary>
        public MenuItem SubmenuLayout
        {
            get
            {
                try
                {
                    MenuItem menuItem;
                    RepoItemInfo layoutInfo = this.repository.menuItemLayoutInfo;
                    Host.Local.TryFindSingle(layoutInfo.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets menu bar -> Envelope Curve -> Layout -> All
        /// </summary>
        public Button EntryAll
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutAllInfo = this.repository.buttonLayoutAllInfo;
                    Host.Local.TryFindSingle(layoutAllInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///  Gets menu bar -> Envelope Curve -> Layout -> Diagram
        /// </summary>
        public Button EntryDiagram
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutDiagramInfo = this.repository.buttonLayoutDiagramInfo;
                    Host.Local.TryFindSingle(layoutDiagramInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Diagram and Parameters
        /// </summary>
        public Button EntryDiagramParameters
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutDiagramParamInfo = this.repository.buttonLayoutDiagramPlusParametersInfo;
                    Host.Local.TryFindSingle(
                        layoutDiagramParamInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Diagram and Info
        /// </summary>
        public Button EntryDiagramInfo
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutDiagramInfoInfo = this.repository.buttonLayoutParametersPlusInfoInfo;
                    Host.Local.TryFindSingle(layoutDiagramInfoInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Diagram and Plausibility
        /// </summary>
        public Button EntryDiagramPlausibility
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutDiagramPlausibilityInfo =
                        this.repository.buttonLayoutParametersPlusPlausibilityInfo;
                    Host.Local.TryFindSingle(
                        layoutDiagramPlausibilityInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Diagram and Info and Plausibility
        /// </summary>
        public Button EntryDiagramInfoPlausibility
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutDiagramInfoPlausibilityInfo =
                        this.repository.buttonLayoutParametersPlusInfoPlusPlausibilityInfo;
                    Host.Local.TryFindSingle(
                        layoutDiagramInfoPlausibilityInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Diagram and Parameters and Plausibility
        /// </summary>
        public Button EntryDiagramParametersPlausibility
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutDiagramParametersPlausibilityInfo =
                        this.repository.DiagramPlusParametersPlusPlausibilitInfo;
                    Host.Local.TryFindSingle(
                        layoutDiagramParametersPlausibilityInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Parameters
        /// </summary>
        public Button EntryParameters
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutParametersInfo = this.repository.buttonLayoutParametersInfo;
                    Host.Local.TryFindSingle(layoutParametersInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Parameters and Info
        /// </summary>
        public Button EntryParameterInfo
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutParametersPlusInfoInfo = this.repository.buttonLayoutParametersPlusInfoInfo;
                    Host.Local.TryFindSingle(
                        layoutParametersPlusInfoInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Parameters and Plausibility
        /// </summary>
        public Button EntryParametersPlausibility
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutParametersPlusPlausibilityInfo =
                        this.repository.buttonLayoutParametersPlusPlausibilityInfo;
                    Host.Local.TryFindSingle(
                        layoutParametersPlusPlausibilityInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Envelope Curve -> Layout -> Parameters and Info and Plausibility
        /// </summary>
        public Button EntryParametersInfoPlausibility
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo layoutParametersPlusInfoPlusPlausibilityInfo =
                        this.repository.buttonLayoutParametersPlusInfoPlusPlausibilityInfo;
                    Host.Local.TryFindSingle(
                        layoutParametersPlusInfoPlusPlausibilityInfo.AbsolutePath,
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
        /// Gets menu bar -> Help -> Contents
        /// </summary>
        public Button EntryContents
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo contentsInfo = this.repository.buttonHelpContentsInfo;
                    Host.Local.TryFindSingle(contentsInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Gets menu bar -> Help -> About
        /// </summary>
        public Button EntryAbout
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo aboutInfo = this.repository.buttonHelpAboutInfo;
                    Host.Local.TryFindSingle(aboutInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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

        #region GUI-specific

        /// <summary>
        /// Gets GUI -> Button Remarks
        /// </summary>
        public Button ButtonRemark
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo remakrButtonInfo = this.repository.buttonRemarkButtonInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + remakrButtonInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        /// Get a (sub)menu-container, containing menu entries
        /// </summary>
        /// <param name="handle">Handle for comparison, to get a different container from previously selected</param>
        /// <returns>
        /// <br>Container: If call worked fine</br>
        /// <br>NULL: If an error occurred</br>
        /// </returns>
        public Element MenuElement(IntPtr handle)
        {
            try
            {
                bool isSearching = true;
                Element element = null;
                int retries = 0;

                while (isSearching && retries < DefaultValues.SearchRetries)
                {
                    Mouse.Click();
                    RepoItemInfo menuElementInfo = this.repository.elementMenuElementInfo;

                    Host.Local.TryFindSingle(menuElementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
                    if (element != null && ((new NativeWindow(element)).Handle != handle))
                    {
                        isSearching = false;
                    }

                    retries = retries + 1;
                }

                return element;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        #endregion
    }
}