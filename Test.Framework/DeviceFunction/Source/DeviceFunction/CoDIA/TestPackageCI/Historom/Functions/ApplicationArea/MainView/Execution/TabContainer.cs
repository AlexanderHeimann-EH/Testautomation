//------------------------------------------------------------------------------
// <copyright file="TabContainer.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Historom.Functions.ApplicationArea.MainView.Execution
{
    using System.Globalization;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Historom.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods to select tabs within HISTOROM module
    /// </summary>
    public class TabContainer : ITabContainer
    {
        #region select methods

        /// <summary>
        ///     select tab "table"
        /// </summary>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectTabTable()
        {
            Element element = (new TabContainerElements()).ContainerTabTable;
            if (element != null)
            {
                return this.SelectTab(0);
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Selection was not found.");
            return false;
        }

        /// <summary>
        ///     select tab "graphic"
        /// </summary>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectTabGraphic()
        {
            Element element = (new TabContainerElements()).ContainerTabGraphic;
            if (element != null)
            {
                return this.SelectTab(1);
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Selection was not found.");
            return false;
        }

        /// <summary>
        ///     select tab "statistic"
        /// </summary>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectTabStatistic()
        {
            Element element = (new TabContainerElements()).ContainerTabStatistic;
            if (element != null)
            {
                return this.SelectTab(2);
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Selection was not found.");
            return false;
        }

        /// <summary>
        ///     select tab "settings"
        /// </summary>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectTabSettings()
        {
            Element element = (new TabContainerElements()).ContainerTabSettings;
            if (element != null)
            {
                return this.SelectTab(3);
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Selection was not found.");
            return false;
        }
        #region private methods

        ///// <summary>
        /////     Get tab index of an element within an tab control
        ///// </summary>
        ///// <param name="element">Tab control element which tab index should be get</param>
        ///// <returns>
        /////     <br>Integer >= 0: if element is valid and tab index found</br>
        /////     <br>Integer = -1: if element was not valid or an error occurred</br>
        ///// </returns>
        ////private int GetTabIndex(Element element)
        ////{
        //    try
        //    {
        //        if (element != null)
        //        {
        //            string tabIndex = element.GetAttributeValue("tabindex").ToString();
        //            return Convert.ToInt16(tabIndex);
        //        }

        ////        EH.PCPS.TestAutomation.Common.Tools.Log.Error(
        ////            LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element for tab control page was null.");
        //        return -1;
        //    }
        //    catch (Exception exception)
        //    {
        //        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
        //        return -1;
        //    }
        ////}

        /// <summary>
        ///     Select a tab with specified tab index within an tab control
        /// </summary>
        /// <param name="tabIndex">Tab index to select at tab control</param>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        private bool SelectTab(int tabIndex)
        {
            Element element = (new TabContainerElements()).TabulatorControl;
            if (element != null && tabIndex > -1)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Select tab [" + tabIndex.ToString(CultureInfo.InvariantCulture) + "] (without mouse activity!).");
                element.SetAttributeValue("selectedtabpageindex", tabIndex);
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                "Tab with index [" + tabIndex.ToString(CultureInfo.InvariantCulture) + "] was not found.");
            return false;
        }

        #endregion
        #endregion
    }
}