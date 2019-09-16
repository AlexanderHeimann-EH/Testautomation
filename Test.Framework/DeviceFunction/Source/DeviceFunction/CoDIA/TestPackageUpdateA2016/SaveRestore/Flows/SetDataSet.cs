// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetDataSet.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of SetDataSet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.Flows
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.SaveRestore.Flows;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2016.SaveRestore.Functions.MenuArea.Toolbar.Execution;

    using Ranorex;

    /// <summary>
    ///     Description of SetDataSet.
    /// </summary>
    public class SetDataSet : MarshalByRefObject, ISetDataSet
    {
        #region Public Methods and Operators

        /// <summary>
        /// Set dataset to a specific dataset
        /// </summary>
        /// <param name="datasetlabel">
        /// Name of dataset
        /// </param>
        /// <returns>
        /// <br>True: If call worked fine</br>
        ///     <br>False: If an error occurred</br>
        /// </returns>
        public bool Run(string datasetlabel)
        {
            try
            {
                if (new SetFocusOnDataSet().Run())
                {
                    IList<ListItem> datasetlist = Host.Local.Find<ListItem>("/form[@title='' and @processname='FMPFrame']/element[@controltypename='GuiComboBoxEditListBox']/list/listItem", 10000);
                    foreach (ListItem listItem in datasetlist)
                    {
                        string datasettext = listItem.Text;
                        if (datasettext == datasetlabel)
                        {
                            listItem.Click();
                        }
                    }

                    return true;
                }

                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Element was not focused");
                return false;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }

        #endregion
    }
}