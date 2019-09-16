// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSettingsTab.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ConfigureSettingsTab.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Flows
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Historom.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class ConfigureSettingsTab.
    /// </summary>
    public class ConfigureSettingsTab : IConfigureSettingsTab
    {
        #region Public Methods and Operators

        /// <summary>
        /// Configures the HistoRom settings.
        /// </summary>
        /// <param name="assignChannel1">
        /// Assignment for channel1. Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="assignChannel2">
        /// Assignment for channel2.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="assignChannel3">
        /// Assignment for channel3.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="assignChannel4">
        /// Assignment for channel4.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="loggingInterval">
        /// The logging interval.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <param name="clearLoggingData">
        /// Clear logging data.Use string.empty if you do not want to modify this parameter.
        /// </param>
        /// <returns>
        /// <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(string assignChannel1, string assignChannel2, string assignChannel3, string assignChannel4, string loggingInterval, string clearLoggingData)
        {
            bool result = Execution.RunSelectTab.Run(3);

            if (assignChannel1 != string.Empty)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Assigning Channel 1 to: " + assignChannel1 + " .");
                result &= Execution.ChangeChannelAssignment.Run(1, assignChannel1);
            }

            if (assignChannel2 != string.Empty)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Assigning Channel 2 to: " + assignChannel2 + " .");
                result &= Execution.ChangeChannelAssignment.Run(2, assignChannel2);
            }

            if (assignChannel3 != string.Empty)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Assigning Channel 3 to: " + assignChannel3 + " .");
                result &= Execution.ChangeChannelAssignment.Run(3, assignChannel3);
            }

            if (assignChannel4 != string.Empty)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Assigning Channel 4 to: " + assignChannel4 + " .");
                result &= Execution.ChangeChannelAssignment.Run(4, assignChannel4);
            }

            if (loggingInterval != string.Empty)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Setting Logging Interval to: " + loggingInterval + " .");
                result &= Execution.Settings.SetLoggingInterval(loggingInterval);
            }

            if (clearLoggingData != string.Empty)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Setting Clear Logging Data to: " + clearLoggingData + " .");
                result &= Execution.Settings.ClearLoggingData(clearLoggingData);
            }

            return result;
        }

        #endregion
    }
}