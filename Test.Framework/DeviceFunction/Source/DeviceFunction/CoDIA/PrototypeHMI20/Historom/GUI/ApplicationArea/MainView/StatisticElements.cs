//------------------------------------------------------------------------------
// <copyright file="StatisticElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Historom.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of StatisticElements.
    /// </summary>
    public class StatisticElements
    {
        #region members

        /// <summary>
        /// The HISTOROM repository.
        /// </summary>
        private readonly Controls historom;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticElements"/> class. 
        ///     Constructor creates an instance of repository which will be used
        /// </summary>
        public StatisticElements()
        {
            this.historom = Controls.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region methods

        #region overall statistic

        /// <summary>
        ///     Gets text field of "numbers of values per channel"
        /// </summary>
        public Element TxtNumberValuesPerChannel
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.OverallStatistic.txtNumberValuesPerChannelInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Textfield numbers of values per channel is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field "logging interval"
        /// </summary>
        public Element TxtLoggingInterval
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.OverallStatistic.txtLoggingIntervalInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield logging interval is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field "time first value"
        /// </summary>
        public Element TxtTimeFirstValue
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.OverallStatistic.txtTimeFirstValueInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield time first value is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field "time last value"
        /// </summary>
        public Element TxtTimeLastValue
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.OverallStatistic.txtTimeLastValueInfo;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield time last value is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #region channel statistic

        #region channel 1

        /// <summary>
        ///     Gets label caption channel1
        /// </summary>
        public Element LblCaptionChannel1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.lblCaptionChanel1Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Label caption channel1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error("StatisticElements.lblCaptionChanel1", exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "mean value channel 1"
        /// </summary>
        public Element TxtMeanValueChannel1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMeanValueChannel1Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield mean value channel1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Standard deviation Channel 1"
        /// </summary>
        public Element TxtStandardDeviationChannel1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtStandardDeviationChannel1Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Textfield standarddeviation channel1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Minimum Channel 1"
        /// </summary>
        public Element TxtMinimumChannel1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMinimumChannel1Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield minimum channel1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Maximum Channel 1"
        /// </summary>
        public Element TxtMaximumChannel1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMaximumChannel1Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield maximium channel1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Range Channel 1"
        /// </summary>
        public Element TxtRangeChannel1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtRangeChannel1Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield range channel1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #region channel 2

        /// <summary>
        ///     Gets label caption channel2
        /// </summary>
        public Element LblCaptionChannel2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.lblCaptionChanel2Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Label caption channel2 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "mean value channel 2"
        /// </summary>
        public Element TxtMeanValueChannel2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMeanValueChannel2Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield mean value channel2 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Standard deviation Channel 2"
        /// </summary>
        public Element TxtStandardDeviationChannel2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtStandardDeviationChannel2Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Textfield standard deviation channel2 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Minimum Channel 2"
        /// </summary>
        public Element TxtMinimumChannel2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMinimumChannel2Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield minimum channel2 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Maximum Channel 2"
        /// </summary>
        public Element TxtMaximumChannel2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMaximumChannel2Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield maximum channel 2 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Range Channel 2"
        /// </summary>
        public Element TxtRangeChannel2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtRangeChannel2Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield range channel1 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #region channel 3

        /// <summary>
        ///     Gets label caption channel3
        /// </summary>
        public Element LblCaptionChannel3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.lblCaptionChanel3Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Label caption channel3 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "mean value channel 3"
        /// </summary>
        public Element TxtMeanValueChannel3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMeanValueChannel3Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield mean value channel3 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Standard deviation Channel 3"
        /// </summary>
        public Element TxtStandardDeviationChannel3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtStandardDeviationChannel3Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Textfield standarddeviation channel3 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Minimum Channel 3"
        /// </summary>
        public Element TxtMinimumChannel3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMinimumChannel3Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield minimum channel3 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Maximum Channel 3"
        /// </summary>
        public Element TxtMaximumChannel3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMaximumChannel3Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield maximium channel3 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Range Channel 3"
        /// </summary>
        public Element TxtRangeChannel3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtRangeChannel3Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield range channel3 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #region channel 4

        /// <summary>
        ///     Gets label caption channel4
        /// </summary>
        public Element LblCaptionChannel4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.lblCaptionChanel4Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Label caption channel4 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "mean value channel 4"
        /// </summary>
        public Element TxtMeanValueChannel4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMeanValueChannel4Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield mean value channel4 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Standard deviation Channel 4"
        /// </summary>
        public Element TxtStandardDeviationChannel4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtStandardDeviationChannel4Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Textfield standard deviation channel4 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Minimum Channel 4"
        /// </summary>
        public Element TxtMinimumChannel4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMinimumChannel4Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield minimum channel4 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Maximum Channel 4"
        /// </summary>
        public Element TxtMaximumChannel4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtMaximumChannel4Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield maximium channel4 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text field of "Range Channel 4"
        /// </summary>
        public Element TxtRangeChannel4
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.historom.Statistic.ChannelStatistic.txtRangeChannel4Info;
                    string pathToItem = this.mdiClientPath + elementInfo.AbsolutePath;
                    Host.Local.TryFindSingle(pathToItem, DefaultValues.iTimeoutLong, out element);
                    if (element == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Textfield range channel4 is null");
                        return null;
                    }

                    return element;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion

        #endregion

        #endregion
    }
}