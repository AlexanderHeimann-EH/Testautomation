//------------------------------------------------------------------------------
// <copyright file="OpenModuleOnline.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDtmAddress.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDtmAddress.Flows;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDtmAddress.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    ///     Provides function to open module frame-independent
    /// </summary>
    public class OpenModuleOnline : IOpenModuleOnline
    {
        /// <summary>
        ///     Open module via frame menu within a default time
        /// </summary>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run()
        {
            // get number of currently opened modules
            int numberOfOpenedModules = Validation.GetNumberOfOpenedModules.Run();
            bool result = false;

            // if module is already open
            if (Validation.IsModuleAlreadyOpened.Run((new ModuleName()).Name))
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is already opened");
                result = true;
            }
            else
            {
                // Try to open module
                if (CommonFlows.OpenAdditionalFunction.Run((new ModuleName()).Name)
                    == false)
                {
                    EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Opening module failed");
                }
                else
                {
                    // Is module opening in time
                    if (
                        CommunicationLoader.HART.NXA820.ChangeDtmAddress.Functions.ApplicationArea.MainView.Validation
                                            .ModuleOpeningAndClosing.WaitUntilModuleIsOpen(
                                                numberOfOpenedModules, DefaultValues.iTimeoutModules) == false)
                    {
                        EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not opened in time.");
                    }
                    else
                    {
                        // Is module online in time
                        if (
                            CommunicationLoader.HART.NXA820.ChangeDtmAddress.Functions.StatusArea.Statusbar.Validation
                                                .WaitUntilDtmIsConnected.Run(DefaultValues.iTimeoutModules) == false)
                        {
                            EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not online in time.");
                        }
                        else
                        {
                            // Is module ready in time
                            if (
                                CommunicationLoader.HART.NXA820.ChangeDtmAddress.Functions.ApplicationArea.MainView
                                                    .Validation.WaitUntilModuleOnlineIsReady.Run(
                                                        DefaultValues.iTimeoutModules) == false)
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module not ready in time.");
                            }
                            else
                            {
                                EH.PCPS.TestAutomation.Common.Tools.Log.Info(
                                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                                    "Module is opened and ready to use.");
                                result = true;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
