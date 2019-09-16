// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Elements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   EnvCurIconElements contains methods to get access to [Envelope Curve] menu bar entries.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.GUI.MenuArea.Menubar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// EnvCurIconElements contains methods to get access to [Envelope Curve] menu bar entries.
    /// </summary>
    public class Elements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Elements"/> class. 
        /// Creates an instance of the repository which will be used
        /// </summary>
        public Elements()
        {
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
            this.repository = ElementsRepository.Instance;
        }

        #endregion

        #region Public Properties

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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        // DO NOT USE A MDI CLIENT PATH FOR THE MENU ELEMENTS

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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Host.Local.TryFindSingle(cyclicReadSettingsInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Host.Local.TryFindSingle(this.mdiClientPath + envelopeCurveMenuInfo.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Host.Local.TryFindSingle(this.mdiClientPath + helpMenuInfo.AbsolutePath, DefaultValues.iTimeoutLong, out menuItem);
                    return menuItem;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Get a (sub)menu-container, containing menu entries
        /// </summary>
        /// <param name="handle">
        /// Handle for comparison, to get a different container from previously selected
        /// </param>
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