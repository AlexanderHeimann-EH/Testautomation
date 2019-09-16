// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveClipboardDataToFile.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Saves the clipboard data of the About Box to a text file
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.AboutBox.Flows
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.AboutBox.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.AboutBox.Functions.ApplicationArea.MainView;

    /// <summary>
    /// Saves the clipboard data of the About Box to a text file
    /// </summary>
    public class SaveClipboardDataToFile : ISaveClipboardDataToFile
    {
        #region Public Methods and Operators

        /// <summary>
        /// Saves the clipboard data to a file with a default file name on the desktop (File name = actual date and time + AboutBox.txt).
        /// </summary>
        /// <returns>
        /// True if file is saved; False otherwise
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
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filename = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + "_AboutBox.txt";
                    string path = Path.Combine(desktop, filename);
                    File.WriteAllText(path, Clipboard.GetText());
                }
                catch (Exception e)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing clipboard into file failed. " + e.Message);
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Saves the clipboard data to a file
        /// </summary>
        /// <param name="filePath">
        /// The file path including the file name i.e. "C:\Test\AboutBox-Micropilot.txt"
        /// </param>
        /// <returns>
        /// True if file is saved; False otherwise
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public bool Run(string filePath)
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
                    File.WriteAllText(filePath, Clipboard.GetText());
                }
                catch (Exception e)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing clipboard into file failed. " + e.Message);
                    result = false;
                }
            }

            return result;
        }

        #endregion
    }
}