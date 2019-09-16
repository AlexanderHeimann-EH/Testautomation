namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    using Common.Tools;
    using DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;

    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class GetParameterEnumItems.
    /// </summary>
    public class GetParameterEnumItems : IGetParameterEnumItems
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets all enums from a parameter in current display content
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>List with all enums of a parameter</returns>
        public List<string> Run(string parameterId)
        {
            try
            {
                List<string> resultList = new List<string>();

                string parameterName = string.Empty;
                string[] separator = { "//" };
                string[] pathParts = parameterId.Split(separator, StringSplitOptions.None);
                if (pathParts.Length > 0)
                {
                    parameterName = pathParts[pathParts.Length - 1];
                }

                var xml = XDocument.Parse(AppComController.GetDisplayContent());
                if (xml.Document != null)
                {
                    var displayContent = xml.Element("DisplayContent");
                    var listPage = displayContent?.Element("ListPage");
                    var listPageList = listPage?.Element("List");
                    var parameterWeAreLookingFor = listPageList?.Elements("ListItem").Where(e => e.Attribute("id")?.Value == parameterName);

                    if (parameterWeAreLookingFor != null && parameterWeAreLookingFor.Any())
                    {
                        var listColumns = parameterWeAreLookingFor.Elements("ListColumn");
                        var selectionItems = listColumns?.Elements("SelectionValue")?.Elements("SelectionItem");

                        if (selectionItems.Any())
                        {
                            foreach (var selectionItem in selectionItems)
                            {
                                var selectionItemAttribute = selectionItem.Attribute("name");
                                if (selectionItemAttribute != null)
                                {
                                    resultList.Add(selectionItemAttribute.Value);
                                }
                            }
                        }
                    }
                    else
                    {
                        Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterId + "' is not available in current display content.");
                    }
                }

                return resultList;
            }
            catch (Exception e)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterEnumItems threw an exception:" + e.Message);
                return new List<string>();
            }
        }

        #endregion
    }
}