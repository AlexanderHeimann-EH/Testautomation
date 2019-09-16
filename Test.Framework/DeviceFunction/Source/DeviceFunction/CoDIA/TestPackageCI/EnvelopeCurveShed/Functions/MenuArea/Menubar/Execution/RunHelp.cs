// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RunHelp.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurveShed.GUI.MenuArea.Menubar;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Go online with focused device
    /// </summary>
    public class RunHelp : IRunHelp
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Start via related menu-entry
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public Element ViaMenu()
        {
            try
            {
                MenuItem menuItem = (new Elements()).MenuHelp;
                if (menuItem != null && menuItem.Enabled)
                {
                    Mouse.MoveTo(menuItem, 500);
                    menuItem.Click(DefaultValues.locDefaultLocation);

                    // Select container for Help -> menu entries
                    Element element = (new Elements()).MenuElement(HandleFunctions.GetZeroHandle());
                    Mouse.MoveTo(element, DefaultValues.locDefaultLocation);
                    return element;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu is not accessable");
                return null;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }

        #endregion
    }
}