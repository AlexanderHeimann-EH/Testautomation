// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestObjectHandler.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test object handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.DTMstudioTest.TestScriptEngine.Execution
{
    using System;
    using System.IO;
    using System.Reflection;

    using EH.DTMstudioTest.Common.TransportObjects.ControlDocument.TestObjects;
    using EH.DTMstudioTest.TestScriptEngine.DataTypes;
    using EH.PCPS.TestAutomation.Common.Configurator.GUI;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Log = EH.DTMstudioTest.Common.Utilities.Logging.Log;

    /// <summary>
    /// The test object handler.
    /// </summary>
    public class TestObjectHandler
    {
        #region Public Methods and Operators

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="executionObject">
        /// The execution object.
        /// </param>
        /// <param name="guid">
        /// The guid.
        /// </param>
        public static void Execute(ExecutionObject executionObject, string guid)
        {
            Log.Enter(LogInfo.Namespace(MethodBase.GetCurrentMethod()), MethodBase.GetCurrentMethod().Name);

            try
            {
                TestObject testObject = executionObject.TestConfiguration.GetTestObject(executionObject.TestConfiguration.AvailableTestObjects, guid);

                if (testObject != null)
                {
                    executionObject.ExecutionData.Parameters = executionObject.TestConfiguration.GetTestObjectParameters(testObject);
                    executionObject.CurrentTestCase = testObject as TestCase;

                    if (executionObject.CurrentTestCase != null)
                    {
                        if (executionObject.ExecutionData.ParentGuid == null)
                        {
                            executionObject.ExecutionData.ParentGuid = executionObject.CurrentTestCase.Parent.Guid;
                            executionObject.ExecutionData.TestSuiteBaseFolder = executionObject.ReportFolderOverview;
                        }

                        if (!string.Equals(executionObject.ExecutionData.ParentGuid, executionObject.CurrentTestCase.Parent.Guid))
                        {
                            executionObject.ExecutionData.ParentGuid = executionObject.CurrentTestCase.Parent.Guid;
                            executionObject.ExecutionData.TestSuiteBaseFolder = executionObject.ReportFolderOverview;
                        }

                        executionObject.ExecutionData.AssemblyName = executionObject.CurrentTestCase.AssemblyName;
                        executionObject.ExecutionData.SearchedGuid = executionObject.CurrentTestCase.AssemblyMethodRefId;

                        // ToDo: Der Pfad muss auf etwas Konfigurierbares angepasst werden
                        // Wird die TestLibrary verwendet, muss auf das Installationsverzeichnis referenziert werden
                        // Wird die UserDefined verwendet, muss auf das entsprechende Verzeichnis referenziert werden

                        // try path to installed testframework
                        string pathToAssembly = ConfiguratorDialog.SelectedConfiguration.TestFramework.PathToAssemblies + @"\" + executionObject.ExecutionData.AssemblyName;
                        if (!File.Exists(pathToAssembly))
                        {
                            // try path to userdefined assembly within running project
                            pathToAssembly = Directory.GetCurrentDirectory() + @"\" + executionObject.ExecutionData.AssemblyName;
                            if (!File.Exists(pathToAssembly))
                            {
                                Exception exception = new Exception("Assembly " + executionObject.ExecutionData.AssemblyName + "not found.");
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                                throw exception;
                            }
                        }

                        executionObject.ExecutionData.Assembly = Assembly.LoadFrom(pathToAssembly);

                        if (executionObject.ExecutionData.Assembly != null)
                        {
                            TypeHandler.Execute(executionObject);
                        }
                    }
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