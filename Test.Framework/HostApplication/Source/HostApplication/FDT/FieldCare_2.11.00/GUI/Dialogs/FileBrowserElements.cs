//------------------------------------------------------------------------------
// <copyright file="FileBrowserElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 18.04.2012
 * Time: 13:33 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of FileBrowserElements.
    /// </summary>
    public class FileBrowserElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileBrowserElements"/> class and determines the path of the mdi client
        /// </summary>
        public FileBrowserElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        ///     Gets button Save
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Save
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.FileBrowser.SaveInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
        public Button Open
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.FileBrowser.OpenInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
        public Button Cancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.FileBrowser.CancelInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
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
        public Text Filename
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.repository.FileBrowser.FilenameInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out text);
                    return text;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
    }
}