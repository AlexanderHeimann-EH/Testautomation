// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckExpertResults.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Class CheckExpertResults.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.Flows
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.ConcentrationV2.Flows;
    using EH.PCPS.TestAutomation.DeviceFunctionLoader.CoDIA.ConcentrationV2.Functions.ApplicationArea.MainView;
    using EH.PCPS.TestAutomation.PrototypeHMI20.ConcentrationV2.GUI.ApplicationArea.MainView;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// Class CheckExpertResults.
    /// </summary>
    public class CheckExpertResults : ICheckExpertResults
    {
        #region Public Methods and Operators

        /// <summary>
        /// Selects each result from the combo box and takes a screenshot of the diagram
        /// </summary>
        /// <returns><c>true</c> if execution was successful, <c>false</c> otherwise.</returns>
        public bool SelectEachResultAndTakeScreenshot()
        {
            bool result = true;
            Element comboBox = new ExpertResultsElements().ComboBoxDiagram;
            Element moduleContainer = new ModuleContainerElements().ModuleContainer;

            if (comboBox == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "The combo box element is null");
                result = false;
            }
            else
            {
                Mouse.MoveTo(comboBox, 500);
                Mouse.Click(comboBox, DefaultValues.locDefaultLocation);
                IList<ListItem> listItems = (new CommonElements()).ListItemsComboBox;
                Mouse.Click(comboBox, DefaultValues.locDefaultLocation);

                if (listItems == null || listItems.Count <= 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Combo box list items are not available.");
                    result = false;
                }
                else
                {
                    foreach (ListItem item in listItems)
                    {
                        Execution.CommonMethods.SetComboBoxValue(comboBox, item.Text);
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), item.Text + " selected. Taking screenshot...");
                        Log.Screenshot(moduleContainer);
                    }

                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Selecting all available Expert results finished.");
                }
            }

            return result;
        }

        #endregion
    }
}