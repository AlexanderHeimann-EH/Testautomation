//------------------------------------------------------------------------------
// <copyright file="Statistic.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.ApplicationArea.MainView.Execution
{
    using System;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.GUI.ApplicationArea.MainView;

    /// <summary>
    ///     Provides methods for text boxes in tab "Statistics"
    /// </summary>
    public class Statistic : MarshalByRefObject, IStatistic
    {
        #region text boxes

        #region overall statistic

        /// <summary>
        /// Gets the number values per channel.
        /// </summary>
        public string NumberValuesPerChannel
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtNumberValuesPerChannel); }
        }

        /// <summary>
        /// Gets the logging interval.
        /// </summary>
        public string LoggingInterval
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtLoggingInterval); }
        }

        /// <summary>
        /// Gets the time first value.
        /// </summary>
        public string TimeFirstValue
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtTimeFirstValue); }
        }

        /// <summary>
        /// Gets the time last value.
        /// </summary>
        public string TimeLastValue
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtTimeLastValue); }
        }

        #endregion

        #region channel statistics

        #region channel1

        /// <summary>
        /// Gets the caption channel 1.
        /// </summary>
        public string CaptionChannel1
        {
            get { return Common.GetParameterValue((new StatisticElements()).LblCaptionChannel1); }
        }

        /// <summary>
        /// Gets the mean value channel 1.
        /// </summary>
        public string MeanValueChannel1
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMeanValueChannel1); }
        }

        /// <summary>
        /// Gets the standard deviation channel 1.
        /// </summary>
        public string StandardDeviationChannel1
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtStandardDeviationChannel1); }
        }

        /// <summary>
        /// Gets the minimum channel 1.
        /// </summary>
        public string MinimumChannel1
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMinimumChannel1); }
        }

        /// <summary>
        /// Gets the maximum channel 1.
        /// </summary>
        public string MaximumChannel1
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMaximumChannel1); }
        }

        /// <summary>
        /// Gets the range channel 1.
        /// </summary>
        public string RangeChannel1
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtRangeChannel1); }
        }

        #endregion

        #region channel2

        /// <summary>
        /// Gets the caption channel 2.
        /// </summary>
        public string CaptionChannel2
        {
            get { return Common.GetParameterValue((new StatisticElements()).LblCaptionChannel2); }
        }

        /// <summary>
        /// Gets the mean value channel 2.
        /// </summary>
        public string MeanValueChannel2
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMeanValueChannel2); }
        }

        /// <summary>
        /// Gets the standard deviation channel 2.
        /// </summary>
        public string StandardDeviationChannel2
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtStandardDeviationChannel2); }
        }

        /// <summary>
        /// Gets the minimum channel 2.
        /// </summary>
        public string MinimumChannel2
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMinimumChannel2); }
        }

        /// <summary>
        /// Gets the maximum channel 2.
        /// </summary>
        public string MaximumChannel2
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMaximumChannel2); }
        }

        /// <summary>
        /// Gets the range channel 2.
        /// </summary>
        public string RangeChannel2
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtRangeChannel2); }
        }

        #endregion

        #region channel3

        /// <summary>
        /// Gets the caption channel 3.
        /// </summary>
        public string CaptionChannel3
        {
            get { return Common.GetParameterValue((new StatisticElements()).LblCaptionChannel3); }
        }

        /// <summary>
        /// Gets the mean value channel 3.
        /// </summary>
        public string MeanValueChannel3
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMeanValueChannel3); }
        }

        /// <summary>
        /// Gets the standard deviation channel 3.
        /// </summary>
        public string StandardDeviationChannel3
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtStandardDeviationChannel3); }
        }

        /// <summary>
        /// Gets the minimum channel 3.
        /// </summary>
        public string MinimumChannel3
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMinimumChannel3); }
        }

        /// <summary>
        /// Gets the maximum channel 3.
        /// </summary>
        public string MaximumChannel3
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMaximumChannel3); }
        }

        /// <summary>
        /// Gets the range channel 3.
        /// </summary>
        public string RangeChannel3
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtRangeChannel3); }
        }

        #endregion

        #region channel4

        /// <summary>
        /// Gets the caption channel 4.
        /// </summary>
        public string CaptionChannel4
        {
            get { return Common.GetParameterValue((new StatisticElements()).LblCaptionChannel4); }
        }

        /// <summary>
        /// Gets the mean value channel 4.
        /// </summary>
        public string MeanValueChannel4
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMeanValueChannel4); }
        }

        /// <summary>
        /// Gets the standard deviation channel 4.
        /// </summary>
        public string StandardDeviationChannel4
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtStandardDeviationChannel4); }
        }

        /// <summary>
        /// Gets the minimum channel 4.
        /// </summary>
        public string MinimumChannel4
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMinimumChannel4); }
        }

        /// <summary>
        /// Gets the maximum channel 4.
        /// </summary>
        public string MaximumChannel4
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtMaximumChannel4); }
        }

        /// <summary>
        /// Gets the range channel 4.
        /// </summary>
        public string RangeChannel4
        {
            get { return Common.GetParameterValue((new StatisticElements()).TxtRangeChannel4); }
        }

        #endregion

        #endregion

        #endregion
    }
}