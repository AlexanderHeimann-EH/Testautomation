// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceValuesElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class ReferenceValuesElements.
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
    /// Class ReferenceValuesElements.
    /// </summary>
    public class ReferenceValuesElements
    {
        #region Fields

        /// <summary>
        /// Repository and mdi client paths
        /// </summary>
        private readonly Controls concentration;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceValuesElements" /> class.
        /// </summary>
        public ReferenceValuesElements()
        {
            this.concentration = Controls.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of the list carrier.
        /// </summary>
        /// <value>The type of the list carrier.</value>
        public List ListCarrierType
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.ReferenceValues.referenceValues.listWaterBasedInfo;
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
        /// Gets the list item carrier type yes.
        /// </summary>
        /// <value>The list item carrier type yes.</value>
        public ListItem ListItemCarrierTypeYes
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.ReferenceValues.referenceValues.listItemWaterBasedYesInfo;
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
        /// Gets the list item carrier type no.
        /// </summary>
        /// <value>The list item carrier type no.</value>
        public ListItem ListItemCarrierTypeNo
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.ReferenceValues.referenceValues.listItemWaterBasedNoInfo;
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
        /// Gets the edit field linear expansion coefficient carrier.
        /// </summary>
        /// <value>The edit field linear expansion coefficient carrier.</value>
        public Element EditFieldLinearExpansionCoefficientCarrier
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo info = this.concentration.ReferenceValues.calculated.editFieldLinearExpansionCoefficientCarrierInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + info.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field linear expansion coefficient target.
        /// </summary>
        /// <value>The edit field linear expansion coefficient target.</value>
        public Element EditFieldLinearExpansionCoefficientTarget
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo info = this.concentration.ReferenceValues.groupControl.editFieldLinearExpansionCoefficientTargetInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + info.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field sugar expansion coefficient carrier.
        /// </summary>
        /// <value>The edit field sugar expansion coefficient carrier.</value>
        public Element EditFieldSugarExpansionCoefficientCarrier
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo info = this.concentration.ReferenceValues.calculated.editFieldSquareExpansionCoefficientCarrierInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + info.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field sugar expansion coefficient target.
        /// </summary>
        /// <value>The edit field sugar expansion coefficient target.</value>
        public Element EditFieldSugarExpansionCoefficientTarget
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo info = this.concentration.ReferenceValues.groupControl.editFieldSquareExpansionCoefficientTargetInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + info.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
                    RepoItemInfo info = this.concentration.ReferenceValues.referenceValues.editFieldReferenceTemperatureInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + info.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field reference density carrier fluid.
        /// </summary>
        /// <value>The edit field reference density carrier fluid.</value>
        public Element EditFieldReferenceDensityCarrierFluid
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo info = this.concentration.ReferenceValues.calculated.editFieldReferenceDensityCarrierFluidInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + info.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field reference density target fluid.
        /// </summary>
        /// <value>The edit field reference density target fluid.</value>
        public Element EditFieldReferenceDensityTargetFluid
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo info = this.concentration.ReferenceValues.groupControl.editFieldReferenceDensityTargetFluidInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + info.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox density unit.
        /// </summary>
        /// <value>The ComboBox density unit.</value>
        public Element ComboBoxDensityUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo info = this.concentration.ReferenceValues.referenceValues.comboBoxDensityUnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + info.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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