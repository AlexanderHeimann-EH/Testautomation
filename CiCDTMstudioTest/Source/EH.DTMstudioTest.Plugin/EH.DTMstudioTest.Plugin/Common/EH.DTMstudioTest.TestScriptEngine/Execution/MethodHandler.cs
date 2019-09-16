// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The method handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.Execution
{
    using System;
    using System.Reflection;

    using EH.DTMstudioTest.TestScriptEngine.DataTypes;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Log = EH.DTMstudioTest.Common.Utilities.Logging.Log;

    /// <summary>
    /// Handles calling of TestFramework-functions
    /// </summary>
    public class MethodHandler
    {
        #region Public Methods and Operators

        /// <summary>
        /// Executes the invoke for a method depending it´s number of parameters
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        public static void Execute(ExecutionObject executionObject)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);

            try
            {
                if (executionObject.ExecutionData.Method.GetParameters().Length > 0)
                {   
                    if (executionObject.ExecutionData.Parameters.Count == executionObject.ExecutionData.Method.GetParameters().Length)
                    {
                        var parameterObjects = new object[executionObject.ExecutionData.Parameters.Count];
                        parameterObjects.Initialize();
                        for (var index = 0; index < executionObject.ExecutionData.Parameters.Count; index++)
                        {
                            var parameterType = executionObject.ExecutionData.Parameters[index].ParameterType;

                            switch (parameterType)
                            {
                                case "System.Int32":
                                    {
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Return: System.Int32");
                                        parameterObjects[index] = int.Parse(executionObject.ExecutionData.Parameters[index].ParameterValue);
                                        break;
                                    }

                                case "System.Single":
                                    {
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Return: System.Single");
                                        parameterObjects[index] = float.Parse(executionObject.ExecutionData.Parameters[index].ParameterValue);
                                        break;
                                    }

                                case "System.String":
                                    {
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Return: System.String");
                                        parameterObjects[index] = executionObject.ExecutionData.Parameters[index].ParameterValue;
                                        break;
                                    }

                                case "System.Boolean":
                                    {
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Return: System.Boolean");
                                        parameterObjects[index] = bool.Parse(executionObject.ExecutionData.Parameters[index].ParameterValue);
                                        break;
                                    }

                                default:
                                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "EH.DTMstudioTest.TestScriptEngine.Execution.MethodHandler: Unknown type " + parameterType + " for cast.");
                                    break;
                            }
                        }

                        executionObject.ExecutionData.Method.Invoke(null, parameterObjects);

                        // Cleanup
                        executionObject.ExecutionData.Parameter = null;
                    }
                    else
                    {
                        PCPS.TestAutomation.Common.Tools.Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), string.Format("Number of parameters from control document and expected number of parameters are not equal. Please contact developer. TestCase: [{0}]", executionObject.TestCaseName));
                        
                    }
                }
                else
                {
                    executionObject.ExecutionData.Method.Invoke(null, null);
                }
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                throw;
            }
        }

        #endregion
    }
}