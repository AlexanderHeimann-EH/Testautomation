// -----------------------------------------------------------------------
// <copyright file="Class1.cs" company="Endress+Hauser Process Solutions AG">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ToolboxControl1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Class1
    {
        /// <summary>
        /// The get setup delivery device functions from assembly.
        /// </summary>
        /// <param name="testFrameworkAssemblyPath">
        /// The test framework assembly path.
        /// </param>
        /// <param name="deviceFunctionList">
        /// The device function list.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public static void GetSetupDeliveryDeviceFunctionsFromAssembly(string testFrameworkAssemblyPath)
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
                        Trace.WriteLine(
                            string.Format(
                                "TestCategory: {0}, TestFocus: {1}, TestScript: {2}",
                                testScriptInformation.TestCategory,
                                testScriptInformation.TestFocus,
                                testScriptInformation.TestScript));
                    }
                }
            }
        }
    }
}
