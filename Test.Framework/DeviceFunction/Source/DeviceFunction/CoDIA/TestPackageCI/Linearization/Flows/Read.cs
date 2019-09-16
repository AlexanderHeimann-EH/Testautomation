// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Read.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   The read.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace EH.PCPS.TestAutomation.TestPackageCI.Linearization.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Linearization.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.ApplicationArea.MainView;

    using Validation = EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Statusbar.Validation;

    /// <summary>
    /// The read.
    /// </summary>
    public class Read : IRead
    {
        #region Public Methods and Operators

        /// <summary>
        /// Reads table from device
        /// </summary>
        /// <param name="timeoutInMilliseconds">
        /// The timeout In Milliseconds.
        /// </param>
        /// <returns>
        /// true: if reading is finished successfully; false: if an error occurred
        /// </returns>
        public bool Run(int timeoutInMilliseconds)
        {
            bool result;

            // Try to click the read button
            if (Execution.ClickOnRead.Run() == false)
            {
                result = false;
            }
            else
            {
                // Check whether reading has started
                if (Validation.ReadingAndWriting.HasReadingStarted(DefaultValues.iTimeoutModules) == false)
                {
                    result = false;
                }
                else
                {
                    // Control whether read and write buttons are inactive after reading started
                    if (Validation.ReadingAndWriting.IsReadButtonActive())
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read button is not grayed out during reading");
                    }

                    if (Validation.ReadingAndWriting.IsWriteButtonActive())
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Write button is not grayed out during reading");
                    }

                    // Check whether reading has finished
                    if (Validation.ReadingAndWriting.WaitUntilReadingIsFinished(timeoutInMilliseconds) == false)
                    {
                        result = false;
                    }
                    else
                    {
                        // Control whether read and write buttons are active after reading
                        if (Validation.ReadingAndWriting.WaitUntilReadButtonAndWriteButtonAreActive(DefaultValues.iTimeoutDefault) == false)
                        {
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Read and or write button are inactive after reading finished.");
                        }

                        // Check whether the Linearization user message contains an error or does not show that reading was successful
                        if (DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Usermessages.Validation.CheckUserNotificationMessages.ContainsError() || DeviceFunctionLoader.CoDIA.Linearization.Functions.StatusArea.Usermessages.Validation.CheckUserNotificationMessages.ContainsString("has been read successfully") == false)
                        {
                            result = false;
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading failed");
                        }
                        else
                        {
                            result = true;
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Reading finished successfully");
                        }
                    }
                }
            }

            return result;
        }

        #endregion
    }
}