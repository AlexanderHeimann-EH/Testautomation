// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureHorizontalCylindricalTank.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
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
    /// The test case TC_ConfigureHorizontalCylindricalTank.
    /// </summary>
// ReSharper disable InconsistentNaming
    public class TC_ConfigureHorizontalCylindricalTank
// ReSharper restore InconsistentNaming
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////

        /// <summary>
        /// Selects tank type Horizontal cylindrical tank and configures its parameter if needed. Use empty strings if you do not want to configure a parameter.
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
        /// <param name="angle">
        /// The angle.
        /// </param>
        /// <param name="endTypeRight">
        /// The end type right.
        /// </param>
        /// <param name="endTypeLeft">
        /// The end type left.
        /// </param>
        /// <param name="wallThickness">
        /// The wall thickness.
        /// </param>
        /// <param name="changePosition">
        /// The change position.
        /// </param>
        /// <returns>
        /// Returns true if test case is passed, false otherwise.
        /// </returns>
        [TestScriptInformation("41f675bb-2756-40ef-a65d-c231d73d8c63", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string height, string diameter, string length, string angle, string endTypeRight, string endTypeLeft, string wallThickness, string changePosition)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */

            bool isPassed = Flows.ConfigureHorizontalCylindricalTank.Run(height, diameter, length, angle, endTypeRight, endTypeLeft, wallThickness, changePosition);

            if (isPassed)
            {
                Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureHorizontalCylindricalTank passed.");
            }
            else
            {
                Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Test case TC_ConfigureHorizontalCylindricalTank failed.");
                Log.Screenshot();
            }

            TearDown();
            return isPassed;
        }

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
    }
}
