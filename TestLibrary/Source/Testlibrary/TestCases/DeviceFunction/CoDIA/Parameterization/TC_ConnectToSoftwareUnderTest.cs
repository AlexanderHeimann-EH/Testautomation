// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConnectToSoftwareUnderTest.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConnectToSoftwareUnderTest.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Parameterization
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;    

    /// <summary>
    /// The test case TC_ConnectToSoftwareUnderTest.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ConnectToSoftwareUnderTest
    {
        #region Public Methods and Operators

        /// <summary>
        /// Connects the testing interface using the config file TestInterface.txt in temp folder. Defaults will be used if file not found
        /// </summary>
        /// <returns><c>true</c> if connected, <c>false</c> otherwise.</returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("EF8DC072-A086-4A17-8445-82D3E1060232", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run()
        {
            StartUp();

                bool isPassed = Execution.ConnectToSoftwareUnderTest.Run();

                if (isPassed)
                {
                    Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConnectToSoftwareUnderTest passed.");
                }
                else
                {
                    Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConnectToSoftwareUnderTest failed.");
                    Log.Screenshot();
                }

                TearDown();
                return isPassed;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The startup.
        /// </summary>
        private static void StartUp()
        {
            /////////////////////////////////////////////////////////////////
            // Add your Start Up calls here
            /////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// The tear down.
        /// </summary>
        private static void TearDown()
        {
            /////////////////////////////////////////////////////////////////
            // Add your Tear Down calls here
            /////////////////////////////////////////////////////////////////
        }

        #endregion

        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
    }
}