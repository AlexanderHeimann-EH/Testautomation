// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenFileBrowser.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.Windows81.Functions.Dialogs.Execution
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.OperatingSystemInterfaces.Functions.Dialogs.Execution;
    using EH.PCPS.TestAutomation.Windows81.GUI.Dialogs;

    using Ranorex;

    using Button = Ranorex.Button;

    /// <summary>
    ///     Description of OpenFileBrowser.
    /// </summary>
    public class OpenFileBrowser : IOpenFileBrowser
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Closes open dialog
        /// </summary>
        /// <returns>
        ///     true: if call worked fine
        ///     false: if an error occurred
        /// </returns>
        public bool Close()
        {
            Button buttonClose = new OpenFileBrowserElements().buttonClose;
            if (buttonClose == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Close Button is null");
                return false;
            }

            buttonClose.Click(DefaultValues.locDefaultLocation);
            return true;
        }

        /// <summary>
        /// The cancel.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Cancel()
        {
            Button buttonCancel = new OpenFileBrowserElements().buttonCancel;
            if (buttonCancel == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cancel Button is null");
                return false;
            }

            buttonCancel.Click(DefaultValues.locDefaultLocation);
            return true;
        }

        /// <summary>
        /// Load specified file, close dialog if file is not available
        /// </summary>
        /// <param name="fileName">
        /// Filename for loading.
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Load(string fileName)
        {
            try
            {
                bool result = false;
                string directory = System.IO.Path.GetDirectoryName(fileName);
                if (directory == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "System.IO.Path.GetDirectoryName returned null.");
                    this.Close(); 
                }
                else
                {
                    if (System.IO.Directory.Exists(directory) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The directory: \"" + directory + "\" does not exist.");
                        this.Close();
                    }
                    else
                    {
                        if (System.IO.File.Exists(fileName) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The file: \"" + fileName + "\" does not exist.");
                            this.Close();
                        }
                        else
                        {
                            Text text = new OpenFileBrowserElements().textFileName;
                            Button buttonOpen = new OpenFileBrowserElements().buttonOpen;

                            if (text == null || buttonOpen == null)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text field or Open button is null");
                                this.Close();
                            }
                            else
                            {
                                text.Click(DefaultValues.locDefaultLocation);
                                text.TextValue = string.Empty;

                                Keyboard.Press(fileName);                                
                                Keyboard.Press(Keys.Tab);

                                buttonOpen.MoveTo(DefaultValues.locDefaultLocation);
                                buttonOpen.Click(DefaultValues.locDefaultLocation);

                                // check if ok button from the "file not found" dialog is visible
                                Button buttonOk = new MessageElements().buttonOk;
                                if (buttonOk == null)
                                {
                                    // file was available and has been loaded                                    
                                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File " + "[" + fileName + "]" + " loaded successfully");
                                    result = true;
                                }
                                else
                                {
                                    buttonOk.Click(DefaultValues.locDefaultLocation);
                                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File " + "[" + fileName + "]" + " is not available");
                                    this.Close();
                                }
                            }
                        }
                    }
                }                

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                this.Close();
                return false;
            }           
        }

        #endregion
    }
}