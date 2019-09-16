// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluidPropertiesElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Viscosity.GUI.ApplicationArea.MainView
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    ///     Description of ToolbarElements.
    /// </summary>
    public class FluidPropertiesElements
    {
        #region members

        /// <summary>
        /// The _mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly MainViewElementsRepository repository;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FluidPropertiesElements"/> class. 
        /// Creates an instance of the repository which will be used and determines the path of the mdi client
        /// </summary>
        public FluidPropertiesElements()
        {
            this.repository = MainViewElementsRepository.Instance;
            this.mdiClientPath = CommonHostApplicationLayerLoader.CommonFlows.GetDtmContainerPath.Run();
        }

        #region properties

        /// <summary>
        /// Gets combo box -> ViscosityUnit
        /// </summary>
        /// <returns>
        ///     <br>Button: if combo box is found</br>
        ///     <br>Null: if combo box is not found or an error occurred</br>
        /// </returns>
        public Element ComboBoxViscosityUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.FluidProperties.ComboBoxViscosityUnitInfo;
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
        /// Gets combo box -> TemperatureUnit
        /// </summary>
        /// <returns>
        ///     <br>Button: if combo box is found</br>
        ///     <br>Null: if combo box is not found or an error occurred</br>
        /// </returns>
        public Element ComboBoxReferenceTemperatureUnit
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.FluidProperties.ComboBoxReferenceTemperatureUnitInfo;
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
        /// Gets combo box -> AssignmentColumn1
        /// </summary>
        /// <returns>
        ///     <br>Button: if combo box is found</br>
        ///     <br>Null: if combo box is not found or an error occurred</br>
        /// </returns>
        public Element ComboBoxAssignmentColumn1
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.FluidProperties.ComboBoxAssignmentColumn1Info;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        /// Gets combo box -> AssignmentColumn2
        /// </summary>
        /// <returns>
        ///     <br>Button: if combo box is found</br>
        ///     <br>Null: if combo box is not found or an error occurred</br>
        /// </returns>
        public Element ComboBoxAssignmentColumn2
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.FluidProperties.ComboBoxAssignmentColumn2Info;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        /// Gets combo box -> Spreadsheet
        /// </summary>
        /// <returns>
        ///     <br>Button: if combo box is found</br>
        ///     <br>Null: if combo box is not found or an error occurred</br>
        /// </returns>
        public Element ComboBoxSpreadsheet
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.FluidProperties.ComboBoxSpreadsheetInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        /// Gets combo box list items
        /// </summary>
        public IList<ListItem> ListItemsComboBox
        {
            get
            {
                try
                {
                    List list = this.repository.FluidProperties.comboBoxList;
                    if (list != null && list.Items.Count > 0)
                    {
                        return list.Items;
                    }

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
        /// Gets NumericTextBox -> ReferenceTemperature
        /// </summary>
        /// <returns>
        ///     <br>Button: if control is found</br>
        ///     <br>Null: if control is not found or an error occurred</br>
        /// </returns>
        public Element NumericTextBoxReferenceTemperature
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.FluidProperties.NumericTextBoxReferenceTemperatureInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
        /// Gets EditControl -> ReferenceViscosity
        /// </summary>
        /// <returns>
        ///     <br>Button: if control is found</br>
        ///     <br>Null: if control is not found or an error occurred</br>
        /// </returns>
        public Element EditControlReferenceViscosity
        {
            get
            {
                try
                {
                    Element element;
                    RepoItemInfo elementInfo = this.repository.FluidProperties.EditControlReferenceViscosityInfo;
                    Host.Local.TryFindSingle(
                        this.mdiClientPath + elementInfo.AbsolutePath,
                        DefaultValues.iTimeoutLong,
                        out element);
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
                    RepoItemInfo itemInfo = this.repository.FluidProperties.CellInfo;
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
                RepoItemInfo itemInfo = this.repository.FluidProperties.SingleCellInfo;
                string modifiedPath = itemInfo.AbsolutePath.ToString();
                modifiedPath = modifiedPath.Replace("REPLACEROW", row.ToString(CultureInfo.InvariantCulture));
                modifiedPath = modifiedPath.Replace("REPLACECOLUMN", column.ToString(CultureInfo.InvariantCulture));
                Element singleCell;
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