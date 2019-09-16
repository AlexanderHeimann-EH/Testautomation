/*
 * Created by Ranorex
 * User: testadmin
 * Date: 22/01/2015
 * Time: 16:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace EH.PCPS.TestAutomation.DeviceCare.V10300.Functions.Helpers
{
    using System.Diagnostics;

    using Ranorex;

    /// <summary>
    /// Description of NavigateToLanguagePage.
    /// </summary>
    public static class NavigateToLanguagePage
    {
        /// <summary>
        /// Navigate to the language page where the language button is displayed
        /// </summary>
        /// <param name="language">gives the language to search for (culture info; e.g. en-us)</param>
        /// <returns>true if the language was found and the page is now displayed; false if the language could not be found</returns>
        public static bool navigateToPage(string language)
        {
            var repo = EH.PCPS.TestAutomation.DeviceCare.V10300.GUI.DeviceCareApplication.Instance;
            repo.Culture = language;
            
            // Navigate to first page; Only possible if Button left is enabled.
            while (repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.ButtonLeft.Enabled)
            {
                repo.DeviceCare.ApplicationArea.Page_Settings.ButtonLeft.Click();
            }

            bool isAvailable = false;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < 10000)
            {
                if (watch.ElapsedMilliseconds >= 10000)
                {
                    watch.Stop();
                }

                if (!repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.Button_LanguageViaCultureInfo.Exists() &&
                    repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.ButtonRight.Enabled)
                {
                    watch.Stop();
                    repo.DeviceCare.ApplicationArea.Page_Settings.ButtonRight.Click();
                }

                if (repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.Button_LanguageViaCultureInfo.Exists())
                {
                    watch.Stop();
                    isAvailable = true;
                }
            }

            if (!isAvailable)
            {
                Report.Failure("Item was not found within Language Pages");
                return false;
            }

            return true;
            
            // // While the correct language is not found and there is another page comming --> navigate right
            // while (!repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.Button_LanguageViaCultureInfo.Exists(1000)
            //       && repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.ButtonRight.Enabled)
            // {
            //    repo.DeviceCare.ApplicationArea.Page_Settings.ButtonRight.Click();
            // }
            
            // Check if the element is found at least on the last page.
            // if yes: return true
            // if no: return false
            // if(repo.DeviceCare.ApplicationArea.Page_Settings.Page_Settings_Language.Button_LanguageViaCultureInfo.Exists(1000))
            // {
            //    return true;
            // }
            // else
            // {
            //    return false;
            // }
        }
    }
}
