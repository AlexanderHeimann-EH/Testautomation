// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_CreateProjectAddCommDtmAndScan.cs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The test case TC_CreateProjectAddCommDtmAndScan.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare;

    /// <summary>
    /// The test case TC_CreateProjectAddCommDtmAndScan.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    // ReSharper disable InconsistentNaming
    public class TC_CreateProjectAddCommDtmAndScan
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Creates a new project, adds the specified CommDtm and creates a network
        /// </summary>
        /// <param name="commDtm">
        /// The comm DTM which will be used.
        /// </param>
        /// <param name="timeoutInMilliseconds">
        /// The timeout in milliseconds for the scanning progress.
        /// </param>
        /// <param name="networkTag">
        /// The network Tag for the device found.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("a58c36b3-c792-4cc2-a5bb-b8c0887e6e49", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string commDtm, int timeoutInMilliseconds, string networkTag)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */            
            bool isPassed = CommonFlows.CreateProject.Run(string.Empty);
            isPassed &= CommonFlows.AddDevice.Run("Host", commDtm);
            isPassed &= CommonFlows.SelectDevice.Run(commDtm);
            isPassed &= SpecificFlows.CreateNetwork.Run(timeoutInMilliseconds, networkTag);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CreateProjectAddCommDtmAndScan passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_CreateProjectAddCommDtmAndScan failed.");
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
    }
}