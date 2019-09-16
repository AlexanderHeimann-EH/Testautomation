// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Write.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Linearization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;

    /// <summary>
    /// Provides methods for writing to device
    /// </summary>
    public class Write : IWrite
    {
        /// <summary>
        /// Writes to device
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds.
        /// </param>
        /// <returns>
        /// true: if writing finished successfully; false: if an error occurred
        /// </returns>
        public bool Run(int timeoutInMilliseconds)
        {
            bool result;

            // Try to click the write button
            if (DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView.Execution.ClickOnWrite.Run() == false)
            {
                result = false;
            }
            else
            {
                // Check whether writing has started
                if (DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Statusbar.Validation.ReadingAndWriting.HasWritingStarted(DefaultValues.iTimeoutModules) == false)
                {
                    result = false;
                }
                else
                {
                    // Control whether read and write buttons are inactive after writing started
                    if (DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Statusbar.Validation.ReadingAndWriting.IsReadButtonActive())
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is not grayed out during writing");
                    }

                    if (DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Statusbar.Validation.ReadingAndWriting.IsWriteButtonActive())
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is not grayed out during writing");
                    }

                    // Check whether writing has finished
                    if (DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Statusbar.Validation.ReadingAndWriting.WaitUntilWritingIsFinished(timeoutInMilliseconds) == false)
                    {
                        result = false;
                    }
                    else
                    {
                        // Check whether read and write buttons are active after writing
                        if (DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Statusbar.Validation.ReadingAndWriting.WaitUntilReadButtonAndWriteButtonAreActive(DefaultValues.iTimeoutDefault) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read and or write button are inactive after writing finished.");
                        }

                        // Check whether the Linearization user message contains an error or does not show that writing was successful
                        if (DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Usermessages.Validation.CheckUserNotificationMessages.ContainsError() || DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Usermessages.Validation.CheckUserNotificationMessages.ContainsString("has been written successfully") == false)
                        {
                            result = false;
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing failed");
                        }
                        else
                        {
                            result = true;
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Writing finished successfully");
                        }
                    }
                }
            }

            return result;
        }
    }
}
