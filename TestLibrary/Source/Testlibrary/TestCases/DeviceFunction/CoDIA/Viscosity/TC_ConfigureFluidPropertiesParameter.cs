// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureFluidPropertiesParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureFluidPropertiesParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Viscosity
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Viscosity;

    /// <summary>
    /// The test case TC_ConfigureFluidPropertiesParameter.
    /// </summary>
    // ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
    public class TC_ConfigureFluidPropertiesParameter
// ReSharper restore ClassNeverInstantiated.Global
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Configures the parameter of the tab Fluid Properties.
        /// </summary>
        /// <param name="dynamicViscosityUnit">
        /// The dynamic viscosity unit. Use string.empty if you want to skip this parameter.
        /// </param>
        /// <param name="temperatureUnit">
        /// The temperature unit. Use string.empty if you want to skip this parameter.
        /// </param>
        /// <param name="referenceTemperature">
        /// The reference temperature. Use string.empty if you want to skip this parameter.
        /// </param>
        /// <param name="firstColumn">
        /// The first column. Use string.empty if you want to skip this parameter.
        /// </param>
        /// <param name="secondColumn">
        /// The second column. Use string.empty if you want to skip this parameter.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("c7f8d99e-e779-44ac-82a4-51138fff008c", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string dynamicViscosityUnit, string temperatureUnit, string referenceTemperature, string firstColumn, string secondColumn)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.ConfigureFluidPropertiesParameter.Run(dynamicViscosityUnit, temperatureUnit, referenceTemperature, firstColumn, secondColumn);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureFluidPropertiesParameter passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureFluidPropertiesParameter failed.");
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