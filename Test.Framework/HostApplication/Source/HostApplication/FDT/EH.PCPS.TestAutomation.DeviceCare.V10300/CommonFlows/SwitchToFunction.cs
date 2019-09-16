// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwitchToFunction.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.CommonFlows
{
    using EH.PCPS.TestAutomation.Common;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SwitchToFunction : ISwitchToFunction
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <param name="functionToSelect">
        /// The function to select.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Run(string functionToSelect)
        {
            GUI.DeviceCareApplication deviceCareApplication = GUI.DeviceCareApplication.Instance;
            RepoItemInfo repo = deviceCareApplication.ApplicationArea.ModuleSelection.TabPagesInfo;

            System.Collections.Generic.IList<TabPage> tabPages;
            tabPages = Host.Local.Find<TabPage>(repo.AbsolutePath, DefaultValues.GeneralTimeout);
            

            foreach (var tabPage in tabPages)
            {
                Text text = tabPage.FindDescendant<Text>();
                if (text.TextValue.Equals(functionToSelect))
                {
                    tabPage.MoveTo();  
                    tabPage.Click();
                }
            }

            //string modifiedPath = repo.AbsolutePath.ToString();
            //modifiedPath = modifiedPath.Replace("MODULENAME", functionToSelect);

            //TabPage tabPage;
            //Host.Local.TryFindSingle((RxPath)modifiedPath, DefaultValues.GeneralTimeout, out tabPage);

            //if (tabPage != null && tabPage.HasFocus == false)
            //{
            //    tabPage.Focus();
            //}
                


            return false;
        }
    }
}
