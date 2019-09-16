// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrintDeviceInformation.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.CI.SpecificFlows
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.CI.Functions.Dialogs.ReportConfiguration.Execution;
    using EH.PCPS.TestAutomation.FieldCare.CI.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;
    using EH.PCPS.TestAutomation.OperatingSystemLoader.Functions.Dialogs;

    using Ranorex;

    /// <summary>
    /// The print device information.
    /// </summary>
    public class PrintDeviceInformation : IPrintDeviceInformation
    {
        #region Public Methods and Operators

        /// <summary>
        /// Performs a FDT-Print with a specified filename, overwrite if necessary
        /// </summary>
        /// <param name="reportType">Kind of report to print</param>
        /// <param name="fileName">Filename for the printout</param>
        /// <param name="timeoutInMilliseconds">The timeout in milliseconds. Be aware that printing can take several minutes.</param>
        /// <returns>
        /// true: if FDT-Print was successful; false: if an error occurred
        /// </returns>
        public bool Run(string reportType, string fileName, int timeoutInMilliseconds)
        {
            bool result = true;
            if ((new OpenFdtPrint()).ViaMenu() == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening FDT-Print dialog failed.");
                result = false;
            }
            else
            {
                (new ReportConfiguration()).SelectReportType(reportType);
                Button saveAs = (new ReportConfigurationElements()).SaveAs;
                if (saveAs == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Save As button is null.");
                    result = false;
                }
                else
                {
                    saveAs.Click(DefaultValues.locDefaultLocation);
                    if (this.WaitUntilPrintingIsFinished(timeoutInMilliseconds) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Create documentation took too long or is frozen.");
                        Button cancel = new ReportConfigurationElements().Cancel;
                        if (cancel != null)
                        {
                            cancel.Click();
                        }

                        result = false;
                    }
                    else if (Execution.SaveAsFileBrowser.SaveAs(fileName) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving Report failed.");
                        Button cancel = new ReportConfigurationElements().Cancel;
                        if (cancel != null)
                        {
                            cancel.Click();
                        }

                        result = false;
                    }
                    else
                    {
                        // If print out with equal file name already exists and the field care internal dialog comes up
                        Button replaceYes = (new ReplaceProjectMessageElements()).Yes;
                        if (replaceYes != null)
                        {
                            // Confirm replace message
                            replaceYes.Click(DefaultValues.locDefaultLocation);
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Report generated and saved successfully");
                    }
                }
            }

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Waits until generating report (or printing) is finished
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds.
        /// </param>
        /// <returns>
        /// true: if action is finished; false: if an error occurred
        /// </returns>
        private bool WaitUntilPrintingIsFinished(int timeoutInMilliseconds)
        {
            var watch = new Stopwatch();
            watch.Start();
            while (Validation.IsSaveAsDialogOpen.Run() == false)
            {
                if (watch.ElapsedMilliseconds > timeoutInMilliseconds)
                {
                    watch.Stop();
                    return false;
                }
            }

            watch.Stop();
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Creating document finished.");
            return true;
        }

        #endregion
    }
}
