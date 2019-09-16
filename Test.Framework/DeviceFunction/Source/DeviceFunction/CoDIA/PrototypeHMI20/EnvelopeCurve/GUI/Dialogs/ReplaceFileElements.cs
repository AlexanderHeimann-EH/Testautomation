//------------------------------------------------------------------------------
// <copyright file="ReplaceFileElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     This class contains elements of message box [Replace File]
    /// </summary>
    public class ReplaceFileElements
    {
        #region members

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ReplaceFileElementsRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ReplaceFileElements"/> class.
        /// </summary>
        public ReplaceFileElements()
        {
            this.repository = ReplaceFileElementsRepository.Instance;
        }

        #endregion

        /// <summary>
        ///     Gets [Replace File]-MessageBox.Button.Yes
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button BtnYes
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnYesInfo = this.repository.buttonYesInfo;
                    return Host.Local.TryFindSingle(btnYesInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button) ? button : null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Replace File]-MessageBox.Button.No
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button BtnNo
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnNoInfo = this.repository.buttonNoInfo;
                    return Host.Local.TryFindSingle(btnNoInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button) ? button : null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Replace File]-MessageBox.Button.Cancel
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button BtnCancel
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnCancelInfo = this.repository.buttonCancelInfo;
                    return Host.Local.TryFindSingle(btnCancelInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button) ? button : null;
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