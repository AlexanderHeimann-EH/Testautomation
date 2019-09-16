// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveClipboardDataToReport.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Saves the clipboard data of the About Box to the report
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.AboutBox.Flows
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.AboutBox.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Saves the clipboard data of the About Box to the report
    /// </summary>
    public class SaveClipboardDataToReport : ISaveClipboardDataToReport
    {
        #region Public Methods and Operators

        /// <summary>
        /// Saves the clipboard data to report.
        /// </summary>
        /// <returns>
        /// True if successful; False otherwise
        /// </returns>
        public bool Run()
        {
            bool result = true;

            if (Execution.CopyToClipboard.Run() == false)
            {
                result = false;
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Clicking [Copy to Clipboard] failed. Aborting...");
            }
            else
            {
                try
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Printing About Box information...");
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), Clipboard.GetText());
                }
                catch (Exception e)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing clipboard into the report failed. " + e.Message);
                    result = false;
                }
            }

            return result;
        }

        #endregion
    }
}