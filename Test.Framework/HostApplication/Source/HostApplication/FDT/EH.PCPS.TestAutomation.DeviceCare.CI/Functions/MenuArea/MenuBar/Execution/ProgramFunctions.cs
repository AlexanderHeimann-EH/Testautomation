// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgramFunctions.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.Functions.MenuArea.MenuBar.Execution
{
    using System.Collections.Generic;
    using System.Reflection;

    using EH.PCPS.TestAutomation.DeviceCare.CI.GUI;

    using Ranorex;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The program functions.
    /// </summary>
    public static class ProgramFunctions
    {
        /// <summary>
        /// The open program functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenMenu()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            MenuItem menuItem;
            Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsInfo.AbsolutePath, out menuItem);
            if (menuItem != null && menuItem.Visible)
            {
                menuItem.Click();
                Reporting.Debug("Menu item Program Functions found and clicked.");
                return true;
            }

            Reporting.Error("Could not access menu Program Functions.");
            return false;
        }

        /// <summary>
        /// The toggle online.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool RunToggleOnline()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                MenuItem menuItem;
                Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ToggleOnlineInfo.AbsolutePath, out menuItem);
                if (menuItem != null && menuItem.Visible)
                {
                    menuItem.Click();
                    Reporting.Debug("Menu item Toggle Online found and clicked.");
                    return true;
                }    
            }

            Reporting.Error("Could not access menu item Toggle Online.");
            return false;
        }

        /// <summary>
        /// The read from device.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool RunReadFromDevice()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                MenuItem menuItem;
                Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ReadFromDeviceInfo.AbsolutePath, out menuItem);
                if (menuItem != null && menuItem.Visible)
                {
                    menuItem.Click();
                    Reporting.Debug("Menu item Read From Device found and clicked.");
                    return true;
                }
            }

            Reporting.Error("Could not access menu item Read From Device.");
            return false;
        }

        /// <summary>
        /// The write to device.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool RunWriteToDevice()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                MenuItem menuItem;
                Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.WriteToDeviceInfo.AbsolutePath, out menuItem);
                if (menuItem != null && menuItem.Visible)
                {
                    menuItem.Click();
                    Reporting.Debug("Menu item Write To Device found and clicked.");
                    return true;
                }
            }

            Reporting.Error("Could not access menu item Write To Device.");
            return false;
        }

        /// <summary>
        /// The save device data.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool RunSaveDeviceData()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                MenuItem menuItem;
                Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.SaveDeviceDataInfo.AbsolutePath, out menuItem);
                if (menuItem != null && menuItem.Visible)
                {
                    menuItem.Click();
                    Reporting.Debug("Menu item Save Device Data found and clicked.");
                    return true;
                }
            }

            Reporting.Error("Could not access menu item Save Device Data.");
            return false;
        }

        /// <summary>
        /// The restore device data.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool RunRestoreDeviceData()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                MenuItem menuItem;
                Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.RestoreDeviceDataInfo.AbsolutePath, out menuItem);
                if (menuItem != null && menuItem.Visible)
                {
                    menuItem.MoveTo();
                    Reporting.Debug("Menu item Restore Device Data found and moved to.");
                    return true;
                }
            }

            Reporting.Error("Could not access menu item Restore Device Data.");
            return false;
        }

        /// <summary>
        /// The restore device data browse.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool OpenRestoreDeviceDataBrowse()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            // DeviceCareApplication repo = DeviceCareApplication.Instance;
            // if (RestoreDeviceData())
            // {
            //    repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.RestoreBrowseInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
            //    MenuItem restoreDeviceDataBrowse;
            //    Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.RestoreBrowseInfo.AbsolutePath, out restoreDeviceDataBrowse);
            //    if (restoreDeviceDataBrowse != null && restoreDeviceDataBrowse.Visible)
            //    {
            //        restoreDeviceDataBrowse.Click();
            //        Reporting.Error("Menu item Device Data Browse found and clicked.");
            //        return true;
            //    }
            // }

            // Reporting.Error("Could not access menu item Restore Device Data Browse.");
            Reporting.Error("Not Implemented Yet");
            return false;
        }

        /// <summary>
        /// The additional functions.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool RunAdditionalFunctions()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            if (OpenMenu())
            {
                DeviceCareApplication repo = DeviceCareApplication.Instance;
                MenuItem menuItem;
                Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.AdditionalFunctionsInfo.AbsolutePath, out menuItem);
                if (menuItem != null && menuItem.Visible)
                {
                    menuItem.MoveTo();
                    Reporting.Debug("Menu item Additional Functions found and moved to.");
                    return true;
                }
            }

            Reporting.Error("Could not access menu item Additional Functions.");
            return false;
        }

        /// <summary>
        /// The show progress.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static string OpenShowProgress()
        {
            Logging.Enter(typeof(ProgramFunctions), MethodBase.GetCurrentMethod().Name);

            DeviceCareApplication repo = DeviceCareApplication.Instance;
            if (RunAdditionalFunctions())
            {
                repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ShowProgressInfo.WaitForExists(Common.DefaultValues.GeneralTimeout);
                MenuItem showProgress;
                Host.Local.TryFindSingle(repo.MenuArea.MainMenu.ProgramFunctionsMenuItems.ShowProgressInfo.AbsolutePath, out showProgress);

                IList<TabPage> tabPagesBefore = Host.Local.Find<TabPage>(repo.ApplicationArea.ModuleSelection.ModuleTabPagesInfo.AbsolutePath);
                
                if (showProgress != null && showProgress.Visible)
                {
                    showProgress.Click();
                    Reporting.Debug("Menu item Show Progress found and clicked.");

                    IList<TabPage> tabPagesAfter = Host.Local.Find<TabPage>(repo.ApplicationArea.ModuleSelection.ModuleTabPagesInfo.AbsolutePath);
                    foreach (var tabPageAfter in tabPagesAfter)
                    {
                        Text textAfter = tabPageAfter.FindSingle("text");
                        if (textAfter != null)
                        {
                            string textValueAfter = textAfter.Element.GetAttributeValueText("caption");
                            if (textValueAfter != null)
                            {
                                foreach (var tabPageBefore in tabPagesBefore)
                                {
                                    Text textBefore = tabPageBefore.FindSingle("text");
                                    if (textBefore != null)
                                    {
                                        string textValueBefore = textBefore.Element.GetAttributeValueText("caption");
                                        if (textValueBefore != null)
                                        {
                                            if (!textValueBefore.Equals(textValueAfter))
                                            {
                                                Reporting.Debug(string.Format("Name of currently opened function is {0}", textValueAfter));
                                                return textValueAfter;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Reporting.Error("Could not access menu item Show Progress.");
            return string.Empty;
        }
    }
}
