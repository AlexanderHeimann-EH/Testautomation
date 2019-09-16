// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Functions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions
{
    using System.Diagnostics;

    using EH.PCPS.TestAutomation.DeviceCare.V10300.GUI;

    using Ranorex;
    using Ranorex.Core;
    using Ranorex.Core.Repository;
    using Ranorex.Plugin;

    /// <summary>
    /// The device care rx path test.
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// The currentselection.
        /// </summary>
        private static WpfTreeSelection currentWpfSelection;

        /// <summary>
        /// Initializes static members of the <see cref="Functions"/> class.
        /// </summary>
        static Functions()
        {
            SaveRanorexWpfConfiguration();
        }

        /// <summary>
        /// The open program functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenMenuProgramFunctions()
        {
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsInfo;
            return OpenMenuItem(GetMenuItem(repoItemInfo));
        }

        /// <summary>
        /// The open submenu toggle online offline.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuToggleOnlineOffline()
        {
            if (OpenMenuProgramFunctions())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ToggleOnlineInfo;
                return OpenMenuItem(GetMenuItem(repoItemInfo));
            }

            return false;
        }

        /// <summary>
        /// The open submenu read from device.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuReadFromDevice()
        {
            if (OpenMenuProgramFunctions())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ReadFromDeviceInfo;
                return OpenMenuItem(GetMenuItem(repoItemInfo));
            }

            return false;
        }

        /// <summary>
        /// The open submenu write to device.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuWriteToDevice()
        {
            if (OpenMenuProgramFunctions())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.WriteToDeviceInfo;
                return OpenMenuItem(GetMenuItem(repoItemInfo));
            }

            return false;
        }

        /// <summary>
        /// The open submenu save device data.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuSaveDeviceData()
        {
            if (OpenMenuProgramFunctions())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.SaveDeviceDataInfo;
                return OpenMenuItem(GetMenuItem(repoItemInfo));
            }

            return false;
        }

        /// <summary>
        /// The open submenu restore device data.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuRestoreDeviceData()
        {
            if (OpenMenuProgramFunctions())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.RestoreDeviceDataInfo;
                return OpenMenuItem(GetMenuItem(repoItemInfo));
            }

            return false;
        }

        /// <summary>
        /// The open submenu browse for device data.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuBrowseForDeviceData()
        {
            // if (OpenSubmenuRestoreDeviceData())
            // {
            //    DeviceCareApplication repo = DeviceCareApplication.Instance;
            //    RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.RestoreBrowseInfo;
            //    return OpenMenuItem(GetMenuItem(repoItemInfo));
            // }
            Report.Warn("This function is not supported.");
            return false;
        }

        /// <summary>
        /// The open submenu additional functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuAdditionalFunctions()
        {
            if (OpenMenuProgramFunctions())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.AdditionalFunctionsInfo;
                return OpenMenuItem(GetMenuItem(repoItemInfo));
            }

            return false;
        }

        /// <summary>
        /// The open submenu show progress.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuShowProgress()
        {
            // if (OpenSubmenuAdditionalFunctions())
            // {
            //    DeviceCareApplication repo = DeviceCareApplication.Instance;
            //    RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ShowProgressInfo;
            //    return OpenMenuItem(GetMenuItem(repoItemInfo));
            // }
            Report.Warn("This function is not supported.");
            return false;
        }

        /// <summary>
        /// The open dtm functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenMenuDtmFunctions()
        {
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.DTMFunctionsInfo;
            return OpenMenuItem(GetMenuItem(repoItemInfo));
        }

        /// <summary>
        /// The open submenu offline parameterize.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuOfflineParameterize()
        {
            if (OpenMenuDtmFunctions())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.DTMFunctionMenuItems.OfflineParameterizationInfo;
                return OpenMenuItem(GetMenuItem(repoItemInfo));
            }

            return false;
        }

        /// <summary>
        /// The open submenu online parameterize.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSubmenuOnlineParameterize()
        {
            if (OpenMenuDtmFunctions())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.DTMFunctionMenuItems.OnlineParameterizationInfo;
                return OpenMenuItem(GetMenuItem(repoItemInfo));
            }

            return false;
        }

        /// <summary>
        /// The open menu additional functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenMenuAdditionalFunctions()
        {
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.AdditionalFunctionsInfo;
            return OpenMenuItem(GetMenuItem(repoItemInfo));
        }

        /// <summary>
        /// The device report.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenMenuDeviceReport()
        {
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.MenuArea.MainMenu.DeviceReportInfo;
            return OpenMenuItem(GetMenuItem(repoItemInfo));
        }

        /// <summary>
        /// The menu test.
        /// </summary>
        public static void MenuTestProgramFunctions()
        {
            SaveRanorexWpfConfiguration();
            RestoreRanorexUiaConfiguration();
        }

        /// <summary>
        /// The open specific additional module.
        /// </summary>
        /// <param name="moduleToOpen">
        /// The module to open.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenSpecificAdditionalModule(string moduleToOpen)
        {
            DeviceCareApplication repo1 = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo1.MenuArea.MainMenu.AdditionalFunctionsInfo;
            if (OpenMenuItem(GetMenuItem(repoItemInfo)))
            {
                DeviceCareApplication deviceCareApplication = DeviceCareApplication.Instance;
                RepoItemInfo repo = deviceCareApplication.MenuArea.MainMenu.AdditionalFunctionMenuItems.MenuItemInfo;
                string modifiedPath = repo.AbsolutePath.ToString().Replace("MODULENAME", moduleToOpen);

                Text text;
                Host.Local.TryFindSingle(modifiedPath, 5000, out text);
                if (text != null && text.Enabled)
                {
                    text.Click();

                    var watch = new Stopwatch();
                    watch.Start();

                    // Wait until module is visible at tabpage
                    while (IsModuleOpen(moduleToOpen) == false)
                    {
                        if (watch.ElapsedMilliseconds <= Common.DefaultValues.GeneralTimeout)
                        {
                            continue;
                        }

                        Report.Failure("Module is not opend within time", moduleToOpen + "(" + watch.ElapsedMilliseconds + "/" + Common.DefaultValues.GeneralTimeout + ")");
                        return false;
                    }

                    watch.Stop();
                    Report.Info("Module opened within time", moduleToOpen + "(" + watch.ElapsedMilliseconds + "/" + Common.DefaultValues.GeneralTimeout + ")");
                    return true;
                }

                Report.Failure("Module entry is not available or enabled", moduleToOpen);
                return false;
            }

            Report.Failure("Menu entry for module is not available", moduleToOpen);
            return false;
        }

        /// <summary>
        /// The open fdt defined function.
        /// </summary>
        /// <param name="moduleToOpen">
        /// The module to open.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenFdtDefinedFunction(string moduleToOpen)
        {
            DeviceCareApplication repo1 = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo1.MenuArea.MainMenu.DTMFunctionsInfo;
            if (OpenMenuItem(GetMenuItem(repoItemInfo)))
            {
                DeviceCareApplication deviceCareApplication = DeviceCareApplication.Instance;
                RepoItemInfo repo = deviceCareApplication.MenuArea.MainMenu.AdditionalFunctionMenuItems.MenuItemInfo;
                string modifiedPath = repo.AbsolutePath.ToString().Replace("MODULENAME", moduleToOpen);

                Text text;
                Host.Local.TryFindSingle(modifiedPath, 5000, out text);
                if (text != null && text.Enabled)
                {
                    text.Click();

                    var watch = new Stopwatch();
                    watch.Start();

                    // Wait until module is visible at tabpage
                    while (IsModuleOpen(moduleToOpen) == false)
                    {
                        if (watch.ElapsedMilliseconds <= Common.DefaultValues.GeneralTimeout)
                        {
                            continue;
                        }

                        Report.Failure("Module is not opend within time", moduleToOpen + "(" + watch.ElapsedMilliseconds + "/" + Common.DefaultValues.GeneralTimeout + ")");
                        return false;
                    }

                    watch.Stop();
                    Report.Info("Module opened within time", moduleToOpen + "(" + watch.ElapsedMilliseconds + "/" + Common.DefaultValues.GeneralTimeout + ")");
                    return true;
                }

                Report.Failure("Module entry is not available or enabled", moduleToOpen);
                return false;
            }

            Report.Failure("Menu entry for module is not available", moduleToOpen);
            return false;
        }

        /// <summary>
        /// The is module open.
        /// </summary>
        /// <param name="moduleName">
        /// The module name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsModuleOpen(string moduleName)
        {
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.ApplicationArea.ModuleCloseButtonInfo;
            string modifiedPath = repoItemInfo.AbsolutePath.ToString().Replace("MODULENAME", moduleName);
            Button button;
            if (Host.Local.TryFindSingle(modifiedPath, 5000, out button))
            {
                if (button != null)
                {
                    Report.Info("Module is open: ", moduleName);
                    return true;
                }

                Report.Failure("Module is not open: ", moduleName);
                return false;
            }

            return false;
        }

        /// <summary>
        /// The focus module.
        /// </summary>
        /// <param name="moduleName">
        /// The module name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool FocusModule(string moduleName)
        {
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.ApplicationArea.ModuleNameTextInfo;
            string modifiedPath = repoItemInfo.AbsolutePath.ToString().Replace("MODULENAME", moduleName);
            Text text;
            if (Host.Local.TryFindSingle(modifiedPath, 5000, out text))
            {
                if (text != null)
                {
                    text.Click();
                    Report.Info("Module focused: ", moduleName);
                    return true;
                }

                Report.Failure("Module is not open: ", moduleName);
                return false;
            }

            return false;
        }

        /// <summary>
        /// The get number of open tab pages.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static bool CheckIfOpenCloseModuleHelperIsNeccessary()
        {
            Container container;
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.ApplicationArea.ModuleTabPagesInfo;
            Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, out container);
            if (container != null)
            {
                if (container.Children.Count == 1)
                {
                    if (container.Children[0].Children.Count == 0)
                    {
                        Report.Info("Open another module as work around to ensure closing of module.");
                        return true;
                    }

                    return false;
                }

                return false;
            }

            Report.Failure("There is no open module available.");
            return false;
        }
        
        /// <summary>
        /// The close module.
        /// </summary>
        /// <param name="moduleToClose">
        /// The module to close.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CloseModule(string moduleToClose)
        {
            int numberOfOpenModules = GetNumberOfOpenModules();
            if (IsModuleOpen(moduleToClose))
            {
                if (CheckIfOpenCloseModuleHelperIsNeccessary())
                {
                    if (!OpenCloseHelper())
                    {
                        Report.Failure("Button to close is not available: ", moduleToClose);
                        return false;
                    }
                }
                
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                RepoItemInfo repoItemInfo = repo.ApplicationArea.ModuleCloseButtonInfo;
                string modifiedPath = repoItemInfo.AbsolutePath.ToString().Replace("MODULENAME", moduleToClose);
                Button button;
                if (Host.Local.TryFindSingle(modifiedPath, 5000, out button))
                {
                    if (button != null)
                    {
                        button.Click();
                        Report.Info("Module is going to be closed: ", moduleToClose);
                        var watch = new Stopwatch();
                        watch.Start();

                        // Wait until tabpage has decreased by one
                        while (GetNumberOfOpenModules() != numberOfOpenModules - 1)
                        {
                            if (watch.ElapsedMilliseconds <= Common.DefaultValues.GeneralTimeout)
                            {
                                continue;
                            }

                            Report.Failure("Module is not closed within time", moduleToClose + "(" + watch.ElapsedMilliseconds + "/" + Common.DefaultValues.GeneralTimeout + ")");
                            return false;
                        }

                        watch.Stop();
                        Report.Info("Module is closed within time", moduleToClose + "(" + watch.ElapsedMilliseconds + "/" + Common.DefaultValues.GeneralTimeout + ")");
                        return true;
                    }
                }

                Report.Failure("Button to close is not available: ", moduleToClose);
                return false;
            }

            Report.Failure("Module is not open and there fore cannot be closed: ", moduleToClose);
            return false;
        }

        /// <summary>
        /// The open close helper module.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool OpenCloseHelper()
        {
            const string ModuleNameOnlineParameterize = "Online Paramterize";
            const string ModuleNameAbout = "About";
            string moduleToOpen;

            bool isModuleOpen = IsModuleOpen(ModuleNameAbout);
            if (isModuleOpen)
            {
                Report.Info("Open second module as workaround: ", ModuleNameOnlineParameterize);
                OpenSubmenuOnlineParameterize();
            }
            else
            {
                Report.Info("Open second module as workaround: ", ModuleNameAbout);
                OpenSpecificAdditionalModule(ModuleNameAbout);    
            }
            
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.ApplicationArea.ModuleCloseButtonInfo;

            if (isModuleOpen)
            {
                moduleToOpen = ModuleNameAbout;
            }
            else
            {
                moduleToOpen = ModuleNameOnlineParameterize;
            }
            
            string modifiedPath = repoItemInfo.AbsolutePath.ToString().Replace("MODULENAME", moduleToOpen);    
            Button button;
            if (Host.Local.TryFindSingle(modifiedPath, 5000, out button))
            {
                if (button != null)
                {
                    button.Click();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The set ranorex wpf configuration.
        /// </summary>
        private static void SaveRanorexWpfConfiguration()
        {
            // .<UiaOnly/UiaPreferred/WpfOnly/WpfPreferred>;  
            currentWpfSelection = WpfConfiguration.WpfApplicationTrees;
            WpfConfiguration.WpfApplicationTrees = WpfTreeSelection.WpfOnly;
            Configuration.Current.SaveToUserSettings();
        }

        /// <summary>
        /// The set ranorex uia configuration.
        /// </summary>
        private static void RestoreRanorexUiaConfiguration()
        {
            WpfConfiguration.WpfApplicationTrees = currentWpfSelection;
            Configuration.Current.SaveToUserSettings();
        }

        /// <summary>
        /// The get menu item.
        /// </summary>
        /// <param name="repoItemInfo">
        /// The repo item info.
        /// </param>
        /// <returns>
        /// The <see cref="MenuItem"/>.
        /// </returns>
        private static MenuItem GetMenuItem(RepoItemInfo repoItemInfo)
        {
            MenuItem menuItem;
            if (Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, out menuItem))
            {
                if (menuItem != null && menuItem.Visible && menuItem.Enabled)
                {
                    Report.Info("Menu Item found", repoItemInfo.AbsolutePath.ToString());
                    return menuItem;
                }

                Report.Failure("Menu Item not found", repoItemInfo.AbsolutePath.ToString());
                return null;
            }

            return null;
        }

        /// <summary>
        /// The open menu item.
        /// </summary>
        /// <param name="menuItem">
        /// The menu item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool OpenMenuItem(MenuItem menuItem)
        {
            if (menuItem != null && menuItem.Visible)
            {
                menuItem.Click();

                // Report.Info("Menu clicked", menuItem.Text.ToString(CultureInfo.InvariantCulture));
                return true;
            }

            return false;
        }

        /// <summary>
        /// The get number of open modules.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        private static int GetNumberOfOpenModules()
        {
            Container container;
            DeviceCareApplication repo = DeviceCareApplication.Instance;
            RepoItemInfo repoItemInfo = repo.ApplicationArea.ModuleTabPagesInfo;
            Host.Local.TryFindSingle(repoItemInfo.AbsolutePath, out container);
            if (container != null)
            {
                return container.Children.Count;
            }

            Report.Failure("There is no module at a tabpage available");
            return -1;
        }
    }
}
