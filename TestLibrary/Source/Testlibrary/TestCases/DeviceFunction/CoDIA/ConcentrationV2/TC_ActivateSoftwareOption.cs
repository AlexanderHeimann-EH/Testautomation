// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ActivateSoftwareOption.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class TC_ActivateSoftwareOption.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Class TC_ActivateSoftwareOption.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_ActivateSoftwareOption
// ReSharper restore InconsistentNaming
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Activates the software using the Online Parameterization
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to the software activation option parameter.
        /// </param>
        /// <param name="softwareOptionCode">
        /// The software option code.
        /// </param>
        /// <returns>
        /// True if passed, false otherwise.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [TestScriptInformation("09847387-C331-4949-8902-BF5C2A6607B8", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string pathToParameter, string softwareOptionCode)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.OpenModuleOnline.Run();
            isPassed &= Execution.SetParameter.Run(pathToParameter, softwareOptionCode);
            isPassed &= Execution.CheckParameterValue.Run(pathToParameter, softwareOptionCode);
            isPassed &= Flows.CloseModuleOnline.Run();
            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ActivateSoftwareOption passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ActivateSoftwareOption failed.");
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