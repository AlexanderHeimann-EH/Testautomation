// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleOpeningAndClosing.cs" company="PCPS">
//   Endress + Hauser
// </copyright>
// <summary>
//   The module opening and closing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using
        EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.
            Validation;

    using Ranorex.Core;

    /// <summary>
    /// The module opening and closing.
    /// </summary>
    public class ModuleOpeningAndClosing : IModuleOpeningAndClosing
    {

        #region OnlineParameterization

        /// <summary>
        /// Validates that a module is already open or not (brings module to foreground if it is already open)
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsOnlineModuleAlreadyOpened()
        {
            bool result = false;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainerOnline;
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
        public bool IsOnlineModuleClosed()
        {
            bool result = true;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainerOnline;
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
        public bool IsOnlineModuleOpened()
        {
            bool result = true;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainerOnline;
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
        public bool WaitUntilOnlineModuleIsClosed(int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            // Wait until the module container is not present anymore 
            while (this.IsOnlineModuleClosed() == false)
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
                Log.Info(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is closed after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: "
                    + timeOutInMilliseconds + " milliseconds)");
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
        public bool WaitUntilOnlineModuleIsOpen(int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            // Wait until the module container is present
            while (this.IsOnlineModuleOpened() == false)
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
                Log.Info(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is opened after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: "
                    + timeOutInMilliseconds + " milliseconds)");
            }
            else
            {
                Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is not opened after " + timeOutInMilliseconds + "Milliseconds.");
            }

            return result;
        }

        #endregion

        #region OfflineParameterization

        /// <summary>
        /// Validates that a module is already open or not (brings module to foreground if it is already open)
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsOfflineModuleAlreadyOpened()
        {
            bool result = false;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainerOffline;
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
        public bool IsOfflineModuleClosed()
        {
            bool result = true;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainerOffline;
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
        public bool IsOfflineModuleOpened()
        {
            bool result = true;
            Element moduleContainer = new GUI.ApplicationArea.MainView.ModuleContainerElements().ModuleContainerOffline;
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
        public bool WaitUntilOfflineModuleIsClosed(int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            // Wait until the module container is not present anymore 
            while (this.IsOfflineModuleClosed() == false)
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
                Log.Info(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is closed after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: "
                    + timeOutInMilliseconds + " milliseconds)");
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
        public bool WaitUntilOfflineModuleIsOpen(int timeOutInMilliseconds)
        {
            bool result = true;

            var watch = new Stopwatch();
            watch.Start();

            // Wait until the module container is present
            while (this.IsOfflineModuleOpened() == false)
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
                Log.Info(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is opened after " + watch.ElapsedMilliseconds + " milliseconds. (Timeout: "
                    + timeOutInMilliseconds + " milliseconds)");
            }
            else
            {
                Log.Error(
                    LogInfo.Namespace(MethodBase.GetCurrentMethod()),
                    "Module is not opened after " + timeOutInMilliseconds + "Milliseconds.");
            }

            return result;
        }

        #endregion
    }
}