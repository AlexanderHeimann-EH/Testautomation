// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetHostApplicationLanguage.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Gets the FieldCare language.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.FieldCare.V20901.CommonFlows
{
    using System.Collections;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;
    using EH.PCPS.TestAutomation.FieldCare.V20901.Resources;

    using Microsoft.Win32;

    /// <summary>
    /// Gets the host application's language.
    /// </summary>
    public class GetHostApplicationLanguage : IGetHostApplicationLanguage
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets language from registry
        /// </summary>
        /// <returns>
        /// The language.
        /// </returns>
        public string Run()
        {
            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Getting FieldCare language from registry.");
            var result = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\MEHT\FMP\Settings", "LanguageId", string.Empty).ToString();
            ResourceSet languages = FieldCareLanguageIDs.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry language in languages)
            {
                if (result == language.Value.ToString())
                {
                    result = language.Key.ToString();
                    Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "FieldCare language : " + result + ".");
                    break;
                }
            }

            return result;
        }

        #endregion
    }
}