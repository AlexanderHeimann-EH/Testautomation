// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_ConfigureLiquidProperties.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case TC_ConfigureExpertResults.
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
    /// The test case TC_ConfigureLiquidProperties.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class TC_ConfigureLiquidProperties
    {
        // ReSharper restore InconsistentNaming
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// Configure Liquid Properties
        /// </summary>
        /// <param name="inputFormat">The input format.</param>
        /// <param name="spreadsheet">The spreadsheet.</param>
        /// <param name="column1Selection">The column1 selection.</param>
        /// <param name="column1Minimum">The column1 minimum.</param>
        /// <param name="column1Max">The column1 maximum.</param>
        /// <param name="column1Unit">The column1 unit.</param>
        /// <param name="column2Selection">The column2 selection.</param>
        /// <param name="column2Minimum">The column2 minimum.</param>
        /// <param name="column2Max">The column2 maximum.</param>
        /// <param name="column2Unit">The column2 unit.</param>
        /// <param name="column3Selection">The column3 selection.</param>
        /// <param name="column3Minimum">The column3 minimum.</param>
        /// <param name="column3Max">The column3 maximum.</param>
        /// <param name="column3Unit">The column3 unit.</param>
        /// <returns><c>true</c> if passed., <c>false</c> otherwise.</returns>
        [TestScriptInformation("94B85DD5-54D7-466F-BC71-5E6C7B08D9A2", TestDefinition.Predefined, TestScript.TestCase)]
        public static bool Run(string inputFormat, string spreadsheet, string column1Selection, string column1Minimum, string column1Max, string column1Unit, string column2Selection, string column2Minimum, string column2Max, string column2Unit, string column3Selection, string column3Minimum, string column3Max, string column3Unit)
        {
            StartUp();

            /* Add your TestFramework calls here, for example:
             * EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run(pathToApplication);
             * EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Parameterization.Flows.OpenModuleOnline.Run();
             */
            bool isPassed = Execution.Container.SelectTabLiquidProperties();
            isPassed &= Flows.ConfigureLiquidProperties.Run(inputFormat, spreadsheet, column1Selection, column1Minimum, column1Max, column1Unit, column2Selection, column2Minimum, column2Max, column2Unit, column3Selection, column3Minimum, column3Max, column3Unit);

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