// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureCylindricalTankStanding.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureCylindricalTankStanding.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Linearization
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization;

    /// <summary>
    /// The test case TC_ConfigureCylindricalTankStanding.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_ConfigureCylindricalTankStanding
// ReSharper restore InconsistentNaming
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Selects tank type cylindrical tank standing and configures its parameter if needed. Use empty strings if you do not want to configure a parameter.
        /// </summary>
        /// <param name="height">
        /// The height.
        /// </param>
        /// <param name="diameter">
        /// The diameter.
        /// </param>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <param name="ceilingType">
        /// Type of the ceiling.
        /// </param>
        /// <param name="bottomType">
        /// Type of the bottom.
        /// </param>
        /// <param name="wallThickness">
        /// The wall thickness.
        /// </param>
        /// <param name="ceilingHeight">
        /// Height of the ceiling.
        /// </param>
        /// <param name="ceilingWidth">
        /// Width of the ceiling.
        /// </param>
        /// <param name="bottomHeight">
        /// Height of the bottom.
        /// </param>
        /// <param name="bottomWidth">
        /// Width of the bottom.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("682733b7-8418-46ea-b7ac-9cb86603414e", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string height, string diameter, string length, string ceilingType, string bottomType, string wallThickness, string ceilingHeight, string ceilingWidth, string bottomHeight, string bottomWidth)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Flows.ConfigureCylindricalTankStanding.Run(height, diameter, length, ceilingType, bottomType, wallThickness, ceilingHeight, ceilingWidth, bottomHeight, bottomWidth);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureCylindricalTankStanding passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureCylindricalTankStanding failed.");
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