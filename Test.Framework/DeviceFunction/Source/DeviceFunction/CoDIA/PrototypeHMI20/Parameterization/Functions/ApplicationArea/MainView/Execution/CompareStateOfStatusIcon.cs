namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class CompareStateOfStatusIcon.
    /// </summary>
    public class CompareStateOfStatusIcon : ICompareStateOfStatusIcon
    {
        #region Public Methods and Operators

        /// <summary>
        /// Compares the current state of header status icon with expected value
        /// </summary>
        /// <param name="statusIconId">The status icon identifier.</param>
        /// <param name="expectedValue">The reference value.</param>
        /// <returns><c>true</c> if states are the same, <c>false</c> otherwise.</returns>
        public bool Run(string statusIconId, string expectedValue)
        {
            return expectedValue == new GetStatusIconState().Run(statusIconId);
        }

        #endregion
    }
}