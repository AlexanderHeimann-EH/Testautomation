namespace EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization.Functions.ApplicationArea.MainView.Execution
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Xml.Linq;

    using EH.PCPS.TestAutomation.Common.Tools;
    using EH.PCPS.TestAutomation.DeviceFunctionInterfaces.CoDIA.Parameterization.Functions.ApplicationArea.MainView.Execution;
    using EH.PCPS.TestAutomation.PrototypeHMI20.Parameterization._hmiSpecific.Controller;

    /// <summary>
    /// Class GetParameterValueRange.
    /// </summary>
    public class GetParameterValueRange : IGetParameterValueRange
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the maximum range from parameter in current display content.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>System.String.</returns>
        public string MaximumRange(string parameterId)
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
                            var maxRanges = listColumns?.Elements().Where(e => e.Attribute("rangeMax")?.Value != string.Empty);
                            if (maxRanges.Any())
                            {
                                foreach (var value in maxRanges)
                                {
                                    var rangeMaxAttribute = value.Attribute("rangeMax");
                                    if (rangeMaxAttribute != null)
                                    {
                                        result = rangeMaxAttribute.Value;
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
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterValueRangeMaximumRange threw an exception:" + e.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the minimum range from parameter in current display content.
        /// </summary>
        /// <param name="parameterId">The parameter identifier.</param>
        /// <returns>System.String.</returns>
        public string MinimumRange(string parameterId)
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
                            var minRanges = listColumns?.Elements().Where(e => e.Attribute("rangeMin")?.Value != string.Empty);
                            if (minRanges.Any())
                            {
                                foreach (var value in minRanges)
                                {
                                    var rangeMinAttribute = value.Attribute("rangeMin");
                                    if (rangeMinAttribute != null)
                                    {
                                        result = rangeMinAttribute.Value;
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
                Log.Error(LogInfo.Namespace(MethodBase.GetCurrentMethod()), "GetParameterValueRangeMinimumRange threw an exception:" + e.Message);
                return string.Empty;
            }
        }

        #endregion
    }
}