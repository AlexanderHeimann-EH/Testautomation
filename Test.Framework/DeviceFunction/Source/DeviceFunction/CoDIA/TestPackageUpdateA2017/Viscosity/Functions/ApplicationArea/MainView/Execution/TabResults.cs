// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TabResults.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.GUI.ApplicationArea.MainView;

    /// <summary>
    /// Provides methods for configuring tab results
    /// </summary>
    public class TabResults : ITabResults
    {
        #region Public Properties

        /// <summary>
        /// Gets Edit Control Calculation Model
        /// </summary>
        public string EditControlCalculationModel
        {
            get
            {
                return (new EditParameter()).GetParameterValue((new ResultElements()).EditControlCalculationModel);
            }
        }

        /// <summary>
        /// Gets EditControlCoefficientX1
        /// </summary>
        public string EditControlCoefficientX1
        {
            get
            {
                return (new EditParameter()).GetParameterValue((new ResultElements()).EditControlCoefficientX1);
            }
        }

        /// <summary>
        /// Gets EditControlCoefficientX2
        /// </summary>
        public string EditControlCoefficientX2
        {
            get
            {
                return (new EditParameter()).GetParameterValue((new ResultElements()).EditControlCoefficientX2);
            }
        }

        /// <summary>
        /// Gets EditControlReferenceTemperature
        /// </summary>
        public string EditControlReferenceTemperature
        {
            get
            {
                return (new EditParameter()).GetParameterValue((new ResultElements()).EditControlReferenceTemperature);
            }
        }

        /// <summary>
        /// Gets EditControlTemperatureUnit
        /// </summary>
        public string EditControlTemperatureUnit
        {
            get
            {
                return (new EditParameter()).GetParameterValue((new ResultElements()).EditControlTemperatureUnit);
            }
        }

        /// <summary>
        /// Gets EditControlViscosityUnit
        /// </summary>
        public string EditControlViscosityUnit
        {
            get
            {
                return (new EditParameter()).GetParameterValue((new ResultElements()).EditControlViscosityUnit);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Compares all calculated coefficients against user given coefficients
        /// </summary>
        /// <param name="accuracy">
        /// maximum allowed difference between two coefficients
        /// </param>
        /// <param name="expectedCoefficients">
        /// string[] with user given coefficients
        /// </param>
        /// <returns>
        /// <br>true: if all coefficients are identical</br>
        ///     <br>false: if one paring is not identical</br>
        /// </returns>
        public bool CompareCoefficients(string accuracy, string[] expectedCoefficients)
        {
            try
            {
                double acc = Convert.ToDouble(accuracy);
                return this.CompareCoefficients(acc, expectedCoefficients);
            }
            catch (Exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Converting " + accuracy + " to double failed.");
                return false;
            }
        }

        /// <summary>
        /// Compares all calculated coefficients against user given coefficients
        /// </summary>
        /// <param name="accuracy">
        /// maximum allowed difference between two coefficients
        /// </param>
        /// <param name="expectedCoefficients">
        /// string[] with user given coefficients
        /// </param>
        /// <returns>
        /// <br>true: if all coefficients are identical</br>
        ///     <br>false: if one paring is not identical</br>
        /// </returns>
        public bool CompareCoefficients(double accuracy, string[] expectedCoefficients)
        {
            // create string arrays with all coefficients within tab Results
            var calculatedCoefficients = new[] { this.EditControlCoefficientX1, this.EditControlCoefficientX2 };

            int index = 0;

            // convert strings to double values, check if absolute value of the difference between them is smaller than the accuracy value
            foreach (string actualValue in calculatedCoefficients)
            {
                decimal actualValueAsDecimal;
                decimal expectedCoefficientsAsDecimal;

                if (decimal.TryParse(actualValue, out actualValueAsDecimal) && decimal.TryParse(expectedCoefficients[index], out expectedCoefficientsAsDecimal))
                {
                    double calculated = Convert.ToDouble(actualValue);
                    double userGivenCoefficient = Convert.ToDouble(expectedCoefficients[index]);
                    if (Math.Abs(calculated - userGivenCoefficient) > accuracy)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients are different: " + calculated + " -> " + userGivenCoefficient);
                        return false;
                    }
                }
                else
                {
                    if (actualValue == null || expectedCoefficients[index] == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A Coefficient is null");
                        return false;
                    }

                    if (actualValue != expectedCoefficients[index])
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients are different, + " + actualValue + " != " + expectedCoefficients[index]);
                        return false;
                    }
                }

                index++;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculated Coefficients and usergiven coefficients are equal");
            return true;
        }

        #endregion
    }
}