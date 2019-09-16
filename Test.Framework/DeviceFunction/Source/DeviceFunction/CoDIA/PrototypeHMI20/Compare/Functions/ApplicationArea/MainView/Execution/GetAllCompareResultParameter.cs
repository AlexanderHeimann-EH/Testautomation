// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAllCompareResultParameter.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright (c) Endress+Hauser Process Solutions AG. All rights reserved.
// </copyright>
// <summary>
//   Class GetAllCompareResultParameter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Compare.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Compare.GUI.ApplicationArea.MainView;

    using Ranorex;

    /// <summary>
    /// Class GetAllCompareResultParameter.
    /// </summary>
    public class GetAllCompareResultParameter : IGetAllCompareResultParameter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Navigates through the Compare results tree and stores every parameter in a list. A parameter contains its name, the offline and online value.
        /// </summary>
        /// <returns>A list containing the Compare result parameter.</returns>
        public List<CompareParameter> Run()
        {
            try
            {
                var result = new List<CompareParameter>();
                IList<TreeItem> list = new ResultListTreeElements().ResultLisTreeItems;

                if (list.Count == 0)
                {
                    Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "List is empty.");
                }
                else
                {
                    foreach (TreeItem item in list)
                    {
                        item.Click();

                        // Get the children cells of each tree item which represent the offline and online values.   
                        var parameterNameCell = item.Children[0].Element;
                        var offlineValueCell = item.Children[1].Element;
                        var onlineValueCell = item.Children[2].Element;
                        string parameterName = parameterNameCell.GetAttributeValueText("accessiblevalue");
                        string offlineValue = offlineValueCell.GetAttributeValueText("accessiblevalue");
                        string onlineValue = onlineValueCell.GetAttributeValueText("accessiblevalue");

                        if (offlineValue == null && onlineValue == null)
                        {
                            // This tree item is a folder not a parameter -> double click to expand
                            item.DoubleClick();
                        }
                        else
                        {
                            // Item is a parameter just store it
                            result.Add(new CompareParameter(parameterName, offlineValue, onlineValue));
                        }

                        Keyboard.Press(System.Windows.Forms.Keys.Down);
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                var result = new List<CompareParameter>();
                return result;
            }
        }

        #endregion
    }
}