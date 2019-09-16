// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Write.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.PrototypeHMI20.DipTable.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.DipTable.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.DipTable.Functions.ApplicationArea.MainView;

    using Validation = EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.DipTable.Functions.StatusArea.Statusbar.Validation;

    /// <summary>
    /// Provides methods for writing to device
    /// </summary>
    public class Write : IWrite
    {
        #region Public Methods and Operators

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
            if (Execution.ClickOnWrite.Run() == false)
            {
                result = false;
            }
            else
            {
                // Check whether writing has started
                if (Validation.ReadingAndWriting.HasWritingStarted(DefaultValues.iTimeoutModules) == false)
                {
                    result = false;
                }
                else
                {
                    // Control whether read and write buttons are inactive after writing started
                    if (Validation.ReadingAndWriting.IsReadButtonActive())
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is not grayed out during writing");
                    }

                    if (Validation.ReadingAndWriting.IsWriteButtonActive())
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is not grayed out during writing");
                    }

                    // Check whether writing has finished
                    if (Validation.ReadingAndWriting.WaitUntilWritingIsFinished(timeoutInMilliseconds) == false)
                    {
                        result = false;
                    }
                    else
                    {
                        // Check whether read and write buttons are active after writing
                        if (Validation.ReadingAndWriting.WaitUntilReadButtonAndWriteButtonAreActive(DefaultValues.iTimeoutDefault) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read and or write button are inactive after writing finished.");
                        }

                        // Check whether the Dip table user message contains an error or does not show that writing was successful
                        if (DeviceFunctionLoader.CoDIA.DipTable.Functions.StatusArea.Usermessages.Validation.CheckUserNotificationMessages.ContainsError() || DeviceFunctionLoader.CoDIA.DipTable.Functions.StatusArea.Usermessages.Validation.CheckUserNotificationMessages.ContainsString("has been written successfully") == false)
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

        #endregion
    }
}