// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Run
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Configuration;
    using EH.PCPS.TestAutomation.Common.Configurator.GUI;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces;
    using EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.FieldCare;

    using Execution = EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using Validation = EH.PCPS.TestAutomation.TestPackageCI.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using ConcentrationV2 = EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.ConcentrationV2;
    using CreateDocumentation = EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.CreateDocumentation;

    using Ranorex;
    using Ranorex.Core.Reporting;

    /// <summary>
    /// The program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The configurator dialog.
        /// </summary>
        private static ConfiguratorDialog configuratorDialog;

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        [STAThread]
        public static int Main(string[] args)
        {
            int error = -1;

            if (ArgumentHelper.IsHelpNeeded(args))
            {
                ArgumentHelper.ShowHelp();
            }
            else
            {
                Keyboard.AbortKey = Keys.Pause;
                var silentMode = ArgumentHelper.IsSilent(args);
                var dialogResult = DialogResult.None;

                string pathToReport = Directory.GetCurrentDirectory() + @"\..\..\Source\Run\Bin\Debug\Report\";
                if (!Directory.Exists(pathToReport))
                {
                    Directory.CreateDirectory(pathToReport);
                }

                string report = pathToReport + "LatestReport.rxlog";

                TestReport.Setup(ReportLevel.Debug, report, true);

                try
                {
                    string configFile = Directory.GetCurrentDirectory() + @"\..\..\Source\Run\Bin\Debug\ConfigData\Configuration.xml";
                    configuratorDialog = new ConfiguratorDialog(configFile);

                    if (!silentMode)
                    {
                        dialogResult = configuratorDialog.ShowDialog();
                    }

                    if (dialogResult == DialogResult.Cancel)
                    {
                        MessageBox.Show(@"Operation was canceled by user.");
                    }
                    else if (dialogResult == DialogResult.OK || silentMode)
                    {
                        LoaderHelper.InitializeAssemblyProvider();
                        ReportHelper.ReportPath = @"C:\Report\Output\";
                        EH.PCPS.TestAutomation.Common.Tools.Logging.Log4Net.Log4NetLog.XmlInitialize();

                        /*----------------*/
                        /* Test Area      */
                        /*----------------*/

                        //EH.PCPS.TestAutomation.Testlibrary.TestCases.DeviceFunction.CoDIA.Parameterization.TC_ConnectToRemoteHost_HMI.Run();
                        //EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.TC_OpenHostApplication.Run(@"C:\Program Files (x86)\Endress+Hauser\FieldCare\Frame\FMPFrame.exe");
                        EH.PCPS.TestAutomation.Testlibrary.TestCases.HostApplication.FDT.TC_FdtPrint.Run(@"C:\Report\Output\Test", 30000);
                    }
                    else
                    {
                        throw new Exception("Impossible error");
                    }
                }
                catch (ImageNotFoundException e)
                {
                    Report.Error(e.ToString());
                    Report.LogData(ReportLevel.Error, "Image not found", e.Feature);
                    Report.LogData(ReportLevel.Error, "Searched image", e.Image);
                    error = -1;
                }
                catch (RanorexException e)
                {
                    Report.Error(e.ToString());
                    Report.Screenshot();
                    error = -1;
                }
                catch (ThreadAbortException e)
                {
                    Report.Warn("AbortKey has been pressed: " + e);
                    Thread.ResetAbort();
                    error = -1;
                }
                catch (Exception e)
                {
                    Report.Error("Unexpected exception occurred: " + e);
                    error = -1;
                }

                Report.End();
                return error;
            }

            return 0;
        }
    }
}


