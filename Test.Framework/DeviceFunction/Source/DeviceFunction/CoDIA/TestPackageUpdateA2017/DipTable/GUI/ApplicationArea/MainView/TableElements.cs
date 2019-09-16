// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TableElements.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class TableElements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.DipTable.GUI.ApplicationArea.MainView
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
    /// Class TableElements.
    /// </summary>
    public class TableElements
    {
        #region Fields

        /// <summary>
        /// The mdi client path.
        /// </summary>
        private readonly string mdiClientPath;

        /// <summary>
        /// The repository.
        /// </summary>
        private readonly MainViewElementsRepository repository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TableElements"/> class. 
        /// </summary>
        public TableElements()
        {
            this.repository = MainViewElementsRepository.Instance;
            this.mdiClientPath = CommonFlows.GetDtmContainerPath.Run();
        }

        #endregion

        #region Public Properties

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
                    RepoItemInfo itemInfo = this.repository.Table.CellInfo;
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

        #endregion

        #region Public Methods and Operators

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
                RepoItemInfo itemInfo = this.repository.Table.SingleCellInfo;
                string modifiedPath = itemInfo.AbsolutePath.ToString();
                modifiedPath = modifiedPath.Replace("REPLACEROW", row.ToString(CultureInfo.InvariantCulture));
                modifiedPath = modifiedPath.Replace("REPLACECOLUMN", column.ToString(CultureInfo.InvariantCulture));
                new RxPath(modifiedPath);
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