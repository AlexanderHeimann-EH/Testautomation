// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TC_TESTAREA.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 12.01.2011
 * Time: 6:47 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.Testlibrary.TestSuites.HostApplication.FDT
{
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Attributes;
    using EH.PCPS.TestAutomation.Common.Enumerations;

    /// <summary>
    /// Description of TC_TESTAREA.
    /// </summary>
    public class TC_TESTAREA
    {
        #region Public Methods and Operators

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="testString">
        /// The test string.
        /// </param>
        /// <param name="testInteger">
        /// The test integer.
        /// </param>
        /// <param name="testFloat">
        /// The test float.
        /// </param>
        /// <param name="testArray">
        /// The test array.
        /// </param>
        /// <returns>
        /// The string.
        /// </returns>
        [TestScriptInformation("E8EEF1DF-C9D3-48E5-8C3B-B82502B9624B", TestDefinition.Predefined, TestScript.TestCase)]
        public static string Run(string testString, int testInteger, float testFloat, string[] testArray)
        {
            MessageBox.Show("string testString, int testInteger, float testFloat, string[] testArray", "TestMessageBox");
            return "Dies ist ein Test";
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="testString">
        /// The test string.
        /// </param>
        /// <param name="testInteger">
        /// The test integer.
        /// </param>
        /// <param name="testFloat">
        /// The test float.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [TestScriptInformation("3A776F2A-15C8-4014-85B8-AA5D57E08D3F", TestDefinition.Predefined, TestScript.TestCase)]
        public static string Run(string testString, int testInteger, float testFloat)
        {
            MessageBox.Show("string testString, int testInteger, float testFloat", "TestMessageBox");
            return "Dies ist ein Test";
        }

        /// <summary>
        /// Run test case
        /// </summary>
        [TestScriptInformation("43BA702E-7A16-4911-AFBF-80902738428A", TestDefinition.Predefined, TestScript.TestCase)]
        public static void Run()
        {
            MessageBox.Show("no parameter", "TestMessageBox");
            // Loader.Frame.LoadImplementation();
            // Frame.RunDeviceFunction.ViaMenu();

            // bool isTrue = HelperFunctions.IsReading();
            // System.Windows.Forms.MessageBox.Show(isTrue.ToString());

            // for(int i = 0; i < 1; i++)
            // {
            // DeviceFunction.Common.Functions.OpenDTMRelatedModule.ViaMenu(ModuleNames.EnvelopeCurveEN,true);
            // DeviceFunction.Common.Functions.CloseDTMRelatedModule.CloseViaWindow(ModuleNames.EnvelopeCurveEN);
            // }

            // for(int i = 0; i < 100; i++)
            // {
            // bool isPassed = true;
            // isPassed &= TM_OpenOnlineParameterizationWithWaiting.Run();
            // isPassed &= TM_OpenOfflineParameterizationWithWaiting.Run();
            // isPassed &= TM_CloseFocusedDTMModuleViaX.Run();
            // isPassed &= HostApplicationLoader.FDT.FieldCare.Functions.MenuArea.Menubar.Validation.OpenAdditionalModule.ViaMenu(ModuleNames.EnvelopeCurveDE);
            // isPassed &= TM_SingleCurveReadingViaMenuWithWaiting.Run();
            // isPassed &= TM_SingleCurveReadingViaMenuWithWaiting.Run();
            // isPassed &= TM_CyclicCurveReadingViaMenuWithWaiting.Run(10);
            // isPassed &= TM_SaveCurvesViaMenu.Run();
            // isPassed &= TM_CloseFocusedDTMModuleViaX.Run();
            // isPassed &= TM_CloseFocusedDTMModuleViaX.Run();
            // if(isPassed)
            // {
            // Log.Success(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "PASSED");
            // }
            // else
            // {
            // Log.Failure(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FAILED");
            // }
            // }
            // DeviceFunction.Common.Functions.CloseFocusedDTMModule.ViaRightX();

            // Element element = null; 
            // Host.Local.TryFindSingle(DeviceFunction.Common.ModulePaths.ModuleFrameUpperRight, 10000, out element);
            // System.Diagnostics.Debug.Print(element.Children.Count.ToString());

            // for(int i = 0; i < 5; i++)
            // {
            // Report.Info("DURCHLAUF: " + (i+1));
            // Testlibrary.TestModules.DeviceFunction.CoDIA.EnvelopeCurve.TM_SaveCurvesAsViaMenu.Run("blubberdiblub", false, true);
            // }

            // System.Drawing.Bitmap bmp = null;
            // Element element = null;
            // Host.Local.TryFindSingle(Paths.IconNewCurve, 30000, out element);
            // bmp = new System.Drawing.Bitmap(Imaging.CaptureImage(element));
            // bmp.Save(@"C:\Documents and Settings\testadmin\Desktop\Pictures\NewCurve.bmp");

            // Frame.LoadImplementation();
            // for (int i = 0; i < 2; i++)
            // {
            // Report.Info("Testenvironment:", "Loop: " + i.ToString());
            // TC_CreateSaveCloseCDIProject.Run();
            // TC_CreateSaveCloseHARTProject.Run();
            // TC_CreateSaveClosePAProject.Run();
            // }
        }

        #endregion
    }
}