// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdditionalFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.Common.Tools.Logging;
    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Ranorex;
    using Ranorex.Core;

    /// <summary>
    /// The program functions.
    /// </summary>
    public static class AdditionalFunctions
    {
        /// <summary>
        /// The open program functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenMenu()
        {
            Log.Enter(typeof(AdditionalFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            MenuItem menuItem;
            Host.Local.TryFindSingle(repo.MenuArea.MainMenu.AdditionalFunctionsInfo.AbsolutePath, out menuItem);
            if (menuItem != null && menuItem.Visible)
            {
                menuItem.Click();
                Common.Tools.Log.Debug("Menu item Additional Functions found and clicked.");
                return true;
            }

            Common.Tools.Log.Error("Could not access menu Additional Functions.");
            return false;
        }

        /// <summary>
        /// The open additional function.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenAdditionalFunction(string functionName)
        {
            Log.Enter(typeof(AdditionalFunctions), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                Text text;
                string path = repo.MenuArea.MainMenu.AdditionalFunctionMenuItems.MenuItemInfo.AbsolutePath.ToString();
                path = path.Replace("MODULENAME", functionName);
                RxPath ranorexPath = path;
                Host.Local.TryFindSingle(ranorexPath, Common.DefaultValues.GeneralTimeout, out text);
                if (text != null && text.Visible)
                {
                    text.Click();
                    Common.Tools.Log.Debug(string.Format("Menu item {0} found and clicked.", functionName));
                    return true;
                }    
            }

            Common.Tools.Log.Error(string.Format("Could not access menu item {0}.", functionName));
            return false;
        }

        /// <summary>
        /// The close additional function.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CloseAdditionalFunction(string functionName)
        {
            Log.Enter(typeof(AdditionalFunctions), MethodBase.GetCurrentMethod().Name);

            return DtmFunctions.CloseDtmFunction(functionName);
        }
    }
}
