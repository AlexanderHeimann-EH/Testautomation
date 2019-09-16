//------------------------------------------------------------------------------
// <copyright file="StatusBar.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Historom.Functions.StatusArea.Statusbar.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Historom.Functions.StatusArea.Statusbar.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.Historom.GUI.StatusArea.Statusbar;

    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for status tool bar elements
    /// </summary>
    public class StatusBar : IStatusBar
    {
        /// <summary>
        ///     Gets actual connection state
        /// </summary>
        public string ConnectionState
        {
            get
            {
                Element element = new StatusBarElements().ConnectionState;
                string state = element.GetAttributeValueText("accessibledescription");
                return state;
            }
        }
    }
}