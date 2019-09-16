// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleName.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of ModuleName.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Collections;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Parameterization.GUI.Resources;

    /// <summary>
    ///     Description of ModuleName.
    /// </summary>
    public class ModuleName
    {
        #region Public Properties

        /// <summary>
        /// Gets the module name offline.
        /// </summary>
        /// <value>
        /// The module name offline.
        /// </value>
        /// <returns>
        /// The translated module name.
        /// </returns>
        public string ModuleNameOffline()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Getting name of actual module depending on the language set in host application");
            string result = string.Empty;
            string hostApplicationLanguage = CommonFlows.GetHostApplicationLanguage.Run();
            ResourceSet languages = OfflineModuleNameTranslations.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry language in languages)
            {
                if (hostApplicationLanguage == language.Key.ToString())
                {
                    result = language.Value.ToString();
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module name: " + result + ".");
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the module name online.
        /// </summary>
        /// <value>
        /// The module name online.
        /// </value>
        /// <returns>
        /// The translated module name.
        /// </returns>
        public string ModuleNameOnline()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Getting name of actual module depending on the language set in host application");
            string result = string.Empty;
            string hostApplicationLanguage = CommonFlows.GetHostApplicationLanguage.Run();
            ResourceSet languages = OnlineModuleNameTranslations.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry language in languages)
            {
                if (hostApplicationLanguage == language.Key.ToString())
                {
                    result = language.Value.ToString();
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Module name: " + result + ".");
                    break;
                }
            }

            return result;
        }

        #endregion
    }
}