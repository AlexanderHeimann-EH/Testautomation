// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseModule.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.AboutBox.Flows
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.AboutBox.Flows;
    using EH.PCPS.TestAutomation.HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.AboutBox.Functions.ApplicationArea.MainView.Validation;

    /// <summary>
    ///     Provides function to close module frame-independent
    /// </summary>
    public class CloseModule : ICloseModule
    {
        /// <summary>
        ///     Close module via frame menu within a default time
        /// </summary>
        /// <returns>
        ///     <br>True: if everything worked fine</br>
        ///     <br>False: if an error occurred</br>
        /// </returns>
        public bool Run()
        {
            // get number of currently opened modules
            int numberOfOpenedModules = Validation.GetNumberOfOpenedModules.Run();

            // Close module
            if (CommonFlows.CloseFunction.Run(new ModuleName().Name) == false)
            {
                return false;
            }

            // Is module closed in time
            if (
                CommunicationLoader.HART.NXA820.AboutBox.Functions.ApplicationArea.MainView.Validation.ModuleOpeningAndClosing.WaitUntilModuleIsClosed(numberOfOpenedModules, DefaultValues.iTimeoutModules) == false)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is not closed in time.");
                return false;
            }

            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed.");
            return true;
        }
    }
}