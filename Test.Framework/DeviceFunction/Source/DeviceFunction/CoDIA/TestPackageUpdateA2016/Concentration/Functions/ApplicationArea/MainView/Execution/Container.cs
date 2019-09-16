// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Globalization;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Concentration.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Concentration.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    ///     Provides methods to select different tabs within module concentration
    /// </summary>
    public class Container : IContainer
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Select tab base settings
        /// </summary>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectTabBaseSettings()
        {
            Element element = (new ContainerElements()).TabBaseSettings;
            if (element != null)
            {
                // int tabIndex = GetTabIndex(element);
                return this.SelectTab(0);
            }

            Log.Error("DeviceFunction.Modules.Concentration.MainView.Areas.Container.SelectTabBaseSettings", "Tab Base Settings was not found.");
            return false;
        }

        /// <summary>
        ///     Select tab coefficients overview
        /// </summary>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectTabCoefficientsOverview()
        {
            Element element = (new ContainerElements()).TabCoefficientsOverview;
            if (element != null)
            {
                // int tabIndex = GetTabIndex(element);
                return this.SelectTab(2);
            }

            Log.Error("DeviceFunction.Modules.Concentration.MainView.Areas.Container.SelectTabCoefficientsOverview", "Tab Coefficients Overview was not found.");
            return false;
        }

        /// <summary>
        ///     Select tab expert results
        /// </summary>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectTabExpertResults()
        {
            Element element = (new ContainerElements()).TabExpertResults;
            if (element != null)
            {
                // int tabIndex = GetTabIndex(element);
                return this.SelectTab(3);
            }

            Log.Error("DeviceFunction.Modules.Concentration.MainView.Areas.Container.SelectTabExpertResults", "Tab Expert Results was not found.");
            return false;
        }

        /// <summary>
        ///     Select tab liquid properties
        /// </summary>
        /// <returns>
        ///     <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool SelectTabLiquidProperties()
        {
            Element element = (new ContainerElements()).TabLiquidProperties;
            if (element != null)
            {
                // int tabIndex = GetTabIndex(element);
                return this.SelectTab(1);
            }

            Log.Error("DeviceFunction.Modules.Concentration.MainView.Areas.Container.SelectTabLiquidProperties", "Tab Liquid Properties was not found.");
            return false;
        }

        /// <summary>
        /// The select tab reference values.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// Not implemented exception
        /// </exception>
        public bool SelectTabReferenceValues()
        {
            throw new NotImplementedException();
        }

        #endregion

        /*
        /// <summary>
        ///     Get tab index of an element within an tab control
        /// </summary>
        /// <param name="element">Tab control element which tab index should be get</param>
        /// <returns>
        ///     <br>Integer >= 0: if element is valid and tab index found</br>
        ///     <br>Integer = -1: if element was not valid or an error occurred</br>
        /// </returns>
        private int GetTabIndex(Element element)
        {
            try
            {
                if (element != null)
                {
                    string tabIndex = element.GetAttributeValue("tabindex").ToString();
                    return Convert.ToInt16(tabIndex);
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                   LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element for tab control page was null.");
                return -1;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return -1;
            }
        }
*/
        #region Methods

        /// <summary>
        /// Select a tab with specified tab index within an tab control
        /// </summary>
        /// <param name="tabIndex">
        /// Tab index to select at tab control
        /// </param>
        /// <returns>
        /// <br>True: if selection worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        private bool SelectTab(int tabIndex)
        {
            Element element = (new ContainerElements()).TabulatorContainer;
            if (element != null && tabIndex > -1)
            {
                Log.Info("DeviceFunction.Modules.Concentration.MainView.Areas.Container.SelectTab", "Select tab [" + tabIndex.ToString(CultureInfo.InvariantCulture) + "] (without mouse activity!).");
                element.SetAttributeValue("selectedtabpageindex", tabIndex);
                string tabIndexAsString = element.GetAttributeValueText("selectedtabpageindex");
                if (tabIndexAsString.Equals(tabIndex.ToString(CultureInfo.InvariantCulture)))
                {
                    return true;
                }

                Log.Info("DeviceFunction.Modules.Concentration.MainView.Areas.Container.SelectTab", "Tab with index [" + tabIndex.ToString(CultureInfo.InvariantCulture) + "] could not be selected. May there are specific preconditions make tab accessible.");
                return false;
            }

            Log.Error("DeviceFunction.Modules.Concentration.MainView.Areas.Container.SelectTab", "Tab with index [" + tabIndex.ToString(CultureInfo.InvariantCulture) + "] was not found.");
            return false;
        }

        #endregion
    }
}