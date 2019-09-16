// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckThatAllFieldsInBaseSettingsAreGrayed.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CheckThatAllFieldsInBaseSettingsAreGrayed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Class CheckThatAllFieldsInBaseSettingsAreGrayed.
    /// </summary>
    public class CheckThatAllFieldsInBaseSettingsAreGrayed : ICheckThatAllFieldsInBaseSettingsAreGrayed
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether all elements in the tab 'Base settings' ( combo boxes, edit fields etc...) except 'Calculation base' are grayed and inactive. 
        /// This is the case when selecting 'Fine tuning' as 'Calculation base'.
        /// </summary>
        /// <returns><c>true</c> if all elements are grayed, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            bool result = true;

            Element calculationBase = new BaseSettingsElements().ComboBoxCalculationBase;
            Element liquidType = new BaseSettingsElements().ComboBoxLiquidType;            
            Element mineralContent = new BaseSettingsElements().EditFieldMineralContent;            
            Element averageProcessPressure = new BaseSettingsElements().EditFieldAverageProcessPressure;
            Element averageProcessPressureUnit = new BaseSettingsElements().ComboBoxAverageProcessPressureUnit;
            Element temperatureMax = new BaseSettingsElements().TextTemperatureMax;
            Element temperatureMin = new BaseSettingsElements().TextTemperatureMin;
            Element temperatureUnit = new BaseSettingsElements().ComboBoxTemperatureUnit;
            Element concentrationMax = new BaseSettingsElements().TextConcentrationMax;
            Element concentrationMin = new BaseSettingsElements().TextConcentrationMin;
            Element concentrationUnit = new BaseSettingsElements().ComboBoxConcentrationUnit;

            Element[] elements = { liquidType, mineralContent, averageProcessPressure, averageProcessPressureUnit, temperatureMax, temperatureMin, temperatureUnit, concentrationMax, concentrationMin, concentrationUnit };

            if (calculationBase == null)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation Base is null.");
            }
            else if (calculationBase.Enabled == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation Base is grayed out and not enabled.");
            }
            else
            {
                foreach (var element in elements)
                {
                    if (element == null)
                    {
                        result = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "One element in tab 'Base Settings' is null.");
                        break;
                    }

                    if (element.Enabled)
                    {
                        result = false;
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element: \" " + element.GetAttributeValueText("controlname") + " \" is enabled but should be grayed and inactive.");
                        new TakeScreenshotOfModule().Run();
                        break;
                    }
                }
            }

            if (result)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "All elements (except 'Calculation Base' are grayed and inactive as expected.");
            }

            return result;
        }

        #endregion
    }
}