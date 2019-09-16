//------------------------------------------------------------------------------
// <copyright file="StatisticResults.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.Historom.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    ///     Description of StatisticResults.
    /// </summary>
    public class StatisticResults : IStatisticResults
    {
        /// <summary>
        ///     Compares the actual channel assignment with a user given value
        /// </summary>
        /// <param name="channel">Channel number</param>
        /// <param name="selection">Assignment given by the user</param>
        /// <returns>
        /// true: If user given assignment and actual assignment match; false: If an error occurred
        /// </returns>
        public bool IsChannelAssignmentCorrect(int channel, string selection)
        {
            int channelNumber = channel;
            switch (channelNumber)
            {
                case 1:
                    string channel1 = new Statistic().CaptionChannel1;
                    if (channel1 == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Label Caption Channel1 is null");
                        return false;
                    }

                    if (channel1.Equals(selection))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Channel assignment is correct");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Channel assignment is not correct. Is: " + channel1 + " should be: " + selection);
                    return false;

                case 2:
                    string channel2 = new Statistic().CaptionChannel2;
                    if (channel2 == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Label Caption Channel2 is null");
                        return false;
                    }

                    if (channel2.Equals(selection))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Channel assignment is correct");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Channel assignment is not correct. Is: " + channel2 + " should be: " + selection);
                    return false;

                case 3:
                    string channel3 = new Statistic().CaptionChannel3;
                    if (channel3 == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Label Caption Channel3 is null");
                        return false;
                    }

                    if (channel3.Equals(selection))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Channel assignment is correct");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Channel assignment is not correct. Is: " + channel3 + " should be: " + selection);
                    return false;

                case 4:
                    string channel4 = new Statistic().CaptionChannel4;
                    if (channel4 == null)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Label Caption Channel4 is null");
                        return false;
                    }

                    if (channel4.Equals(selection))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Channel assignment is correct");
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                        LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                        "Channel assignment is not correct. Is: " + channel4 + " should be: " + selection);
                    return false;
                default:
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), " Unkown Channel selection");
                    return false;
            }
        }

        /// <summary>
        ///     Checks whether the tab statistic contains any values
        /// </summary>
        /// <returns>
        ///     true: if at least on textbox contains a value
        ///     false: all textboxes are empty
        /// </returns>
        public bool HasStatisticTabValues()
        {
            return this.HasOverallStatisticValues() || this.HasChannel1Values() || this.HasChannel2Values() || this.HasChannel3Values() ||
                   this.HasChannel4Values();
        }

        /// <summary>
        ///     Checks if overall statistic within tab statistic has values
        /// </summary>
        /// <returns>
        ///     true: if one text field has a value
        ///     false: if none text fields contain a value
        /// </returns>
        private bool HasOverallStatisticValues()
        {
            // overall statistic
            if (new Statistic().NumberValuesPerChannel.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().LoggingInterval.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().TimeFirstValue.Equals(string.Empty) == false)
            {
                return true;
            }

            return new Statistic().TimeLastValue.Equals(string.Empty) == false;
        }

        /// <summary>
        ///     Checks if channel 1 within tab statistic has values
        /// </summary>
        /// <returns>
        ///     true: if one text field has a value
        ///     false: if none text fields contain a value
        /// </returns>
        private bool HasChannel1Values()
        {
            // channel1
            if (new Statistic().MeanValueChannel1.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().StandardDeviationChannel1.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().MinimumChannel1.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().MaximumChannel1.Equals(string.Empty) == false)
            {
                return true;
            }

            return new Statistic().RangeChannel1.Equals(string.Empty) == false;
        }

        /// <summary>
        ///     Checks if channel 2 within tab statistic has values
        /// </summary>
        /// <returns>
        ///     true: if one text field has a value
        ///     false: if none text fields contain a value
        /// </returns>
        private bool HasChannel2Values()
        {
            // channel2
            if (new Statistic().MeanValueChannel2.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().StandardDeviationChannel2.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().MinimumChannel2.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().MaximumChannel2.Equals(string.Empty) == false)
            {
                return true;
            }

            return new Statistic().RangeChannel2.Equals(string.Empty) == false;
        }

        /// <summary>
        ///     Checks if channel 3 within tab statistic has values
        /// </summary>
        /// <returns>
        ///     true: if one text field has a value
        ///     false: if none text fields contain a value
        /// </returns>
        private bool HasChannel3Values()
        {
            // channel3
            if (new Statistic().MeanValueChannel3.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().StandardDeviationChannel3.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().MinimumChannel3.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().MaximumChannel3.Equals(string.Empty) == false)
            {
                return true;
            }

            return new Statistic().RangeChannel3.Equals(string.Empty) == false;
        }

        /// <summary>
        ///     Checks if channel 4 within tab statistic has values
        /// </summary>
        /// <returns>
        ///     true: if one text field has a value
        ///     false: if none text fields contain a value
        /// </returns>
        private bool HasChannel4Values()
        {
            // channel4
            if (new Statistic().MeanValueChannel4.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().StandardDeviationChannel4.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().MinimumChannel4.Equals(string.Empty) == false)
            {
                return true;
            }

            if (new Statistic().MaximumChannel4.Equals(string.Empty) == false)
            {
                return true;
            }

            return new Statistic().RangeChannel4.Equals(string.Empty) == false;
        }
    }
}