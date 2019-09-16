namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Validation;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class IsButtonVisible.
    /// </summary>
    public class IsButtonVisible : IIsButtonVisible
    {
        #region Public Methods and Operators

        /// <summary>
        /// Validates, whether a specified parameter is visible in current display content.
        /// </summary>        
        /// <param name="buttonId">The parameter identifier.</param>
        /// <returns><c>true</c> if parameter is available, <c>false</c> otherwise.</returns>
        public bool Run(string buttonId)
        {
            try
            {
                string isOnScreen = string.Empty;
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
                            Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + buttonId + "' id attribute is null.");
                        }
                        else if (idAttribute.Value == buttonId)
                        {
                            var parameterChildren = parameter.Elements();
                            foreach (XElement child in parameterChildren)
                            {
                                var childName = child.Name.LocalName;
                                if (childName == "ListColumn")
                                {
                                    {
                                        var visibilityAttribute = child.Attribute("isOnScreen");
                                        if (visibilityAttribute != null)
                                        {
                                            isOnScreen = visibilityAttribute.Value;
                                        }
                                    }
                                }
                            }

                            if (isOnScreen.Equals("true"))
                            {
                                result = true;
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button '" + buttonId + "' is visible.");
                            }
                            else
                            {
                                Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Button '" + buttonId + "' is not visible.");
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

        #endregion
    }
}