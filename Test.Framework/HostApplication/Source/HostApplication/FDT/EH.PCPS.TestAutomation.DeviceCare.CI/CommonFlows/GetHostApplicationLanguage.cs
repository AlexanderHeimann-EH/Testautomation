// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetHostApplicationLanguage.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.DeviceCare.CI.CommonFlows
{
    using System;
    using System.Reflection;
    using System.Xml;

    using EH.PCPS.TestAutomation.CommonHostApplicationLayerInterfaces.CommonFlows;

    using Logging = EH.PCPS.TestAutomation.Common.Tools.Logging.Log;
    using Reporting = EH.PCPS.TestAutomation.Common.Tools.Log;

    /// <summary>
    /// The get host application language.
    /// </summary>
    public class GetHostApplicationLanguage : IGetHostApplicationLanguage
    {
        /// <summary>
        /// The run.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public string Run()
        {
            Logging.Enter(typeof(GetHostApplicationLanguage), MethodBase.GetCurrentMethod().Name);
            Reporting.Debug("Getting DeviceCare language from application config file.");

            const string EnvironmentVariable = "APPDATA";
            string path = Environment.GetEnvironmentVariable(EnvironmentVariable);
            path = path + "\\..\\Local\\Endress+Hauser\\DeviceCare SFE100\\Shared\\Application.config";
            string languageCulture = string.Empty;
            if (!string.IsNullOrEmpty(path))
            {
                XmlDocument applicationConfiguration = new XmlDocument();
                applicationConfiguration.Load(path);
                XmlNodeList nodes = applicationConfiguration.SelectNodes("/config/settings/culture/name");
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        languageCulture = node.InnerText;
                    }
                }
            }

            switch (languageCulture)
            {
                case "en-US":
                    return "English";
                case "fr-FR":
                    return "French";
                case "de-DE":
                    return "German";
                case "it-IT":
                    return "Italian";
                case "es-ES":
                    return "Spanish";
                default:
                    Reporting.Error(string.Format("Language culture {0}  is not supported", languageCulture));
                    return string.Empty;
            }
        }
    }
}
