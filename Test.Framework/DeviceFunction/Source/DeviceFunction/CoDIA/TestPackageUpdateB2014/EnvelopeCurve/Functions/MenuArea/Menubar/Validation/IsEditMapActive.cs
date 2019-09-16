//------------------------------------------------------------------------------
// <copyright file="IsEditMapActive.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.Functions.MenuArea.Menubar.Validation
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Functions.MenuArea.Menubar.Validation;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurve.GUI.MenuArea.Menubar;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///    Provides validation methods for determining whether edit map is active 
    /// </summary>
    public class IsEditMapActive : IIsEditMapActive
    {
        /// <summary>
        /// Opens then envelope curve menu and checks the edit map and stop edit map buttons. Closes menu afterwards
        /// </summary>
        /// <returns>true: if edit map button is not enabled and stop edit is enabled; false: everything else :-)</returns>
        public bool IsActive()
        {
            Element envCurveMenu = (new Elements()).MenuEnvelopeCurve;

            if (envCurveMenu == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Envelope Curve Menu is not reachable");
                return false;
            }

            envCurveMenu.Focus();
            Mouse.Click(envCurveMenu);
            Button editMap = (new Elements()).EntryEditMAP;
            Element stopEditMapMenu = (new Elements()).SubmenuStopEditMAP;

            if (editMap == null || stopEditMapMenu == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()), "EditMap and/or StopEditMap elements are null");
                return false;
            }

            if (editMap.Enabled || !stopEditMapMenu.Enabled)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Map is not in edit mode");
                envCurveMenu.Focus();
                Mouse.Click(envCurveMenu);

                return false;
            }

            envCurveMenu.Focus();
            Mouse.Click(envCurveMenu);

            return true;
        }
    }
}