//------------------------------------------------------------------------------
// <copyright file="OpenFileBrowserElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 29.02.2012
 * Time: 13:33 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Windows10.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     Provides access to the elements of "Open" file browser dialog
    /// </summary>
    public class OpenFileBrowserElements
    {
        #region members

        /// <summary>
        /// The repository
        /// </summary>
        private readonly FileBrowserRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileBrowserElements"/> class. 
        /// </summary>
        public OpenFileBrowserElements()
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
        public Button buttonClose
        {
            get
            {
                try
                {
                    return this.repository.OpenFileBrowser.Open.buttonClose;
                }
                catch (Exception exception)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets button Open
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button buttonOpen
        {
            get
            {
                try
                {
                    return this.repository.OpenFileBrowser.Open.buttonOpen;
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
        public Button buttonCancel
        {
            get
            {
                try
                {
                    return this.repository.OpenFileBrowser.Open.buttonCancel;
                }
                catch (Exception exception)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets text Filename
        /// </summary>
        /// <returns>
        ///     <br>Text: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text textFileName
        {
            get
            {
                try
                {
                    return this.repository.OpenFileBrowser.Open.textFileName;
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