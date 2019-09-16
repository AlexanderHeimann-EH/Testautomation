using System;
using System.Diagnostics;

using CiC_DTMstudio_Test_Template.TestModul.Configuration;

using Testlibrary.TestModules.Frame;
using Ranorex;
using DateTime = System.DateTime;

namespace CiC_DTMstudio_Test_Template
{
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}

        private static void Main(string[] args)
        {
            string logFileName = @"C:/Reports/" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_Report.rxlog";

            Report.Setup(ReportLevel.Debug, logFileName, true);

            //int error;
            try
            {
                ////----------------//
                //// Call testcases //
                ////----------------//

                Common.Configuration.SystemConfiguration.GetConfig(@"SystemConfig.xml");

                TM_StartFrameFieldCareWithDefault.Run();

                //var watch = new Stopwatch();
                //watch.Start();

                ////SystemConfiguration.GetConfig(@"Z:\VM_Transfer\Framework EC\Run\ConfigData\SystemConfig.xml");
                ////SystemConfiguration.GetConfig(@"SystemConfig.xml");

                //ConfigurationData.GetConfigurationData();
                ////TestFrameworkVersion.GetTestFrameworkVersion();

                //TM_StartFrameFieldCareWithDefault.Run();

                //watch.Stop();
                //Debug.Print("Ellapsed: " + watch.ElapsedMilliseconds);
            }
            //catch (ImageNotFoundException e)
            //{
            //    Report.Error(e.ToString());
            //    Report.LogData(ReportLevel.Error, "Image not found", e.Feature);
            //    Report.LogData(ReportLevel.Error, "Searched image", e.Image);
            //    error = -1;
            //}
            //catch (RanorexException e)
            //{
            //    Report.Error(e.ToString());
            //    Report.Screenshot();
            //    error = -1;
            //}
            //catch (ThreadAbortException)
            //{
            //    Report.Warn("AbortKey has been pressed");
            //    Thread.ResetAbort();
            //    error = -1;
            //}
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Report.Error("Unexpected exception occured: " + e);
                //error = -1;??
            }

            Report.End();
            //return error;
        }
    }
}
