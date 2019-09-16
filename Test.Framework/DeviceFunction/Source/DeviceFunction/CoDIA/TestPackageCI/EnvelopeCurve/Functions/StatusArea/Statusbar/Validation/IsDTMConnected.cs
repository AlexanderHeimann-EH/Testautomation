// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IsDTMConnected.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   Description of IsDTMConnected.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurve.Functions.StatusArea.Statusbar.Validation
{
    using System.Collections;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.CommonHostApplicationLayerLoader;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.EnvelopeCurve.Functions.StatusArea.Statusbar.Validation;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurve.GUI.Resources;
    using EH.PCPS.TestAutomation.TestPackageCI.EnvelopeCurve.GUI.StatusArea.Statusbar;

    /// <summary>
    ///     Description of IsDTMConnected.
    /// </summary>
    // ReSharper disable InconsistentNaming
    public class IsDTMConnected : IIsDTMConnected
    {
        // ReSharper restore InconsistentNaming
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