// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetParameterLabel.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   ApplicationArea provides functionality to select and change specified parameters.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml.Linq;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class GetParameterLabel.
    /// </summary>
    public class GetParameterLabel : IGetParameterLabel
    {
        #region Public Methods and Operators

        /// <summary>
        /// Returns label of specified parameter.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>System.String.</returns>
        public string Run(string parameterId)
        {
            try
            {
                string parameterName = string.Empty;
                string[] separator = { "//" };
                string[] pathParts = parameterId.Split(separator, StringSplitOptions.None);
                if (pathParts.Length > 0)
                {
                    parameterName = pathParts[pathParts.Length - 1];
                }

                string result = string.Empty;

                if (new SelectParameterAbsolute().Run(parameterId))
                {
                    var xml = XDocument.Parse(AppComController.GetDisplayContent());
                    if (xml.Document != null)
                    {
                        IEnumerable<XElement> parameterList = xml.Document.Descendants("ListItem");
                        foreach (XElement parameter in parameterList)
                        {
                            var idAttribute = parameter.Attribute("id");
                            if (idAttribute == null)
                            {
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterName + "' id attribute is null.");
                            }
                            else if (idAttribute.Value == parameterName)
                            {
                                var parameterChildren = parameter.Elements();
                                foreach (XElement child in parameterChildren)
                                {
                                    var childName = child.Name.LocalName;
                                    if (childName == "ListColumn")
                                    {
                                        var text = child.Element("Text");
                                        if (text != null)
                                        {
                                            var label = text.Attribute("fullText");
                                            if (label != null)
                                            {
                                                result = label.Value;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Display content xml is null.");
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }

        #endregion
    }
}