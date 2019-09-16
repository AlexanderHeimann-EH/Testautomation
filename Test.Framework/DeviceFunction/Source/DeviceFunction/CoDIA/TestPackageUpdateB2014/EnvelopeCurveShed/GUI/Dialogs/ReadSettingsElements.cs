//------------------------------------------------------------------------------
// <copyright file="ReadSettingsElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurveShed.GUI.Dialogs
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
    public class ReadSettingsElements
    {
        #region members

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ReadSettingsElementsRepository repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadSettingsElements"/> class.
        /// </summary>
        public ReadSettingsElements()
        {
            this.repository = ReadSettingsElementsRepository.Instance;
        }

        #endregion

        /// <summary>
        ///     Gets [Read Settings]-Dialog.Button.ReadNow-object
        ///     Start reading all curves
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button ReadNow
        {
            get
            {
                try
                {
                    Button button;
                    RepoItemInfo readNowInfo = this.repository.buttonReadNowInfo;
                    Host.Local.TryFindSingle(readNowInfo.AbsolutePath, DefaultValues.iTimeoutLong, out button);
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
        ///     Gets [Open]-Dialog.Button.Open-object
        ///     It is needed to confirm selection and close dialog
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Slider Resolution
        {
            get
            {
                try
                {
                    Slider slider;
                    RepoItemInfo resolutionInfo = this.repository.sliderResolutionInfo;
                    Host.Local.TryFindSingle(resolutionInfo.AbsolutePath, DefaultValues.iTimeoutLong, out slider);
                    return slider;
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
        public Text BeginRangeUnit
        {
            get
            {
                try
                {
                    Text beginRangeUnit;
                    RepoItemInfo textBeginRangeUnitInfo = this.repository.textBeginRangeUnitInfo;
                    Host.Local.TryFindSingle(
                        textBeginRangeUnitInfo.AbsolutePath, DefaultValues.iTimeoutLong, out beginRangeUnit);
                    return beginRangeUnit;
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
        public Text EndRangeUnit
        {
            get
            {
                try
                {
                    Text endRangeUnit;
                    RepoItemInfo endRangeUnitInfo = this.repository.textEndRangeUnitInfo;
                    Host.Local.TryFindSingle(endRangeUnitInfo.AbsolutePath, DefaultValues.iTimeoutLong, out endRangeUnit);
                    return endRangeUnit;
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
        public Text BeginRangeText
        {
            get
            {
                try
                {
                    Text beginRange;
                    RepoItemInfo beginRangeTextInfo = this.repository.textBeginRangeInfo;
                    Host.Local.TryFindSingle(beginRangeTextInfo.AbsolutePath, DefaultValues.iTimeoutLong, out beginRange);
                    return beginRange;
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
        public Text EndRangeText
        {
            get
            {
                try
                {
                    Text endRage;
                    RepoItemInfo endRangeTextInfo = this.repository.textEndRangeInfo;
                    Host.Local.TryFindSingle(endRangeTextInfo.AbsolutePath, DefaultValues.iTimeoutLong, out endRage);
                    return endRage;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Open]-Dialog.Button.Open-object
        ///     It is needed to confirm selection and close dialog
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
// ReSharper disable UnusedMember.Global
        public Container Curves
// ReSharper restore UnusedMember.Global
        {
            get
            {
                try
                {
                    Container container;
                    RepoItemInfo containerInfo = this.repository.ContainerCurvesInfo;
                    Host.Local.TryFindSingle(containerInfo.AbsolutePath, DefaultValues.iTimeoutLong, out container);
                    return container;
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