namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml.Linq;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class GetDescriptionText.
    /// </summary>
    public class GetDescriptionText : IGetDescriptionText
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the description of a parameter (if available). Empty if not.
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
                StringBuilder resultBuilder = new StringBuilder();
                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var helpPage = displayContent?.Element("HelpPage");
                    var helpPageList = helpPage?.Element("List");
                    var parameterWeAreLookingFor = helpPageList?.Elements().Where(e => e.Attribute("id")?.Value == parameterName);

                    if (parameterWeAreLookingFor != null && parameterWeAreLookingFor.Any())
                    {
                        foreach (var parameter in parameterWeAreLookingFor)
                        {
                            var selectionItems = parameter.Elements("ListColumn")?.Elements("SelectionValue")?.Elements("SelectionItem");
                            if (selectionItems.Any())
                            {
                                foreach (var selectionItem in selectionItems)
                                {
                                    var valueAttribute = selectionItem.Attribute("value");
                                    if (valueAttribute != null)
                                    {
                                        resultBuilder.AppendLine(valueAttribute.Value);
                                    }
                                }
                            }
                        }

                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Description for parameter '" + parameterId + "' is available.");
                        result = resultBuilder.ToString();
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Description for parameter '" + parameterId + "' is not available.");
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