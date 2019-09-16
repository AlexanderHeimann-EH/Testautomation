//------------------------------------------------------------------------------
// <copyright file="ConfirmDeleteMessageElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 15.03.2011
 * Time: 12:50 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of ConfirmDelete.
    /// </summary>
    public class ConfirmDeleteMessageElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmDeleteMessageElements"/> class and determines the path of the mdi client
        /// </summary>
        public ConfirmDeleteMessageElements()
        {
            this.repository = Dialogs.Instance;
        }
        
        /// <summary>
        ///     Gets [Confirm Delete]-MessageBox.Button.Yes
        /// </summary>
        /// <returns>
        ///     <br>Button: If available</br>
        ///     <br>NULL: If not available</br>
        /// </returns>
        public Button Yes
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.ConfirmDeleteMessage.YesInfo;
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
        ///     Gets [Confirm Delete]-MessageBox.Button.No
        /// </summary>
        /// <returns>
        ///     <br>Button: If available</br>
        ///     <br>NULL: If not available</br>
        /// </returns>
        public Button No
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.ConfirmDeleteMessage.NoInfo;
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
    }
}