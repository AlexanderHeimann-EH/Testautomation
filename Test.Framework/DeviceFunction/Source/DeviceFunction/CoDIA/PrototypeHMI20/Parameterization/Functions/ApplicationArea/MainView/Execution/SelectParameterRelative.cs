namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class SelectParameterRelative.
    /// </summary>
    public class SelectParameterRelative : ISelectParameterRelative
    {
        #region Public Methods and Operators

        /// <summary>
        /// Selects parameter with relative path
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns><c>true</c> if selected, <c>false</c> otherwise.</returns>
        public bool Run(string parameterId)
        {
            return new SelectParameter().Run(parameterId);
        }

        #endregion
    }
}