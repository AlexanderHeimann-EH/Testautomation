namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System.Reflection;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    /// <summary>
    /// Class CreateScreenshot.
    /// </summary>
    public class CreateScreenshot : ICreateScreenshot
    {
        #region Public Methods and Operators

        /// <summary>
        /// Takes a screenshot.
        /// </summary>
        public void Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Taking screenshot of the HMI Parameterization");
            Log.Screenshot();
        }

        #endregion
    }
}