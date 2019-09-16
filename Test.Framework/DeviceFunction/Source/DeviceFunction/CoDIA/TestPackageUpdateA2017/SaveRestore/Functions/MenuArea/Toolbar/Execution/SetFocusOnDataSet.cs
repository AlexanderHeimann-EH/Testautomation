//------------------------------------------------------------------------------
// <copyright file="SetFocusOnDataSet.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

/*
 * Created by Ranorex
 * User: testadmin
 * Date: 7/22/2013
 * Time: 1:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.Functions.MenuArea.Toolbar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Functions.MenuArea.Toolbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.SaveRestore.GUI.MenuArea.Toolbar;

    using Ranorex;

    using EH.PCPS.TestAutomation.Common.Tools;

    /// <summary>
    ///     Description of SetFocusOnDataSet.
    /// </summary>
    public class SetFocusOnDataSet : MarshalByRefObject, ISetFocusOnDataSet
    {
        /// <summary>
        ///     Set focus on combobox DataSet
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run()
        {
            Button button = new ToolbarElements().ButtonParameterSelection;
            if (button != null && button.Enabled)
            {
                Mouse.MoveTo(button, 500);
                button.Click();
                return true;
            }
            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is not available.");
            return false;
        }
    }
}