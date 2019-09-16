// ***********************************************************************
// Assembly         : EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.ConcentrationV2
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

namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.ConcentrationV2
{
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication;
    using ConcentrationV2 = EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2;
    using CreateDocumentation = EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.CreateDocumentation;

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
            ConcentrationV2.TC_ActivateSoftwareOption.Run(string.Empty, string.Empty);
            ConcentrationV2.TC_OpenModuleOnline.Run();
            ConcentrationV2.TC_CheckTabsAfterOpenModule.Run();
            ConcentrationV2.TC_ConfigureCalculationBaseToPredefinedLiquid.Run();
            ConcentrationV2.TC_CalculateCoefficientsAndCheckOutput.Run();
            ConcentrationV2.TC_SaveAs.Run();
            ConcentrationV2.TC_CreateNewConcentration.Run();
            ConcentrationV2.TC_LoadConcentrationFile.Run();
            ConcentrationV2.TC_CheckExpertResults.Run();
            ConcentrationV2.TC_CompareCoefficientsWithExpectedCoefficients.Run();
            ConcentrationV2.TC_WriteCoefficientsToDevice.Run();
            ConcentrationV2.TC_CreateNewConcentration.Run();
            ConcentrationV2.TC_ReadCoefficientsFromDevice.Run();
            ConcentrationV2.TC_EnterDataForLiquidProperties.Run();
            ConcentrationV2.TC_ExportConcentrationFile.Run();
            ConcentrationV2.TC_CreateNewConcentration.Run();
            ConcentrationV2.TC_ImportConcentrationFile.Run();
            ConcentrationV2.TC_CreateNewConcentration.Run();
            ConcentrationV2.TC_CheckReferenceValueTabBehaviour.Run();
            ConcentrationV2.TC_CheckFineTuningGuiBehaviour.Run();
            ConcentrationV2.TC_CheckHelpForConcentration.Run();
            ConcentrationV2.TC_CloseModule.Run();
            ConcentrationV2.TC_OpenModuleOnline.Run();
            CreateDocumentation.TC_OpenModuleOnline.Run();
            CreateDocumentation.TC_SaveDocumentationAsPdf.Run();
            CreateDocumentation.TC_CloseModule.Run();
            ConcentrationV2.TC_CloseModule.Run();
            ConcentrationV2.TC_DeactivateSoftwareOption.Run(string.Empty);
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
