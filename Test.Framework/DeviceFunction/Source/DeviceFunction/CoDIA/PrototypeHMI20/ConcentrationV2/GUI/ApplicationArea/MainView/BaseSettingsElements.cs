// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseSettingsElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides access to tab settings controls within module concentration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView
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

        #region Public Base Configuration

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
                    RepoItemInfo infoCalculationBase = this.concentration.BaseSettings.BaseConfiguration.comboBoxCalculationBaseInfo;
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
        /// Gets the combo box liquid type.
        /// </summary>
        public Element ComboBoxLiquidType
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.BaseSettings.BaseConfiguration.comboBoxLiquidTypeInfo;
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
        /// Gets the ComboBox user profile.
        /// </summary>
        /// <value>The ComboBox user profile.</value>
        public Element ComboBoxUserProfile
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.BaseSettings.BaseConfiguration.comboBoxUserProfileInfo;
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
        /// Gets the edit field reference temperature.
        /// </summary>
        /// <value>The edit field reference temperature.</value>
        public Element EditFieldReferenceTemperature
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.BaseSettings.BaseConfiguration.editFieldReferenceTemperatureInfo;
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
        /// Gets the content of the edit field mineral.
        /// </summary>
        /// <value>The content of the edit field mineral.</value>
        public Element EditFieldMineralContent
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.BaseSettings.BaseConfiguration.editFieldMinearlContentInfo;
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
        #endregion

        #region Average Pressure

        /// <summary>
        /// Gets the edit field average process pressure.
        /// </summary>
        /// <value>The edit field average process pressure.</value>
        public Element EditFieldAverageProcessPressure
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.BaseSettings.AveragePressure.editFieldAverageProcessPressureInfo;
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
        /// Gets the ComboBox average process pressure unit.
        /// </summary>
        /// <value>The ComboBox average process pressure unit.</value>
        public Element ComboBoxAverageProcessPressureUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.BaseSettings.AveragePressure.comboBoxPressureUnitInfo;
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

        #endregion

        #region Operating Range
        
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
                    RepoItemInfo infoConcentrationUnit = this.concentration.BaseSettings.ProcessConditions.comboBoxConcentrationUnitInfo;
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
        /// Gets the combo box temperature unit.
        /// </summary>
        public Element ComboBoxTemperatureUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTemperatureUnit = this.concentration.BaseSettings.ProcessConditions.comboBoxTemperatureUnitInfo;
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
        /// Gets the text concentration max.
        /// </summary>
        public Element TextConcentrationMax
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoConcentrationMax = this.concentration.BaseSettings.ProcessConditions.editFieldConcentrationMaxInfo;
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
                    RepoItemInfo infoConcentrationMin = this.concentration.BaseSettings.ProcessConditions.editFieldConcentrationMinInfo;
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
                    RepoItemInfo infoTemperatureMax = this.concentration.BaseSettings.ProcessConditions.editFieldTemperatureMaxInfo;
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
                    RepoItemInfo infoTemperatureMin = this.concentration.BaseSettings.ProcessConditions.editFieldTemperatureMinInfo;
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

        #endregion
    }
}