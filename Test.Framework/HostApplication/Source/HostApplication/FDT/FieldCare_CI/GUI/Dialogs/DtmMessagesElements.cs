//------------------------------------------------------------------------------
// <copyright file="DtmMessagesElements.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 10.11.2010
 * Time: 1:39 
 * Last: 25.11.2010
 * Reason: Code documentation
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.CI.GUI.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class DTM Messages Elements.
    /// </summary>
    public class DtmMessagesElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DtmMessagesElements"/> class and determines the path of the mdi client
        /// </summary>
        public DtmMessagesElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        /// Gets a list of rows, that contains DTM messages
        /// </summary>
        /// <returns>
        ///     <br>IList[Row]: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public IList<Row> RowMessages
        {
            get
            {
                try
                {
                    if (this.Table != null)
                    {
                        RepoItemInfo elementInfo = this.repository.DtmMessage.MessageInfo;
                        IList<Row> rowList = Host.Local.Find<Row>(elementInfo.AbsolutePath);
                        if (rowList.Count > 0)
                        {
                            return rowList;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No rows available.");
                        return null;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Table is not accessible.");
                    return null;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a table-element, that contains DTM messages
        /// </summary>
        /// <returns>
        ///     <br>Table: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Table Table
        {
            get
            {
                try
                {
                    Table messageTable;
                    RepoItemInfo elementInfo = this.repository.DtmMessage.TableInfo;
                    if (!Host.Local.TryFindSingle(elementInfo.AbsolutePath, out messageTable))
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Table is not found.");
                    }

                    return messageTable;
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