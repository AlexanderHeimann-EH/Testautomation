// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateDTMCatalogueElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 20.02.2012
 * Time: 1:39 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class UpdateDTMCatalogueElements.
    /// </summary>
    public class UpdateDtmCatalogueElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateDtmCatalogueElements"/> class and determines the path of the mdi client
        /// </summary>
        public UpdateDtmCatalogueElements()
        {
            this.repository = Dialogs.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets [Update DTM Catalog]-Dialog.Button.Cancel
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
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.CatalogInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets [Update DTM Catalog]-Dialog. LeftListItems
        /// </summary>
        /// <returns>
        ///     <br>List: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public IList<Row> DevicesOnLeft
        {
            get
            {
                try
                {
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.LeftRowInfo;
                    IList<Row> listDevicesOnLeft = Host.Local.Find<Row>(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                    return listDevicesOnLeft;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///  Gets [Update DTM Catalog]-Dialog. RightListItems
        /// </summary>
        /// <returns>
        ///     <br>List: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public IList<Row> DevicesOnRight
        {
            get
            {
                try
                {
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.RightRowInfo;
                    IList<Row> listDevicesOnRight = Host.Local.Find<Row>(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                    return listDevicesOnRight;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Update DTM Catalog]-Dialog.Button.Help
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
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.HelpInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the in progress dialog.
        /// </summary>
        /// <value>The in progress dialog.</value>
        public Element InProgressDialog
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.InProgressInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Update DTM Catalog]-Dialog.Button.Move
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Move
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.MoveInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Update DTM Catalog]-Dialog.Button.Ok
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
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.OkInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the removed devices dialog.
        /// </summary>
        /// <value>The removed devices dialog.</value>
        public Element RemovedDevicesDialog
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.DeviceRemovedInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the removed devices dialog ok button.
        /// </summary>
        /// <value>The removed devices dialog ok button.</value>
        public Button RemovedDevicesDialogOkButton
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.DeviceRemovedDialogOkButtonInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Update DTM Catalog]-Dialog.Button.Update
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Update
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.UpdateInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Update DTM Catalog]-Dialog Form
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Form UpdateCatalogue
        {
            get
            {
                try
                {
                    Form frmCatalogue;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.CatalogInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out frmCatalogue);
                    return frmCatalogue;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the update DTM catalog dialog.
        /// </summary>
        /// <value>The update DTM catalog dialog.</value>
        public Element UpdateDtmCatalogDialog
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.UpdateDtmCatalog.CatalogInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out element);
                    return element;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        #endregion
    }
}