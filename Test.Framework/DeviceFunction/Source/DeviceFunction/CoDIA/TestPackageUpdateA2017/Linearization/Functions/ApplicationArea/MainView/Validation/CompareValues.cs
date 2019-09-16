// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompareValues.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class CompareTableValues.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Linearization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    /// Class CompareValues.
    /// </summary>
    public class CompareValues : ICompareValues
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether values of two lists representing the Linearization table are equal
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="referenceValues">The reference values.</param>
        /// <param name="accuracy">The accuracy for the comparison of two double values.</param>
        /// <returns><c>true</c> if values are equal, <c>false</c> otherwise.</returns>
        public bool AreValuesEqual(List<string> values, List<string> referenceValues, double accuracy)
        {
            bool result = true;

            // Validate whether both lists have the same number of elements
            if (values.Count != referenceValues.Count)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The lists do not have the same number of elements and therefor can not be compared.");
                result = false;
            }
            else
            {
                // Compare each value with its reference value
                int index = 0;
                foreach (string s in values)
                {
                    decimal valueAsDecimal;
                    decimal refValueAsDecimal;

                    // Decimal.TryParse is used to make sure, that the string values represent decimal values
                    if (decimal.TryParse(values[index], out valueAsDecimal) && decimal.TryParse(referenceValues[index], out refValueAsDecimal))
                    {
                        double val = Convert.ToDouble(values[index]);
                        double refVal = Convert.ToDouble(referenceValues[index]);
                        if (Math.Abs(val - refVal) > accuracy)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different " + values[index] + " -> " + referenceValues[index]);
                            result = false;
                        }
                    }
                    else
                    {
                        // Parsing failed
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "One or more list elements are not decimal values. Please check your list elements");
                        result = false;
                    }

                    index++;
                }
            }

            return result;
        }

        #endregion
    }
}