//------------------------------------------------------------------------------
// <copyright file="RunSelectTab.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;

    /// <summary>
    ///     Provides methods to open a specified tab within module HISTOROM
    /// </summary>
    public class RunSelectTab : IRunSelectTab
    {
        /// <summary>
        ///     Selects a tab within module HISTOROM
        /// </summary>
        /// <param name="tabIndex">
        ///     Index of the tab the caller wants to select
        /// </param>
        /// <returns>
        ///     true: if tab has been selected successfully
        ///     false: if something went wrong
        /// </returns>
        public bool Run(int tabIndex)
        {
            try
            {
                switch (tabIndex)
                {
                    case 0:
                        if (new TabContainer().SelectTabTable())
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened Tab Table successfully!");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Table!");
                        return false;

                    case 1:
                        if (new TabContainer().SelectTabGraphic())
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened Tab Graphic successfully!");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Graphic!");
                        return false;

                    case 2:
                        if (new TabContainer().SelectTabStatistic())
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened Tab Statistic successfully!");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Statistic!");
                        return false;
                    case 3:
                        if (new TabContainer().SelectTabSettings())
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened Tab Settings successfully!");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Settings!");
                        return false;

                    default:
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                            LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                            "Wrong index used!Use 0 for table, 1 for graphic , 2 for statistic and 3 for settings");
                        return false;
                }
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        /// <summary>
        ///     Selects a tab within module HISTOROM
        /// </summary>
        /// <param name="tabName">
        ///     Name of the tab the caller wants to have selected
        /// </param>
        /// <returns>
        ///     true: if tab has been selected successfully
        ///     false: if something went wrong
        /// </returns>
        public bool Run(string tabName)
        {
            try
            {
                switch (tabName)
                {
                    case "Data overview":
                        if (new TabContainer().SelectTabTable())
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened Tab Table successfully!");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Table!");
                        return false;

                    case "Diagram data":
                        if (new TabContainer().SelectTabGraphic())
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened Tab Graphic successfully!");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Graphic!");
                        return false;

                    case "Statistic results":
                        if (new TabContainer().SelectTabStatistic())
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened Tab Statistic successfully!");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Statistic!");
                        return false;

                    case "Settings":
                        if (new TabContainer().SelectTabSettings())
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opened Tab Settings successfully!");
                            return true;
                        }

                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Could not open Tab Settings!");
                        return false;

                    default:
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Wrong tab name!");
                        return false;
                }
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}