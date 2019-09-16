﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScanningElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class ScanningResultElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V20901.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class ScanningResultElements.
    /// </summary>
    public class ScanningElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScanningElements"/> class. 
        /// Initializes a new instance of the <see cref="DtmMessagesElements"/> class and determines the path of the mdi client
        /// </summary>
        public ScanningElements()
        {
            this.repository = Dialogs.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the scanning result dialog.
        /// </summary>
        /// <value>The scanning result dialog.</value>
        public Element ScanningResultDialog
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.Scanning.ScanningResultDialogInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out element);
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
        /// Gets the ok button from the scanning result dialog.
        /// </summary>
        /// <value>The ok button.</value>
        public Button OkButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.Scanning.ScanningResultOkButtonInfo;
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
        /// Gets the scanning in progress dialog.
        /// </summary>
        /// <value>The scanning in progress dialog.</value>
        public Element ScanningInProgressDialog
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.Scanning.ScanningInProgressDialogInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, out element);
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