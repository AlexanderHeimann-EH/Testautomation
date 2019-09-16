//------------------------------------------------------------------------------
// <copyright file="UpdateProcessMessageElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.02.2012
 * Time: 12:50 
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21000.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of UpdateProcessMessageElements.
    /// </summary>
    public class UpdateProcessMessageElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateProcessMessageElements"/> class and determines the path of the mdi client
        /// </summary>
        public UpdateProcessMessageElements()
        {
            this.repository = Dialogs.Instance;
        }
        
        /// <summary>
        ///     Gets [Update Process]-MessageBox.Button.Cancel
        /// </summary>
        /// <returns>
        ///     <br>Button: If available</br>
        ///     <br>NULL: If not available</br>
        /// </returns>
        public Button Cancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.UpdateProcessMessage.CancelInfo;
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