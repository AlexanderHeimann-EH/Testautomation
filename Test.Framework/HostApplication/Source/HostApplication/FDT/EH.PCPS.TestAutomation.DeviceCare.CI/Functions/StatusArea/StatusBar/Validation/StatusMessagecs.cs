// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusMessagecs.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.StatusArea.StatusBar.Validation
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The progress indicator.
    /// </summary>
    public class StatusMessage
    {
        /// <summary>
        /// The wait until status message becomes available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool WaitUntilStatusMessageBecomesAvailable()
        {
            Logging.Enter(typeof(ProgressIndicator), MethodBase.GetCurrentMethod().Name);

            try
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                repo.StatusArea.ProgressIndicatorInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
                Reporting.Debug("Progress Indicator is available.");
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while (stopwatch.ElapsedMilliseconds < Common.DefaultValues.GeneralTimeout)
                {
                    if (IsStatusMessageAvailable())
                    {
                        repo.StatusArea.ProgressIndicator.MoveTo();
                        Reporting.Debug("Status Message is available.");
                        return true;
                    }
                }

                Reporting.Error(string.Format("Status Message is not available after {0} miliseconds.", Common.DefaultValues.GeneralTimeout));
                return false;
            }
            catch (Exception exception)
            {
                Reporting.Error(exception.Message);
                return false;
            }
        }

        ///// <summary>
        ///// The wait until status message becomes not available.
        ///// </summary>
        ///// <returns>
        ///// The <see cref="bool"/>.
        ///// </returns>
        //public static bool WaitUntilStatusMessageBecomesNotAvailable()
        //{
        //    Logging.Enter(typeof(ProgressIndicator), MethodBase.GetCurrentMethod().Name);

        //    try
        //    {
        //        Stopwatch stopwatch = new Stopwatch();
        //        stopwatch.Start();

        //        Reporting.Debug("Wait until Message  becomes not visible.");
        //        while (stopwatch.ElapsedMilliseconds < Common.DefaultValues.GeneralTimeout)
        //        {
        //            if (!IsProgressIndicatorVisible())
        //            {
        //                Reporting.Debug("Progress Indicator is not visible.");
        //                return true;
        //            }
        //        }

        //        Reporting.Error(string.Format("Progress Indicator is still visible after {0} miliseconds.", Common.DefaultValues.GeneralTimeout));
        //        return false;
        //    }
        //    catch (Exception exception)
        //    {
        //        Reporting.Error(exception.Message);
        //        return false;
        //    }
        //}

        /// <summary>
        /// The is progress indicator visible.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsStatusMessageAvailable()
        {
            Logging.Enter(typeof(ProgressIndicator), MethodBase.GetCurrentMethod().Name);
            DeviceCareApplication repo = DeviceCareApplication.Instance;

            if (repo.StatusArea.StatusBarTextInfo.Exists())
            {
                if (repo.StatusArea.StatusBarText.ScreenRectangle.Height > 0 && repo.StatusArea.StatusBarText.ScreenRectangle.Width > 0)
                {
                    return true;    
                }

                return false;
            }

            return false;
        }
    }
}
