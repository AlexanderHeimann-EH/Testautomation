// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LiquidPropertiesElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.ConcentrationV2.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Provides access to tab liquid properties within module concentration
    /// </summary>
    public class LiquidPropertiesElements
    {
        #region Fields

        /// <summary>
        ///     Repository and mdi client path
        /// </summary>
        private readonly Controls concentration;

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LiquidPropertiesElements"/> class.
        /// </summary>
        public LiquidPropertiesElements()
        {
            this.concentration = Controls.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the combo box input format. 
        /// </summary>
        public Element ComboBoxInputFormat
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoInputFormat = this.concentration.LiquidProperties.comboBoxInputFormatInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoInputFormat.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the element for button recalculate.
        /// </summary>
        public Element ButtonRecalculate
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo repoItemInfo = this.concentration.LiquidProperties.buttonRecalculateInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + repoItemInfo.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box Spreadsheet.
        /// </summary>
        public Element ComboBoxSpreadsheet
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoSpreadsheet = this.concentration.LiquidProperties.comboBoxSpreadsheetInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoSpreadsheet.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box row 1.
        /// </summary>
        public Element ComboBoxRow1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue1 = this.concentration.LiquidProperties.DefineLiquidProperties.comboBoxRow1Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue1.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox data unit.
        /// </summary>
        /// <value>The ComboBox data unit.</value>
        public Element ComboBoxDataUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue1 = this.concentration.LiquidProperties.DefineLiquidProperties.comboBoxDensityUnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue1.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox column1.
        /// </summary>
        /// <value>The ComboBox column1.</value>
        public Element ComboBoxColumn1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue1 = this.concentration.LiquidProperties.DefineLiquidProperties.comboBoxColumn1Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue1.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox data.
        /// </summary>
        /// <value>The ComboBox data.</value>
        public Element ComboBoxData
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2 = this.concentration.LiquidProperties.DefineLiquidProperties.comboBoxDensityInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box value 2 unit.
        /// </summary>
        public Element ComboBoxRow1Unit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.DefineLiquidProperties.comboBoxRow1UnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox column1 unit.
        /// </summary>
        /// <value>The ComboBox column1 unit.</value>
        public Element ComboBoxColumn1Unit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.DefineLiquidProperties.comboBoxColumn1UnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox fine tuning column1 unit.
        /// </summary>
        /// <value>The ComboBox fine tuning column1 unit.</value>
        public Element ComboBoxFineTuningColumn1Unit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.FineTuning.column1UnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox fine tuning column2 unit.
        /// </summary>
        /// <value>The ComboBox fine tuning column2 unit.</value>
        public Element ComboBoxFineTuningColumn2Unit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.FineTuning.column2UnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the ComboBox fine tuning column3 unit.
        /// </summary>
        /// <value>The ComboBox fine tuning column3 unit.</value>
        public Element ComboBoxFineTuningColumn3Unit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.FineTuning.column3UnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field row1 minimum value.
        /// </summary>
        /// <value>The edit field row1 minimum value.</value>
        public Element EditFieldRow1MinimumValue
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.DefineLiquidProperties.editFieldRow1MinInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field row1 maximum value.
        /// </summary>
        /// <value>The edit field row1 maximum value.</value>
        public Element EditFieldRow1MaximumValue
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.DefineLiquidProperties.editFieldRow1MaxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field column1 minimum value.
        /// </summary>
        /// <value>The edit field column1 minimum value.</value>
        public Element EditFieldColumn1MinimumValue
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.DefineLiquidProperties.editFieldColumn1MinInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field column1 maximum value.
        /// </summary>
        /// <value>The edit field column1 maximum value.</value>
        public Element EditFieldColumn1MaximumValue
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.DefineLiquidProperties.editFieldColumn1MaxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field data minimum value.
        /// </summary>
        /// <value>The edit field data minimum value.</value>
        public Element EditFieldDataMinimumValue
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.DefineLiquidProperties.editFieldDataMinInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the edit field data maximum value.
        /// </summary>
        /// <value>The edit field data maximum value.</value>
        public Element EditFieldDataMaximumValue
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.DefineLiquidProperties.editFieldDataMaxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the table grid control.
        /// </summary>
        public Element TableGridControl
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoTableGridControl = this.concentration.LiquidProperties.elementTableGridControlInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoTableGridControl.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the table cells.
        /// </summary>
        /// <value>The table cells.</value>
        public IList<Cell> TableCells
        {
            get
            {
                try
                {
                    RepoItemInfo itemInfo = this.concentration.LiquidProperties.CellInfo;
                    IList<Cell> list = Host.Local.Find<Cell>(this.mdiClientPath + itemInfo.AbsolutePath, DefaultValues.iTimeoutModules);

                    return list;
                }
                catch (Exception exception)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to create list with table cells. " + exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// The table cell.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="Cell"/>.
        /// </returns>
        public Element TableCell(int row, int column)
        {
            try
            {
                RepoItemInfo itemInfo = this.concentration.LiquidProperties.SingleCellInfo;
                string modifiedPath = itemInfo.AbsolutePath.ToString();
                modifiedPath = modifiedPath.Replace("REPLACEROW", row.ToString(CultureInfo.InvariantCulture));
                modifiedPath = modifiedPath.Replace("REPLACECOLUMN", column.ToString(CultureInfo.InvariantCulture));                
                Element singleCell;
                Host.Local.TryFindSingle(this.mdiClientPath + modifiedPath, DefaultValues.iTimeoutModules, out singleCell);
                if (singleCell.Location.X < 0 && singleCell.Location.Y < 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Cell is not accessible. Return Row");
                    return singleCell.Parent;
                }

                return singleCell;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Failed to access specific cells " + exception.Message);
                return null;
            }
        }

        #endregion
    }
}