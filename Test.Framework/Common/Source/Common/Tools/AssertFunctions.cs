// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssertFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   This class provides the different methods which are necessary to check and compare
//   actual values against reference values during a test run.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Common.Tools
{
    using System;
    using System.Reflection;

    /// <summary>
    /// This class provides the different methods which are necessary to check and compare
    /// actual values against reference values during a test run.
    /// </summary>
    public class AssertFunctions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Verifies whether two booleans are equal. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True if values are equal, false if not.
        /// </returns>
        public static bool AreEqual(bool referenceValue, bool testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (referenceValue != testValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are not equal: reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies whether two integer are equal. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True if values are equal, false if not.
        /// </returns>
        public static bool AreEqual(int referenceValue, int testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (referenceValue != testValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are not equal: reference value = " + referenceValue + ";  Test value = " + testValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: reference value = " + referenceValue + ";  Test value = " + testValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies whether two strings are equal. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True if values are equal, false if not.
        /// </returns>
        public static bool AreEqual(string referenceValue, string testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (referenceValue != testValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are not equal: reference value = " + referenceValue + ";  Test value = " + testValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: reference value = " + referenceValue + ";   Test value = " + testValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies whether two doubles are equal. They are considered equal if the absolute value of their difference is less than or equal to a specified limit.        
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison.
        /// </param>
        /// <param name="difference">
        /// The difference at which two doubles are considered equal.
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// true if values are equal, false if not
        /// </returns>
        public static bool AreEqual(double referenceValue, double testValue, double difference, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (Math.Abs(referenceValue - testValue) > difference)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are not equal: reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies whether two booleans are different. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// true if values are different, false if not.
        /// </returns>
        public static bool AreNotEqual(bool referenceValue, bool testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (referenceValue == testValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different:  reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies whether two integer are different. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// true if values are different, false if not.
        /// </returns>
        public static bool AreNotEqual(int referenceValue, int testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (referenceValue == testValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different:  reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies whether two strings are different. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// true if values are different, false if not.
        /// </returns>
        public static bool AreNotEqual(string referenceValue, string testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (referenceValue == testValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different:  reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies whether two doubles are different. They are considered equal if the absolute value of their difference is less  than or equal to a specified limit.
        /// The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// reference value
        /// </param>
        /// <param name="testValue">
        /// test value
        /// </param>
        /// <param name="difference">
        /// The difference at which two doubles are considered equal.
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// true if values are not equal, false if not.
        /// </returns>
        public static bool AreNotEqual(double referenceValue, double testValue, double difference, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (Math.Abs(referenceValue - testValue) <= difference)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal: reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are different:  reference value = " + referenceValue + "; Test value = " + testValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies whether two booleans are equal. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True if values are equal, false if not.
        /// </returns>
        public static bool Contains(string referenceValue, string testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue.Contains(referenceValue) == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "'" + testValue + "' does not contain '" + referenceValue + "'.");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "'" + testValue + "' contains '" + referenceValue + "'.");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is greater than the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is greater than the reference value. False: otherwise.
        /// </returns>
        public static bool Greater(double referenceValue, double testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue <= referenceValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not greater than the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is greater than the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is greater than the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is greater than the reference value. False: otherwise.
        /// </returns>
        public static bool Greater(int referenceValue, int testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue <= referenceValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not greater than the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is greater than the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is greater than the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is greater than the reference value. False: otherwise.
        /// </returns>
        public static bool Greater(string referenceValue, string testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            double refVal = Convert.ToDouble(referenceValue);
            double testVal = Convert.ToDouble(testValue);
            if (testVal <= refVal)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not greater than the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is greater than the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is greater than or equal to the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is greater than or equal to the reference value. False: otherwise.
        /// </returns>
        public static bool GreaterOrEqual(double referenceValue, double testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue < referenceValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not greater than or equal to the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is greater than or equal to the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is greater than or equal to the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is greater than or equal to the reference value. False: otherwise.
        /// </returns>
        public static bool GreaterOrEqual(int referenceValue, int testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue < referenceValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not greater than or equal to the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is greater than or equal to the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is greater than or equal to the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison. 
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is greater than or equal to the reference value. False: otherwise.
        /// </returns>
        public static bool GreaterOrEqual(string referenceValue, string testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            double refVal = Convert.ToDouble(referenceValue);
            double testVal = Convert.ToDouble(testValue);
            if (testVal < refVal)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not greater than or equal to the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "test value " + testValue + " is greater than or equal to the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verify that the test value is approximately the same as the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison.
        /// </param>
        /// <param name="bound">
        /// The allowed difference between the test value and the reference value.
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is approximately the same as the reference value. False: otherwise.
        /// </returns>
        public static bool IsValueInBound(double referenceValue, double testValue, double bound, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue > referenceValue + bound || testValue < referenceValue - bound)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not approximately the same as the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is approximately the same as the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verify that the test value is approximately the same as the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison.
        /// </param>
        /// <param name="bound">
        /// The allowed difference between the test value and the reference value.
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is approximately the same as the reference value. False: otherwise.
        /// </returns>
        public static bool IsValueInBound(int referenceValue, int testValue, int bound, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue > referenceValue + bound || testValue < referenceValue - bound)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not approximately the same as the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is approximately the same as the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verify that the test value is approximately the same as the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison.
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison.
        /// </param>
        /// <param name="bound">
        /// The allowed difference between the test value and the reference value.
        /// </param>
        /// <param name="description">
        /// Description for the comparison.
        /// </param>
        /// <returns>
        /// True: if the test value is approximately the same as the reference value. False: otherwise.
        /// </returns>
        public static bool IsValueInBound(string referenceValue, string testValue, double bound, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            double refVal = Convert.ToDouble(referenceValue);
            double testVal = Convert.ToDouble(testValue);
            if (testVal > refVal + bound || testVal < refVal - bound)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not approximately the same as the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is approximately the same as the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Determines whether the test value doesn't differ more than the toleranceInPercent percentage. The user can add a message which will be shown in the test report.
        /// from the reference value.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for comparison
        /// </param>
        /// <param name="testValue">
        /// Test value for comparison
        /// </param>
        /// <param name="toleranceInPercent">
        /// The tolerance in percent.
        /// </param>
        /// <param name="description">
        /// The description for the comparison
        /// </param>
        /// <returns>
        /// True: if the test value is within the tolerance. False: otherwise.
        /// </returns>
        public static bool IsValueInTolerance(double referenceValue, double testValue, double toleranceInPercent, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue > (referenceValue + ((referenceValue / 100) * toleranceInPercent)) || testValue < (referenceValue - ((referenceValue / 100) * toleranceInPercent)))
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " differs more than " + toleranceInPercent + " % from the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " doesn't differ more than " + toleranceInPercent + " % from the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Determines whether the test value doesn't differ more than the toleranceInPercent percentage. The user can add a message which will be shown in the test report.
        /// from the reference value.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for the comparison
        /// </param>
        /// <param name="testValue">
        /// Test value for the comparison
        /// </param>
        /// <param name="toleranceInPercent">
        /// The tolerance in percent.
        /// </param>
        /// <param name="description">
        /// The description for the comparison
        /// </param>
        /// <returns>
        /// True: if the test value is within the tolerance. False: otherwise.
        /// </returns>
        public static bool IsValueInTolerance(string referenceValue, string testValue, double toleranceInPercent, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            double refVal = Convert.ToDouble(referenceValue);
            double testVal = Convert.ToDouble(testValue);
            if (testVal > (refVal + ((refVal / 100) * toleranceInPercent)) || testVal < (refVal - ((refVal / 100) * toleranceInPercent)))
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " differs more than " + toleranceInPercent + " % from the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " doesn't differ more than " + toleranceInPercent + " % from the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is less than the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for the comparison
        /// </param>
        /// <param name="testValue">
        /// Test value for the comparison
        /// </param>
        /// <param name="description">
        /// The description for the comparison
        /// </param>
        /// <returns>
        /// True: if the test value is less than the reference value. False: otherwise.
        /// </returns>
        public static bool Less(double referenceValue, double testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue >= referenceValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not less than the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is less than the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is less than the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for the comparison
        /// </param>
        /// <param name="testValue">
        /// test value for the comparison
        /// </param>
        /// <param name="description">
        /// The description for the comparison
        /// </param>
        /// <returns>
        /// True: if the test value is less than the reference value. False: otherwise.
        /// </returns>
        public static bool Less(int referenceValue, int testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue >= referenceValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not less than the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is less than the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is less than the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for the comparison
        /// </param>
        /// <param name="testValue">
        /// test value for the comparison
        /// </param>
        /// <param name="description">
        /// The description for the comparison
        /// </param>
        /// <returns>
        /// True: if the test value is less than the reference value. False: otherwise.
        /// </returns>
        public static bool Less(string referenceValue, string testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            double refVal = Convert.ToDouble(referenceValue);
            double testVal = Convert.ToDouble(testValue);
            if (testVal >= refVal)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not less than the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is less than the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is less than or equal to the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for the comparison
        /// </param>
        /// <param name="testValue">
        /// test value for the comparison
        /// </param>
        /// <param name="description">
        /// The description for the comparison
        /// </param>
        /// <returns>
        /// True: if the test value is less than or equal to the reference value. False: otherwise.
        /// </returns>
        public static bool LessOrEqual(double referenceValue, double testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue > referenceValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not less  than or equal to the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is less  or equal than the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is less than or equal to the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for the comparison
        /// </param>
        /// <param name="testValue">
        /// test value for the comparison
        /// </param>
        /// <param name="description">
        /// The description for the comparison
        /// </param>
        /// <returns>
        /// True: if the test value is less than or equal to the reference value. False: otherwise.
        /// </returns>
        public static bool LessOrEqual(int referenceValue, int testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            if (testValue > referenceValue)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not less  than or equal to the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is less  than or equal to the reference value " + referenceValue + ".");
            }

            return result;
        }

        /// <summary>
        /// Verifies that the test value is less than or equal to the reference value. The user can add a message which will be shown in the test report.
        /// </summary>
        /// <param name="referenceValue">
        /// Reference value for the comparison
        /// </param>
        /// <param name="testValue">
        /// test value for the comparison
        /// </param>
        /// <param name="description">
        /// The description for the comparison
        /// </param>
        /// <returns>
        /// True: if the test value is less than or equal to the reference value. False: otherwise.
        /// </returns>
        public static bool LessOrEqual(string referenceValue, string testValue, string description)
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), description);

            bool result = true;
            double refVal = Convert.ToDouble(referenceValue);
            double testVal = Convert.ToDouble(testValue);
            if (testVal > refVal)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is not less  than or equal to the reference value " + referenceValue + ".");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test value " + testValue + " is less  or equal than the reference value " + referenceValue + ".");
            }

            return result;
        }

        #endregion
    }
}