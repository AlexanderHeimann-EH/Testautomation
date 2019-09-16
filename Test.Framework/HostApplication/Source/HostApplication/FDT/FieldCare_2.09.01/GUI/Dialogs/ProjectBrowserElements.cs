//------------------------------------------------------------------------------
// <copyright file="ProjectBrowserElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 11.03.2011
 * Time: 6:44 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     This class describes [Project Browser] in an abstract way.
    ///     Elements could be accessed for using.
    /// </summary>
    public class ProjectBrowserElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectBrowserElements"/> class and determines the path of the mdi client
        /// </summary>
        public ProjectBrowserElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        ///     Gets [ProjectBrowser]-Dialog.Button.Open-object
        ///     It is needed to open a selected item / project
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
                    RepoItemInfo elementInfo = this.repository.ProjectBrowser.OpenInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [ProjectBrowser]-Dialog.Button.Save-object
        ///     It is needed to save a project
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
                    RepoItemInfo elementInfo = this.repository.ProjectBrowser.SaveInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [ProjectBrowser]-Dialog.Button.Cancel-object
        ///     It is needed to discard selection and close dialog
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
                    RepoItemInfo elementInfo = this.repository.ProjectBrowser.CancelInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [ProjectBrowser]-Dialog.Button.Help-object
        ///     It is needed to open help
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Help
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.ProjectBrowser.HelpInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button);
                    return button;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [ProjectBrowser]-Dialog.ListItem.EmptyProject
        ///     It is needed to select the empty project template
        /// </summary>
        /// <returns>
        ///     <br>ListItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public ListItem EmptyProject
        {
            get
            {
                try
                {
                    ListItem listItem;
                    RepoItemInfo elementInfo = this.repository.ProjectBrowser.EmptyInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out listItem);
                    return listItem;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [ProjectBrowser]-Dialog.Text
        /// </summary>
        /// <returns>
        ///     <br>Text: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text ProjectName
        {
            get
            {
                try
                {
                    Text text;
                    RepoItemInfo elementInfo = this.repository.ProjectBrowser.TextInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out text);
                    return text;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets [ProjectBrowser]-Dialog.ListItem
        /// It is needed to select specific object
        /// </summary>
        /// <param name="project">
        /// Specific Project
        /// </param>
        /// <returns>
        /// <br>ListItem: If call worked fine</br>
        /// <br>NULL: If an error occurred</br>
        /// </returns>
        public ListItem SpecificElement(string project)
        {
            try
            {
                List list;
                RepoItemInfo elementInfo = this.repository.ProjectBrowser.ListInfo;
                if (Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out list))
                {
                    foreach (Element item in list.Children)
                    {
                        ListItem listItemCache = item;
                        if (listItemCache.Text == project)
                        {
                            return listItemCache;
                        }       
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ProjectBrowserElement not found");
                    return null;
                }

                return null;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        /// <summary>
        ///     Gets [ProjectBrowser]-Dialog.AvailableProject
        /// </summary>
        /// <param name="strProjectName">Name of project to access</param>
        /// <returns>
        ///     <br>ListItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public ListItem AvailableProject(string strProjectName)
        {
            try
            {
                ListItem listItem;
                RepoItemInfo elementInfo = this.repository.ProjectBrowser.NameInfo;
                if (Host.Local.TryFindSingle(elementInfo.AbsolutePath + "[@text~'" + strProjectName + "']", DefaultValues.iTimeoutShort, out listItem))
                {
                    return listItem;
                }

                return null;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}