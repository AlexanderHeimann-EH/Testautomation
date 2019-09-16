// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.GUI.ApplicationArea.MainView
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
    ///     Provides access to the combo boxes within tab "settings"
    /// </summary>
    public class SettingsElements
    {
        #region Fields

        /// <summary>
        /// The HISTOROM repository.
        /// </summary>
        private readonly Controls historom;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public SettingsElements()
        {
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
            this.historom = Controls.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets tab "Settings" -> combo box assignment channel 1"
        /// </summary>
        public Element ComboBoxAssignmentChannel1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.ComboBoxAssignmentChannel1Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combobox assignement channel 1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab "Settings" -> combo box assignment channel 2"
        /// </summary>
        public Element ComboBoxAssignmentChannel2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.ComboBoxAssignmentChannel2Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combobox assignment channel 2 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab "Settings" -> combo box assignment channel 3"
        /// </summary>
        public Element ComboBoxAssignmentChannel3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.ComboBoxAssignmentChannel3Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combobox assignment channel 3 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab "Settings" -> combo box assignment channel 4"
        /// </summary>
        public Element ComboBoxAssignmentChannel4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.ComboBoxAssignmentChannel4Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combobox assignment channel 4 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab "Settings" -> combo box ComboBoxClearLoggingData"
        /// </summary>
        public Element ComboBoxClearLoggingData
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.ComboBoxClearLoggingDataInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combo box ComboBoxClearLoggingData is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///    Gets control which contains status icon for channel 1"
        /// </summary>
        public Element StatusIconChannel1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.StatusIconChannel1Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Status icon channel 1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the control which contains status icon for channel 2"
        /// </summary>
        public Element StatusIconChannel2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.StatusIconChannel2Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Status icon channel 2 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the control which contains status icon for channel 3"
        /// </summary>
        public Element StatusIconChannel3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.StatusIconChannel3Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Status icon channel 3 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the control which contains status icon for channel 4"
        /// </summary>
        public Element StatusIconChannel4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.StatusIconChannel4Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Status icon channel 4");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the control which contains status icon for logging interval"
        /// </summary>
        public Element StatusIconLogInterval
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.StatusIconLogIntervalInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Status icon log interval is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets the control which contains status icon for clear logging data"
        /// </summary>
        public Element StatusIconClearLoggingData
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.StatusIconClearLoggingDataInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Status icon clear logging data is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets tab "Settings" -> text box save interval"
        /// </summary>
        public Element TextBoxSaveInterval
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Settings.TextBoxSaveIntervalInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textbox save intervall is null");
                        return null;
                    }

                    return element;
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