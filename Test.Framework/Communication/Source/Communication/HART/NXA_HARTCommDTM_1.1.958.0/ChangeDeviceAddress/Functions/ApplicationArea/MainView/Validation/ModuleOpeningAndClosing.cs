//------------------------------------------------------------------------------
// <copyright file="ModuleOpeningAndClosing.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.NXA_HARTCommDTM.V119580.ChangeDeviceAddress.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommunicationInterfaces.HART.NXA820.ChangeDeviceAddress.Functions.ApplicationArea.MainView.Validation;

    using Ranorex;

    /// <summary>
    /// The module opening and closing.
    /// </summary>
    public class ModuleOpeningAndClosing : IModuleOpeningAndClosing
    {
        /// <summary>
        ///     Check if number of opened modules has decreased
        /// </summary>
        /// <param name="moduleName">Name of module to check</param>
        /// <returns>
        ///     <br>True: if module is already open</br>
        ///     <br>False: if module is not already opened</br>
        /// </returns>
        public bool IsModuleAlreadyOpened(string moduleName)
        {
            return
                HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation.IsModuleAlreadyOpened
                                     .Run(moduleName);
        }

        /// <summary>
        ///     Check if number of opened modules has decreased
        /// </summary>
        /// <param name="numberOfOpenedModules">Number of already opened modules</param>
        /// <returns>
        ///     <br>True: if module is open</br>
        ///     <br>False: if module is not open</br>
        /// </returns>
        public bool IsModuleClosed(int numberOfOpenedModules)
        {
            return HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation
                                        .GetNumberOfOpenedModules.Run() == numberOfOpenedModules - 1;
        }

        /// <summary>
        ///     Check if number of opened modules has increased
        /// </summary>
        /// <param name="numberOfOpenedModules">Number of already opened modules</param>
        /// <returns>
        ///     <br>True: if module is open</br>
        ///     <br>False: if module is not open</br>
        /// </returns>
        public bool IsModuleOpened(int numberOfOpenedModules)
        {
            return HostApplicationLoader.FDT.FieldCare.Functions.ApplicationArea.MainView.Validation
                                        .GetNumberOfOpenedModules.Run() == numberOfOpenedModules + 1;
        }

        /// <summary>
        /// Validation if module is closed within a specified time
        /// </summary>
        /// <param name="numberOfOpenedModules">
        /// Number of already opened modules
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time within module must be closed
        /// </param>
        /// <returns>
        /// <br>True: if module is closed</br>
        ///     <br>False: if module is not closed</br>
        /// </returns>
        public bool WaitUntilModuleIsClosed(int numberOfOpenedModules, int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            // check if number of open modules has increased
            while (this.IsModuleClosed(numberOfOpenedModules) == false)
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                result = false;
                break;
            }

            watch.Stop();

            if (result)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed.");
            }
            else
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is not closed after " + timeOutInMilliseconds + "Milliseconds.");
            }

            return result;
        }

        /// <summary>
        /// Validation if module is opened within a specified time
        /// </summary>
        /// <param name="numberOfOpenedModules">
        /// Number of already opened modules
        /// </param>
        /// <param name="timeOutInMilliseconds">
        /// Time within module should be opened
        /// </param>
        /// <returns>
        /// <br>True: if module is opened in time</br>
        ///     <br>False: if module is not opened in time</br>
        /// </returns>
        public bool WaitUntilModuleIsOpen(int numberOfOpenedModules, int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            // check if number of open modules has increased
            while (this.IsModuleOpened(numberOfOpenedModules) == false)
            {
                if (watch.ElapsedMilliseconds <= timeOutInMilliseconds)
                {
                    continue;
                }

                result = false;
                break;
            }

            watch.Stop();

            if (result)
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is opened.");
            }
            else
            {
                EH.PCPS.TestAutomation.Common.Tools.Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is not opened after " + timeOutInMilliseconds + "Milliseconds.");
            }

            return result;
        }
    }
}