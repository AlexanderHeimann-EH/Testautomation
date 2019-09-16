//------------------------------------------------------------------------------
// <copyright file="Common.cs" company="Endress+Hauser Process Solutions AG">
//     Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>Description of file.</summary>
//------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.Functions.ApplicationArea.MainView.Execution
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.Historom.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    ///     Provides methods for settings values and modify combo boxes within module HISTOROM
    /// </summary>
    public static class Common
    {
        #region public

        /// <summary>
        ///     Set a specific control to a specific value
        /// </summary>
        /// <param name="element">control to set</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public static bool SetParameterValue(Element element, string value)
        {
            string controlType = element.GetAttributeValue("controltype").ToString();

            // TODO: 2012-11-01: ControlType an zentraler Stelle als Enum verwalten.
            switch (controlType)
            {
                case "EH.PCSW.PresentationLayer.WinFormBase.Controls.EditControl":
                    {
                        return SetTextValue(element, value);
                    }

                case "EH.PCSW.PresentationLayer.WinFormBase.Controls.ValidatedEditNumberControl":
                    {
                        return SetTextValue(element, value);
                    }

                case "EH.PCSW.PresentationLayer.WinFormBase.Controls.ComboBoxControl":
                    {
                        return SetComboBoxValue(element, value);
                    }

                default:
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Unknown ControlType [" + controlType + "].");
                        return false;
                    }
            }
        }

        /// <summary>
        ///     Get value of a specific control
        /// </summary>
        /// <param name="element">control to get the value from</param>
        /// <returns>
        ///     <br>String: if everything worked fine</br>
        ///     <br>Empty String: if an error occurred</br>
        /// </returns>
        public static string GetParameterValue(Element element)
        {
            if (element != null && element.Enabled)
            {
                return element.GetAttributeValue("text").ToString();
            }

            return string.Empty;
        }

        /// <summary>
        ///     Set a text control to a specified value
        /// </summary>
        /// <param name="element">parameter to set</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public static bool SetTextValue(Element element, string value)
        {
            if (element != null && element.Enabled)
            {
                Mouse.MoveTo(element, 500);
                element.SetAttributeValue("text", value);
                return true;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Text is not available.");
            return false;
        }

        /// <summary>
        ///     Set a combo box control to a specified value
        /// </summary>
        /// <param name="element">parameter to set</param>
        /// <param name="value">value to set</param>
        /// <returns>
        ///     <br>True: if parameter was set</br>
        ///     <br>Null: if an error occurred</br>
        /// </returns>
        public static bool SetComboBoxValue(Element element, string value)
        {
            if (element != null && element.Enabled)
            {
                Mouse.MoveTo(element, 500);
                Mouse.Click(element, DefaultValues.locDefaultLocation);
                IList<ListItem> listItems = (new CommonElements()).ListItemsComboBox;
                if (listItems != null && listItems.Count > 0)
                {
                    bool itemFound = false;
                    foreach (ListItem listItem in listItems)
                    {
                        if (!listItem.Text.Equals(value) || itemFound)
                        {
                            continue;
                        }

                        listItem.Click(DefaultValues.locDefaultLocation);
                        itemFound = true;
                    }

                    if (itemFound == false)
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItem is not available.");
                        return false;
                    }

                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ListItems are not available.");
                return false;
            }

            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "ComboBox is not available.");
            return false;
        }

        #endregion
    }
}