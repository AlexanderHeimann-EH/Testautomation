////------------------------------------------------------------------------------
//// <copyright file="CheckFrameGUI.cs" company="Endress+Hauser Process Solutions AG">
////     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
//// </copyright>
//// <summary>Description of file.</summary>
////------------------------------------------------------------------------------

//*
// * Created by Ranorex
// * User: testadmin
// * Date: 31.03.2011
// * Time: 11:22 
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
 
//using System;
//using Ranorex;
//using Ranorex.Core;
//using Common;
//using Testlibrary.TestModules.Frame;

//namespace Testlibrary.TestCases
//{
//    /// <summary>
//    /// Description of CheckFrameGUI.
//    /// </summary>
//    public class TC_CheckFrameGUI
//    {
//        /// <summary>
//        /// Run testcase
//        /// </summary>
//        public void Run()
//        {
//            bool isPassed = true;

//            CommonHostApplicationLayerLoader.CommonFlows.OpenHostApplication.Run();
			
//            // Confirm Frame evaluation message box
//            isPassed &= TM_ConfirmEvaluation.Run();
			
//            // Check Dialog ProjectBrowserOpen
//            isPassed &= TM_CheckDialogProjectBrowserOpen.Run();
//            isPassed &= Loader.Frame.Dialogs.ProjectBrowser.Close();
			
//            // Check Dialog ProjectBrowserLoad
//            isPassed &= Loader.Frame.Functions.OpenProjectLoad.ViaMenu();
//            isPassed &= TM_CheckDialogProjectBrowserLoad.Run();
//            isPassed &= Loader.Frame.Dialogs.ProjectBrowser.Close();
			
//            // Neccessary intermediate steps
//            isPassed &= Loader.Frame.Functions.OpenProjectNew.ViaMenu();
//            isPassed &= Loader.Frame.Dialogs.ProjectBrowser.CreateNew();
			
//            // Check Dialog Add Device
//            isPassed &= Loader.Frame.Functions.OpenAddDevice.ViaMenu();
//            isPassed &= TM_CheckDialogAddDevice.Run();
//            isPassed &= Loader.Frame.Dialogs.AddDevice.Close();
			
//            // Check Dialog Find Device
//            isPassed &= Loader.Frame.Functions.OpenFindDevice.ViaMenu();
//            isPassed &= TM_CheckDialogFindDevice.Run();
//            isPassed &= Loader.Frame.Dialogs.FindDevice.Close();
			
//            // Neccessary intermediate steps
//            isPassed &= TM_AddParentDtm.Run("FXA291");
//            isPassed &= TM_AddChildDTM_CDI.Run("FXA291", "Levelflex");
//            isPassed &= TM_FindDevice.Run("Levelflex");
			
//            // Check Menu
//            isPassed &= TM_CheckMenu.Run();
			
//            // Check MessageBox Confirm Delete
//            isPassed &= Loader.Frame.Functions.RunDeleteDevice.ViaMenu();
//            isPassed &= TM_CheckMessageConfirmDelete.Run();
//            ConfirmDeleteElements.btnNo.Click(DefaultValues.locDefaultLocation);
			
//            // Check MessageBox Shutdown DTMs
//            isPassed &= Loader.Frame.Functions.RunFrameExit.ViaMenu();
//            isPassed &= TM_CheckMessageShutdownDTMs.Run();
//            ShutdownDTMsElements.btnYes.Click(DefaultValues.locDefaultLocation);
			
//            // Check MessageBox Save Project 
//            isPassed &= TM_CheckMessageSaveProject.Run();
//            SaveProjectElements.btnNo.Click(DefaultValues.locDefaultLocation);
			
//            if(isPassed){ Log.Success("TC_CheckFrameGUI", "Testcase passed."); }
//            else { Log.Failure("TC_CheckFrameGUI", "Testcase failed."); }
//        }
//    }
//}


//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_OpenHostApplication.Run(@"C:\Program Files (x86)\Endress+Hauser\FieldCare\Frame\FMPFrame.exe");
////EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_UpdateDtmCatalog.Run(5000, 120000, true, 1, 2);
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_CreateProjectAddCommDtmAndScan.Run("CDI Communication FXA291", 10000, "CDI Communication FXA291");
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_SaveProject.Run("FC21100 GUI TEST");
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_CloseProject.Run();
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_CreateNewProject.Run();
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_AddDeviceToProject.Run("Host", "CDI Communication FXA291");
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_AddDeviceToProject.Run("CDI Communication FXA291", "Promass 100 / 8x1Bxx / MR4-CDIS / FW 1.03.zz / Dev.Rev. 3");
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_FindAndSelectDeviceInTopology.Run("Promass 100 / 8x1Bxx / MR4-CDIS / FW 1.03.zz / Dev.Rev. 3");
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_ConnectDevice.Run();
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_DisconnectDevice.Run();
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_CloseProject.Run();
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_LoadProject.Run("FC21100 GUI TEST");
//EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare.TC_CloseHostApplication.Run();