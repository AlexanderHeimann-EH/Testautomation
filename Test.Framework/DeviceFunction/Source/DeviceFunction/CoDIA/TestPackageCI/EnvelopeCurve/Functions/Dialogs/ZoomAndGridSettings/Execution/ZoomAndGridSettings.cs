// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoomAndGridSettings.cs" company="Process Solutions AG">
//   Endress + Hauser Process Solutions AG
// </copyright>
// <summary>
//   Description of ReadSettings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurve.Functions.Dialogs.ZoomAndGridSettings.Execution
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Functions.Dialogs.ZoomAndGridSettings.Execution;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurve.GUI.Dialogs;

    using Ranorex;

    /// <summary>
    ///     Description of ReadSettings.
    /// </summary>
    public class ZoomAndGridSettings : IZoomAndGridSettings
    {
        /// <summary>
        ///  Gets the xMax unit of zoom area.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public string XMaxUnit
        {
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
            get
            {
                string pattern = "[\\[\\]]";
                Text xMaxUnit = (new ZoomAndGridSettingsElements()).ZoomAreaXMaxUnit;
                var regex = new Regex(pattern, RegexOptions.None);
                return regex.Replace(xMaxUnit.TextValue, string.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the x max.
        /// </summary>
        public double XMax
        {
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
                Justification = "Reviewed. Suppression is OK here.")]
            get
            {
                Text xMax = (new ZoomAndGridSettingsElements()).ZoomAreaXMaxText;
                return Convert.ToDouble(xMax.TextValue);
            }

            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation",
                Justification = "Reviewed. Suppression is OK here.")]
            set
            {
                Text xMax = (new ZoomAndGridSettingsElements()).ZoomAreaXMaxText;
                xMax.PressKeys(value.ToString(CultureInfo.InvariantCulture), 100);
            }
        }

        /// <summary>
        ///  Gets the xMin Unit of zoom area.
        /// </summary>
        /// <returns>
        ///     <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public string XMinUnit
        {
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
            get
            {
                string pattern = "[\\[\\]]";
                Text xMinUnit = (new ZoomAndGridSettingsElements()).ZoomAreaXMinUnit;
                var regex = new Regex(pattern, RegexOptions.None);
                return regex.Replace(xMinUnit.TextValue, string.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the x min of the zoom area
        /// </summary>
        public double XMin
        {
            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
            get
            {
                Text xMin = (new ZoomAndGridSettingsElements()).ZoomAreaXMinText;
                return Convert.ToDouble(xMin.TextValue);
            }

            [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
            set
            {
                Text xMin = (new ZoomAndGridSettingsElements()).ZoomAreaXMinText;
                xMin.PressKeys(value.ToString(CultureInfo.InvariantCulture), 100);
            }
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
            Button button = (new ZoomAndGridSettingsElements()).Ok;
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
            Button button = (new ZoomAndGridSettingsElements()).Cancel;
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
            Button button = (new ZoomAndGridSettingsElements()).Close;
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