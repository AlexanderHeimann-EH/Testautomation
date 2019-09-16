// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectTab.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides methods for changing the tab within module Viscosity
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.DipTable.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.DipTable.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides methods for changing the tab within module Viscosity
    /// </summary>
    public class SelectTab : ISelectTab
    {
        #region Public Methods and Operators

        /// <summary>
        /// Select a tab with specified tab index
        /// </summary>
        /// <param name="index">
        /// Tab index to select
        /// </param>
        /// <returns>
        /// <br>True: if selection worked </br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(int index)
        {
            Element tabControl = (new MainViewElements()).TabControl;
            if ((index >= 0) && (tabControl != null))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Tab with index " + index + " will be selected.");
                tabControl.SetAttributeValue("selectedtabpageindex", index);
            }
            else
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Index out of bounds or tabcontrol == null");
                return false;
            }

            return true;
        }

        #endregion
    }
}