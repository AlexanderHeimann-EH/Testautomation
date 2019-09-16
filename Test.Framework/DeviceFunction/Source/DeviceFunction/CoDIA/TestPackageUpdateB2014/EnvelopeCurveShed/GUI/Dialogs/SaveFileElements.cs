//------------------------------------------------------------------------------
// <copyright file="SaveFileElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurveShed.GUI.Dialogs
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     This class contains elements of message box [Save Project]
    /// </summary>
    public class SaveFileElements
    {
        #region members

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly SaveFileElementsRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileElements"/> class.
        /// </summary>
        public SaveFileElements()
        {
            this.repository = SaveFileElementsRepository.Instance;
        }

        #endregion

        /// <summary>
        ///     Gets [Save File]-MessageBox.Button.Yes
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
        ///     Gets [Save File]-MessageBox.Button.No
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
    }
}