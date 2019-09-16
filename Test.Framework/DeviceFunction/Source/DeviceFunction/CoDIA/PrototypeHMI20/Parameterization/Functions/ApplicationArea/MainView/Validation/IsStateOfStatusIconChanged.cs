using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class IsStateOfStatusIconChanged.
    /// </summary>
    public class IsStateOfStatusIconChanged : IIsStateOfStatusIconChanged
    {
        /// <summary>
        /// Validates whether status has changed.
        /// </summary>
        /// <param name="statusIconId">The status icon identifier.</param>
        /// <param name="oldState">The old state.</param>
        /// <returns><c>true</c> if changed, <c>false</c> otherwise.</returns>
        public bool Run(string statusIconId, string oldState)
        {
            return !new CompareStateOfStatusIcon().Run(statusIconId, oldState);
        }
    }
}
