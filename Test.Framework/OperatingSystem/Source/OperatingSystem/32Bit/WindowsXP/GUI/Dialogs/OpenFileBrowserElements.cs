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

namespace EH.PCPS.TestAutomation.WindowsXP.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Provides access ot the elements of "Open" filebrowser dialog
    /// </summary>
    public class OpenFileBrowserElements
    {
        #region members

        //repository
        private readonly FileBrowserRepository repository;

        #endregion

        #region constructor

        /// <summary>
        ///     Creates an instance of FileBrowserRepository which will be used
        /// </summary>
        public OpenFileBrowserElements()
        {
            this.repository = FileBrowserRepository.Instance;
        }

        #endregion

        #region methods

        /// <summary>
        ///     Get button Close
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
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Get button Open
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
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Get button Cancel
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
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Get text Filename
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
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}