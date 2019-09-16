// -----------------------------------------------------------------------
// <copyright file="SetCalculationSteps.cs" company="Endress+Hauser Process Solutions AG">
// E+H PCPS AG
// </copyright>
// -----------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.Linearization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Provides functionality for setting the number of calculation steps
    /// </summary>
    public class SetCalculationSteps : ISetCalculationSteps
    {
        /// <summary>
        /// Sets the number of calculation steps
        /// </summary>
        /// <param name="numberOfCalculationSteps">
        /// The number of calculation steps.
        /// </param>
        /// <returns>
        /// True: if number is set; False: if otherwise
        /// </returns>
        public bool Run(string numberOfCalculationSteps)
        {
            bool result;
            Element steps = new GUI.ApplicationArea.MainView.TankTabElements().CalculationStepsTextbox;
            if (steps == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The textbox [Steps] is not accessible");
                result = false;
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The number of calculation steps will be set to: " + numberOfCalculationSteps + ".");
                result = new EditParameter().SetParameterValue(steps, numberOfCalculationSteps);
            }

            return result;
        }
    }
}
