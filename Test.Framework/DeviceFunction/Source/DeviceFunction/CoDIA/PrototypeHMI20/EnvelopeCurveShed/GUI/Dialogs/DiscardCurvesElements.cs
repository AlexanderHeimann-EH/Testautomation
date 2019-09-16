// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscardCurvesElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurveShed.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     This class contains elements of message box [Discard Curves]
    /// </summary>
    public class DiscardCurvesElements
    {
        #region Fields

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly DiscardCurvesElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscardCurvesElements"/> class.
        /// </summary>
        public DiscardCurvesElements()
        {
            this.repository = DiscardCurvesElementsRepository.Instance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets [Discard Curves]-MessageBox.Button.No
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
                    if (Host.Local.TryFindSingle(btnCancelInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button))
                    {
                        return button;
                    }

                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cancel button not available. No problem if 'Discard Curves dialog' is no shown.");
                    return null;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Discard Curves]-MessageBox.Button.Ok
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button BtnOk
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo btnOkInfo = this.repository.buttonOKInfo;
                    if (Host.Local.TryFindSingle(btnOkInfo.AbsolutePath, DefaultValues.iTimeoutShort, out button))
                    {
                        return button;
                    }

                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Ok button not available. No problem if 'Discard Curves dialog' is no shown.");
                    return null;
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