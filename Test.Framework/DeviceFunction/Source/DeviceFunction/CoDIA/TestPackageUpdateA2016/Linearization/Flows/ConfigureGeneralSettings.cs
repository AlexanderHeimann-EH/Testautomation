﻿
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Linearization.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class ConfigureGeneralSettings.
    /// </summary>
    public class ConfigureGeneralSettings : IConfigureGeneralSettings
    {
        /// <summary>
        /// Opens the tab Settings and configures the General Settings parameter. Use string.empty if you want to skip a parameter.
        /// </summary>
        /// <param name="linearizationType">The linearization type.</param>
        /// <param name="emptyCalibration">The empty calibration.</param>
        /// <param name="fullCalibration">The full calibration.</param>
        /// <param name="distanceUnit">The distance unit.</param>
        /// <param name="levelUnit">The level unit.</param>
        /// <returns><c>true</c> if configuration successful, <c>false</c> otherwise.</returns>
        public bool Run(string linearizationType, string emptyCalibration, string fullCalibration, string distanceUnit, string levelUnit)
        {
            bool result = Execution.SelectTab.Run(2);
            var pattern = new Regex(@"\W"); 
           
            if (linearizationType != string.Empty)
            {
                result &= Execution.ConfigureSettingsTab.SetGeneralSettingsLinearizationType(linearizationType);
                string testValue = pattern.Replace(linearizationType, string.Empty);
                string referenceValue = pattern.Replace(Execution.ConfigureSettingsTab.GetGeneralSettingsLinearizationType(), string.Empty);
                result &= AssertFunctions.AreEqual(testValue, referenceValue, "Checking whether the linearizationType has been set correctly.");
            }

            if (emptyCalibration != string.Empty)
            {
                result &= Execution.ConfigureSettingsTab.SetGeneralSettingsEmptyCalibration(emptyCalibration);
                result &= AssertFunctions.AreEqual(emptyCalibration, Execution.ConfigureSettingsTab.GetGeneralSettingsEmptyCalibration(), "Checking whether the empty calibration has been set correctly.");
            }

            if (fullCalibration != string.Empty)
            {
                result &= Execution.ConfigureSettingsTab.SetGeneralSettingsFullCalibration(fullCalibration);
                result &= AssertFunctions.AreEqual(fullCalibration, Execution.ConfigureSettingsTab.GetGeneralSettingsFullCalibration(), "Checking whether the full calibration has been set correctly.");
            }

            if (distanceUnit != string.Empty)
            {
                result &= Execution.ConfigureSettingsTab.SetGeneralSettingsDistanceUnit(distanceUnit);
                result &= AssertFunctions.AreEqual(distanceUnit, Execution.ConfigureSettingsTab.GetGeneralSettingsDistanceUnit(), "Checking whether the distanceUnit has been set correctly.");
            }

            if (levelUnit != string.Empty)
            {
                result &= Execution.ConfigureSettingsTab.SetGeneralSettingsLevelUnit(levelUnit);
                result &= AssertFunctions.AreEqual(levelUnit, Execution.ConfigureSettingsTab.GetGeneralSettingsLevelUnit(), "Checking whether the levelUnit has been set correctly.");
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Configuring settings finished successfully.");
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "An error occurred. Configuration was not successful.");
            }

            return result;
        }
    }
}