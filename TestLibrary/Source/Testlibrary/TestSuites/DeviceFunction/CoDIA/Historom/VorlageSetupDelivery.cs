// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VorlageSetupDelivery.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test case VorlageSetupDelivery.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.DeviceFunction.CoDIA.Historom
{
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Historom;
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
            TC_ReadEvents.Run();
            TC_SaveDataAs.Run("Relativer Pfad auf HistoromData");
			
            TC_ExportHistoRomData.Run("Realtiver Pfad auf HistoromDataExport");
            TC_DeleteHistoromData.Run();
            TC_OpenFile.Run("Relativer Pfad auf HistoromData.his");
            
			TC_SwitchTabs.Run();
            TC_AssignChannelsRandomly.Run();
            TC_ReadEvents.Run();
            
			TC_ConfigureSettings.Run("Off", "Off", "Off", "Off", string.Empty, string.Empty);
            TC_ReadEvents.Run();
            TC_CheckHistoromInfoMessage.Run("All channels are disabled");

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