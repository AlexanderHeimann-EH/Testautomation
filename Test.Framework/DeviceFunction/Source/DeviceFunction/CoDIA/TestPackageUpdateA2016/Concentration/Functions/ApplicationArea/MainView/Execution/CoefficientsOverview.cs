// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoefficientsOverview.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.GUI.ApplicationArea.MainView;

    /// <summary>
    ///     Provides methods for tab coefficients overview within module concentration
    /// </summary>
    public class CoefficientsOverview : ICoefficientsOverview
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the calculated a 0.
        /// </summary>
        public string CalculatedA0
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA0);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA0, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculated a 1.
        /// </summary>
        public string CalculatedA1
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA1);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA1, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculated a 2.
        /// </summary>
        public string CalculatedA2
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA2);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA2, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculated a 3.
        /// </summary>
        public string CalculatedA3
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA3);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA3, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculated a 4.
        /// </summary>
        public string CalculatedA4
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA4);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextCalculatedA4, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculated b 1.
        /// </summary>
        public string CalculatedB1
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextCalculatedB1);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextCalculatedB1, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculated b 2.
        /// </summary>
        public string CalculatedB2
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextCalculatedB2);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextCalculatedB2, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculated b 3.
        /// </summary>
        public string CalculatedB3
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextCalculatedB3);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextCalculatedB3, value);
            }
        }

        /// <summary>
        /// Gets or sets the calculated d 1.
        /// </summary>
        public string CalculatedD1 { get; set; }

        /// <summary>
        /// Gets or sets the calculated d 2.
        /// </summary>
        public string CalculatedD2 { get; set; }

        /// <summary>
        /// Gets or sets the calculated d 3.
        /// </summary>
        public string CalculatedD3 { get; set; }

        /// <summary>
        /// Gets or sets the calculated d 4.
        /// </summary>
        public string CalculatedD4 { get; set; }

        /// <summary>
        /// Gets or sets the from device a 0.
        /// </summary>
        public string FromDeviceA0
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA0);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA0, value);
            }
        }

        /// <summary>
        /// Gets or sets the from device a 1.
        /// </summary>
        public string FromDeviceA1
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA1);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA1, value);
            }
        }

        /// <summary>
        /// Gets or sets the from device a 2.
        /// </summary>
        public string FromDeviceA2
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA2);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA2, value);
            }
        }

        /// <summary>
        /// Gets or sets the from device a 3.
        /// </summary>
        public string FromDeviceA3
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA3);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA3, value);
            }
        }

        /// <summary>
        /// Gets or sets the from device a 4.
        /// </summary>
        public string FromDeviceA4
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA4);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceA4, value);
            }
        }

        /// <summary>
        /// Gets or sets the from device b 1.
        /// </summary>
        public string FromDeviceB1
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceB1);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceB1, value);
            }
        }

        /// <summary>
        /// Gets or sets the from device b 2.
        /// </summary>
        public string FromDeviceB2
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceB2);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceB2, value);
            }
        }

        /// <summary>
        /// Gets or sets the from device b 3.
        /// </summary>
        public string FromDeviceB3
        {
            get
            {
                return (new CommonMethods()).GetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceB3);
            }

            set
            {
                (new CommonMethods()).SetParameterValue((new CoefficientsOverviewElements()).TextFromDeviceB3, value);
            }
        }

        /// <summary>
        /// Gets or sets the from device d 1.
        /// </summary>
        public string FromDeviceD1 { get; set; }

        /// <summary>
        /// Gets or sets the from device d 2.
        /// </summary>
        public string FromDeviceD2 { get; set; }

        /// <summary>
        /// Gets or sets the from device d 3.
        /// </summary>
        public string FromDeviceD3 { get; set; }

        /// <summary>
        /// Gets or sets the from device d 4.
        /// </summary>
        public string FromDeviceD4 { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Checks whether calculated Coefficients are available or not
        /// </summary>
        /// <returns>
        ///     true: if at least one value is not empty
        ///     false: if all values are empty
        /// </returns>
        public bool AreCalculatedCoefficientsAvailable()
        {
            // create string arrays with all calculated coefficients  
            var calculatedCoeffs = new[] { this.CalculatedA0, this.CalculatedA1, this.CalculatedA2, this.CalculatedA3, this.CalculatedA4, this.CalculatedB1, this.CalculatedB2, this.CalculatedB3 };
            bool result = false;

            foreach (string actualValue in calculatedCoeffs)
            {
                if (actualValue != string.Empty && actualValue != "NaN")
                {
                    result = true;
                }
            }

            return result;

            // foreach (string actualValue in calculatedCoeffs)
            // {
            // if (actualValue.Equals(string.Empty))
            // {
            // continue;
            // }

            // Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculated Coefficients are available");
            // return true;
            // }

            // Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculated Coefficients are not available");
            // return false;
        }

        /// <summary>
        ///     Checks whether Coefficients are available or not
        /// </summary>
        /// <returns>
        ///     true: if at least one coefficient is not "0"
        ///     false: if all values are "0"
        /// </returns>
        public bool AreCoefficientsAvailable()
        {
            if (this.AreCalculatedCoefficientsAvailable() || this.AreReadCoefficientsAvailable())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients are available");
                return true;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients are not available");
            return false;
        }

        /// <summary>
        ///     Checks whether Coefficients read from device are available or not
        /// </summary>
        /// <returns>
        ///     true: if at least one value is not empty
        ///     false: if all values are empty
        /// </returns>
        public bool AreReadCoefficientsAvailable()
        {
            // create string arrays with all device read coefficients        
            var deviceCoeffs = new[] { this.FromDeviceA0, this.FromDeviceA1, this.FromDeviceA2, this.FromDeviceA3, this.FromDeviceA4, this.FromDeviceB1, this.FromDeviceB2, this.FromDeviceB3 };
            bool result = false;

            foreach (string actualValue in deviceCoeffs)
            {
                if (actualValue != string.Empty && actualValue != "NaN")
                {
                    result = true;
                }
            }

            return result;

            // foreach (string actualValue in deviceCoeffs)
            // {
            // if (actualValue.Equals(string.Empty))
            // {
            // continue;
            // }

            // Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients read from device are available");
            // return true;
            // }

            // Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients read from device are not available");
            // return false;
        }

        /// <summary>
        /// Compares all calculated coefficients against the coefficients read from device
        /// </summary>
        /// <param name="accuracy">
        /// maximum difference between two coefficients
        /// </param>
        /// <returns>
        /// <br>true: if all coefficients are identical</br>
        ///     <br>false: if one paring is not identical</br>
        /// </returns>
        public bool CompareCoefficients(double accuracy)
        {
            // create string arrays with all coefficients, calculated and read from device
            var calculatedCoeffs = new[] { this.CalculatedA0, this.CalculatedA1, this.CalculatedA2, this.CalculatedA3, this.CalculatedA4, this.CalculatedB1, this.CalculatedB2, this.CalculatedB3 };
            var deviceCoeffs = new[] { this.FromDeviceA0, this.FromDeviceA1, this.FromDeviceA2, this.FromDeviceA3, this.FromDeviceA4, this.FromDeviceB1, this.FromDeviceB2, this.FromDeviceB3 };
            int index = 0;

            // convert strings to double values, check if absolute value of the difference between them is smaller than a defined accuracy
            foreach (string actualValue in calculatedCoeffs)
            {
                decimal actualValueAsDecimal;
                decimal deviceCoeffsAsDecimal;

                if (decimal.TryParse(actualValue, out actualValueAsDecimal) && decimal.TryParse(deviceCoeffs[index], out deviceCoeffsAsDecimal))
                {
                    double calculated = Convert.ToDouble(actualValue);
                    double fromDevice = Convert.ToDouble(deviceCoeffs[index]);
                    if (Math.Abs(calculated - fromDevice) > accuracy)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients are different: " + calculated + " -> " + fromDevice);
                        return false;
                    }
                }
                else
                {
                    if (actualValue == null || deviceCoeffs[index] == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "A Coefficient is null");
                        return false;
                    }

                    if (actualValue != deviceCoeffs[index])
                    {
                        string errorLog = "Coefficients are different: actual value A" + index.ToString(CultureInfo.InvariantCulture) + " = " + actualValue + " , expected value = " + deviceCoeffs[index];

                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), errorLog);
                        return false;
                    }
                }

                index++;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculated Coefficients and device read coefficients are equal");
            return true;
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
            // create string arrays with all coefficients, calculated and read from device
            var calculatedCoeffs = new[] { this.CalculatedA0, this.CalculatedA1, this.CalculatedA2, this.CalculatedA3, this.CalculatedA4, this.CalculatedB1, this.CalculatedB2, this.CalculatedB3 };
            int index = 0;

            // convert strings to double values, check if absolute value of the difference between them is smaller than a defined accuracy
            foreach (string actualValue in calculatedCoeffs)
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
                        string errorLog = "Coefficients are different: actual value A" + index.ToString(CultureInfo.InvariantCulture) + " = " + actualValue + " , expected value = " + expectedCoefficients[index];
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), errorLog);
                        return false;
                    }
                }

                index++;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Calculated Coefficients and usergiven coefficients are equal");
            return true;
        }

        /// <summary>
        /// The compare coefficients.
        /// </summary>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareCoefficients(string accuracy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The compare coefficients.
        /// </summary>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <param name="expectedCoefficients">
        /// The expected coefficients.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareCoefficients(string accuracy, string[] expectedCoefficients)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Compares all coefficients from device against user given coefficients
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
        public bool CompareCoefficientsFromDevice(double accuracy, string[] expectedCoefficients)
        {
            // create string arrays with all coefficients, calculated and read from device
            var coefficientsReadFromDevice = new[] { this.FromDeviceA0, this.FromDeviceA1, this.FromDeviceA2, this.FromDeviceA3, this.FromDeviceA4, this.FromDeviceB1, this.FromDeviceB2, this.FromDeviceB3 };
            int index = 0;

            // convert strings to double values, check if absolute value of the difference between them is smaller than a defined accuracy
            foreach (string actualValue in coefficientsReadFromDevice)
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
                        string errorLog = "Coefficients are different: actual value A" + index.ToString(CultureInfo.InvariantCulture) + " = " + actualValue + " , expected value = " + expectedCoefficients[index];
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), errorLog);
                        return false;
                    }
                }

                index++;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Coefficients from device and user given coefficients are equal");
            return true;
        }

        /// <summary>
        /// The compare coefficients from device.
        /// </summary>
        /// <param name="accuracy">
        /// The accuracy.
        /// </param>
        /// <param name="expectedCoefficients">
        /// The expected coefficients.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool CompareCoefficientsFromDevice(string accuracy, string[] expectedCoefficients)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}