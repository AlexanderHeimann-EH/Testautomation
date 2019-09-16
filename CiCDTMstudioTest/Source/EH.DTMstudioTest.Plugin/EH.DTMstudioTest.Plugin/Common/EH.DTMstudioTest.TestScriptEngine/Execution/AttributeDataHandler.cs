// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributeDataHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The attribute data handler.
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
    /// The attribute data handler.
    /// </summary>
    public class AttributeDataHandler
    {
        #region Public Methods and Operators

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        public static void Execute(ExecutionObject executionObject)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);

            try
            {
                if (executionObject.ExecutionData.Method.GetCustomAttributesData().Count > 0)
                {
                    foreach (var attributeData in executionObject.ExecutionData.Method.GetCustomAttributesData())
                    {
                        executionObject.ExecutionData.AttributeData = attributeData;

                        if (executionObject.ExecutionData.AttributeData.ConstructorArguments.Count > 0)
                        {
                            if (attributeData.ConstructorArguments[0].Value.Equals(executionObject.ExecutionData.SearchedGuid))
                            {
                                MethodHandler.Execute(executionObject);
                            }
                        }
                    }
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No attributeData available");
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