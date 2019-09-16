// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckCompareResult.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CheckCompareResult.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Compare.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Compare.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class CheckCompareResult.
    /// </summary>
    public class CheckCompareResult : ICheckCompareResult
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks whether the offline and online value of a parameter are identical.
        /// </summary>
        /// <param name="parameterNames">
        /// List with the name(s) of the parameter which will be checked. E.g. Full calibration (4), Empty calibration (3), Device tag.
        /// </param>
        /// <returns>
        /// <c>true</c> if the offline and online values of all parameter are identical, <c>false</c> otherwise.
        /// </returns>
        public bool CheckThatOfflineAndOnlineParameterAreEqual(List<string> parameterNames)
        {
            try
            {
                bool result = true;
                if (parameterNames.Count == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The input list is empty. Comparing parameter is not possible");
                    result = false;
                }
                else
                {
                    var compareParameter = Execution.GetAllCompareResultParameter.Run();
                    foreach (var parameterName in parameterNames)
                    {
                        int index = 0;
                        string name = compareParameter[index].ParameterName;
                        while (name != parameterName)
                        {
                            if (index >= compareParameter.Count - 1)
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + parameterName + "' not found.");
                                break;
                            }

                            index++;
                            name = compareParameter[index].ParameterName;
                        }

                        if (name == parameterName)
                        {
                            if (compareParameter[index].OfflineValue != compareParameter[index].OnlineValue)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The offline and online value for the parameter: '" + parameterName + "' are not equal. Offline value = '" + compareParameter[index].OfflineValue + "'. Online value = '" + compareParameter[index].OnlineValue + "'.");
                                result = false;
                            }
                        }
                    }

                    if (result)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checked all parameter from the list. Their offline and online values are equal.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Checks whether the offline and online value of a parameter are not equal.
        /// </summary>
        /// <param name="parameterNames">
        /// List with the name(s) of the parameter which will be checked. E.g. Full calibration (4), Empty calibration (3), Device tag.
        /// </param>
        /// <returns>
        /// <c>true</c> if the offline and online values of all parameter from the list are not identical, <c>false</c> otherwise.
        /// </returns>
        public bool CheckThatOfflineAndOnlineParameterAreNotEqual(List<string> parameterNames)
        {
            try
            {
                bool result = true;
                if (parameterNames.Count == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The input list is empty. Comparing parameter is not possible");
                    result = false;
                }
                else
                {
                    var compareParameter = Execution.GetAllCompareResultParameter.Run();
                    foreach (var parameterName in parameterNames)
                    {
                        int index = 0;
                        string name = compareParameter[index].ParameterName;
                        while (name != parameterName)
                        {
                            if (index >= compareParameter.Count - 1)
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter: '" + parameterName + "' not found.");
                                break;
                            }

                            index++;
                            name = compareParameter[index].ParameterName;
                        }

                        if (name == parameterName)
                        {
                            if (compareParameter[index].OfflineValue == compareParameter[index].OnlineValue)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The offline and online value for the parameter: '" + parameterName + "' are equal. Offline value = '" + compareParameter[index].OfflineValue + "'. Online value = '" + compareParameter[index].OnlineValue + "'.");
                                result = false;
                            }
                        }
                    }

                    if (result)
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Checked all parameter from the list. Their offline and online values are equal.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Navigates through the Compare result and logs all parameter with different offline and online values. Result is shown in the report.
        /// </summary>
        /// <returns>
        /// True if successful, false otherwise.
        /// </returns>
        public bool LogAllParameterWithDifferentOfflineAndOnlineValues()
        {
            try
            {
                var result = new StringBuilder();
                var parameterList = Execution.GetAllCompareResultParameter.Run();
                foreach (var compareParameter in parameterList)
                {
                    if (compareParameter.OfflineValue != compareParameter.OnlineValue)
                    {
                        result.Append("Different values for '" + compareParameter.ParameterName + "'. Offline value = '" + compareParameter.OfflineValue + "'. Online value = '" + compareParameter.OnlineValue + "'.");
                        result.AppendLine();
                    }
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Logging all parameter with different offline and online values:");
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), result.ToString());
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Navigates through the Compare result and logs all parameter with identical offline and online values. Result is shown in the report.
        /// </summary>
        /// <returns>
        /// True if successful, false otherwise.
        /// </returns>
        public bool LogAllParameterWithIdenticalOfflineAndOnlineValues()
        {
            try
            {
                var result = new StringBuilder();
                var parameterList = Execution.GetAllCompareResultParameter.Run();
                foreach (var compareParameter in parameterList)
                {
                    if (compareParameter.OfflineValue == compareParameter.OnlineValue)
                    {
                        result.Append("Identical values for '" + compareParameter.ParameterName + "'. Offline value = '" + compareParameter.OfflineValue + "'. Online value = '" + compareParameter.OnlineValue + "'.");
                        result.AppendLine();
                    }
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Logging all parameter with identical offline and online values:");
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), result.ToString());
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Navigates through the Compare result and logs all parameter with offline and online values. Result is shown in the report.
        /// </summary>
        /// <returns>
        /// True if successful, false otherwise.
        /// </returns>
        public bool LogAllParameterWithOfflineAndOnlineValues()
        {
            try
            {
                var result = new StringBuilder();
                var parameterList = Execution.GetAllCompareResultParameter.Run();
                foreach (var compareParameter in parameterList)
                {
                    result.Append("Parameter = '" + compareParameter.ParameterName + "'. Offline value = '" + compareParameter.OfflineValue + "'. Online value = '" + compareParameter.OnlineValue + "'.");
                    result.AppendLine();
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Logging all parameter with offline and online values:");
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), result.ToString());
                return true;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}