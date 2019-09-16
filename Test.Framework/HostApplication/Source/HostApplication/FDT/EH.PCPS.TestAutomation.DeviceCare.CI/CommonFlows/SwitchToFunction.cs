// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="SwitchToFunction.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of CloseProject.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System;
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The close project.
    /// </summary>
    public class SwitchToFunction : ISwitchToFunction
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string functionName)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            try
            {
                Text text = Functions.ApplicationArea.MainView.Helpers.DeviceCareModuleFunctions.IsFunctionOpened(functionName);
                if (text != null && text.Visible)
                {
                    text.Click();
                    return true;
                }

                Reporting.Error("Functions is not opened");
                return false;
            }
            catch (Exception exception)
            {
                Reporting.Error(string.Format("Could not switch to function {0}", functionName));
                Reporting.Error(exception.Message);
                return false;
            }
        }
    }
}
