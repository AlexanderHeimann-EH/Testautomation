namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class SelectMenuItem.
    /// </summary>
    public class SelectMenuItem : ISelectMenuItem
    {
        #region Public Methods and Operators

        /// <summary>
        /// Selects a menu 
        /// </summary>
        /// <param name="menuId">The menu identifier.</param>
        /// <returns><c>true</c> if menu opened, <c>false</c> otherwise.</returns>
        public bool Run(string menuId)
        {
            return new SelectParameter().Run(menuId);
        }

        #endregion
    }
}