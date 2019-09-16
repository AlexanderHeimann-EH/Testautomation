//------------------------------------------------------------------------------
// <copyright file="AddRemovePrograms.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.Common.OSSpecific
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     Description of AddRemovePrograms.
    /// </summary>
    public class AddRemovePrograms
    {
        /// <summary>
        ///     Open Add Remove Programs-Dialog
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static int Open()
        {
            try
            {
                var prcsStartInfo = new ProcessStartInfo(AddRemoveProgramsPaths.ApplicationPath);
                prcsStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process prcsSetup = Process.Start(prcsStartInfo);
                if (prcsSetup == null)
                {
                    return 0;
                }

                return prcsSetup.Id;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return -1;
            }
        }

        /// <summary>
        ///     Close Add Remove Programs-Dialog
        /// </summary>
        /// <param name="processId">Id of process to kill</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool Close(int processId)
        {
            try
            {
                Process prcsSetup = Process.GetProcessById(processId);
                prcsSetup.Kill();
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Show Program's Support Information
        /// </summary>
        /// <param name="programName">Name of program whose support information should be opened</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool ShowSupportInformation(string programName)
        {
            try
            {
                if (SelectProgram(programName))
                {
                    AddRemoveProgramsElements.TxtSupportInformation.Click();
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Take screenshot of SupportInformation
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool PrintSupportInformation()
        {
            try
            {
                int form = 0;
                IList<Form> openForm = Host.Local.Find<Form>(AddRemoveProgramsPaths.OpenForms, DefaultValues.iTimeoutShort);
                int height = openForm[0].ScreenRectangle.Height;
                int width = openForm[0].ScreenRectangle.Width;

                for (int counter = 0; counter < openForm.Count; counter++)
                {
                    if ((openForm[counter].ScreenRectangle.Height < height) &&
                        (openForm[counter].ScreenRectangle.Width < width))
                    {
                        form = counter;
                        height = openForm[counter].ScreenRectangle.Height;
                        width = openForm[counter].ScreenRectangle.Width;
                    }
                }

                openForm[form].MoveTo();
                EH.PCPS.TestAutomation.Common.Tools.Log.Screenshot();
                openForm[form].Close();
                return true;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Clicks list item
        /// </summary>
        /// <param name="programName">Name of program to select</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        private static bool SelectProgram(string programName)
        {
            try
            {
                ListItem listItem = AddRemoveProgramsElements.LiItem(programName);
                if (listItem != null)
                {
                    return true;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}