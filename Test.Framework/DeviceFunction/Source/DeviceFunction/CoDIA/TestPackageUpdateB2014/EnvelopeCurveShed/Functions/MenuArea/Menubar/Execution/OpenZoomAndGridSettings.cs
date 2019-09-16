// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenZoomAndGridSettings.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurveShed.Functions.MenuArea.Menubar.Execution
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurveShed.Functions.MenuArea.Menubar.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateB2014.EnvelopeCurveShed.GUI.MenuArea.Menubar;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Go online with focused device
    /// </summary>
    public class OpenZoomAndGridSettings : IOpenZoomAndGridSettings
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Start via related menu-entry
        /// </summary>
        /// <returns>
        ///     <br>Button: If call worked fine</br>
        ///     <br>NULL: If an error occurred</br>
        /// </returns>
        public bool ViaMenu()
        {
            try
            {
                Element element = (new RunDisplay()).ViaMenu();
                if (element != null && element.Enabled)
                {
                    Button button = (new Elements()).EntryZoomAndGridSettings;
                    if (button != null && button.Enabled)
                    {
                        Mouse.MoveTo(button, 500);
                        button.Click(DefaultValues.locDefaultLocation);
                        return true;
                    }

                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Menu entry is not accessible.");
                    return false;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Function is not accessible.");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}