// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveAsFileBrowserElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Testadmin
 * Date: 21.02.2013
 * Time: 15:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.WindowsXP.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     Provides access to the Save As File browser dialog
    /// </summary>
    public class SaveAsFileBrowserElements
    {
        #region members

        /// <summary>
        /// The _repository.
        /// </summary>
        private readonly FileBrowserRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveAsFileBrowserElements"/> class.
        /// </summary>
        public SaveAsFileBrowserElements()
        {
            this.repository = FileBrowserRepository.Instance;
        }

        #endregion

        #region methods

        /// <summary>
        ///     Gets button Close
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button ButtonClose
        {
            get
            {
                try
                {
                    return this.repository.SaveAsFileBrowser.SaveAs.buttonClose;
                }
                catch (Exception exception)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets button Cancel
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button ButtonCancel
        {
            get
            {
                try
                {
                    return this.repository.SaveAsFileBrowser.SaveAs.buttonCancel;
                }
                catch (Exception exception)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets button Save
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button ButtonSave
        {
            get
            {
                try
                {
                    return this.repository.SaveAsFileBrowser.SaveAs.buttonSave;
                }
                catch (Exception exception)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets Text filename
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text TextFileName
        {
            get
            {
                try
                {
                    return this.repository.SaveAsFileBrowser.SaveAs.textFileName;
                }
                catch (Exception exception)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}