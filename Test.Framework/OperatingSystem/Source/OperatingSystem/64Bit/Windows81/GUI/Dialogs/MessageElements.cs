// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageElements.cs" company="Endress+Hauser Process Solutions AG">
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
 * Time: 12:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.Windows81.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;

    /// <summary>
    ///     Provides access to the message elements
    /// </summary>
    public class MessageElements
    {
        #region members

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly Messages repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageElements"/> class.
        /// </summary>
        public MessageElements()
        {
            this.repository = Messages.Instance;
        }

        #endregion

        #region Open dialog

        /// <summary>
        ///     Gets button OK
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button buttonOk
        {
            get
            {
                try
                {
                    return this.repository.OpenMessages.Open.buttonOK;
                }
                catch (Exception exception)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message + " No problem if file to open existed");
                    return null;
                }
            }
        }

        #endregion

        #region Save as dialog

        /// <summary>
        ///     Gets button confirm save as "Yes"
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button buttonYes
        {
            get
            {
                try
                {
                    return this.repository.SaveAsMessages.ConfirmSaveAs.buttonYes;
                }
                catch (Exception exception)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message + " No problem if file to save didn't already exist");
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets button confirm save as "No"
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button buttonNo
        {
            get
            {
                try
                {
                    return this.repository.SaveAsMessages.ConfirmSaveAs.buttonNo;
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