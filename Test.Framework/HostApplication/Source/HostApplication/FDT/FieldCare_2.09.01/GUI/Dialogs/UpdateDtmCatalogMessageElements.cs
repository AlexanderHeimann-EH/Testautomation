//------------------------------------------------------------------------------
// <copyright file="UpdateDTMCatalogMessageElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 20.02.2012
 * Time: 9:07 
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
    ///     Description of UpdateDTMCatalog.
    /// </summary>
    public class UpdateDtmCatalogMessageElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateDtmCatalogMessageElements"/> class and determines the path of the mdi client
        /// </summary>
        public UpdateDtmCatalogMessageElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        ///     Gets [Update DTM catalog]-MessageBox.Button.Help
        /// </summary>
        /// <returns>
        ///     <br>Button: If available</br>
        ///     <br>NULL: If not available</br>
        /// </returns>
        public Button Help
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalogMessage.HelpInfo;
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
        ///     Gets [Update DTM catalog]-MessageBox.Button.Update
        /// </summary>
        /// <returns>
        ///     <br>Button: If available</br>
        ///     <br>NULL: If not available</br>
        /// </returns>
        public Button Update
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalogMessage.UpdateInfo;
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
        ///     Gets [Update DTM catalog]-MessageBox.Button.Ignore
        /// </summary>
        /// <returns>
        ///     <br>Button: If available</br>
        ///     <br>NULL: If not available</br>
        /// </returns>
        public Button Ignore
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalogMessage.IgnoreInfo;
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