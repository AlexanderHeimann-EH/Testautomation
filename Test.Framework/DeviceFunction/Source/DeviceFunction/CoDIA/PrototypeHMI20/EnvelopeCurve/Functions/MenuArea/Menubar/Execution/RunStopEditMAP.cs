//------------------------------------------------------------------------------
// <copyright file="RunStopEditMAP.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.EnvelopeCurve.GUI.MenuArea.Menubar;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Go online with focused device
    /// </summary>
    public class RunStopEditMAP : IRunStopEditMAP
    {
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
                Element element = (new RunEnvelopeCurve()).ViaMenu();
                if (element != null && element.Enabled)
                {
                    // Select entry Stop Edit MAP
                    MenuItem menuItem = (new Elements()).SubmenuStopEditMAP;
                    if (menuItem != null && menuItem.Enabled)
                    {
                        Mouse.MoveTo(menuItem, 500);
                        menuItem.Click(DefaultValues.locDefaultLocation);

                        // Select container for Envelope Curve -> Stop Edit MAP menu entries
                        element = (new Elements()).MenuElement(HandleFunctions.GetHandle(element));
                        Mouse.MoveTo(element, DefaultValues.locDefaultLocation);
                        return element;
                    }

                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessable");
                    return null;
                }

                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu is not accessable");
                return null;
            }
            catch (Exception exception)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return null;
            }
        }
    }
}