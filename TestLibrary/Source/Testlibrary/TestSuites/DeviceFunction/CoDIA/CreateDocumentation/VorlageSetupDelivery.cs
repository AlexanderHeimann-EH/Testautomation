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

namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.CreateDocumentation
{
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.CreateDocumentation;
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

            TC_OpenModuleOnline.Run();
            TC_SaveDocumentationAsPdf.Run("Relativer Pfad auf CreateDocumentationData.pdf");
            TC_SaveDocumentationAsPdf.Run("Relativer Pfad auf CreateDocumentationData1.pdf");
            TC_CloseModule.Run();

            TC_OpenModuleOnline.Run();            
            TC_SaveDocumentationAsPdf.Run("Relativer Pfad auf CreateDocumentationData2.pdf");
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
