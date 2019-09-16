// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleName.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of ModuleName.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.Functions.ApplicationArea.MainView.Validation
{
    using System.Collections;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.TestPackageUpdateA2017.Historom.GUI.Resources;

    /// <summary>
    ///     Description of ModuleName.
    /// </summary>
    public class ModuleName
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets name of actual module depending on the language set in host application
        /// </summary>
        /// <returns>Module name.</returns>
        public string Name()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Getting name of actual module depending on the language set in host application");
            string result = string.Empty;
            string hostApplicationLanguage = CommonFlows.GetHostApplicationLanguage.Run();
            ResourceSet languages = ModuleNameTranslations.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
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