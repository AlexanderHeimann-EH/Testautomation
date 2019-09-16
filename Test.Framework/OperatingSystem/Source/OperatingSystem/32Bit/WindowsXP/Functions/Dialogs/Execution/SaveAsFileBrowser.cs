// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveAsFileBrowser.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.WindowsXP.Functions.Dialogs.Execution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.OperatingSystemInterfaces.Functions.Dialogs.Execution;
    using EH.PCPS.TestAutomation.WindowsXP.Functions.Dialogs.Validation;
    using EH.PCPS.TestAutomation.WindowsXP.GUI.Dialogs;

    using Ranorex;

    using Button = Ranorex.Button;

    /// <summary>
    ///     Provides methods to save Historom files
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class SaveAsFileBrowser : ISaveAsFileBrowser
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a proposed filename
        /// </summary>
        public string ProposedFileName
        {
            get
            {
                Text text = (new SaveAsFileBrowserElements()).TextFileName;
                if (text != null && text.TextValue.Length > 0)
                {
                    return text.TextValue;
                }

                return string.Empty;
            }

            set
            {
                Text text = (new SaveAsFileBrowserElements()).TextFileName;
                if (text != null && text.TextValue.Length > 0)
                {
                    text.Click();
                    text.TextValue = string.Empty;
                    Keyboard.Press(value);
                    Keyboard.Press(Keys.Tab);
                }
                else
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not set filename");
                }
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Closes save as dialog
        /// </summary>
        /// <returns>
        ///     true: if call worked fine
        ///     false: if an error occurred
        /// </returns>
        public bool Close()
        {
            Button buttonClose = new SaveAsFileBrowserElements().ButtonClose;
            if (buttonClose == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Close button is null");
                return false;
            }

            buttonClose.Click(DefaultValues.locDefaultLocation);
            return true;
        }

        /// <summary>
        ///     save a file with proposed filename
        /// </summary>
        /// <returns>
        ///     true: if saving was successful
        ///     false: if an error occurred
        /// </returns>
        public bool Save()
        {
            try
            {
                bool result = false;

                Button buttonSave = new SaveAsFileBrowserElements().ButtonSave;
                Text text = new SaveAsFileBrowserElements().TextFileName;
                if (text == null || buttonSave == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text field or Save button is null");
                    this.Close();
                }
                else
                {
                    string fileName = text.TextValue;
                    string directory = Path.GetDirectoryName(fileName);
                    if (directory == null)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "System.IO.Path.GetDirectoryName returned null.");
                        this.Close();
                    }
                    else
                    {
                        if (Directory.Exists(directory) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The directory: \"" + directory + "\" does not exist.");
                            this.Close();
                        }
                        else
                        {
                            buttonSave.Click(DefaultValues.locDefaultLocation);

                            // check if File already exists dialog appears, look for ok button
                            Button buttonYes = new MessageElements().buttonYes;
                            if (buttonYes == null)
                            {
                                // saving was successful
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File " + "[" + fileName + "]" + "Saved successfully");
                                result = true;
                            }
                            else
                            {
                                // button yes available -> file with that filename already exists, replace file dialog appeared, replace file;
                                buttonYes.Click(DefaultValues.locDefaultLocation);
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File " + "[" + fileName + "]" + " already exists, overwriting...");
                                result = true;
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

        /// <summary>
        /// save a file with given filename
        /// </summary>
        /// <param name="fileName">
        /// filename under which file will be saved
        /// </param>
        /// <returns>
        /// true: if saving was successful
        ///     false: if an error occurred
        /// </returns>
        public bool SaveAs(string fileName)
        {
            try
            {
                bool result = false;
                string directory = Path.GetDirectoryName(fileName);
                if (directory == null)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "System.IO.Path.GetDirectoryName returned null.");
                    this.Close();
                }
                else
                {
                    if (Directory.Exists(directory) == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The directory: \"" + directory + "\" does not exist.");
                        this.Close();
                    }
                    else
                    {
                        if ((new IsSaveAsDialogOpen()).Run())
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog is open");
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Dialog is not open");
                        }

                        Text text = new SaveAsFileBrowserElements().TextFileName;
                        Button buttonSave = new SaveAsFileBrowserElements().ButtonSave;
                        if (text == null || buttonSave == null)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text field or Save button is null");
                            this.Close();
                        }
                        else
                        {
                            text.Click(DefaultValues.locDefaultLocation);
                            text.TextValue = string.Empty;

                            Keyboard.Press(fileName);
                            Keyboard.Press(Keys.Tab);

                            buttonSave.MoveTo(DefaultValues.locDefaultLocation);
                            buttonSave.Click(DefaultValues.locDefaultLocation);

                            // check if File already exists dialog appears, look for ok button
                            Button buttonYes = new MessageElements().buttonYes;
                            if (buttonYes == null)
                            {
                                // saving was successful
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File " + "[" + fileName + "]" + "Saved successfully");
                                result = true;
                            }
                            else
                            {
                                // button yes available -> file with that filename already exists, replace file dialog appeared, replace file;
                                buttonYes.Click(DefaultValues.locDefaultLocation);
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "File " + "[" + fileName + "]" + " already exists, overwriting...");
                                result = true;
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