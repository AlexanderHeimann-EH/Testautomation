//------------------------------------------------------------------------------
// <copyright file="SelectTab.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Reflection;
    using Ranorex;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Viscosity.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Viscosity.GUI.ApplicationArea.MainView;

    using Ranorex.Core;

    /// <summary>
    /// Provides methods for changing the tab within module Viscosity
    /// </summary>
    public class SelectTab : MarshalByRefObject, ISelectTab
    {
        /// <summary>
        ///     Select a tab with specified tab index
        /// </summary>
        /// <param name="index">Tab index to select</param>
        /// <returns>
        ///     <br>True: if selection worked </br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run(int index)
        {
            Element tabControl = (new TabControlElements()).TabControlViscosity;
            if ((index >= 0) && (tabControl != null))
            {
                tabControl.SetAttributeValue("selectedtabpageindex", index); 
            }
            else
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Index out of bounds or tabcontrol == null");
                return false;
            }

          return true;
        }
    }
}
