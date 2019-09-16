// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScanningElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ScanningResultElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using System;
    using System.Collections.Generic;
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
        /// Gets the cancel button.
        /// </summary>
        public Button CancelButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.Scanning.ScanningResultCancelButtonInfo;
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
        /// Gets the detail button.
        /// </summary>
        public Button DetailsButton
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo elementInfo = this.repository.Scanning.ScanningResultDetailsButtonInfo;
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

        /// <summary>
        /// Gets the scanning result all rows.
        /// </summary>
        public IList<Row> ScanningResultAllRows
        {
            get
            {
                try
                {
                    IList<Row> rows;
                    RepoItemInfo elementInfo = this.repository.Scanning.ScanningResultAllRowsInfo;
                    rows = Host.Local.Find<Row>(elementInfo.AbsolutePath);
                    return rows;
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