//------------------------------------------------------------------------------
// <copyright file="ZoomAndGridSettingsElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.GUI.Dialogs
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of ReadSettingsElements.
    /// </summary>
    public class ZoomAndGridSettingsElements
    {
        #region members

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ZoomAndGridSettingsElementsRepository repository;

        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomAndGridSettingsElements"/> class.
        /// </summary>
        public ZoomAndGridSettingsElements()
        {
            this.repository = ZoomAndGridSettingsElementsRepository.Instance;
        }

        #endregion

        /// <summary>
        ///     Gets [Read Settings]-Dialog.Button.Ok-object
        ///     Confirm selected curves, reading range and resolution
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Ok
        {
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo okInfo = this.repository.buttonOKInfo;
                    Host.Local.TryFindSingle(okInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///     Gets [Read Settings]-Dialog.Button.Cancel-object
        ///     Cancel selected curves, reading range and resolution
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
                    Button button;
                    RepoItemInfo cancelInfo = this.repository.buttonCancelInfo;
                    Host.Local.TryFindSingle(cancelInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///     Gets [Read Settings]-Dialog.Button.Close-object
        ///     Close dialog
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Close
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo closeInfo = this.repository.buttonCloseInfo;
                    Host.Local.TryFindSingle(closeInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///     Gets Text.Open-object
        ///     It is needed to get/set the range value
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text ZoomAreaXMaxText
        {
            get
            {
                try
                {
                    Text zoomAreaXMaxText;
                    RepoItemInfo textInfo = this.repository.txtZoomAreaXMaxInfo;
                    Host.Local.TryFindSingle(textInfo.AbsolutePath, DefaultValues.iTimeoutLong, out zoomAreaXMaxText);
                    return zoomAreaXMaxText;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets Text.Open-object
        ///     It is needed to get/set the range value
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text ZoomAreaXMaxUnit
        {
            get
            {
                try
                {
                    Text zoomAreaXMaxUnit;
                    RepoItemInfo textInfo = this.repository.txtZoomAreaXMaxUnitInfo;
                    Host.Local.TryFindSingle(textInfo.AbsolutePath, DefaultValues.iTimeoutLong, out zoomAreaXMaxUnit);
                    return zoomAreaXMaxUnit;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets Text.Open-object
        ///     It is needed to get/set the range value
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text ZoomAreaXMinText
        {
            get
            {
                try
                {
                    Text zoomAreaXMinText;
                    RepoItemInfo textInfo = this.repository.txtZoomAreaXMinInfo;
                    Host.Local.TryFindSingle(textInfo.AbsolutePath, DefaultValues.iTimeoutLong, out zoomAreaXMinText);
                    return zoomAreaXMinText;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets Text.Open-object
        ///     It is needed to get/set the range value
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Text ZoomAreaXMinUnit
        {
            get
            {
                try
                {
                    Text zoomAreaXMinUnit;
                    RepoItemInfo textInfo = this.repository.txtZoomAreaXMinUnitInfo;
                    Host.Local.TryFindSingle(textInfo.AbsolutePath, DefaultValues.iTimeoutLong, out zoomAreaXMinUnit);
                    return zoomAreaXMinUnit;
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