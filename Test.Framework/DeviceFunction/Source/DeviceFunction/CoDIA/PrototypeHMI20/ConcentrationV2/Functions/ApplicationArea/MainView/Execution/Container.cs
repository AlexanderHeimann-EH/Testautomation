// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Container.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Functions.ApplicationArea.MainView.Execution
{
    using System.Globalization;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides methods to select different tabs within module concentration
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

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Base Settings was not found.");
            return false;
        }

        /// <summary>
        /// Selects the tab reference values.
        /// </summary>
        /// <returns><c>true</c> if tab selected, <c>false</c> otherwise.</returns>
        public bool SelectTabReferenceValues()
        {
            Element element = (new ContainerElements()).TabLiquidProperties;
            if (element != null)
            {
                // int tabIndex = GetTabIndex(element);
                return this.SelectTab(1);
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Liquid Properties was not found.");
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
                return this.SelectTab(2);
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Liquid Properties was not found.");
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
                return this.SelectTab(3);
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Coefficients Overview was not found.");
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
                return this.SelectTab(4);
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab Expert Results was not found.");
            return false;
        }

        #endregion

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
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Select tab [" + tabIndex.ToString(CultureInfo.InvariantCulture) + "] (without mouse activity!).");
                element.SetAttributeValue("selectedtabpageindex", tabIndex);
                string tabIndexAsString = element.GetAttributeValueText("selectedtabpageindex");
                if (tabIndexAsString.Equals(tabIndex.ToString(CultureInfo.InvariantCulture)))
                {
                    return true;
                }

                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab with index [" + tabIndex.ToString(CultureInfo.InvariantCulture) + "] could not be selected. May there are specific preconditions make tab accessible.");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab with index [" + tabIndex.ToString(CultureInfo.InvariantCulture) + "] was not found.");
            return false;
        }

        #endregion
    }
}