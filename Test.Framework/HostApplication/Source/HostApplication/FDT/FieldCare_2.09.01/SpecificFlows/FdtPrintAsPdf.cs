//------------------------------------------------------------------------------
// <copyright file="FDTPrintAsPDF.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 13.05.2011
 * Time: 1:16 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.SpecificFlows
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.Dialogs.ReportConfiguration.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.SpecificFlows;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Workflow Close.
    /// </summary>
    public class FdtPrintAsPdf : MarshalByRefObject, IFdtPrintAsPdf
    {
        /// <summary>
        ///     Run workflow
        /// </summary>
        /// <param name="reportType">Report type to create</param>
        /// <param name="documentationName">Name of to be created file</param>
        /// <param name="replaceProject">Boolean to allow overwrite existing file or not</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string reportType, string documentationName, bool replaceProject)
        {
            // If save-functionality called successfully
            if ((new OpenFdtPrint()).ViaMenu())
            {
                (new ReportConfiguration()).SelectReportType(reportType);
                Button button = (new ReportConfigurationElements()).SaveAs;
                if (button != null && button.Enabled)
                {
                    button.Click(DefaultValues.locDefaultLocation);

                    var watch = new Stopwatch();
                    watch.Start();
                    
                    var dialogFound = false;
                    dialogFound = OperatingSystemLoader.Functions.Dialogs.Validation.IsSaveAsDialogOpen.Run();
                    while (dialogFound == false)
                    {
                        if (watch.ElapsedMilliseconds > DefaultValues.GeneralTimeout)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                           "Create documentation took to much time or freezed.");
                            watch.Stop();
                            return false;
                        }
                        dialogFound = OperatingSystemLoader.Functions.Dialogs.Validation.IsSaveAsDialogOpen.Run();
                    }
                    watch.Stop();
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Data reading finished");

                    // speichern anstossen
                    if (OperatingSystemLoader.Functions.Dialogs.Execution.SaveAsFileBrowser.SaveAs(documentationName))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving document.");

                        Button replaceYes = (new ReplaceProjectMessageElements()).Yes;
                        if (replaceYes != null)
                        {
                            // Confirm replace message
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Overwriting existing file.");
                            replaceYes.Click(DefaultValues.locDefaultLocation);
                        }
                        return true; 
                    }
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving the document failed.");
                    return false;
                }
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Report Type could not be selected.");
                return false;
            }
            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Report Configuration could not be opened.");
            return false;
        }
    }
}