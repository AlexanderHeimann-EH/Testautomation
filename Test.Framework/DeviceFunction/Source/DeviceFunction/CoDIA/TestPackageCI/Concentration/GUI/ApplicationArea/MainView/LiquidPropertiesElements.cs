// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LiquidPropertiesElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Concentration.GUI.ApplicationArea.MainView
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
        /// Gets the combo box value 1.
        /// </summary>
        public Element ComboBoxValue1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue1 = this.concentration.LiquidProperties.OperatingRange.comboBoxValue1Info;
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
        /// Gets the combo box value 1 unit.
        /// </summary>
        public Element ComboBoxValue1Unit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue1Unit = this.concentration.LiquidProperties.OperatingRange.comboBoxValue1UnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue1Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box value 2.
        /// </summary>
        public Element ComboBoxValue2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2 = this.concentration.LiquidProperties.OperatingRange.comboBoxValue2Info;
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
        public Element ComboBoxValue2Unit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Unit = this.concentration.LiquidProperties.OperatingRange.comboBoxValue2UnitInfo;
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
        /// Gets the combo box value 3.
        /// </summary>
        public Element ComboBoxValue3
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue3 = this.concentration.LiquidProperties.OperatingRange.comboBoxValue3Info;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue3.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the combo box value 3 unit.
        /// </summary>
        public Element ComboBoxValue3Unit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue3Unit = this.concentration.LiquidProperties.OperatingRange.comboBoxValue3UnitInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue3Unit.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text value 1 max.
        /// </summary>
        public Element TextValue1Max
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue1Max = this.concentration.LiquidProperties.OperatingRange.textValue1MaxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue1Max.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text value 1 min.
        /// </summary>
        public Element TextValue1Min
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue1Min = this.concentration.LiquidProperties.OperatingRange.textValue1MinInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue1Min.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text value 2 max.
        /// </summary>
        public Element TextValue2Max
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Max = this.concentration.LiquidProperties.OperatingRange.textValue2MaxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Max.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text value 2 min.
        /// </summary>
        public Element TextValue2Min
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue2Min = this.concentration.LiquidProperties.OperatingRange.textValue2MinInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue2Min.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text value 3 max.
        /// </summary>
        public Element TextValue3Max
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue3Max = this.concentration.LiquidProperties.OperatingRange.textValue3MaxInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue3Max.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
        /// Gets the text value 3 min.
        /// </summary>
        public Element TextValue3Min
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo infoValue3Min = this.concentration.LiquidProperties.OperatingRange.textValue3MinInfo;
                    Host.Local.TryFindSingle(this.mdiClientPath + infoValue3Min.AbsolutePath, DefaultValues.iTimeoutLong, out element);
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
                RxPath modifiedRxPath = new RxPath(modifiedPath);
                Element singleCell = null;
                Host.Local.TryFindSingle(this.mdiClientPath + modifiedPath, DefaultValues.iTimeoutModules, out singleCell);
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