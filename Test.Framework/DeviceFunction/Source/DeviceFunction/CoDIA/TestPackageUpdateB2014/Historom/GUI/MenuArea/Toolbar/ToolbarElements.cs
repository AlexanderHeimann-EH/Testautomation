//------------------------------------------------------------------------------
// <copyright file="ToolbarElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.GUI.MenuArea.Toolbar
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to the toolbar icons within HISTOROM module
    /// </summary>
    public class ToolbarElements
    {
        #region members

        /// <summary>
        /// The HISTOROM.
        /// </summary>
        private readonly Toolbar historom;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolbarElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public ToolbarElements()
        {
            this.historom = Toolbar.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Gets tool bar button -> new
        /// </summary>
        public Button ButtonNew
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonNewInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button new is null");
                        return null;
                    }

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
        ///     Gets tool bar button -> load
        /// </summary>
        public Button ButtonLoad
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonLoadInfo;
                    string pathToItem = this.mdiClientPath + buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button load is null");
                        return null;
                    }

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
        ///     Gets tool bar button -> save
        /// </summary>
        public Button ButtonSave
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonSaveInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button new is null");
                        return null;
                    }

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
        ///  Gets tool bar button -> save as
        /// </summary>
        public Button ButtonSaveAs
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonSaveAsInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button new is null");
                        return null;
                    }

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
        ///  Gets tool bar button -> export
        /// </summary>
        public Button ButtonExport
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonExportInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button new is null");
                        return null;
                    }

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
        ///  Gets tool bar button -> zoom in
        /// </summary>
        public Button ButtonZoomIn
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonZoomInInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button zoom in is null");
                        return null;
                    }

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
        ///     Gets tool bar button -> zoom out
        /// </summary>
        public Button ButtonZoomOut
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonZoomOutInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button zoom out is null");
                        return null;
                    }

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
        ///     Gets tool bar button -> scroll up
        /// </summary>
        public Button ButtonScrollUp
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonNavigateForwardsInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button navigate forward is null");
                        return null;
                    }

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
        /// Gets toolbar button -> scroll down
        /// </summary>
        public Button ButtonScrollDown
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonNavigateBackwardsInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button navigate backward is null");
                        return null;
                    }

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
        /// Gets tool bar button -> read
        /// </summary>
        public Button ButtonRead
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonReadInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button read is null");
                        return null;
                    }

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
        /// Gets tool bar button -> cancel
        /// </summary>
        public Button ButtonCancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonCancelInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button cancel is null");
                        return null;
                    }

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
        /// Gets tool bar button -> help
        /// </summary>
        public Button ButtonHelp
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonHelpInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button help is null");
                        return null;
                    }

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
        ///  Gets tool bar button -> Reset Zoom
        /// </summary>
        public Button ButtonResetZoom
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo buttonInfo = this.historom.buttonResetZoomRangeInfo;
                    string pathToItem = this.mdiClientPath +buttonInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out button);
                    if (button == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button reset zoom is null");
                        return null;
                    }

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