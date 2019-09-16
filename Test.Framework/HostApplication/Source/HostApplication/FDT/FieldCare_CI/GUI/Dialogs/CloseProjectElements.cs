// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseProjectElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CloseProjectElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class CloseProjectElements.
    /// </summary>
    public class CloseProjectElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloseProjectElements"/> class.
        /// </summary>
        public CloseProjectElements()
        {
            this.repository = Dialogs.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the closing in progress dialog.
        /// </summary>
        /// <value>The closing in progress dialog.</value>
        public Element ClosingInProgressDialog
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.CloseProject.ClosingInProgressDialogInfo;
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