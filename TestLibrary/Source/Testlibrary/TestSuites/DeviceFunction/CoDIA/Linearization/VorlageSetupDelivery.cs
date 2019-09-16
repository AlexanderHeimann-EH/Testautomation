// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VorlageSetupDelivery.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case VorlageSetupDelivery.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.Linearization
{
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Linearization;
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication;
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT;

    /// <summary>
    /// The test case VorlageSetupDelivery.
    /// </summary>
    public class VorlageSetupDelivery
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// The run.
        /// </summary>
        public static void Run()
        {
            TC_OpenModuleOnline.Run();
            TC_ReadTable.Run(300000);
            TC_ReadTable.Run(300000);
            TC_ConfigureCylindricalTankStanding.Run(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            TC_Calculate.Run();
            TC_WriteTable.Run(300000);
            TC_WriteTable.Run(300000);
            TestCases.DeviceFunction.CoDIA.Parameterization.TC_OpenModuleOnline.Run();
            TestCases.DeviceFunction.CoDIA.Parameterization.TC_CheckThatDeviceHasNoFailure.Run();
            TestCases.DeviceFunction.CoDIA.Parameterization.TC_CloseModuleOnline.Run();
            TC_Export.Run("Relativer Pfad auf LinearizationData");
            TC_Import.Run("Relativer Pfad auf LinearizationData.csv");
            TC_WriteTable.Run(300000);
            TC_CheckSettingsParameterNotInvalid.Run();
            TestCases.DeviceFunction.CoDIA.Parameterization.TC_OpenModuleOnline.Run();
            TestCases.DeviceFunction.CoDIA.Parameterization.TC_CheckThatDeviceHasNoFailure.Run();
            TestCases.DeviceFunction.CoDIA.Parameterization.TC_CloseModuleOnline.Run();
            TC_CloseModule.Run();

            TC_CheckForCriticalError.Run();
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