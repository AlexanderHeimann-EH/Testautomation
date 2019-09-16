//------------------------------------------------------------------------------
// <copyright file="Apply.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.Configuration.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.Configuration.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.Configuration.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// The Change.
    /// </summary>
    public class Apply : IApply
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            bool result = true;
            Element applyButton = new ConfigurationMainViewElements().ApplyButton;
            if (applyButton == null)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "ApplyButton button is null, check the Ranorex path in the repository");
                result = false;
            }
            else
            {
                if (applyButton.Enabled == false)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Apply button is not enabled");
                    result = false;
                }
                else
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button found and enabled, clicking...");
                    Mouse.Click(applyButton);
                }
            }

            return result;
        }
    }
}
