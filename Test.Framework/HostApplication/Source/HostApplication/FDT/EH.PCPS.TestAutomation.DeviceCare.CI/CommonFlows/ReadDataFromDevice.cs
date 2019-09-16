// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Endress+Hauser Process Solutions AG" file="ReadDataFromDevice.cs">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of ReadDataFromDevice.
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// Description of ReadDataFromDevice.
    /// </summary>
    public class ReadDataFromDevice : IReadDataFromDevice
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run()
        {
            Logging.Enter(typeof(ReadDataFromDevice), MethodBase.GetCurrentMethod().Name);

            bool methodResult;
            
            // check if device is connected
            if (Functions.StatusArea.StatusBar.Validation.Connection.IsDeviceConnected())
            {
                // check if device supports offline functionality
                if (Functions.MenuArea.MenuBar.Validation.DtmFunctions.IsOfflineParameterizeAvailable())
                {
                    methodResult = Functions.MenuArea.MenuBar.Execution.ProgramFunctions.OpenMenu();
                    methodResult &= Functions.MenuArea.MenuBar.Execution.ProgramFunctions.RunReadFromDevice();
                    if (methodResult)
                    {
                        // wait until read is finished
                        // check progress indicator, see create project
                        methodResult &= Functions.StatusArea.StatusBar.Validation.ProgressIndicator.WaitUntilProgressIndicatorBecomesAvailable();
                        methodResult &= Functions.StatusArea.StatusBar.Validation.ProgressIndicator.WaitUntilProgressIndicatorBecomesNotAvailable();
                        
                        // Wait until message is shown
                        methodResult &= Functions.StatusArea.StatusBar.Validation.StatusMessage.WaitUntilStatusMessageBecomesAvailable();

                        if (methodResult)
                        {
                            // check event log, see get last message 
                            if (Functions.Dialogs.Execution.EventLog.OpenEventLog())
                            {
                                if (Functions.Dialogs.Validation.EventLog.IsEventLogOpen())
                                {
                                    string lastMessage = Functions.Dialogs.Execution.EventLog.GetLastMessageFromEventLog();
                                    if (lastMessage.Equals(string.Empty))
                                    {
                                        Reporting.Error("No message is shown after Read Data From Device");
                                        return false;
                                    }

                                    if (Functions.Dialogs.Execution.EventLog.CloseEventLog())
                                    {
                                        return true;
                                    }

                                    // get device care language
                                    string hostApplicationLanguage = new GetHostApplicationLanguage().Run();
                                    string upload = string.Empty;
                                    string successful = string.Empty;

                                    // get language dependent words
                                    ResourceSet languages = GUI.StringTranslation.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                                    foreach (DictionaryEntry language in languages)
                                    {
                                        if (language.Key.ToString().Contains(hostApplicationLanguage) &&
                                            language.Key.ToString().Contains("upload") &&
                                            language.Key.ToString().Contains("successful"))
                                        {
                                            string[] seperator = { "_" };
                                            string[] words = language.Value.ToString().Split(seperator, StringSplitOptions.None);
                                            upload = words[0];
                                            successful = words[1];
                                        }
                                    }

                                    if (lastMessage.ToLower().Contains(upload) && lastMessage.ToLower().Contains(successful))
                                    {
                                        Reporting.Debug("Upload finished successful.");
                                        Reporting.Debug(lastMessage);
                                        return true;
                                    }

                                    Reporting.Error("There is no information about an successful upload");
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

                Reporting.Error("This device does not support an Offline Parameterize. Up / Download is not possible.");
                return false;
            }
            
            return false;
        }
    }
}
