// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureReferenceValues.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureReferenceValues
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView;

    /// <summary>
    /// The test case TC_ConfigureReferenceValues
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ConfigureReferenceValues
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Configure Reference Values
        /// </summary>
        /// <param name="carrierType">
        /// Type of the carrier.
        /// </param>
        /// <param name="referenceTemperature">
        /// The reference temperature.
        /// </param>
        /// <param name="densityUnit">
        /// The density unit.
        /// </param>
        /// <param name="carrierLinearExpansionCoefficient">
        /// The carrier linear expansion coefficient.
        /// </param>
        /// <param name="carrierSquareExpansionCoefficientTarget">
        /// The carrier square expansion coefficient target.
        /// </param>
        /// <param name="carrierReferenceDensity">
        /// The carrier reference density.
        /// </param>
        /// <param name="targetLinearExpansionCoefficient">
        /// The target linear expansion coefficient.
        /// </param>
        /// <param name="targetSquareExpansionCoefficientTarget">
        /// The target square expansion coefficient target.
        /// </param>
        /// <param name="targetReferenceDensity">
        /// The target reference density.
        /// </param>
        /// <returns>
        /// <c>true</c> if passed, <c>false</c> otherwise.
        /// </returns>
        [TestScriptInformation("83F52E1E-77FA-4F51-85A7-7C2E7E772608", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string carrierType, string referenceTemperature, string densityUnit, string carrierLinearExpansionCoefficient, string carrierSquareExpansionCoefficientTarget, string carrierReferenceDensity, string targetLinearExpansionCoefficient, string targetSquareExpansionCoefficientTarget, string targetReferenceDensity)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabReferenceValues();
            isPassed &= Flows.ConfigureReferenceValues.Run(carrierType, referenceTemperature, densityUnit, carrierLinearExpansionCoefficient, carrierSquareExpansionCoefficientTarget, carrierReferenceDensity, targetLinearExpansionCoefficient, targetSquareExpansionCoefficientTarget, targetReferenceDensity);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureBaseSettings passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureBaseSettings failed.");
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