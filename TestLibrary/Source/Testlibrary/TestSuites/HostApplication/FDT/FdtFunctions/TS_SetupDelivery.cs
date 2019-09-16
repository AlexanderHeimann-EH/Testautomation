// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TS_SetupDelivery.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   The test suite TS_SetupDelivery.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.HostApplication.FDT.FdtFunctions
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Compare;
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT;

    /// <summary>
    /// Setup Delivery Test FDT-Functions
    /// ---------------------------------
    /// Preconditions:
    /// - DTM ist online
    /// - Device supports FDT Functionality
    /// - Online und Offline Parametrierung enthalten unterschiedliche Werte
    /// ---------------------------------
    /// Teststeps:
    /// - Öffne Compare Datasets
    ///              - Modul geöffnet
    /// - Vergleiche Online Daten mit Offline Daten
    ///              - Für den Vergleich erlaubte Parameter stimmen überein
    ///              - Progressbar zeigt den Fortschritt des Vergleichs
    /// - Prüfe Parameter
    ///              - Parameter die übereinstimmen sollen, stimmen überein
    ///              - Parameter die nicht übereinstimmen sollen, stimmen nicht überein
    /// - Schließe Compare Datasets
    ///              - Modul geschlossen
    /// - Daten hochladen
    ///              - Vorgang beendet
    /// - Prüfe HostApplication
    ///              - Es ist keine Fehlermeldung verfügbar
    ///              - Es ist eine Erfolgsmeldung verfügbar
    /// - Öffne Compare Datasets
    ///              - Modul geöffnet
    /// - Vergleiche Online Daten mit Offline Daten
    ///              - Für den Vergleich erlaubte Parameter stimmen überein
    ///              - Progressbar zeigt den Fortschritt des Vergleichs
    /// - Prüfe Parameter
    ///              - Parameter die übereinstimmen sollen, stimmen überein
    ///              - Parameter die nicht übereinstimmen sollen, stimmen nicht überein
    /// - Schließe Compare Datasets
    ///              - Modul geschlossen
    /// - Daten runterladen
    ///              - Vorgang beendet
    /// - Prüfe HostApplication
    ///              - Es ist keine Fehlermeldung verfügbar
    ///              - Es ist eine Erfolgsmeldung verfügbar
    /// - Öffne Compare Datasets
    ///              - Modul geöffnet
    /// - Vergleiche Online Daten mit Offline Daten
    ///              - Für den Vergleich erlaubte Parameter stimmen überein
    ///              - Progressbar zeigt den Fortschritt des Vergleichs
    /// - Prüfe Parameter
    ///              - Parameter die übereinstimmen sollen, stimmen überein
    ///              - Parameter die nicht übereinstimmen sollen, stimmen nicht überein
    /// - Schließe Compare Datasets
    ///              - Modul geschlossen
    /// - Druck-Dialog öffnen (HostApplication)
    ///              - Druck Dialog geöffnet
    /// - Erstelle Dokumentation
    ///              - Dokument ist verfügbar
    /// - Vergleiche Dokument mit Referenzwerten aus einem Referenzdokument
    ///              - Parameterwerte Online sind gedruckt
    ///              - Einheiten sind gedruckt
    ///              - Angewählte Module wurden gedruckt
    /// </summary>
// ReSharper disable InconsistentNaming
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class TS_SetupDelivery
// ReSharper restore InconsistentNaming
    {
        /////////////////////////////////////////////////////////////////
        // DO NOT CHANGE Guid, TestDefinition or TestScript-Attribute; 
        // Changes are allowed at TestCategory and TestFocus, at your own risk
        /////////////////////////////////////////////////////////////////
        #region Public Methods and Operators

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="parameterList">
        /// A list of parameters which should be checked after a download
        /// </param>
        public static void Run(string parameterList)
        {
            List<string> testList = Common.Tools.StringToListConverter.Run(parameterList);

            TC_OpenModuleOnline.Run();
            TC_CompareOfflineWithOnline.Run(120000);
            TC_CheckThatParameterAreEqual.Run(testList);
            TC_CloseModule.Run();

            TC_FdtUpload.Run();

            TC_OpenModuleOnline.Run();
            TC_CompareOfflineWithOnline.Run(120000);
            TC_CheckThatParameterAreEqual.Run(testList);
            TC_CloseModule.Run();
            
            TC_FdtDownload.Run();
            
            TC_OpenModuleOnline.Run();
            TC_CompareOfflineWithOnline.Run(120000);
            TC_CheckThatParameterAreEqual.Run(testList);
            TC_CloseModule.Run();

            TC_FdtPrint.Run("fileName", 100000);
        }

        #endregion
    }
}