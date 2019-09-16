// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveProjectProgressElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class SaveProjectProgressElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V21100.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class SaveProjectProgressElements.
    /// </summary>
    public class SaveProjectProgressElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveProjectProgressElements"/> class.
        /// </summary>
        public SaveProjectProgressElements()
        {
            this.repository = Dialogs.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the saving in progress dialog.
        /// </summary>
        /// <value>The saving in progress dialog.</value>
        public Element SavingInProgressDialog
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.SaveProjectProgress.savingInProgressDialogInfo;
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