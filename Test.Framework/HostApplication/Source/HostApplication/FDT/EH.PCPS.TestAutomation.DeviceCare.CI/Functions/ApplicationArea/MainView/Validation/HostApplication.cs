// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HostApplication.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Validation
{
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools.Logging;

    /// <summary>
    /// The host application.
    /// </summary>
    public static class HostApplication
    {
        /// <summary>
        /// The process name.
        /// </summary>
        private const string ProcessName = "DeviceCareSfe100";

        /// <summary>
        /// The is host application open.
        /// </summary>
        /// <param name="processName">
        /// The process Name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsHostApplicationOpen(string processName = ProcessName)
        {
            Log.Enter(typeof(HostApplication), MethodBase.GetCurrentMethod().Name);

            GUI.DeviceCareApplication deviceCareApplication = GUI.DeviceCareApplication.Instance;
            Ranorex.Core.Repository.RepoItemInfo repoItemInfo = deviceCareApplication.MenuArea.MainMenu.MainMenuItems.ButtonExitInfo;
            
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process.ProcessName.Equals(processName))
                {
                    if (repoItemInfo.Exists())
                    {
                        Common.Tools.Log.Debug("Device Care is running.");
                        return true;    
                    }
                }
            }

            Common.Tools.Log.Debug("Device Care is not running.");
            return false;
        }

        /// <summary>
        /// The is host application open.
        /// </summary>
        /// <param name="processId">
        /// The process id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsHostApplicationOpen(int processId)
        {
            Log.Enter(typeof(HostApplication), MethodBase.GetCurrentMethod().Name);
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process.Id.Equals(processId))
                {
                    Common.Tools.Log.Debug("Device Care is running.");
                    return true;
                }
            }

            Common.Tools.Log.Debug("Device Care is not running.");
            return false;
        }

        /// <summary>
        /// The is host application closed.
        /// </summary>
        /// <param name="processName">
        /// The process Name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsHostApplicationClosed(string processName = ProcessName)
        {
            Log.Enter(typeof(HostApplication), MethodBase.GetCurrentMethod().Name);
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process.ProcessName.Equals(processName))
                {
                    return false;
                }
            }

            Common.Tools.Log.Debug("Device Care is closed.");
            return true;
        }

        /// <summary>
        /// The is host application open.
        /// </summary>
        /// <param name="processId">
        /// The process id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsHostApplicationClosed(int processId)
        {
            Log.Enter(typeof(HostApplication), MethodBase.GetCurrentMethod().Name);
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process.Id.Equals(processId))
                {
                    return false;
                }
            }

            Common.Tools.Log.Debug("Device Care is closed.");
            return true;
        }

        /// <summary>
        /// The wait until host application opened.
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// The time out in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool WaitUntilHostApplicationOpened(int timeOutInMilliseconds = Common.DefaultValues.GeneralTimeout)
        {
            Log.Enter(typeof(HostApplication), MethodBase.GetCurrentMethod().Name);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.ElapsedMilliseconds <= timeOutInMilliseconds)
            {
                if (IsHostApplicationOpen())
                {
                    Common.Tools.Log.Debug(string.Format("Device Care is opened in time {0}/{1}{2}", stopwatch.ElapsedMilliseconds, timeOutInMilliseconds, "ms"));
                    return true;
                }
            }
            
            Common.Tools.Log.Error(string.Format("Device Care is not opened in time {0}{1}", timeOutInMilliseconds, "ms"));
            return false;
        }

        /// <summary>
        /// The wait until host application closed.
        /// </summary>
        /// <param name="timeOutInMilliseconds">
        /// The time out in milliseconds.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool WaitUntilHostApplicationClosed(int timeOutInMilliseconds = Common.DefaultValues.GeneralTimeout)
        {
            Log.Enter(typeof(HostApplication), MethodBase.GetCurrentMethod().Name);
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.ElapsedMilliseconds <= timeOutInMilliseconds)
            {
                if (IsHostApplicationClosed())
                {
                    Common.Tools.Log.Debug(string.Format("Device Care is closed in time {0}/{1}{2}", stopwatch.ElapsedMilliseconds, timeOutInMilliseconds, "ms"));
                    return true;
                }
            }

            Common.Tools.Log.Error(string.Format("Device Care is not closed in time {0}{1}", timeOutInMilliseconds, "ms"));
            return false;
        }
    }
}
