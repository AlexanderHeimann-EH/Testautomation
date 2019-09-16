// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpertResultsElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides access to tab expert results within module concentration
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.ApplicationArea.MainView
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
    ///     Provides access to tab expert results within module concentration
    /// </summary>
    public class ExpertResultsElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client path
        /// </summary>
        private readonly Controls concentration;

        /// <summary>
        ///  MDI client path
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpertResultsElements"/> class.
        /// </summary>
        public ExpertResultsElements()
        {
            this.concentration = Controls.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the ComboBox density calibration
        /// </summary>
        /// <value>The ComboBox density calibration.</value>
        public Element ComboBoxDensityCalibration
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoComboboxDiagram = this.concentration.ExpertResults.SensorCalibration.comboBoxDensityCalibrationInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoComboboxDiagram.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box diagram. 
        /// </summary>
        public Element ComboBoxDiagram
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoComboboxDiagram = this.concentration.ExpertResults.comboboxDiagramSelectionInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoComboboxDiagram.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox sensor.
        /// </summary>
        /// <value>The ComboBox sensor.</value>
        public Element ComboBoxSensor
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoComboboxDiagram = this.concentration.ExpertResults.SensorCalibration.comboBoxSensorInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoComboboxDiagram.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the image diagram.
        /// </summary>
        public Element ImageDiagram
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoImageDiagram = this.concentration.ExpertResults.imageDiagramInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoImageDiagram.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the list field density adjustment.
        /// </summary>
        /// <value>The list field density adjustment.</value>
        public List ListFieldDensityAdjustment
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.ExpertResults.SensorCalibration.FieldDensityAdjustment.listInfo;
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
        /// Gets the list item field density no.
        /// </summary>
        /// <value>The list item field density no.</value>
        public ListItem ListItemFieldDensityNo
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.ExpertResults.SensorCalibration.FieldDensityAdjustment.listItemNoInfo;
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
        /// Gets the list item field density yes.
        /// </summary>
        /// <value>The list item field density yes.</value>
        public ListItem ListItemFieldDensityYes
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoLiquidType = this.concentration.ExpertResults.SensorCalibration.FieldDensityAdjustment.listItemYesInfo;
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
    }
}