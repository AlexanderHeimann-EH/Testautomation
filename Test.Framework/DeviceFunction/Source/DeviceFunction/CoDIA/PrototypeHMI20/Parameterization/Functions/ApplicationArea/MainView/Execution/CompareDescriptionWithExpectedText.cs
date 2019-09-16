namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class CompareDescriptionWithExpectedText.
    /// </summary>
    public class CompareDescriptionWithExpectedText : ICompareDescriptionWithExpectedText
    {
        #region Public Methods and Operators

        /// <summary>
        /// Compares the help text of a specified parameter with an expected text.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <param name="expectedText">The expected text.</param>
        /// <returns>System.Boolean.</returns>
        public bool Run(string parameterId, string expectedText)
        {
            var result = false;
            var actualDescriptionString = new GetDescriptionText().Run(parameterId);
            if (actualDescriptionString.Equals(string.Empty))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Description for parameter '" + parameterId + "'does not contain " + expectedText + ".");
            }
            else if (actualDescriptionString.Contains(expectedText))
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Description for parameter '" + parameterId + "' contains " + expectedText + ".");
                result = true;
            }

            return result;
        }

        #endregion
    }
}