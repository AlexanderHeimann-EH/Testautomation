// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetParameterInText.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Provides functionality to set parameter for different control types
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.CDICommDTMTCPIP.V20700.Functions.ApplicationArea.Execution
{
    using System.Reflection;
    using System.Windows.Forms;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Provides functionality to set parameter for different control types
    /// </summary>
    public class SetParameterInText
    {
        /// <summary>
        /// Set a specific control to a specific value
        /// </summary>
        /// <param name="element">The control to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>
        ///     <br>True: if value was set</br>
        ///     <br>False: if value could not be set</br>
        /// </returns>
        public static bool SetParameterValue(Element element, string value)
        {
            if (element == null || value == string.Empty)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element is null or value is empty");
                return false;
            }

            return SetTextValue(element, value);
        }

        /// <summary>
        ///     Set a comboBox control to a specified value
        /// </summary>
        /// <param name="element">parameter to set</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        private static bool SetTextValue(Element element, string value)
        {
            if (element != null && element.Enabled)
            {
                Mouse.MoveTo(element, 500);
                Mouse.Click(element, DefaultValues.locDefaultLocation);
                ((Text)element).TextValue = value;
                Keyboard.Press(Keys.Enter);
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not accessible.");
            return false;
        }
    }
}
