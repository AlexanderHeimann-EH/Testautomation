// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleOpeningAndClosing.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Compare.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Functions.ApplicationArea.MainView.Validation;

    using Ranorex.Core;

    /// <summary>
    /// Provides methods for opening and closing the module
    /// </summary>
    public class ModuleOpeningAndClosing : IModuleOpeningAndClosing
    {
        /// <summary>
        /// Validates that a module is already open or not (brings module to foreground if it is already open)
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsModuleAlreadyOpened()
        {
            bool result = false;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainer;
            if (moduleContainer != null)
            {
                moduleContainer.EnsureVisible();
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Validates that a module is closed
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsModuleClosed()
        {
            bool result = true;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainer;
            if (moduleContainer != null)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Validates that a module is open
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsModuleOpened()
        {
            bool result = true;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainer;
            if (moduleContainer == null)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Wait until module is closed.
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// The time Out In Milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool WaitUntilModuleIsClosed(int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            // Wait until the module container is not present anymore 
            while (this.IsModuleClosed() == false)
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
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is closed after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            }
            else
            {
                Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is not closed after " + timeOutInMilliseconds + "Milliseconds.");
            }

            return result;
        }

        /// <summary>
        /// The wait until module is open.
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// The time out in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool WaitUntilModuleIsOpen(int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            // Wait until the module container is present
            while (this.IsModuleOpened() == false)
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
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module is opened after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: " + timeOutInMilliseconds + " milliseconds)");
            }
            else
            {
                Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is not opened after " + timeOutInMilliseconds + "Milliseconds.");
            }

            return result;
        }
    }
}