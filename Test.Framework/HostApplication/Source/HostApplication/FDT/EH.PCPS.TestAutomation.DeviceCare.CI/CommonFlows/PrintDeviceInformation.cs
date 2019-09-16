// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="PrintDeviceInformation.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of PrintDeviceInformation.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// Description of PrintDeviceInformation.
    /// </summary>
    public class PrintDeviceInformation : IPrintDeviceInformation
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="filePathAndName">
        /// The file path and name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string filePathAndName)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            return this.Run(filePathAndName, Common.DefaultValues.GeneralTimeout);
        }

        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="word">
        /// The word.
        /// </param>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string word, int number)
        {
            Logging.Enter(this, MethodBase.GetCurrentMethod().Name);

            // check if device is connected
            if (Functions.StatusArea.StatusBar.Validation.Connection.IsDeviceConnected())
            {
                if (Functions.MenuArea.MenuBar.Execution.DeviceReport.SaveDeviceReport())
                {
                    bool methodResult = Functions.StatusArea.StatusBar.Validation.ProgressIndicator.WaitUntilProgressIndicatorBecomesAvailable();
                    methodResult &= Functions.StatusArea.StatusBar.Validation.ProgressIndicator.WaitUntilProgressIndicatorBecomesNotAvailable();

                    if (methodResult)
                    {
                        if (Functions.Dialogs.Execution.EventLog.OpenEventLog())
                        {
                            string lastMessage = Functions.Dialogs.Execution.EventLog.GetLastMessageFromEventLog();
                            Reporting.Debug(lastMessage);

                            if (Functions.Dialogs.Execution.EventLog.CloseEventLog())
                            {
                                return true;
                            }

                            return false;
                        }

                        return false;
                    }

                    return false;
                }

                return false;
            }

            return false;
        }
    }
}
