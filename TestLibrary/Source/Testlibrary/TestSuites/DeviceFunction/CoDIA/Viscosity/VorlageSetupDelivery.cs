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

namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.Viscosity
{
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Viscosity;
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
        
        /// <summary>
        /// The run.
        /// </summary>
        public static void Run()
        {
            TC_ActivateViscositySoftwareOption.Run("DeviceMenu//_Expert_//_System_//_Management_//STD_LicenseCode_", "33631279");
            TC_OpenModuleOnline.Run();
            TC_SetTableValue.Run("10;2;2;3;3;4;4;5;5;6;6;7");
            TC_ConfigureFluidPropertiesParameter.Run("cP", @"°C", "5.00", string.Empty, string.Empty);
            TC_Calculate.Run();
            TC_CheckResultsAfterCalculation.Run();
            TC_CompareCoefficients.Run("0.001", "-0.0593", "0.0010");
            TC_WriteValuesToDevice.Run(true);
            TC_Export.Run();
            TC_CloseModule.Run();
            TC_OpenModuleOnline.Run();
            TC_Import.Run();
            TC_ConfigureFluidPropertiesParameter.Run("cP", @"°C", "5.00", string.Empty, string.Empty);
            TC_Calculate.Run();
            TC_CheckResultsAfterCalculation.Run();
            TC_CompareCoefficients.Run("0.001", "-0.0593", "0.0010");
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
