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

namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.Parameterization
{
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Parameterization;
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication;
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT;

    /// <summary>
    /// The test case VorlageSetupDelivery.
    /// </summary>
    public class VorlageSetupDeliveryOffline
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        /////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// The run.
        /// </summary>        
        public static void Run()
        {
            ////	Für die Verwendung der Offline Parametrierung ist ein FDT Upload notwendig
            ////    Der Test findet nach dem Test der Linearisierung statt

            TC_OpenModuleOffline.Run();
            TC_CheckThatParameterAreNotInvalid.Run();            
            TC_CloseModuleOffline.Run();

            TC_OpenModuleOffline.Run();
            //// Vom PC zu setzen:
            TC_ChangeParameterAndCheckValue.Run("Pfad zum Parameter", "Wert");
            TC_CheckThatParameterCannotBeSetToAnInvalidValue.Run("Pfad zum Parameter", "Invalider Wert");
            TC_CloseModuleOffline.Run();

            TC_OpenModuleOffline.Run();
            TC_CheckParameterValue.Run("Pfad zum Parameter", "Wert");
            TC_CloseModuleOffline.Run();

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
