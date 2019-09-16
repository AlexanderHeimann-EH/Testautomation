//------------------------------------------------------------------------------
// <copyright file="ReportConfiguration.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: Effner, Christian
 * Date: 17.04.2012
 * Time: 9:47  
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.FieldCare.V21000.Functions.Dialogs.ReportConfiguration.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.FieldCare.V21000.GUI.Dialogs;
    using EH.PCPS.TestAutomation.HostApplicationInterfaces.FDT.FieldCare.Functions.Dialogs.ReportConfiguration.Execution;

    using Ranorex;

    /// <summary>
    ///     This class describes dialog [Report Configuration] in an abstract way.
    ///     Elements could be accessed for reading or using.
    /// </summary>
    public class ReportConfiguration : MarshalByRefObject, IReportConfiguration
    {
        /// <summary>
        ///     SelectReportType: Select a report type in dialog Report Configuration
        /// </summary>
        /// <param name="reportType">Report type to select</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SelectReportType(string reportType)
        {
            try
            {
                ComboBox comboBox;
                comboBox = (new ReportConfigurationElements()).ReportType;
                if (comboBox != null && comboBox.Enabled)
                {
                    comboBox.Click();
                    if (this.SelectListItem(reportType))
                    {
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItem is not accessible.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not accessible.");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Create paper-documentation
        /// </summary>
        /// <param name="reportType">Report type to select and print</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Print(string reportType)
        {
            try
            {
                if (this.SelectReportType(reportType))
                {
                    Button button = (new ReportConfigurationElements()).Print;
                    if (button != null && button.Enabled)
                    {
                        button.Click(DefaultValues.locDefaultLocation);
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessible.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "An error occurred while selecting report type.");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Create documentation as file
        /// </summary>
        /// <param name="reportType">Report type to select and save</param>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool SaveAsPDF(string reportType)
        {
            try
            {
                if (this.SelectReportType(reportType))
                {
                    Button button = (new ReportConfigurationElements()).SaveAs;
                    if (button != null && button.Enabled)
                    {
                        button.Click(DefaultValues.locDefaultLocation);
                        return true;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessible.");
                    return false;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "An error occurred while selecting report type.");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Close dialog via cancel
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            try
            {
                Button cancel = (new ReportConfigurationElements()).Cancel;
                if (cancel != null && cancel.Enabled)
                {
                    cancel.Click(DefaultValues.locDefaultLocation);
                    return true;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessible");
                return false;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Get [Report configuration]-Dialog.ListItem.toBeSelected-object
        ///     It is needed to select an list entry
        /// </summary>
        /// <param name="reportType">
        /// The report Type.
        /// </param>
        /// <returns>
        /// <br>ListItem: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        private bool SelectListItem(string reportType)
        {
            try
            {
                bool isFound = false;
                IList<ListItem> comboBoxList;
                comboBoxList = (new ReportConfigurationElements()).ListOfReportTypes;
                foreach (ListItem item in comboBoxList)
                {
                    Debug.Print(item.Text);
                    if (string.CompareOrdinal(item.Text, reportType) == 0)
                    {
                        isFound = true;
                        item.Click(DefaultValues.locDefaultLocation);
                    }
                }

                return isFound;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}