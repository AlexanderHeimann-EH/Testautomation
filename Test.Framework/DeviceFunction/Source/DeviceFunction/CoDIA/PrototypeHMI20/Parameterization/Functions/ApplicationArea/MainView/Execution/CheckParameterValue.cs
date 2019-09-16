namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class CheckParameterValue./
    /// </summary>
    /// <seealso cref="EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution.ICheckParameterValue" />
    public class CheckParameterValue : ICheckParameterValue
    {
        #region Public Methods and Operators

        /// <summary>
        /// Compares the actual value of a parameter with an expected result.
        /// </summary>
        /// <param name="pathToParameter">The path to parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns><c>true</c> if equal, <c>false</c> otherwise.</returns>
        public bool Run(string pathToParameter, string parameterValue)
        {
            bool result = true;
            string actualValue = new GetParameterValue().Run(pathToParameter);

            // If parameter has expected value
            if (actualValue == parameterValue)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are equal. Parameter has the value: " + actualValue + " ; Expected value is: " + parameterValue + " ;");
            }
            else
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Values are not equal. Parameter has the value: " + actualValue + " ; Expected value is: " + parameterValue + " ;");
                result = false;
            }

            return result;
        }

        #endregion
    }
}