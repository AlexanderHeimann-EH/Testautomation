namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class WaitForDisplayContentChanged.
    /// </summary>
    public class WaitForDisplayContentChanged : IWaitForDisplayContentChanged
    {
        #region Public Methods and Operators

        /// <summary>
        /// Waits for a changed display content
        /// </summary>
        /// <param name="oldDisplayContent">Old display content.</param>
        /// <param name="timeoutInMilliseconds">The timeout in milliseconds.</param>
        /// <returns><c>true</c> if changed, <c>false</c> otherwise.</returns>
        public bool Run(string oldDisplayContent, int timeoutInMilliseconds)
        {
            bool result = true;

            string newDisplayContent = AppComController.GetDisplayContent();

            var watch = new Stopwatch();
            watch.Start();
            while (newDisplayContent == oldDisplayContent)
            {
                if (watch.ElapsedMilliseconds > timeoutInMilliseconds)
                {
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "No update of display content recognized.");
                    result = false;
                    break;
                }

                if ((watch.ElapsedMilliseconds / 1000) % 2 == 0)
                {
                    newDisplayContent = AppComController.GetDisplayContent();
                }
            }

            watch.Stop();

            return result;
        }

        #endregion
    }
}