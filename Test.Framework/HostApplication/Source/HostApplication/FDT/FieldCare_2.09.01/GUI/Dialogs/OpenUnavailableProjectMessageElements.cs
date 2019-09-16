//------------------------------------------------------------------------------
// <copyright file="OpenUnavailableProjectMessageElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 30.04.2011
 * Time: 7:52 
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
    using Ranorex.Core.Repository;

    /// <summary>
    ///     This class contains elements of message box [Open Unavailable Project]
    /// </summary>
    public class OpenUnavailableProjectMessageElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenUnavailableProjectMessageElements"/> class and determines the path of the mdi client
        /// </summary>
        public OpenUnavailableProjectMessageElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        ///     Gets [Open Unavailable Project]-MessageBox.Button.Ok
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Ok
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.OpenUnavailableProjectMessage.OkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
    }
}