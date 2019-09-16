// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadAssambly.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2012
// </copyright>
// <summary>
//   The test reflection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleApplication1  
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    using Common;

    /// <summary>
    /// The test reflection.
    /// </summary>
    public class LoadAssambly
    {
        /// <summary>
        /// The load test framework assembly.
        /// </summary>
        /// <param name="testFrameworkAssemblyPath">
        /// The test framework assembly path.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool LoadTestScriptInformationAssembly(string testFrameworkAssemblyPath)
        {
            if (File.Exists(testFrameworkAssemblyPath))
            {
                var myDll = Assembly.LoadFrom(testFrameworkAssemblyPath);

                var types = myDll.GetExportedTypes();

                foreach (var type in types)
                {
                    var typeCustomAttributes = type.GetCustomAttributes(typeof(TestScriptInformation), true);

                    foreach (var customAttribute in typeCustomAttributes)
                    {
                        var testScriptInformation = customAttribute as TestScriptInformation;

                        if (testScriptInformation != null 
                            && testScriptInformation.TestCategory == Enumerations.TestCategory.SetupDelivery)
                        {
                            if (testScriptInformation != null)
                            {
                                MessageBox.Show(
                                    string.Format(
                                        "Test Category: {0},  Test Script: {1}, Test Focus: {2}, Full Name: {3}.Run()",
                                        testScriptInformation.TestCategory.ToString(),
                                        testScriptInformation.TestScript,
                                        testScriptInformation.TestFocus,
                                        type.FullName));
                                
                                // var parametersArray = new object[] { "Hello" };
                                // InvokeMethod(type, "Run");
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The invoke method.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="methodName">
        /// The method name.
        /// </param>
        /// <param name="parametersArray">
        /// The parameters array.
        /// </param>
        private static void InvokeMethod(Type type, string methodName, object[] parametersArray = null)
        {
            var methodInfo = type.GetMethod(methodName);
            var parameters = methodInfo.GetParameters();

            var classInstance = Activator.CreateInstance(type, null);
            if (parameters.Length == 0)
            {
                methodInfo.Invoke(classInstance, null);
            }
            else
            {
                methodInfo.Invoke(classInstance, parametersArray);
            }
        }
    }
}
