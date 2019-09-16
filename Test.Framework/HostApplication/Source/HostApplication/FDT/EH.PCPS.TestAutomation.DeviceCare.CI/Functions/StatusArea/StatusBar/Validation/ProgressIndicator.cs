// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressIndicator.cs" company="Endress+Hauser Process Solutions AG">
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
    public class ProgressIndicator
    {
        /// <summary>
        /// The is progress indicator available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool WaitUntilProgressIndicatorBecomesAvailable()
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
                    if (IsProgressIndicatorVisible())
                    {
                        repo.StatusArea.ProgressIndicator.MoveTo();
                        Reporting.Debug("Progress Indicator is visible.");
                        return true;
                    }
                }

                Reporting.Error(string.Format("Progress Indicator is not visible after {0} miliseconds.", Common.DefaultValues.GeneralTimeout));
                return false;
            }
            catch (Exception exception)
            {
                Reporting.Error(exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The is progress indicator available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool WaitUntilProgressIndicatorBecomesNotAvailable()
        {
            Logging.Enter(typeof(ProgressIndicator), MethodBase.GetCurrentMethod().Name);

            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                
                Reporting.Debug("Wait until Progress Indicator becomes not visible.");
                while (stopwatch.ElapsedMilliseconds < Common.DefaultValues.GeneralTimeout)
                {
                    if (!IsProgressIndicatorVisible())
                    {
                        Reporting.Debug("Progress Indicator is not visible.");
                        return true;
                    }
                }

                Reporting.Error(string.Format("Progress Indicator is still visible after {0} miliseconds.", Common.DefaultValues.GeneralTimeout));
                return false;
            }
            catch (Exception exception)
            {
                Reporting.Error(exception.Message);
                return false;
            }
        }

        /// <summary>
        /// The is progress indicator visible.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsProgressIndicatorVisible()
        {
            Logging.Enter(typeof(ProgressIndicator), MethodBase.GetCurrentMethod().Name);
            DeviceCareApplication repo = DeviceCareApplication.Instance;

            if (repo.StatusArea.ProgressIndicator.Visible)
            {
                return true;
            }
            
            return false;
        }
    }
}
