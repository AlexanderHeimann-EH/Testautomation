// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSettingsElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.GUI.ApplicationArea.MainView
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to tab settings controls within module concentration
    /// </summary>
    public class BaseSettingsElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client paths
        /// </summary>
        private readonly Controls concentration;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSettingsElements"/> class.
        /// </summary>
        public BaseSettingsElements()
        {
            this.concentration = Controls.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the combo box calculation base.
        /// </summary>
        public Element ComboBoxCalculationBase
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoCalculationBase = this.concentration.BaseSettings.comboBoxCalculationBaseInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoCalculationBase.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box concentration unit.
        /// </summary>
        public Element ComboBoxConcentrationUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoConcentrationUnit = this.concentration.BaseSettings.OperatingRange.comboBoxConcentrationUnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoConcentrationUnit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box density calibration.
        /// </summary>
        public Element ComboBoxDensityCalibration
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoDensitiyCalibration = this.concentration.BaseSettings.comboBoxDensityCalibrationInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoDensitiyCalibration.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box liquid type.
        /// </summary>
        public Element ComboBoxLiquidType
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.BaseSettings.comboBoxLiquidTypeInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoLiquidType.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box sensor.
        /// </summary>
        public Element ComboBoxSensor
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoSensor = this.concentration.BaseSettings.comboBoxSensorInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoSensor.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box temperature unit.
        /// </summary>
        public Element ComboBoxTemperatureUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTemperatureUnit = this.concentration.BaseSettings.OperatingRange.comboBoxTemperatureUnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTemperatureUnit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the radio button field density adjustment. 
        /// </summary>
        public Element RadioButtonFieldDensityAdjustment
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoDensityAdjustment = this.concentration.BaseSettings.FieldDensity.radioButtonFieldDensityAdjustmentInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoDensityAdjustment.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text concentration max.
        /// </summary>
        public Element TextConcentrationMax
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoConcentrationMax = this.concentration.BaseSettings.OperatingRange.textConcentrationMaxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoConcentrationMax.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text concentration min.
        /// </summary>
        public Element TextConcentrationMin
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoConcentrationMin = this.concentration.BaseSettings.OperatingRange.textConcentrationMinInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoConcentrationMin.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text temperature max.
        /// </summary>
        public Element TextTemperatureMax
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTemperatureMax = this.concentration.BaseSettings.OperatingRange.textTemperatureMaxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTemperatureMax.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text temperature min.
        /// </summary>
        public Element TextTemperatureMin
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTemperatureMin = this.concentration.BaseSettings.OperatingRange.textTemperatureMinInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTemperatureMin.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets edit field 'Average Process Pressure'.
        /// </summary>
        public Element EditFieldAverageProcessPressure
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.concentration.BaseSettings.EditfieldAverageProcessPressureInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets combo box 'Average Process Pressure Unit'
        /// </summary>
        public Element ComboBoxAverageProcessPressureUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.concentration.BaseSettings.ComboBoxAverageProcessPressureUnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + elementInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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