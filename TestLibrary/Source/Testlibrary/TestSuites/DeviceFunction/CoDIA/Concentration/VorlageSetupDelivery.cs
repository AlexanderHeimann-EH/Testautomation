// ***********************************************************************
// Assembly         : EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.AboutBox
// Author           : i02497601
// Created          : 4/4/2016 9:32:07 AM
//
// Last Modified By : i02497601
// Last Modified On : 4/4/2016 9:32:07 AM
// ***********************************************************************
// <copyright file="VorlageSetupDelivery.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.Concentration
{
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Concentration;
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication;

    /// <summary>
    /// The test case VorlageSetupDelivery.
    /// </summary>
    public class VorlageSetupDelivery
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// The run.
        /// </summary>
        public static void Run()
        {
            TC_ActivateSoftwareOption.Run("pathToParameter", "softwareOptionCode");
            TC_OpenModuleOnline.Run();
            TC_DeleteConcentrationData.Run();
            TC_CheckThatAllTabPagesExceptLiquidPropertiesAreActive.Run();
            TC_ConfigureBaseSettings.Run("Defined liquid", "Aqueous sugar", "Standard calibration", string.Empty, string.Empty, @"°C", "10.00", "50.00", @"%", "33.00", "88.00");
            TC_CheckThatAllTabPagesExceptLiquidPropertiesAreActive.Run();
            TC_CalculateCoefficients.Run();
            TC_CompareCalculatedCoefficientsWithExpectedCoefficients.Run("0.001", "-8.8044;19.5445;-16.4714;6.76874;-1.05918;0.87672;3.07597; ");
            TC_CheckExpertResults.Run();
            TC_SetCoefficientsFromDevice.Run("0", "1", "2", "3", "4", "5", "6", "7");
            TC_WriteCoefficientsToDevice.Run();
            TC_ReadCoefficientsFromDevice.Run();
            TC_CompareCalculatedCoefficientsWithCoefficientsReadFromDevice.Run("0.001");
            TC_SaveAs.Run();
            TC_DeleteConcentrationData.Run();
            TC_Load.Run();
            TC_ConfigureBaseSettings.Run("Fine Tuning", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            TC_CheckThatAllFieldsInBaseSettingsAreGrayed.Run();
            TC_CheckThatAllTabPagesAreActive.Run();
            TC_ConfigureBaseSettings.Run("Liquid properties", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            TC_CheckThatAllTabPagesAreActive.Run();
            TC_ConfigureBaseSettings.Run("Liquid properties", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            TC_SetTableValue.Run("5;-10;0.5;10;0;0.6;15;10;0.7;20;20;0.8;25;30;0.9;30;40;1;35;50;1.1;40;60;1.2;45;70;1.3;50;75;1.4;55;80;1.5");
            TC_Export.Run();
            TC_Import.Run();
            TC_CloseModule.Run();
            TC_CheckForCriticalError.Run();
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
