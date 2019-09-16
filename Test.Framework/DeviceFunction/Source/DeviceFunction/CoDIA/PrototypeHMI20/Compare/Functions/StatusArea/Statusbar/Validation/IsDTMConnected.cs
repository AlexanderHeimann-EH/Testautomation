// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDTMConnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of IsDtmConnected.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Compare.Functions.StatusArea.Statusbar.Validation
{
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Compare.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Compare.GUI.Resources;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Compare.GUI.StatusArea.Statusbar;

    /// <summary>
    ///     Description of IsDtmConnected.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    public class IsDtmConnected : IIsDtmConnected
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Determines whether DTM is online
        /// </summary>
        /// <returns>
        ///     true: if DTM is online
        ///     false: if DTM is offline or an error occurred
        /// </returns>
        public bool Run()
        {
            bool result = false;
            string state = new StatusbarElements().ConnectionState;
            if (state == null)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection State is null");
            }
            else
            {
                string hostApplicationLanguage = CommonFlows.GetHostApplicationLanguage.Run();
                string connectionState = string.Empty;
                ResourceSet languages = OnlineConnectionStateTranslations.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                foreach (DictionaryEntry language in languages)
                {
                    if (hostApplicationLanguage == language.Key.ToString())
                    {
                        connectionState = language.Value.ToString();
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Connection state translated: " + connectionState + ".");
                        break;
                    }
                }

                if (state.Equals(connectionState))
                {
                    result = true;
                }
            }

            return result;
        }

        #endregion
    }
}