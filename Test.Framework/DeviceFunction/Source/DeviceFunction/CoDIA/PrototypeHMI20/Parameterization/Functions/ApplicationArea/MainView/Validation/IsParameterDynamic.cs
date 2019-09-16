using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsParameterDynamic.
    /// </summary>
    public class IsParameterDynamic : IIsParameterDynamic
    {
        /// <summary>
        /// Validates, whether a specified parameter is dynamic in current display content.
        /// </summary>        
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns><c>true</c> if parameter is dynamic, <c>false</c> otherwise.</returns>
        public bool Run(string parameterId)
        {
            try
            {
                string isDynamic = string.Empty;
                bool result = false;
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
                                    {
                                        var dynamicAttribute = child.Attribute("isDynamic");
                                        if (dynamicAttribute != null)
                                        {
                                            isDynamic = dynamicAttribute.Value;
                                        }
                                    }
                                }
                            }

                            if (isDynamic.Equals("true"))
                            {
                                result = true;
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterId + "' is dynamic.");
                            }
                            else
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterId + "' is not dynamic.");
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception exception)
            {
                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), exception.Message);
                return false;
            }
        }
    }
}
