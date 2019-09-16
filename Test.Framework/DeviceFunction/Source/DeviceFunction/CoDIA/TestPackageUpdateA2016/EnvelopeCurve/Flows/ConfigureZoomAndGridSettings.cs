//------------------------------------------------------------------------------
// <copyright file="ConfigureZoomAndGridSettings.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.Functions.MenuArea.Menubar.Execution;

    using Ranorex;

    /// <summary>
    ///     Flow: Save Curve As via menu
    /// </summary>
    public class ConfigureZoomAndGridSettings
    {
        /// <summary>
        ///     Save curve(s) with system proposed filename, if file was never saved before.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public static bool RunViaMenu()
        {
            // if function call worked fine
            if ((new OpenZoomAndGridSettings()).ViaMenu())
            {
                // Zoom and Grid Settings Dialog should be open

                // TODO:
                // usecase: öffnen, abfragen, konfigurieren, schließen
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function was not Executiond.");
            return false;
        }
    }
}