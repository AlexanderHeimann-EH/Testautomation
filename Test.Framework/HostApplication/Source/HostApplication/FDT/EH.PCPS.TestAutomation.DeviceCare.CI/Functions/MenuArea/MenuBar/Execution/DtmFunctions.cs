// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtmFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Execution
{
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.Functions.ApplicationArea.MainView.Helpers;
    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Ranorex;
    using Ranorex.Core;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The program functions.
    /// </summary>
    public static class DtmFunctions
    {
        /// <summary>
        /// The open program functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenMenu()
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            MenuItem menuItem;

            bool result;
            Host.Local.TryFindSingle(repo.MenuArea.MainMenu.DTMFunctionsInfo.AbsolutePath, out menuItem);
            if (menuItem != null && menuItem.Visible)
            {
                menuItem.Click();
                Reporting.Debug("Menu item DTM Functions found and clicked.");

                if (Validation.DtmFunctions.IsMenuItemAvailable())
                {
                    result = true;
                }
                else
                {
                    result = false;    
                }
            }
            else
            {
                Reporting.Error("Could not access menu DTM Functions.");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// The open dtm function.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenDtmFunction(string functionName)
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                Text text;
                string path = repo.MenuArea.MainMenu.DTMFunctionMenuItems.MenuItemInfo.AbsolutePath.ToString();
                path = path.Replace("MODULENAME", functionName);
                RxPath ranorexPath = path;
                Host.Local.TryFindSingle(ranorexPath, Common.DefaultValues.GeneralTimeout, out text);
                if (text != null && text.Visible)
                {
                    text.Click();
                    Reporting.Debug(string.Format("Menu item {0} found and clicked.", functionName));
                    return true;
                }
            }

            Reporting.Error(string.Format("Could not access menu item {0}.", functionName));
            return false;
        }

        /// <summary>
        /// The close dtm function.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CloseDtmFunction(string functionName)
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);

            bool result = true;
            if (!DeviceCareModuleFunctions.IsClosingElementAvailable())
            {
                Reporting.Debug("Cannot close module this way.");
                Reporting.Debug("Open and close another module to make close button available.");
                string helperFunctionName = ProgramFunctions.OpenShowProgress();
                if (helperFunctionName.Equals(string.Empty))
                {
                    result = false;
                }

                result &= AdditionalFunctions.CloseAdditionalFunction(helperFunctionName);
            }

            Reporting.Debug(string.Format("Select module {0}.", functionName));
            result &= SelectDtmFunctions(functionName);
            Reporting.Debug(string.Format("Close module {0}.", functionName));
            result &= CloseTabPage(functionName);
            return result;
        }

        /// <summary>
        /// The select dtm functions.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool SelectDtmFunctions(string functionName)
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            TabPage tabPage;
            string path = repo.ApplicationArea.ModuleSelection.ModuleTabPageInfo.AbsolutePath.ToString();
            path = path.Replace("MODULENAME", functionName);
            RxPath ranorexPath = path;
            Host.Local.TryFindSingle(ranorexPath, out tabPage);
            if (tabPage != null)
            {
                tabPage.Select();
                Reporting.Debug(string.Format("Module {0} found and selected.", functionName));
                return true;
            }

            Reporting.Error(string.Format("Could not find module {0} to select.", functionName));
            return false;
        }

        /// <summary>
        /// The close tab page.
        /// </summary>
        /// <param name="functionName">
        /// The function name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CloseTabPage(string functionName)
        {
            Logging.Enter(typeof(DtmFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            Button button;
            string path = repo.ApplicationArea.ModuleSelection.ModuleCloseButtonInfo.AbsolutePath.ToString();
            path = path.Replace("MODULENAME", functionName);
            RxPath ranorexPath = path;
            Host.Local.TryFindSingle(ranorexPath, out button);
            if (button != null)
            {
                button.Press();
                Reporting.Debug(string.Format("Module {0} close button found and pressed.", functionName));
                return true;
            }

            Reporting.Error(string.Format("Could not access module {0} close button.", functionName));
            return false;
        }
    }
}
