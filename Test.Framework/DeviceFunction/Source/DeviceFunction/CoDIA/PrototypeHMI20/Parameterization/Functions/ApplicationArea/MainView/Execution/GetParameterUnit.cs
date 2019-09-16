namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    using Common.Tools;

    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class GetParameterUnit.
    /// </summary>
    public class GetParameterUnit : IGetParameterUnit
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the unit from a parameter in current display content
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>List with all enums of a parameter</returns>
        public string Run(string parameterId)
        {
            try
            {
                string result = string.Empty;

                string parameterName = string.Empty;
                string[] separator = { "//" };
                string[] pathParts = parameterId.Split(separator, StringSplitOptions.None);
                if (pathParts.Length > 0)
                {
                    parameterName = pathParts[pathParts.Length - 1];
                }

                if (new SelectParameterAbsolute().Run(parameterId))
                {
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
                            var values = listColumns?.Elements().Where(e => e.Attribute("unitString")?.Value != string.Empty);
                            if (values.Any())
                            {
                                foreach (var value in values)
                                {
                                    var unitStringAttribute = value.Attribute("unitString");
                                    if (unitStringAttribute != null)
                                    {
                                        result = unitStringAttribute.Value;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Log.Info(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "Parameter '" + parameterId + "' is not available in current display content.");
                        }
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterUnit threw an exception:" + e.Message);
                return string.Empty;
            }
        }

        #endregion
    }
}