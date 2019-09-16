/*
 * Created by Ranorex
 * User: Simon Schwab
 * Date: 04.05.2015
 * Time: 16:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Reflection;

using EH.PCPS.TestAutomation.Common.Tools;

namespace EH.PCPS.TestAutomation.DeviceCare.V10107.CommonFlows
{
    /// <summary>
    /// Description of PrintDeviceInformation.
    /// </summary>
    public class PrintDeviceInformation : EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows.IPrintDeviceInformation
    {
        /// <summary>
        /// 
        /// </summary>
        public PrintDeviceInformation()
        {
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePathAndName"></param>
        /// <returns></returns>
        public bool Run(string filePathAndName)
        {
            //instantiate modules
            var connection = new Functions.StatusArea.Statusbar.Statusbar_Functions();
            var create = new Functions.Helpers.InterfaceHelpers.DeviceReportFunctions();
            var devScreen = new Functions.ApplicationArea.Page_DeviceScreen.Page_DeviceScreen_Functions();
            var dialog = new Functions.Helpers.DialogFunctions();
            
            //check if device is connected
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Current task: Print Device Information");
            
            if (connection.IsDeviceConnected())
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device is connected. Start printing device report...");
                //press button device report
                devScreen.ClickFDTPrintButton();
                // wait until window is open
                if (dialog.WaitForDeviceReportDialog())
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Device Report created. Saving report...");
                    //click button print
                    dialog.ClickPrintButton();
                    
                    //check if print dialog is open
                    if (dialog.IsPrintFormOpen())
                    {
                        //select printer -> E+H FieldCare -> validate -> click print
                        if (dialog.SelectFieldCarePrinter())
                        {
                            //check if save dialog is open
                            if (dialog.IsSaveDialogOpen())
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Saving report in directory: '"+filePathAndName+"'");
                                //save dialog -> set filename and path
                                bool exists = create.IsFileCreated(filePathAndName);
                                if (exists)
                                {
                                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The file already exists. It will be overwritten...");
                                }
                                //check if text is set -> click save
                                if (dialog.SaveReportWithName(filePathAndName, exists))
                                {
                                    //check if file was created
                                    if (create.IsFileCreated(filePathAndName))
                                    {
                                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The file was created successfully");
                                        return true;
                                    }
                                }
                            }    
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="word">
        /// The word.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string word, int number)
        {
            return false;
        }
    }
}
