// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeviceCareModuleFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Helpers
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools.Logging;
    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Ranorex;

    /// <summary>
    /// This class provides function to close a singular module, which normaly cannot be closed because there is no close button
    /// </summary>
    public static class DeviceCareModuleFunctions
    {
        /// <summary>
        /// The is closing element available.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsClosingElementAvailable()
        {
            Log.Enter(typeof(DeviceCareModuleFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            TabPageList tabPageList;
            Host.Local.TryFindSingle(repo.ApplicationArea.ModuleSelection.ModuleTabPageListInfo.AbsolutePath, out tabPageList);
            if (tabPageList != null)
            {
                if (tabPageList.Children.Count > 0)
                {
                    if (tabPageList.Children[0].Children.Count > 1)
                    {
                        Common.Tools.Log.Debug("Gui Control for closing is available.");
                        return true;    
                    }
                }
            }

            Common.Tools.Log.Debug("There is no Gui Control for closing available.");
            return false;
        }

        /// <summary>
        /// The is function opened.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static Text IsFunctionOpened(string functionName)
        {
            Log.Enter(typeof(DeviceCareModuleFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            IList<Text> tabPageTextList;
            tabPageTextList = Host.Local.Find<Text>(repo.ApplicationArea.ModuleSelection.ModuleTabPagesTextInfo.AbsolutePath);
            if (tabPageTextList != null)
            {
                if (tabPageTextList.Count > 0)
                {
                    foreach (var text in tabPageTextList)
                    {
                        if (text.TextValue.Equals(functionName))
                        {
                            return text;
                        }
                    }
                }

                return null;
            }

            return null;
        }
    }
}
