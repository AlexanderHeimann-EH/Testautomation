// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetParameterValue.cs" company="Endress+Hauser Process Solutions AG">
//   Copyright © Endress+Hauser Process Solutions AG 2015
// </copyright>
// <summary>
//   
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
    /// Gets the value of a specified parameter
    /// </summary>
    public class GetParameterValue : IGetParameterValue
    {
        /// <summary>
        /// Searches for the specified parameter and returns its value
        /// </summary>
        /// <param name="pathToParameter">
        /// The path to the parameter
        /// </param>
        /// <returns>
        /// The value of the parameter
        /// </returns>
        public string Run(string pathToParameter)
        {
            try
            {
                string parameterId = string.Empty;
                string result = string.Empty;
                string[] separator = { "//" };
                string[] pathParts = pathToParameter.Split(separator, StringSplitOptions.None);
                if (pathParts.Length > 0)
                {
                    parameterId = pathParts[pathParts.Length - 1];
                }

                if (new SelectParameterAbsolute().Run(pathToParameter))
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
                                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterId + "' id attribute is null.");
                            }
                            else if (idAttribute.Value == parameterId)
                            {
                                var parameterChildren = parameter.Elements();
                                foreach (XElement child in parameterChildren)
                                {
                                    var childName = child.Name.LocalName;
                                    if (childName == "ListColumn")
                                    {
                                        var actualValues = child.Elements();
                                        foreach (var actualValue in actualValues)
                                        {
                                            if (actualValue.Name.LocalName.Contains("Value"))
                                            {
                                                var displayedText = actualValue.Attribute("displayedText");
                                                if (displayedText != null)
                                                {
                                                    result = displayedText.Value;
                                                }

                                                break;
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
            catch (System.Exception exception)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return string.Empty;
            }
        }
    }
}
