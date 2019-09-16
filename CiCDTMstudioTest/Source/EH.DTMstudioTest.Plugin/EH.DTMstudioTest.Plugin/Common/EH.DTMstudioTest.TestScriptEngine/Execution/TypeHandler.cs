// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The type handler.
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
    /// The type handler.
    /// </summary>
    public class TypeHandler
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
                if (executionObject.ExecutionData.Assembly.GetTypes().Length > 0)
                {
                    foreach (var type in executionObject.ExecutionData.Assembly.GetTypes())
                    {
                        executionObject.ExecutionData.Type = type;
                        MethodInfoHandler.Execute(executionObject);
                    }
                }
                else
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No types available");
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