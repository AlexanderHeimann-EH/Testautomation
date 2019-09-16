// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckResultsAfterCalculation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CheckResultsAfterCalculation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.Flows
{
    using System.Reflection;
    using System.Text.RegularExpressions;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Viscosity.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Class CheckResultsAfterCalculation.
    /// </summary>
    public class CheckResultsAfterCalculation : ICheckResultsAfterCalculation
    {
        #region Public Methods and Operators

        /// <summary>
        /// Opens tab 'Fluid Properties' and checks whether 'Reference viscosity' represents a float value.
        /// Then opens tab 'Results' and checks whether 'Calculation Model', 'Coefficient X1, 'Coefficient X2' and 'Reference Temperature' have valid values.
        /// Finally opens tab 'Analysis' and makes a screenshot of the module
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Run()
        {
            bool result = Execution.SelectTab.Run(0);

            result &= this.CheckReferenceViscosityAfterCalculation();
            result &= Execution.SelectTab.Run(1);
            result &= this.CheckCalculationModelAfterCalculation();
            result &= this.CheckCompensationCoefficientsAfterCalculation();
            result &= this.CheckReferenceTemperatureAfterCalculation();
            result &= Execution.SelectTab.Run(2);
            Execution.TakeScreenshotOfModule.Run();

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks the calculation model after calculation.
        /// </summary>
        /// <returns><c>true</c> if it either shows power law, exponential or polynomial, <c>false</c> otherwise.</returns>
        private bool CheckCalculationModelAfterCalculation()
        {
            bool result;
            Element calculationModel = new ResultElements().EditControlCalculationModel;
            if (calculationModel == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Calculation Model' is null.");
                result = false;
            }
            else
            {
                string calculationModelText = calculationModel.GetAttributeValueText("Text");
                if (calculationModelText.Contains("Power Law") || calculationModelText.Contains("Exponential") || calculationModelText.Contains("Polynomial"))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation Model = " + calculationModelText + ".");
                    result = true;
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculation Model = " + calculationModelText + ".");
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks the compensation coefficients after calculation.
        /// </summary>
        /// <returns><c>true</c> if they represent float values, <c>false</c> otherwise.</returns>
        private bool CheckCompensationCoefficientsAfterCalculation()
        {
            bool result;
            Element coefficientX1 = new ResultElements().EditControlCoefficientX1;
            Element coefficientX2 = new ResultElements().EditControlCoefficientX2;

            if (coefficientX1 == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Compensation Coefficient X1' is null.");
                result = false;
            }
            else if (coefficientX2 == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Compensation Coefficient X2' is null.");
                result = false;
            }
            else
            {
                string coefficientX1Text = coefficientX1.GetAttributeValueText("Text");
                string coefficientX2Text = coefficientX2.GetAttributeValueText("Text");

                const string Pattern = @"(\d{1,}\.\d{1,})";
                var regex = new Regex(Pattern);

                if (regex.IsMatch(coefficientX1Text) && regex.IsMatch(coefficientX2Text))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compensation coefficient X1 = " + coefficientX1Text + "." + " Compensation coefficient X2 = " + coefficientX2Text + ".");
                    result = true;
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Compensation coefficient X1 = " + coefficientX1Text + "." + " Compensation coefficient X2 = " + coefficientX2Text + ".");
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks the reference temperature after calculation.
        /// </summary>
        /// <returns><c>true</c> if it represents a float value, <c>false</c> otherwise.</returns>
        private bool CheckReferenceTemperatureAfterCalculation()
        {
            bool result;

            Element referenceTemperature = new FluidPropertiesElements().NumericTextBoxReferenceTemperature;
            if (referenceTemperature == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Reference temperature' is null.");
                result = false;
            }
            else
            {
                string referenceTemperatureText = referenceTemperature.GetAttributeValueText("Text");
                const string Pattern = @"(\d{1,}\.\d{1,})";
                var regex = new Regex(Pattern);

                if (regex.IsMatch(referenceTemperatureText))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reference temperature = " + referenceTemperatureText + ".");
                    result = true;
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reference temperature does not match the pattern digit(s).digit(s). Temperature = " + referenceTemperatureText + ".");
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks the reference viscosity after calculation.
        /// </summary>
        /// <returns><c>true</c> if it is a float value, <c>false</c> otherwise.</returns>
        private bool CheckReferenceViscosityAfterCalculation()
        {
            bool result;

            Element referenceViscosity = new FluidPropertiesElements().EditControlReferenceViscosity;
            if (referenceViscosity == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The element 'Reference viscosity' is null.");
                result = false;
            }
            else
            {
                string referenceViscosityText = referenceViscosity.GetAttributeValueText("Text");
                const string Pattern = @"(\d{1,})";
                var regex = new Regex(Pattern);

                if (regex.IsMatch(referenceViscosityText))
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reference viscosity = " + referenceViscosityText + ".");
                    result = true;
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reference viscosity = " + referenceViscosityText + ".");
                    result = false;
                }
            }

            return result;
        }

        #endregion
    }
}