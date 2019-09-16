// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadSettings.cs" company="Process Solutions AG">
//  Endress + Hauser Process Solutions AG 
// </copyright>
// <summary>
//   Description of ReadSettings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.Functions.Dialogs.ReadSettings.Execution
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Functions.Dialogs.ReadSettings.Execution;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.EnvelopeCurve.GUI.Dialogs;

    using Ranorex;

    /// <summary>
    ///     Description of ReadSettings.
    /// </summary>
    public class ReadSettings : IReadSettings
    {
        /// <summary>
        /// Gets or sets the resolution.
        /// </summary>
        public double Resolution
        {
            // TODO: Under Construction
            get
            {
                Slider slider = (new ReadSettingsElements()).Resolution;
                return slider.Value;
            }

            set
            {
                Slider slider = (new ReadSettingsElements()).Resolution;
                if (value < slider.MinValue)
                {
                    slider.Value = slider.MinValue;
                }
                else if (value > slider.MaxValue)
                {
                    slider.Value = slider.MaxValue;
                }
                else
                {
                    slider.Value = value;
                }
            }
        }

        /// <summary>
        /// Gets the begin range unit.
        /// </summary>
        public string BeginRangeUnit
        {
            get
            {
                string pattern = "[\\[\\]]";
                Text beginRangeUnit = (new ReadSettingsElements()).BeginRangeUnit;
                var regex = new Regex(pattern, RegexOptions.None);
                return regex.Replace(beginRangeUnit.TextValue, string.Empty);
            }
        }

        /// <summary>
        /// Gets the end range unit.
        /// </summary>
        public string EndRangeUnit
        {
            get
            {
                string pattern = "[\\[\\]]";
                Text endRangeUnit = (new ReadSettingsElements()).EndRangeUnit;
                var regex = new Regex(pattern, RegexOptions.None);
                return regex.Replace(endRangeUnit.TextValue, string.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the edit begin range.
        /// </summary>
        public double EditBeginRange
        {
            get
            {
                Text beginRage = (new ReadSettingsElements()).BeginRangeText;
                return Convert.ToDouble(beginRage.TextValue);
            }

            set
            {
                Text beginRage = (new ReadSettingsElements()).BeginRangeText;
                beginRage.PressKeys(value.ToString(CultureInfo.InvariantCulture), 100);
            }
        }

        /// <summary>
        /// Gets or sets the edit end rage.
        /// </summary>
        public double EditEndRage
        {
            get
            {
                Text endRage = (new ReadSettingsElements()).EndRangeText;
                return Convert.ToDouble(endRage.TextValue);
            }

            set
            {
                Text endRage = (new ReadSettingsElements()).EndRangeText;
                endRage.PressKeys(value.ToString(CultureInfo.InvariantCulture), 100);
            }
        }

        /// <summary>
        ///     Check curves which should be read
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool CheckAllCurves()
        {
            // TODO: Not implemented
            return false;
        }

        /// <summary>
        ///     Check curves which should not be read
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool UncheckAllCurves()
        {
            // TODO: Not implemented
            return false;
        }

        /// <summary>
        ///     Confirm settings and start to read immediately. Dialog is closed.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool ReadNow()
        {
            Button button = (new ReadSettingsElements()).ReadNow;
            if (button != null && button.Enabled)
            {
                button.Click(DefaultValues.locDefaultLocation);
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessable");
            return false;
        }

        /// <summary>
        ///     Confirm settings. Dialog is closed.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Confirm()
        {
            Button button = (new ReadSettingsElements()).Ok;
            if (button != null && button.Enabled)
            {
                button.Click(DefaultValues.locDefaultLocation);
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessable");
            return false;
        }

        /// <summary>
        ///     Cancel settings. Changes are lost. Dialog is closed.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Cancel()
        {
            Button button = (new ReadSettingsElements()).Cancel;
            if (button != null && button.Enabled)
            {
                button.Click(DefaultValues.locDefaultLocation);
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessable");
            return false;
        }

        /// <summary>
        ///     Cancel settings. Changes are lost. Dialog is closed.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Close()
        {
            Button button = (new ReadSettingsElements()).Close;
            if (button != null && button.Enabled)
            {
                button.Click(DefaultValues.locDefaultLocation);
                return true;
            }

            EH.PCPS.TestAutomation.Common.Tools.Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button is not accessable");
            return false;
        }
    }
}