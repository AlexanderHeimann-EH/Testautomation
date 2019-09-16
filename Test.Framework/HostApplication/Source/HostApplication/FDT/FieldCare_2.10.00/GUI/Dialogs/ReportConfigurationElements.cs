//------------------------------------------------------------------------------
// <copyright file="ReportConfigurationElements.cs" company="Endress+Hauser Process Solutions AG">
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

namespace EH.PCPS.TestAutomation.FieldCare.V21000.GUI.Dialogs
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core.Repository;

    /// <summary>
    /// Class ReportConfigurationElements.
    /// </summary>
    public class ReportConfigurationElements
    {
        /// <summary>
        ///     Repository and mdi client
        /// </summary>
        private readonly Dialogs repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportConfigurationElements"/> class and determines the path of the mdi client
        /// </summary>
        public ReportConfigurationElements()
        {
            this.repository = Dialogs.Instance;
        }

        /// <summary>
        ///     Gets [Report configuration]-Dialog.Button.Print-object
        ///     It is needed to start printing
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button Print
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.ReportConfiguration.PrintInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Report configuration]-Dialog.Button.SaveAs-object
        ///     It is needed to start PDF-creation
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Button SaveAs
        {
            get
            {
                try
                {
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.ReportConfiguration.SaveAsInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Report configuration]-Dialog.Button.Cancel-object
        ///     It is needed to start printing
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
                    Button btnButton;
                    RepoItemInfo elementInfo = this.repository.ReportConfiguration.CancelInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out btnButton);
                    return btnButton;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }

        /// <summary>
        ///     Gets [Report configuration]-Dialog.Button.Cancel-object
        ///     It is needed to start printing
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public ComboBox ReportType
        {
            get
            {
                try
                {
                    ComboBox cbxComboBox;
                    RepoItemInfo elementInfo = this.repository.ReportConfiguration.ReportTypeSelectionInfo;
                    Host.Local.TryFindSingle(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort, out cbxComboBox);
                    return cbxComboBox;
                }
                catch (Exception exception)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                    return null;
                }
            }
        }
        
        /// <summary>
        /// Gets [Report configuration]-Dialog.ComboBox.ListItem-list
        /// </summary>
        /// <returns>
        ///     <br>List: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public IList<ListItem> ListOfReportTypes
        {
            get
            {
                try
                {
                    IList<ListItem> comboBoxList;
                    RepoItemInfo elementInfo = this.repository.ReportConfiguration.ReportTypeItemsInfo;
                    comboBoxList = Host.Local.Find<ListItem>(elementInfo.AbsolutePath, DefaultValues.iTimeoutShort);
                    return comboBoxList;
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